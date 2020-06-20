using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {
        //public void Reservation(int siteID, string name, string fromDate, string toDate)
        //{
        //    this.Site_Id = siteID;
        //    this.Name = name;
        //    this.From_Date = fromDate;
        //    this.To_Date = toDate;

        //}




        public int Reservation_Id { get; set; }
        public int Site_Id { get; set; }
        public string  Name { get; set; }
        public string From_Date { get; set; }
        public string To_Date { get; set; }
        public  string Create_Date { get; set; } //not sure if string or DateTime?

        

        public override string ToString()
        {
            return $"{Reservation_Id} {Site_Id} {Name} {From_Date} {To_Date} {Create_Date}";
        }
    }
}
