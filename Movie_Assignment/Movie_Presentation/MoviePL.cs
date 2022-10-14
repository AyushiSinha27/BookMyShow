using System;
using System.Collections.Generic;
using Movie_Entity;
using Movie_Data;

namespace Movie_Presentation
{
    public class MoviePL
    {
        public void AddMoviesPL()
        {
            Movie_Operation movieOperations = new Movie_Operation();
            Movie movie = new Movie();
            Console.WriteLine("Enter MovieName: ");
            movie.Name = Console.ReadLine();
            Console.WriteLine("Enter Movie Description:");
            movie.MoviesDesc = Console.ReadLine();
            Console.WriteLine("Enter Movie Type:");
            movie.MovieType = Console.ReadLine();
            string msg = movieOperations.AddMovie(movie);
            Console.WriteLine(msg);


        }

        public void ShowAllMoviesPL()
        {
            Movie_Operation movieoperations = new Movie_Operation();
            List<Movie> movies = movieoperations.ShowAll();
            foreach (var items in movies)
            {
                Console.WriteLine("Id: \n" + items.Id);
                Console.WriteLine("Name: \n" + items.Name);
                Console.WriteLine("Description: \n" + items.MoviesDesc);
                Console.WriteLine("Movie Type: \n" + items.MovieType);
            }
        }

        public void UpdateMoviesPL()
        {
            Movie_Operation movieoperations =new Movie_Operation();
            Movie movie=new Movie();
            Console.WriteLine("Enter Id to update:");
            movie.Id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name:");
            movie.Name = Console.ReadLine();
            Console.WriteLine("Enter Movie Description:");
            movie.MoviesDesc = Console.ReadLine();
            Console.WriteLine("Enter Movie Type:");
            movie.MovieType = Console.ReadLine();
            string msg = movieoperations.UpdateMovie(movie);
            Console.WriteLine(msg);

        }

        public void DeleteMoviesPL()
        {
            Movie_Operation movieoperations = new Movie_Operation();
            Movie movie = new Movie();
            Console.WriteLine("Enter Id to Remove Movie:");
            movie.Id = Convert.ToInt32(Console.ReadLine());
            string msg=movieoperations.DeleteMovie(movie.Id);
            Console.WriteLine(msg);
        }
    }
}
