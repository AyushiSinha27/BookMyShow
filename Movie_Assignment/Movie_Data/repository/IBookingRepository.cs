using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Data.repository
{
    public interface IBookingRepository
    {
        void addbooking(Booking booking);
        void deletebooking(int bid);
        void updatebooking(Booking booking);
       Booking getBookingById(int bookingId);
        IEnumerable<Booking> GetBooking();
    }
}
