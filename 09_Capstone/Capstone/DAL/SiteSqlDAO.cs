using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class SiteSqlDAO : ISiteDAO
    {
        private string connectionString;

        public SiteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Site> ReturnAvailableSites(int campgroundID, string arrivalDate, string departureDate)
        {
            List<Site> availableSites = new List<Site>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    ////string helper = "Select top 5 * from site" +
                    //                 "where site_id not in (Select site_id from reservation" +
                    //                 "where(from_date between @start_Date and @end_Date)" +
                    //                 "or(to_date between @start_Date and @end_Date)" +
                    //                 "or(@start_Date between from_date and to_date)" +
                    //                 "or(@end_Date between from_date and to_date)) and @campground_id = site.campground_id";

                    SqlCommand cmd = new SqlCommand($"Select top 5 * from site where site_id not in (Select site_id from reservation where(from_date between @start_Date and @end_Date) or (to_date between @start_Date and @end_Date) or (@start_Date between from_date and to_date) or (@end_Date between from_date and to_date)) and @campground_id = site.campground_id", conn);


                    cmd.Parameters.AddWithValue("@start_Date", arrivalDate);
                    cmd.Parameters.AddWithValue("@end_Date", departureDate);
                    cmd.Parameters.AddWithValue("@campground_id", campgroundID);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Site site = ConvertReadertoSite(rdr);
                        availableSites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }
            return availableSites;
        }

        private Site ConvertReadertoSite(SqlDataReader rdr)
        {
            Site site = new Site();

            site.Site_Id = Convert.ToInt32(rdr["site_id"]);
            site.Campground_Id = Convert.ToInt32(rdr["campground_id"]);
            site.Site_Number = Convert.ToInt32(rdr["site_number"]);
            site.Max_Occupancy = Convert.ToInt32(rdr["max_occupancy"]);
            site.Accessible = Convert.ToInt32(rdr["Accessible"]);
            site.Max_Rv_Length = Convert.ToInt32(rdr["max_rv_length"]);
            site.Utilities = Convert.ToInt32(rdr["Utilities"]);

            return site;
        }
    }
}
