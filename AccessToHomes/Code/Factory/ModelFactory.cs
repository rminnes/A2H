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
                Images = (listing.Images.Count == 0) ? new List<string>() : listing.Images.Select(i => i.FileLocation).ToList(),
                FirstImage = listing.Images.Count == 0 ? "/" : listing.Images.First().FileLocation,
                Agent = listing.Agent,
                Bedrooms = listing.Bedrooms,
                Furnished = listing.Furnished
            };
        }


        public static List<DisplayListingVM> Create(this List<Listing> listings)
        {
            return listings.Select(l => l.Create()).ToList();
        }


        public static AddAgentVM Create(this LettingAgent agent)
        {
            return new AddAgentVM
            {
                Address_1 = agent.Address_1,
                Address_2 = agent.Address_2,
                Address_3 = agent.Address_3,
                Postcode = agent.Postcode,
                Description = agent.Description,
                Email = agent.Email,
                Logo = agent.Logo,
                Name = agent.Name,
                Phone = agent.Phone,
                Website = agent.Website
            };
        }

        public static LettingAgent Create(this AddAgentVM agent)
        {
            return new LettingAgent
            {
                Address_1 = agent.Address_1,
                Address_2 = agent.Address_2,
                Address_3 = agent.Address_3,
                Postcode = agent.Postcode,
                Description = agent.Description,
                Email = agent.Email,
                Logo = agent.Logo,
                Name = agent.Name,
                Phone = agent.Phone,
                Website = agent.Website
            };
        }

    }
}