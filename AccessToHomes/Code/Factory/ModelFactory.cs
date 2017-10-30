using AccessToHomes.Models.ViewModels;
using ATH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessToHomes.Code.Factory
{
    public static class ModelFactory
    {
        public static DisplayListingVM Create(this Listing listing)
        {
            return new DisplayListingVM
            {
                Id = listing.Id,
                Title = listing.Title,
                Address = listing.Address,
                ShortDescription = listing.ShortDescription,
                LongDescription = listing.LongDescription,
                Postcode = listing.Postcode,
                Price = listing.Price,
                LongLat = listing.LatLong,
                Images = (listing.Images.Count==0) ? new List<string>() : listing.Images.Select(i => i.FileLocation).ToList(),
                FirstImage = listing.Images.Count == 0 ? "/" : listing.Images.First().FileLocation 
            };
        }


        public static List<DisplayListingVM> Create(this List<Listing> listings)
        {
            return listings.Select(l => l.Create()).ToList();
        }

    }
}