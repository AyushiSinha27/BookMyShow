using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Data.repository
{
    public class MovieRepository:IMovieRepository
    {
        MoviesDb _moviesDb;

       
        public MovieRepository(MoviesDb moviesDb)
        {
            _moviesDb = moviesDb;
        }
        public void addMovie(Movie movie)
        {
            _moviesDb.movies.Add(movie);
            _moviesDb.SaveChanges();
        }



        public void deleteMovie(int movieId)
        {
            var movie = _moviesDb.movies.Find(movieId);
            _moviesDb.movies.Remove(movie);
             _moviesDb.SaveChanges();
        }



        public Movie getMovieById(int movieId)
        {
            return _moviesDb.movies.Find(movieId);
        }



        public IEnumerable<Movie> GetMovies()
        {
            return _moviesDb.movies.ToList();
        }



        public void updateMovie(Movie movie)
        {
            _moviesDb.Entry(movie).State = EntityState.Modified;
            _moviesDb.SaveChanges();
        }

    }
}