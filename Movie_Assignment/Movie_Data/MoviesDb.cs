using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Data
{
    public class MoviesDb : DbContext
    {
        public MoviesDb(DbContextOptions<MoviesDb> options) : base(options)
        {



        }
        public DbSet<User> users { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Theater> theater { get; set; }
        public DbSet<Showtiming> showTiming { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2207;Initial Catalog=MyBookMovieShowApi_UI;Integrated Security=True;");
        }
    }
}
