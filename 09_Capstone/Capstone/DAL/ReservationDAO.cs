using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Capstone.DAL
{
    class ReservationDAO : IReservationDAO
    {
        private string connectionString;

        public ReservationDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Reservation GetReservation(int reservation_ID, string name)
        {
            Reservation reservation = new Reservation();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from reservation where reservation_id = @reservation_id and name = @name", conn);
                    cmd.Parameters.AddWithValue("@reservation_id", reservation_ID);
                    cmd.Parameters.AddWithValue("@name", name);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    reservation = ConvertReadertoReservation(rdr);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }
            return reservation;
        }

        private Reservation ConvertReadertoReservation(SqlDataReader rdr)
        {
            Reservation reservation = new Reservation();
            reservation.Reservation_Id = Convert.ToInt32(rdr["reservation_id"]);
            reservation.Site_Id = Convert.ToInt32(rdr["site_id"]);
            reservation.Name = Convert.ToString(rdr["name"]);
            reservation.From_Date = Convert.ToString(rdr["from_date"]);
            reservation.To_Date = Convert.ToString(rdr["to_date"]);
            reservation.Create_Date = Convert.ToString(rdr["create_date"]);

            return reservation;
        }

        public int MakeReservation(Reservation reservation)
        {
            int reservationId = 0;
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into reservation(site_id, name, from_date, to_date, create_date) VALUES(@site_id, @name, @start_date, @end_date, GETDATE()); Select @@identity;", conn);
                    cmd.Parameters.AddWithValue("@site_id", reservation.Site_Id);
                    cmd.Parameters.AddWithValue("@name", reservation.Name);
                    cmd.Parameters.AddWithValue("@start_date", reservation.From_Date);
                    cmd.Parameters.AddWithValue("@end_date", reservation.To_Date);
                    //cmd.Parameters.AddWithValue("GETDATE", reservation.Create_Date);

                    reservationId = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }
            return reservationId;
        }
        

    
    }
}
