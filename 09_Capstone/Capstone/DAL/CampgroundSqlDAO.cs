using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;


namespace Capstone.DAL
{
    class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;

        public CampgroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Campground> GetCampgroundByParkName(int park_ID)
        {
            List<Campground> campgrounds = new List<Campground>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from campground c join park p on p.park_id = c.park_id where p.park_id = @park_id", conn);
                    cmd.Parameters.Add("park_id", park_ID);
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

        private Campground ConvertReadertoCampground(SqlDataReader rdr)
        {
            Campground campground = new Campground();
            campground.Campground_Id = Convert.ToInt32(rdr["campground_id"]);
            campground.Park_Id = Convert.ToInt32(rdr["park_id"]);
            campground.Name = Convert.ToString(rdr["name"]);
            campground.Open_From_Mm = Convert.ToInt32(rdr["open_from_mm"]);
            campground.Open_To_Mm = Convert.ToInt32(rdr["open_to_mm"]);
            campground.Daily_Fee = Convert.ToDecimal(rdr["daily_fee"]);

            return campground;
        }
    }
}
