using ATH.Models;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ATH.Services
{
   public class ListingService:EntityService<Listing>,IListingService
    {
        IContext _context;

        public ListingService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<Listing>();
        }

        /// <summary>
        /// Returns all listings
        /// </summary>
        /// <returns></returns>
        public List<Listing> GetListings()
        {
            return _context.Listings.Include(l => l.Images).ToList();
        }

        /// <summary>
        /// Returns a number of lisitngs
        /// </summary>
        /// <param name="count"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<Listing> GetListings(int count, int take)
        {
            return _context.Listings.OrderBy(l=>l.Id).Skip(count).Take(take).Include(l => l.Images).ToList();
        }

        /// <summary>
        /// Gets the requested number of listings based on a centre point and distance form that point
        /// </summary>
        /// <param name="count"></param>
        /// <param name="take"></param>
        /// <param name="distance"></param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public List<Listing> GetListings(int count, int take, int distance, double lat, double lng )
        {
            var allListings = _context.Listings.Include(l => l.Images).ToList() ;
            var returnListings = new List<Listing>();

            foreach (var listing in allListings)
            {
                var lLat = Convert.ToDouble(listing.LatLong.Split(',')[0]);
                var lLng = Convert.ToDouble(listing.LatLong.Split(',')[1]);

                var Distance = Getdistance(lat, lng, lLat, lLng);
                if (distance > Distance)
                {
                    returnListings.Add(listing);
                }
            }

            return returnListings.Skip(count).Take(take).ToList();

        }

        /// <summary>
        /// get the distance between two points based on the lat/lng
        /// </summary>
        /// <param name="lng1"></param>
        /// <param name="lat1"></param>
        /// <param name="lgn2"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        private double Getdistance(double lng1, double lat1, double lgn2, double lat2)
        {
            var sCoord = new GeoCoordinate(lng1, lat1);
            var eCoord = new GeoCoordinate(lgn2, lat2);

            return sCoord.GetDistanceTo(eCoord);
        }

        public Listing GetById(long Id)
        {
            return _dbset.Include(l => l.Images).Include(l=>l.Agent).FirstOrDefault(x => x.Id == Id);
        }
        /// <summary>
        /// Adds images to an existing listing
        /// </summary>
        /// <param name="list"></param>
        /// <param name="imgs"></param>
        public void AddImages(Listing list, HttpPostedFileBase[]  imgs)
        {
            list.Images = new List<ListingImage>();
            var count = 1;
            foreach (var file in imgs)
            {
                if (file != null)
                {
                string ext = Path.GetExtension(file.FileName);
                var dir = string.Format(@"C:\Webs\AccessToHomes\AccessToHomes\images\listings\{0}", list.Id);
                System.IO.Directory.CreateDirectory(dir);
                var path = string.Format(@"{0}\image-{1}{2}", dir, count, ext);
                var realtivePath = string.Format(@"/images/listings/{0}/image-{1}{2}", list.Id, count, ext);
                file.SaveAs(path);
                list.Images.Add(new ListingImage { FileLocation = realtivePath });
                count++;
                }
                
            }
         
            Update(list);
        }

        /// <summary>
        /// Get the lat/lng from google based on the postcode o location
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public string LatLngFromPostcode(string pc)
        {

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(pc + ", UK");

            var latitude = point.Latitude;
            var longitude = point.Longitude;

            return latitude+  ", " + longitude;
        }
    }
}
