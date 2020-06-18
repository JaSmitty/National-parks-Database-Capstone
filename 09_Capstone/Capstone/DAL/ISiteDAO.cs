using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    interface ISiteDAO
    {
        IList<Site> ReturnAvailibleSites(int campgroundID, string arrivalDate, string departureDate);
    }
}
