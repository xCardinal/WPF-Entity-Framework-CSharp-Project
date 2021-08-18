using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class Movie
    {
        public override string ToString()
        {
            //return $"{MovieId} - {MovieName} - {CategoryName}";
            return $"{MovieName} - {CategoryName}";
        }
    }
}
