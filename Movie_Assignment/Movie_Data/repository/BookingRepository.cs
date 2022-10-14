using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Data.repository
{
    
        public class BookingRepository : IBookingRepository

        {
            MoviesDb _bookingdb;


            public BookingRepository(MoviesDb bookingdb)
            {
                _bookingdb = bookingdb;
            }

            public void addbooking(Booking booking)
            {
                _bookingdb.booking.Add(booking);
                _bookingdb.SaveChanges();
            }

            public void updatebooking(Booking booking)
            {
                _bookingdb.Entry(booking).State = EntityState.Modified;
                _bookingdb.SaveChanges();

            }

            public void deletebooking(int bid)
            {
                var booking1 = _bookingdb.booking.Find(bid);
                _bookingdb.booking.Remove(booking1);
                _bookingdb.SaveChanges();
            }

            public IEnumerable<Booking> GetBooking()
            {
                return _bookingdb.booking.ToList();
            }

        public Booking getBookingById(int bookingId)
        {
            return _bookingdb.booking.Find(bookingId);
        }
    }
    }

