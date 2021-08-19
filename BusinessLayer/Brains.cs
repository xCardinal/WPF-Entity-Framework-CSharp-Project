using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class Brains
    {
        public User SelectedUser { get; set; }
        public Movie SelectedMovie { get; set; }

        public void SetSelectedUser(object selectedObject)
        {
            SelectedUser = (User)selectedObject;
        }
        public void SetSelectedMovie(object selectedObject)
        {
            SelectedMovie = (Movie)selectedObject;
        }

        public bool Login(string user, string password)
        {
            using (var db = new SMDbContext())
            {
                var listOfUsers =
                    db.Users.ToList();

                var query1 =
                    db.Users.FirstOrDefault(u => u.UserName.ToLower() == user);

                if(query1 != null)
                {
                    if (query1.Status != 0)
                    {
                        if (query1.Password == password)
                        {
                            //OK
                            SelectedUser = query1;
                            StaticClass.CurrentUser = SelectedUser;
                            return true;
                            
                        }
                        else
                        {
                            //FAIL - password is wrong 
                            return false;
                        }
                    }
                    else
                    {
                        //FAIL - Account status is 0
                        return false;
                    }
                }

                return false;
            }
        }

        public void LoadUser()
        {
            SelectedUser = StaticClass.CurrentUser;
        }

        public void Create(
        string newContactName,
        string newUserName,
        string newPassword,
        int accountStatus,
            string accountType)
        {
            var newUser = new User() { ContactName = newContactName, UserName = newUserName, Password = newPassword, Status=accountStatus=1, Type = "user" };
            using (var db = new SMDbContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
       public bool Create(
       string newUserName,
       string newPassword)
        {
            var newUser = new User() { UserName = newUserName, Password = newPassword };
            using (var db = new SMDbContext())
            {
                var users = db.Users.ToList();
                var user = db.Users.FirstOrDefault(c => c.UserName == newUserName);
                if (user == null)
                {
                    db.Users.Add(newUser);
                    newUser.Status = 1;
                    newUser.Type = "user";
                    db.SaveChanges();
                    return true;
                }
            }
            Debug.WriteLine($"Username {newUserName} is taken!");
            return false;
        }
        public bool Delete(int deletingId)
        {
            using (var db = new SMDbContext())
            {
                var customer = db.Users.FirstOrDefault(c => c.UserId == deletingId);
                if (customer == null)
                {
                    Debug.WriteLine($"Customer {deletingId} not found");
                    return false;
                }
                db.Users.RemoveRange(customer);
                db.SaveChanges();
            }
            return true;
        }
        public bool Update(
            string contactName,
            string userName,
            string password,
            int accountStatus,
            string accountType)
        {
            using (var db = new SMDbContext())
            {
                var user = db.Users.FirstOrDefault(c => c.UserName == userName);
                if (user == null)
                {
                    Debug.WriteLine($"User {user} not found");
                    return false;
                }
                user.ContactName = contactName;
                user.UserName = userName;
                user.Password = password;
                user.Type = accountType;
                user.Status = accountStatus;
                // write changes to database
                try
                {
                    db.SaveChanges();
                    SelectedUser = user;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error updating {userName}");
                    return false;
                }
            }
            return true;
        }


        public List<Tuple<string, string>> ListOfMovies()
        {
            List<Tuple<string, string>> output = new List<Tuple<string, string>>();

            using (var db = new SMDbContext())
            {
                var query1 =
                    db.Movies.Select(m => m).ToList();


                foreach (var movie in query1)
                {
                    output.Add(Tuple.Create(movie.MovieName, movie.CategoryName));
                }

                return output;
            }
        }
        public List<Movie> RetrieveAll()
        {
            using (var db = new SMDbContext())
            {
                return db.Movies.ToList();
            }
        }
        public List<Movie> RetrieveMovie(string movieName)
        {
            using(var db = new SMDbContext())
            {
                return db.Movies.Where(m => m.MovieName.Contains(movieName)).ToList();
            }
        }

        public void AddRemoveFavourite()
        {

            using (var db = new SMDbContext())
            {
                if(db.MovieFavourites.Count()>0 && SelectedMovie != null)
                {
                    var queryOfMovies =
                    db.MovieFavourites.Where(fm => fm.MovieId == SelectedMovie.MovieId).FirstOrDefault();

                    if (queryOfMovies == null)
                    {
                        MovieFavourites newMovieFavourite = new MovieFavourites();
                        newMovieFavourite.UserId = SelectedUser.UserId;
                        newMovieFavourite.MovieId = SelectedMovie.MovieId;

                        //SelectedMovie.MovieFavourites.Add(newMovieFavourite);
                        //SelectedUser.MovieFavourites.Add(newMovieFavourite);

                        //Add to Favourites -  Push into table
                        db.MovieFavourites.Add(newMovieFavourite);
                        db.SaveChanges();
                    }
                    else
                    {
                        //Remove from Favourites - Remove from table
                        //db.MovieFavourites.Remove((MovieFavourites)SelectedMovie.MovieFavourites);
                        db.SaveChanges();
                    }
                }
            }

            //I can either have a list with all of the favourite movies from everyone
            //and only display the apporpriate 
        }

        public List<Movie> RetrieveFavourites
        {
            get
            {
                using (var db = new SMDbContext())
                {
                    if (SelectedUser != null)
                    {
                        var query =
                            db.Users.Include(u=>u.MovieFavourites)
                            .ThenInclude(mv=>mv.Movie)
                            .Where(u=>u.UserId ==SelectedUser.UserId)
                            .Select(m => m).FirstOrDefault();
                        
                        if (query != null)
                        {

                            List<Movie> FavMovies = new();

                            foreach(var title in query.MovieFavourites)
                            {
                                FavMovies.Add(title.Movie);
                            }

                            FavMovies.OrderBy(x => x.MovieName);

                            var newList = FavMovies.OrderBy(x => x.MovieName);

                            return newList.ToList();
                        }
                    }
                    return new List<Movie>();
                }
            }
        }
    }
}
