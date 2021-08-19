using System.Collections.Generic;

namespace Data
{
    public class User
    {
        public User()
        {
            //MovieFavouritesCollection = new HashSet<Movie>();
            //MovieFavourites = new HashSet<MovieFavourites>();
        }

        public int UserId { get; set; }
        public string ContactName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type {get; set; }
        public int Status { get; set; }

        //public virtual ICollection<Movie> MovieFavouritesCollection { get; set; }

        //public virtual ICollection<MovieFavourites> MovieFavourites { get; set; }
    }
}
