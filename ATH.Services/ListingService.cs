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

        public List<Listing> GetListings()
        {
            return _context.Listings.Include(l => l.Images).ToList();

        }

        public List<Listing> GetListings(int count, int take)
        {
            return _context.Listings.OrderBy(l=>l.Id).Skip(count).Take(take).Include(l => l.Images).ToList();
        }

        public List<Listing> GetListings(int count, int take, int distance, double lat, double lng )
        {
            // get a

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

            //return _context.Listings.OrderBy(l => l.Id).Skip(count).Take(take).Include(l => l.Images).ToList();
        }

        private double Getdistance(double lng1, double lat1, double lgn2, double lat2)
        {
            var sCoord = new GeoCoordinate(lng1, lat1);
            var eCoord = new GeoCoordinate(lgn2, lat2);

            return sCoord.GetDistanceTo(eCoord);
        }

        public Listing GetById(long Id)
        {
            return _dbset.Include(l => l.Images).FirstOrDefault(x => x.Id == Id);
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
                string ext = Path.GetExtension(file.FileName);
                var dir = string.Format(@"C:\Webs\AccessToHomes\AccessToHomes\images\listings\{0}", list.Id);
                System.IO.Directory.CreateDirectory(dir);
                var path = string.Format(@"{0}\image-{1}{2}", dir, count, ext);
                var realtivePath = string.Format(@"/images/listings/{0}/image-{1}{2}", list.Id, count, ext);
                file.SaveAs(path);
                list.Images.Add(new ListingImage { FileLocation = realtivePath });
                count++;
            }
         
            Update(list);
        }

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
