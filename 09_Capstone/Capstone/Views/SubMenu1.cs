using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
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
            this.menuOptions.Add("1", "View campground");
            this.menuOptions.Add("2", "Search for Reservation");
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
                    Console.Clear();
                    ListParks();
                    int parkReservation = GetInteger("Search for Campground By Park: ");
                    GetCampgrounds(parkReservation);
                    Park parkCampground = ParkDAO.GetInfoById(parkReservation);
                    Pause("");
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
            SetColor(ConsoleColor.Magenta);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Sub-Menu 1"));
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


    }
}
