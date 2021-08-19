using System.Collections.Generic;

namespace Data
{
    public partial class Movie
    {
        public Movie()
        {
            //MovieFavourites = new HashSet<MovieFavourites>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string CategoryName { get; set; }

        //One to Many
        //public virtual ICollection<MovieFavourites> MovieFavourites { get; set; }
    }
}
