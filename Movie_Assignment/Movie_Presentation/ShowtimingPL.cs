using Movie_Data;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Presentation
{
   public class ShowtimingPL
    {

        public void AddShowtime()
        {
            Showtiming_Operation showop = new Showtiming_Operation();
            Showtiming showtiming = new Showtiming();
            Console.WriteLine("Enter Show Id:");
            showtiming.Id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Movie Id:");
            showtiming.MovieId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Theater Id:");
            showtiming.TheaterId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ShowTime:");
            showtiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = showop.AddShowTime(showtiming);
            Console.WriteLine(msg);

        }

        public void RemoveShowTime()
        {
            Showtiming_Operation showop = new Showtiming_Operation();
            Showtiming showtiming = new Showtiming();
            Console.WriteLine("Enter Show Id:");
            showtiming.Id = Convert.ToInt32(Console.ReadLine());
            string msg = showop.DeleteShowTime(showtiming.Id);
            Console.WriteLine(msg);


        }

        public void UpdateShowTime()
        {
            Showtiming_Operation showop = new Showtiming_Operation();
            Showtiming showtiming = new Showtiming();
            Console.WriteLine("Enter Show Id:");
            showtiming.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Movie Id:");
            showtiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Theater Id:");
            showtiming.TheaterId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ShowTime:");
            showtiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = showop.UpdateShowTime(showtiming);
            Console.WriteLine(msg);

        }

        public void DisplayShowTime()
        {
            Showtiming_Operation showop = new Showtiming_Operation();
            List<Showtiming> showtimes = showop.ShowAllShowTime();
            foreach (Showtiming item in showtimes)
            {
                Console.WriteLine("ID: \n" +item.Id);
                Console.WriteLine("Name: \n"+item.MovieId);
                Console.WriteLine("Theater Id: \n"+item.TheaterId);
                Console.WriteLine("Time: \n"+item.ShowTime);
            }


        }
    }
}
