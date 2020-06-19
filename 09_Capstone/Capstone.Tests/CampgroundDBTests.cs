using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using Capstone.Models;
using Capstone.DAL;
using System.Collections.Generic;
using System;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundDBTests
    {
        
        private string connectionString = @"Server=.\SQLEXPRESS; Database =EmployeeDB; Trusted_Connection=True;";
        private TransactionScope transaction;

        private int testParkId1;
        private int testParkId2;
        private int testCampground1;
        private int testCampground2;
        private int testSite1;
        private int testSite2;
        private int testReservation1;
        private int testReservation2;

        [TestInitialize]
        public void SetupDB()
        {
            transaction = new TransactionScope();

            string sqlScript = File.ReadAllText(connectionString);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlScript, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) { }
                {
                    testParkId1 = Convert.ToInt32(rdr["@TestParkId1"]);
                    testParkId2 = Convert.ToInt32(rdr["@TestParkId2"]);
                    testCampground1 = Convert.ToInt32(rdr["@TestCampground1"]);
                    testCampground2 = Convert.ToInt32(rdr["@TestCampground2"]);
                    testSite1 = Convert.ToInt32(rdr["@TestSite1"]);
                    testSite2 = Convert.ToInt32(rdr["@TestSite2"]);
                    testReservation1 = Convert.ToInt32(rdr["@TestReservation1"]);
                    testReservation2 = Convert.ToInt32(rdr["@TestReservation2"]);
                }
            }
        }

        [TestCleanup]
        public void CleanupDB()
        {
            // Roll back the transaction
            transaction.Dispose();
        }

        [TestMethod]
        public void GetParksTest()
        {
            //Arrange

            //Create a department sql dao
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);

            //Act
            IList<Park> parks = dao.GetParks();

            //Assert
            Assert.AreEqual(3, parks.Count);
        }

        [TestMethod]
        public void GetInfoByIdTest(int testId)
        {
            //Arrange

            //Create a department sql dao
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);

            //Act
            Park park = dao.GetInfoById(testId);

            //Assert
            Assert.AreEqual(testId, 1);
        }
        [TestMethod]
        public void ReturnAvailableSitesTest()
        {

        }
        [TestMethod]
        public void MakeReservationTest()
        {

        }
    }
}
