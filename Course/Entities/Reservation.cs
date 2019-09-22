using System;
using System.Collections.Generic;
using System.Text;
using Course.Entities.Exceptions;

namespace Course.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkin, DateTime checkout)
        {
            if (checkout <= checkin)
            {
                throw new DomainException("Checkout < Checkin");
            }
            RoomNumber = roomNumber;
            CheckIn = checkin;
            CheckOut = checkout;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int) duration.TotalDays;
        }

        public override string ToString()
        {
            return "Room " + RoomNumber +
                    ", check-in: " + CheckIn.ToString("dd/MM/yyyy") +
                    ", check-out: " + CheckOut.ToString("dd/MM/yyyy") +
                    ", duration: " + Duration() +
                    " nights";
        }

        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if(checkin < now || checkout < now)
            {
                throw new DomainException("Past date");
            }
            if (checkout <= checkin)
            {
                throw new DomainException("Checkout < Checkin");
            }

            CheckIn = checkin;
            CheckOut = checkout;
        }
    }
}
