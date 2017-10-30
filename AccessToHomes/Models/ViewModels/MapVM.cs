using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccessToHomes.Models.ViewModels
{
    public class MapVM
    {
        public string Postcode { get; set; }

        public int Distance { get; set; }
        public SelectList DistanceList { get; set; }

        public MapVM()
        {

            var lItems = new List<DistanceItem>();
            lItems.Add(new DistanceItem { Text = "3km", Value = 3000 });
            lItems.Add(new DistanceItem { Text = "5km", Value = 5000 });
            lItems.Add(new DistanceItem { Text = "10km", Value = 10000 });
            lItems.Add(new DistanceItem { Text = "25km", Value = 25000 });
            
            DistanceList = new SelectList(lItems, "Value", "Text", Distance);
        }
    }
}