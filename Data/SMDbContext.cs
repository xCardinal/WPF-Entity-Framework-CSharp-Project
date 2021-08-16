using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database;

namespace Data
{
    public partial class SMDbContext : DbContext
    {
        public static SMDbContext Instance { get; } = new SMDbContext();


        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = SMDb;");
            }
        }
    }
}
