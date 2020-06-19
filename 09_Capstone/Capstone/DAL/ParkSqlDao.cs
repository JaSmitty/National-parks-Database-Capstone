using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ParkSqlDao :IParkDAO 
    {
        private string connectionString;
        public ParkSqlDao(string dbconnectionString)
        {
            connectionString = dbconnectionString;
        }
        public IList<Park> GetParks() 
        {
            List<Park> parks = new List<Park>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from park order by name", conn);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Park park = ConvertReadertoPark(rdr);
                        parks.Add(park);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }
            return parks;
        }

        private Park ConvertReadertoPark(SqlDataReader rdr)
        {
            Park park = new Park();
            park.Park_Id = Convert.ToInt32(rdr["park_id"]);
            park.Name = Convert.ToString(rdr["name"]);
            park.Location = Convert.ToString(rdr["location"]);
            park.Establish_Date = Convert.ToDateTime(rdr["establish_date"]);
            park.Area = Convert.ToInt32(rdr["area"]);
            park.Vistors = Convert.ToInt32(rdr["visitors"]);
            park.Description = Convert.ToString(rdr["description"]);

            return park;
        }

        public Park GetInfoById(int park_Id) 
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from park where park_id = @park_id", conn);

                    cmd.Parameters.AddWithValue("@park_id", park_Id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    

                    while (rdr.Read())
                    {
                        park = ConvertReadertoPark(rdr);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }
            return park;
        }

    }
}
