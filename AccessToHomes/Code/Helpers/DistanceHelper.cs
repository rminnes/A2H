using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device;
using System.Device.Location;

namespace AccessToHomes.Code.Helpers
{
    public static class DistanceHelper
    {

        public static double Getdistance(double lng1, double lat1, double lgn2, double lat2)
        {
            var sCoord = new GeoCoordinate(lng1, lat1);
            var eCoord = new GeoCoordinate(lgn2, lat2);

            return sCoord.GetDistanceTo(eCoord);
        }

    }
}