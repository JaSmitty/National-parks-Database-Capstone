using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
        IList<Park> GetParks();

        Park GetInfoById(int park_Id);



    }
}
