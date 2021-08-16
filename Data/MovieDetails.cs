using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MovieDetails
    {
        //PK
        public int MovieDetailsID { get; set; }

        public int MovieID { get; set; }

        public string CategoryName { get; set; }

        //Possible List of actors && actresses
        //public string[] listOfActors { get; set; }

        //FK
        public virtual Movie Movie { get; set; }

    }
}
