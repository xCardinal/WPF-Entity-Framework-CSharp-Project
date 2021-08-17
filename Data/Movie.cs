using System.Collections.Generic;

namespace Data
{
    public class Movie
    {
        public Movie()
        {
            MovieDetails = new HashSet<MovieDetails>();
        }

        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string MovieName { get; set; }

        //One to One
        public virtual User User { get; set; }

        //One to many
        public virtual ICollection<MovieDetails> MovieDetails { get; set; }

    }
}
