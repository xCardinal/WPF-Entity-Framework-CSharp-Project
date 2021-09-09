using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ICustomerService
    {
        public List<User> UsersList { get; }
        List<Movie> AllMoviesList { get; }
        public List<Movie> GetMovieByName(string movieName);
        public void AddMovieToDatabase(Movie newMovie);
        public void RemoveMovieFromDatabase(Movie deleteMovie);
        public void UpdateMovieFromDatabase(Movie updateMovie, string newMovieName, string newCategory, string trailerPath);
        List<MovieFavourites> GetAllFavouriteMoviesList();
        public void AddMovieToFavourites(MovieFavourites movieName);
        public void RemoveFromFavourites(MovieFavourites movieName);
        public void SaveChanges();
    }
}
