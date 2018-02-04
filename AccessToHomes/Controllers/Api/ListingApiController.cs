using ATH.Models;
using ATH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccessToHomes.Code.Factory;
using AccessToHomes.Models.ViewModels;
using Newtonsoft;

namespace AccessToHomes.Controllers.Api
{
    public class ListingApiController : ApiController
    {
        public IListingService _lService;

        public ListingApiController(IListingService lService)
        {
            _lService = lService;
        }
        
        [HttpGet]
        public List<DisplayListingVM> GetListings()
        {
            var listings = _lService.GetListings().Create();
            return listings;
        }

        [HttpGet]
        public List<DisplayListingVM> GetListingsJson()
        {


            var listings = _lService.GetListings().Create();
            return listings;
        }

        
        [HttpGet]
        public List<DisplayListingVM> GetListings(int count, int take)
        {
            var listings = _lService.GetListings(count, take).Create();
            return listings;
        }

        [HttpGet]
        public List<DisplayListingVM> GetListings(int count, int take, int distance, double lat, double lng)
        {
            var listings = _lService.GetListings(count, take, distance, lat, lng).Create();
            return listings;
        }

        [HttpGet]
        public DisplayListingVM GetListing(long id)
        {
            var listing = _lService.GetById(id).Create();
            return listing;
        }

        [HttpGet]
        public string GetLatLng(string location)
        {
           return _lService.LatLngFromPostcode(location);
        }

    }
}
