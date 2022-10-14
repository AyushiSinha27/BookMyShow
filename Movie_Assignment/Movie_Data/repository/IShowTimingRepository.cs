
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Data.repository
{
    public interface IShowTimingRepository
    {
        void addshowtiming(Showtiming show);
        void updateshowtiming(Showtiming show);
        void deleteshowtiming(int showId);
       Showtiming getshowtimingById(int showId);
        IEnumerable<Showtiming> GetShowtiming();
    }
}
