using Capstone.DAL;
using System;
using System.Collections.Generic;
using Capstone.Models;
using System.Data;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        // You may want to store some private variables here.  YOu may want those passed in 
        // in the constructor of this menu
        protected ICampgroundDAO CampgroundDAO;
        protected IParkDAO ParkDAO;
        protected ISiteDAO SiteDAO;
        protected IReservationDAO ReservationDAO;


        public MainMenu(ICampgroundDAO campgroundDAO, IParkDAO parkDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO) : base("Main Menu")
        {
            this.CampgroundDAO = campgroundDAO;
            this.ParkDAO = parkDAO;
            this.SiteDAO = siteDAO;
            this.ReservationDAO = reservationDAO;
        }


        /// <summary>
        /// Constructor adds items to the top-level menu. You will likely have parameters  passed in
        /// here...
        /// </summary>
        

        protected override void SetMenuOptions()
        {
            // A Sample menu.  Build the dictionary here
            this.menuOptions.Add("1", "View Parks");
            this.menuOptions.Add("2", "Make A Reservation");
            this.menuOptions.Add("Q", "Quit program");
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
                    ListParks();
                    Pause("");
                    return true;
                case "2":
                    int parkID = GetInteger("Please enter ParkID: ");
                    Park park = ParkDAO.GetInfoById(parkID);
                    SubMenu1 sm = new SubMenu1(park, CampgroundDAO, ParkDAO, SiteDAO, ReservationDAO);
                    sm.Run();
                    Pause("");
                    return true;
                  
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }


        private void PrintHeader()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Main Menu"));
            ResetColor();
        }


        private void ListParks()
        {
            IList<Park> parks = ParkDAO.GetParks();

            foreach (Park park in parks)
            {
                Console.WriteLine(park);
            }
        }
    }
}
