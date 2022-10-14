using Movie_Data;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Presentation
{
    public  class TheaterPL
    {

        public void AddTheater()
        {
            Theater_Operation theaterop = new Theater_Operation();
            Theater theater=new Theater();
            Console.WriteLine("Enter Id:");
            theater.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            theater.Name = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            theater.Address = Console.ReadLine();
            Console.WriteLine("Enter Comments:");
            theater.Comments = Console.ReadLine();
            string msg = theaterop.AddTheater(theater);
            Console.WriteLine(msg);

        }
        public void DeleteTheater()
        {
            Theater_Operation theaterop = new Theater_Operation();
            Theater theater = new Theater();
            Console.WriteLine("Enter Id:");
            theater.Id = Convert.ToInt32(Console.ReadLine());
            string msg = theaterop.DeleteTheater(theater.Id);
            Console.WriteLine(msg);
        }

        public void UpdateTheater()
        {
            Theater_Operation theaterop = new Theater_Operation();
            Theater theater = new Theater();
            Console.WriteLine("Enter Id:");
            theater.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            theater.Name = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            theater.Address = Console.ReadLine();
            Console.WriteLine("Enter Comments:");
            theater.Comments = Console.ReadLine();
            string msg = theaterop.UpdateTheater(theater);
            Console.WriteLine(msg);
        }

        public void ShowTheater()
        {
            Theater_Operation theaterop = new Theater_Operation();
            List<Theater> theaters = theaterop.ShowAllTheater();
           foreach (Theater item in theaters)
            {
                Console.WriteLine("Item: \n"+item.Id);
                Console.WriteLine("Name: \n"+item.Name);
                Console.WriteLine("Addres: \n"+item.Address);
                Console.WriteLine("Comments: \n"+item.Comments);
            }
        }

    }
}
