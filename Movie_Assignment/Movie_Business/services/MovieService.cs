using Movie_Data.repository;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Business.services
{
    
    public class MovieService
    {
        IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }



        //add movie
        public void AddMovie(Movie movie)
        {
            _movieRepository.addMovie(movie);
        }
        //update movie
        public void UpdateMovie(Movie movie)
        {
            _movieRepository.updateMovie(movie);
        }
        //delete movie
        public void DeleteMovie(int movieId)
        {
            _movieRepository.deleteMovie(movieId);
        }
        //getmoviebyid movie
        public Movie GetMovieById(int movieId)
        {
            
            return _movieRepository.getMovieById(movieId);  
        }
        //get movies
        public IEnumerable<Movie> GetMovies()
        {
            return _movieRepository.GetMovies();
        }
    }
}
