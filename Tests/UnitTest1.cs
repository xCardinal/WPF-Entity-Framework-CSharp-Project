using NUnit.Framework;
using BusinessLayer;
using Data;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        Brains _brains;
        [SetUp]
        public void Setup()
        {
            _brains = new Brains();

            using (var db = new SMDbContext())
            {
                var selectedCustomers =
                from c in db.Users
                where c.UserName == "spYagami"
                select c;

                db.Users.RemoveRange(selectedCustomers);
                db.SaveChanges();
                
                ////////////////////////////

                var newMovie = new Movie()
                {
                    MovieName = "Me Before You",
                    CategoryName = "Romance/Drama"
                };

                db.Movies.Add(newMovie);
                db.SaveChanges();

            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
        {
            using (var db = new SMDbContext())
            {
                var numberOfUsers = db.Users.Count();

                _brains.Create("Sergio Pessegueiro", "spYagami", "HelloGuys",1,"admin");

                var numberOfUsersAfter = db.Users.Count();

                Assert.That(numberOfUsers + 1, Is.EqualTo(numberOfUsersAfter));
            }
        }

        [Test]
        public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new SMDbContext())
            {
                _brains.Create("Sergio Pessegueiro", "spYagami", "HelloGuys", 1, "user");
                _brains.Update("Sergio Pessegueiro", "spYagami", "HelloGuys", 1, "admin");

                User updatedCustomer =
                    db.Users
                        .FirstOrDefault(u => u.UserName == "spYagami");

                if (updatedCustomer != null) Assert.That(updatedCustomer.Type, Is.EqualTo("admin"));
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            using (var db = new SMDbContext())
            {
                var newUser =
                    new User()
                    {
                        UserName = "spYagami",
                        Password = "HelloWorld",
                        ContactName = "Sergio",
                        Status = 1
                    };

                db.Users.Add(newUser);
                db.SaveChanges();

                var selectUser =
                    db.Users
                    .Where(u => u.UserName == "spYagami")
                    .Select(u => u.UserId)
                    .FirstOrDefault();

                var numberOfCustomersBefore = db.Users.ToList().Count();
                _brains.Delete(selectUser);
                var numberOfCustomersAfter = db.Users.ToList().Count();
                Assert.That(numberOfCustomersBefore - 1, Is.EqualTo(numberOfCustomersAfter));
            }
        }

        [Test]
        public void GivenTheCorrectPathTheMovieTrailerIsAdded()
        {
            using (var db = new SMDbContext())
            {

                //var selectedMovie =
                //    from m in db.Movies
                //    where m.MovieName == "Me Before You"
                //    select new
                //    {
                //        m.MovieId, m.MovieName
                //    }
                //    ;

                var selecteMovie = db.Movies
                    .FirstOrDefault(m => m.MovieName == "Me Before You");

                //Update the path HERE
                _brains.UpdateMovie(selecteMovie.MovieId, "Me Before You", "Romance/Drama", "C:\\Users\\iFran\\Desktop\\General\\Sparta - Work\\WPF - Entity - Framework - CSharp - Project\\WPF Front End\\Trailers\\Me Before You Official Trailer #1 (2016) - Emilia Clarke, Sam Claflin Movie HD.mp4");

                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new SMDbContext())
            {
                var selectedUser =
                    from c in db.Users
                    where c.UserName == "spYagami"
                    select c;

                db.Users.RemoveRange(selectedUser);
                db.SaveChanges();

                ///////////////////
                ///

                var selecteMovie = db.Movies
                    .FirstOrDefault(m => m.MovieName == "Me Before You");

                db.Movies.Remove(selecteMovie);
            }
        }
    }
}