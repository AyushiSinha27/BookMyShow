using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Data
{
    public class Movie_Operation
    {
        //MoviesDb db = null;

        MoviesDb db = null;
        public Movie_Operation (MoviesDb db)
        {
            this.db = db;
        }

        public Movie_Operation()
        {
        }

        public string AddMovie(Movie movie)
        {
            //db = new MoviesDb();
            db.movies.Add(movie);
            db.SaveChanges();
            return "saved";
        }

        public string UpdateMovie(Movie movie)
        {
            //db = new MoviesDb();
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }

        public string DeleteMovie(int moviId)
        {
            Movie movieObj = db.movies.Find(moviId);
            db.Entry(movieObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }

        public List<Movie> ShowAll()

        {
            //db = new MoviesDb();
            List<Movie> movieList = db.movies.ToList();
            return movieList;
        }

        //public Movie ShowMovieById(int movieId)
        //{
        //    db = new MoviesDb();
        //    Movie movie = db.movies.Find(movieId);
        //    return movie;
        //}
    }
}
