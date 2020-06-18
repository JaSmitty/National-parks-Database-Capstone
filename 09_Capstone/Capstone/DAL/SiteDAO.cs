using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class SiteDAO : ISiteDAO
    {
        private string connectionString;

        public SiteDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Site> ReturnAvailibleSites(int campgroundID, string arrivalDate, string departureDate)
        {
            List<Site> AvailibleSites = new List<Site>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();



                    SqlCommand cmd = new SqlCommand("Select * from site where campgroundID = @campground_", conn);
                    cmd.Parameters.AddWithValue("@park_id", park_Id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Campground campground = ConvertReadertoCampground(rdr);
                        campgrounds.Add(campground);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }
            return campgrounds;
        }

        private IList<Site> SiteHelper(List<Reservation> reservationNotAvailible, List<Site> sitesSelected)
        {
            List<Site> availibleSites = new List<Site>();

            foreach (Site site in sitesSelected)
            {
                foreach (Reservation reserve in reservationNotAvailible)
                {
                    if (site.Site_Id == reserve.Site_Id)
                    {
                        
                    }
                    else
                    {
                        availibleSites.Add(site);
                    }
                }
            }


            return availibleSites;
        }

    }
}
