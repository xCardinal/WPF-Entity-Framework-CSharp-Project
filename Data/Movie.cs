using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Movie
    {
        public Movie()
        {
            MovieDetails = new HashSet<MovieDetails>();
        }

        public int MovieID { get; set; }
        public int UserID { get; set; }

        //One to One
        public virtual User User { get; set; }

        //One to many
        public virtual ICollection<MovieDetails> MovieDetails { get; set; }

    }
}
