using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    interface IReservationDAO
    {
        //Reservation GetReservation(int reservation_ID);     IF WE WANT TO


        int MakeReservation(int siteID, string arrivalDate, string departureDate);
    }
}
