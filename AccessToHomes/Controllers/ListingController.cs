using AccessToHomes.Models.ViewModels;
using ATH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccessToHomes.Code.Factory;

namespace AccessToHomes.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public IListingService _lService;

        public ListingController(IListingService lService)
        {
            _lService = lService;
        }


        public ActionResult View(long id)
        {
            return View(_lService.GetById(id).Create());
        }

        public ActionResult Map()
        {
            return View(new MapVM());
        }

        [HttpPost]
        public ActionResult Map(HomeVM model)
        {
            return View(new MapVM { Postcode=model.Location, Distance=model.Distance});
        }

        public ActionResult All()
        {
            return View(new MapVM());
        }

        public ActionResult Search()
        {
            return View(new MapVM());
        }

        public ActionResult AddListing()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddListing(ListingVM model)
        {
            var listing = new ATH.Models.Listing { CreatedBy = "MinnesR", CreatedDate = DateTime.Now, Postcode = model.Postcode, LatLong = model.LongLat, LongDescription = model.LongDescription, Price = model.Price, ShortDescription = model.ShortDescription, Title = model.Title, UpdatedBy = "Minnesr", UpdatedDate = DateTime.Now };
            _lService.Create(listing);
            _lService.AddImages(listing, model.Files);

            return View();
        }
    }
}