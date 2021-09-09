using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SMDbContext _context;

        public CustomerService()
        {
            _context = new SMDbContext();
        }

        public CustomerService(SMDbContext context)
        {
            _context = context;
        }

        public List<User> UsersList => _context.Users.ToList();

        public List<Movie> AllMoviesList => _context.Movies.ToList();

        public List<MovieFavourites> GetAllFavouriteMoviesList()
        {
            return _context.MovieFavourites.ToList();
        }

        public void AddMovieToFavourites(MovieFavourites newFavourite)
        {
            _context.MovieFavourites.Add(newFavourite);
            SaveChanges();
        }

        public void RemoveFromFavourites(MovieFavourites movieName)
        {
            _context.MovieFavourites.Remove(movieName);
            SaveChanges();
        }

        public List<Movie> GetMovieByName(string movieName)
        {
            return _context.Movies.Where(m => m.MovieName.Contains(movieName)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddMovieToDatabase(Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            SaveChanges();
        }

        public void RemoveMovieFromDatabase(Movie deleteMovie)
        {
            _context.Movies.Remove(deleteMovie);
            SaveChanges();
        }

        public void UpdateMovieFromDatabase(Movie updateMovie, string newMovieName, string newCategory, string trailerPath)
        {
            updateMovie.MovieName = newMovieName;
            updateMovie.CategoryName = newCategory;
            updateMovie.VideoPath = trailerPath;

            SaveChanges();
        }
    }
}
