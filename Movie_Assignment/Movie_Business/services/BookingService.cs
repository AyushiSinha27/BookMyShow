using Movie_Data.repository;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Business.services
{
    public class BookingService
    {
        IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        // add booking
        public void AddBooking(Booking booking)
        {
            _bookingRepository.addbooking(booking);
        }
        //update Booking

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.updatebooking(booking);
        }
        //delete Booking
        public void DeleteBooking(int uid)
        {
            _bookingRepository.deletebooking(uid);
        }

        //get Booking

        public IEnumerable<Booking> GetBooking()
        {
            return _bookingRepository.GetBooking();
        }
        public Booking GetBookingById(int bookingId)
        {

            return _bookingRepository.getBookingById(bookingId);
        }
    }
}
