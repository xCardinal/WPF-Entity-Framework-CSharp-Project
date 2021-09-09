using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Data.Services;

namespace BusinessLayer
{
    public class Brains
    {
        private ICustomerService _service;
        public Brains()
        {
            _service = new CustomerService();
        }

        public Brains(ICustomerService service)
        {
            //coalesce expression
            _service = service ?? throw new ArgumentException("ICustomerService object cannot be null.");
        }

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
            var listOfUsers =
                    _service.UsersList;

            var query1 =
                _service.UsersList.FirstOrDefault(u => u.UserName.ToLower() == user);

            if (query1 != null)
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
            
            using (var db = new SMDbContext())
            {
                var users = db.Users.ToList();
                var user = db.Users.FirstOrDefault(c => c.UserName == newUserName);
                if (user == null && newUserName != null && newPassword != null)
                {
                    var newUser = new User() { UserName = newUserName, Password = newPassword };

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

        public bool AddMovie(string newMovieName, string newMovieCategory, string path)
        {
            var movie =
                    _service.AllMoviesList.FirstOrDefault(m => m.MovieName == newMovieName);

            if (movie == null && newMovieName != string.Empty)
            {
                var newMovie = new Movie()
                {
                    MovieName = newMovieName,
                    VideoPath = path,
                    CategoryName = newMovieCategory
                };

                _service.AddMovieToDatabase(newMovie);

                return true;
            }
            return false;
        }
        public bool DeleteMovie(int movieID)
        {
            var selectedMovie = _service.AllMoviesList.FirstOrDefault(m => m.MovieId == movieID);
            
            if (selectedMovie != null)
            {
                _service.RemoveMovieFromDatabase(selectedMovie);

                return true;
            }

            return false;
        }

        public bool UpdateMovie(int movieId, string newMovieName, string newCategory, string trailerPath)
        {
            #region Old Method (slow)
            //using(var db = new SMDbContext())
            //{
            //    var query1 =
            //        db.Movies.FirstOrDefault(m => m.MovieId == movieId);

            //    if(query1 != null)
            //    {
            //        query1.MovieName = newMovieName;
            //        query1.CategoryName = newCategory;
            //        query1.VideoPath = trailerPath;

            //        db.SaveChanges();
            //        return true;
            //    }

            //}

            //return false;
            #endregion
            var query1 =
                    _service.AllMoviesList.FirstOrDefault(m => m.MovieId == movieId);

            if (query1 == null)
            {
                return false;
            }
            _service.UpdateMovieFromDatabase(query1, newMovieName, newCategory, trailerPath);
            return true;
        }

        public List<Tuple<string, string>> ListOfMovies()
        {
            List<Tuple<string, string>> output = new List<Tuple<string, string>>();

            var query1 =
                    _service.AllMoviesList.Select(m => m).ToList();


            foreach (var movie in query1)
            {
                output.Add(Tuple.Create(movie.MovieName, movie.CategoryName));
            }

            return output;
        }
        public List<Movie> RetrieveAll()
        {
            //using (var db = new SMDbContext())
            //{
            //    return db.Movies.ToList();
            //}
            return _service.AllMoviesList;
        }
        public List<Movie> RetrieveMovie(string movieName)
        {
            return _service.GetMovieByName(movieName);
        }

        public void AddRemoveFavourite()
        {
            if (_service.GetAllFavouriteMoviesList().Count() >= 0 && SelectedMovie != null)
            {
                var query =
                    _service.GetAllFavouriteMoviesList().Where(fm => fm.MovieId == SelectedMovie.MovieId && fm.UserId == SelectedUser.UserId).FirstOrDefault();

                if (query == null)
                {
                    MovieFavourites newMovieFavourite = new MovieFavourites();
                    newMovieFavourite.UserId = SelectedUser.UserId;
                    newMovieFavourite.MovieId = SelectedMovie.MovieId;

                    //Add to Favourites -  Push into table

                    _service.AddMovieToFavourites(newMovieFavourite);
                }
                else
                {
                    var query2 =
                        _service.GetAllFavouriteMoviesList()
                        .Where(mf => mf.Movie == SelectedMovie).Select(m => m).FirstOrDefault();

                    _service.RemoveFromFavourites(query);
                }
            }
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
