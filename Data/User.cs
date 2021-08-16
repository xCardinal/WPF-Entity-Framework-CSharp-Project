using System;
using System.Collections.Generic;


namespace Database
{
    public class User
    {
        public User()
        {
            Movie = new HashSet<Movie>();
        }

        public int UserID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public string ContactName { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }


    }
}
