using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Data.repository
{
    public class TheaterRepository:ITheaterRepository

    {
        MoviesDb _theaterdb;


        public TheaterRepository(MoviesDb theaterdb)
        {
            _theaterdb = theaterdb;
        }

        public void addtheater(Theater theater)
        {
            _theaterdb.theater.Add(theater);
            _theaterdb.SaveChanges();
        }

        public void updatetheater(Theater theater)
        {
            _theaterdb.Entry(theater).State = EntityState.Modified;
            _theaterdb.SaveChanges();

        }

        public Theater getTheaterById(int theaterId)
        {
            return _theaterdb.theater.Find(theaterId);
        }

        public void deletetheater(int tid)
        {
            var theater1 = _theaterdb.theater.Find(tid);
            _theaterdb.theater.Remove(theater1);
            _theaterdb.SaveChanges();
        }

        public IEnumerable<Theater> GetTheater()
        {
            return _theaterdb.theater.ToList();
        }
    }
}
