using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AccessToHomes.Models.ViewModels
{
    public class HomeVM
    {
        public string Location { get; set; }

        public enum Type
        {
            Rent, 
            Buy
        };


        public int Distance { get; set; }
        public SelectList DistanceList { get; set; }

        public HomeVM()
        {

            var lItems = new List<DistanceItem>();
            lItems.Add(new DistanceItem { Text = "3km", Value = 3000 });
            lItems.Add(new DistanceItem { Text = "5km", Value = 5000 });
            lItems.Add(new DistanceItem { Text = "10km", Value = 10000 });
            lItems.Add(new DistanceItem { Text = "25km", Value = 25000 });

            DistanceList = new SelectList(lItems, "Value","Text");            
        }



    }

}