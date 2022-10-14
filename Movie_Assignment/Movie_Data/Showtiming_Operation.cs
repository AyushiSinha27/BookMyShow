using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Data
{
    public class Showtiming_Operation
    {
        MoviesDb db = null;
        public Showtiming_Operation (MoviesDb db)
        {
            this.db = db;
        }

        public Showtiming_Operation()
        {
        }

        public string AddShowTime(Showtiming show)
        {
            //db = new MoviesDb();
            db.showTiming.Add(show);
            db.SaveChanges();
            return "saved";
        }

        public string UpdateShowTime(Showtiming show)
        {
            //db = new MoviesDb();
            db.Entry(show).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }

        public string DeleteShowTime(int showid)
        {
            Showtiming showtimeObj = db.showTiming.Find(showid);
            db.Entry(showtimeObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }

        public List<Showtiming> ShowAllShowTime()

        {
            //db = new MoviesDb();
            List<Showtiming> showList = db.showTiming.ToList();
            return showList;
        }

        //public Movie ShowMovieById(int movieId)
        //{
        //    db = new MovieDbContext();
        //    Movie movie = db.movies.Find(movieId);
        //    return movie;
        //}
    }
}
