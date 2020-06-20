using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CLI
{
    /// <summary>
    /// A sub-menu 
    /// </summary>
    public class SubMenu1 : MainMenu
    {
        // Store any private variables here....

        
        public SubMenu1(ICampgroundDAO campgroundDAO, IParkDAO parkDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO) :
            base(campgroundDAO, parkDAO, siteDAO, reservationDAO)
        {

        }
        
        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "View campgrounds");
            this.menuOptions.Add("2", "Search for availble reservations");
            this.menuOptions.Add("B", "Back to Main Menu");
            this.quitKey = "B";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    while (true)
                    {
                        Console.Clear();

                        PrintHeader();
                        ListParks();
                        int reservationParkId = GetInteger("Search for Campground By Park: ");
                        GetCampgrounds(reservationParkId);
                        //Park parkCampground = ParkDAO.GetInfoById(reservationParkId); 
                        int campgroundId = GetInteger("Which campground (enter 0 to cancel)?   ");
                        string arrivalDate = GetString("What is the arrival date? (mm/dd/yyyy)  ");
                        string departureDate = GetString("What is the departure date? (mm/dd/yyyy)  ");


                        int siteCount = GetAvailableSites(campgroundId, arrivalDate, departureDate);
                        if (siteCount == 0)
                        {
                            Console.WriteLine("Sorry, no sites were found!");
                            Console.ReadLine();
                            break;
                        }

                        int siteReserved = GetInteger("Which site would you like to reserve?: ");
                        string reservationName = GetString("What should the name of the reservation be under?");

                        int confirmationNumber = MakingTheRes(reservationName, siteReserved, arrivalDate, departureDate);

                        Console.WriteLine($"The reservation has been made!");
                        Console.WriteLine($"Your confirmationID is :{confirmationNumber}");

                        Pause("");
                    }
                    return true;
                    case "2":
                    
                    Pause("");
                    return false;
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.Cyan);
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.Green);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Reservations"));
            ResetColor();
        }

        private void GetCampgrounds(int park_id)
        {
            IList<Campground> campgrounds = CampgroundDAO.GetCampgroundByParkId(park_id);

            foreach (Campground campground in campgrounds)
            {
                Console.WriteLine(campground);
            }
        }
        private int GetAvailableSites(int campgroundId, string arrivalDate, string departureDate)
        {
            IList<Site> sites = SiteDAO.ReturnAvailableSites(campgroundId, arrivalDate, departureDate);

            int sitesCount = sites.Count;
            if (sitesCount == 0)
            {
                return sitesCount;
            }
            foreach (Site site in sites)
            {
                Console.WriteLine(site);
            }
            return sitesCount;
        }

        private int MakingTheRes(string reservationName, int siteReserved, string arrivalDate, string departureDate)
        {
            Reservation newReservation = new Reservation();
            newReservation.Name = reservationName;
            newReservation.Site_Id = siteReserved;
            newReservation.From_Date = arrivalDate;
            newReservation.To_Date = departureDate;
            //newReservation.Create_Date = DateTime.Now.ToString();

            int confirmationNumber = ReservationDAO.MakeReservation(newReservation);

            return confirmationNumber;
        }

        private int GetTotalStayLength(string arrivalDate, string departureDate)
        {

        }

    }

   
}
