using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Data.repository
{  public  interface ITheaterRepository
    {
        void addtheater(Theater theater);
        void deletetheater(int tid);
        void updatetheater(Theater theater);
        Theater getTheaterById(int theaterId);
        IEnumerable<Theater> GetTheater();
        
    }
}
