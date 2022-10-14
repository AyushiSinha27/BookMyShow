using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Movie_Data.repository
{
    public class ShowTimingRepository:IShowTimingRepository
    {

        MoviesDb _showTimingDb;

        public ShowTimingRepository(MoviesDb showTimingDb)
        {
            _showTimingDb=showTimingDb;
        }

        public void addshowtiming (Showtiming showtiming)
        {
            _showTimingDb.showTiming.Add(showtiming);
            _showTimingDb.SaveChanges();
        }
        public void updateshowtiming(Showtiming showtiming)
        {
            _showTimingDb.Entry(showtiming).State = EntityState.Modified;
            _showTimingDb.SaveChanges();
        }

        public void deleteshowtiming(int showid)
        {
            var showtiming = _showTimingDb.showTiming.Find(showid);
            _showTimingDb.showTiming.Remove(showtiming);
            _showTimingDb.SaveChanges();
        }
        public IEnumerable<Showtiming> GetShowtiming( )
        {
            return _showTimingDb.showTiming.ToList();
        }
        public Showtiming getshowtimingById(int showId)
        {
            return _showTimingDb.showTiming.Find(showId);
        }

    }
}
