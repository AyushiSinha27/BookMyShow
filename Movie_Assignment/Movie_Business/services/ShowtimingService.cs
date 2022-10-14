using Movie_Data.repository;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Business.services
{
    public class ShowtimingService
    {
        IShowTimingRepository _showtimingRespository;

        public ShowtimingService(IShowTimingRepository showtimingRepository)
        {
            _showtimingRespository = showtimingRepository;
        }
        // add showtiming
        public void AddShowtiming(Showtiming showtiming )
        {
            _showtimingRespository.addshowtiming(showtiming);
        }
        //update showtiming

        public void UpdateShowTiming(Showtiming showtiming)
        {
            _showtimingRespository.updateshowtiming(showtiming);
        }
        //delete showtiming
        public void DeleteShowTiming(int showid)
        {
            _showtimingRespository.deleteshowtiming(showid);
        }

        //get showtiming

        public IEnumerable<Showtiming> GetShowTiming()
        {
            return _showtimingRespository.GetShowtiming();
        }
        public Showtiming GetShowtimingById(int showId)
        {

            return _showtimingRespository.getshowtimingById(showId);
        }

    }
}
