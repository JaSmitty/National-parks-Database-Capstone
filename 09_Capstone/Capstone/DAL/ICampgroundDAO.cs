using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    interface ICampgroundDAO
    {

        IList<Campground> GetCampgroundByParkName(int park_ID);

        
    }
}
