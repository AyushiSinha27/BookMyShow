using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Data.repository
{
    public interface IMovieRepository
    {
      
            void addMovie(Movie movie);
            void updateMovie(Movie movie);
            void deleteMovie(int movieId);
            Movie getMovieById(int movieId);
            IEnumerable<Movie> GetMovies();



        }
}

