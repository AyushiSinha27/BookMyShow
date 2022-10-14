using Movie_Data.repository;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Business.services
{
    public class TheaterService
    {
        ITheaterRepository _theaterRepository;

        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }

        public void AddTheater(Theater theater)
        {
            _theaterRepository.addtheater(theater);
        }

        public void DeleteTheater(int tid)
        {
            _theaterRepository.deletetheater(tid);
        }

        public IEnumerable<Theater> GetTheater()
        {
            return _theaterRepository.GetTheater();
        }

        public void UpdateTheater(Theater theater)
        {
            _theaterRepository.updatetheater(theater);
        }

        public Theater GetTheaterById(int theaterId)
        {

            return _theaterRepository.getTheaterById(theaterId);
        }
    }
}
