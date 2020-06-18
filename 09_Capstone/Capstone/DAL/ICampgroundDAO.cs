using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    interface ICampgroundDAO
    {

        Campground GetCampgroundByParkName();
        IList<Park> SelectParkByAvailabilty(string name);

        IList<Campground> GetCampgroundsByOpen(int )
    }
}
