using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        Reservation GetReservation(int reservation_ID, string name);


        int MakeReservation(Reservation reservation);
    }
}
