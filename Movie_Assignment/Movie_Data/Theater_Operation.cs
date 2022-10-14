using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Data
{
    public class Theater_Operation
    {
        MoviesDb db = null;
        public Theater_Operation(MoviesDb db)
        {
            this.db = db;
        }

        public Theater_Operation()
        {
        }

        public string AddTheater(Theater movie)
        {
            //db = new MoviesDb();
            db.theater.Add(movie);
            db.SaveChanges();
            return "saved";
        }

        public string UpdateTheater(Theater theater)
        {
            //db = new MoviesDb();
            db.Entry(theater).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }

        public string DeleteTheater(int theaterId)
        {
            Theater theaterObj = db.theater.Find(theaterId);
            db.Entry(theaterObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }

        public List<Theater> ShowAllTheater()

        {
            //db = new MoviesDb();
            List<Theater> theaterList = db.theater.ToList();
            return theaterList;
        }

        //public Movie ShowTheaterById(int movieId)
        //{
        //    db = new MoviesDb();
        //    Movie movie = db.movies.Find(movieId);
        //    return movie;
        //}
    }
}
