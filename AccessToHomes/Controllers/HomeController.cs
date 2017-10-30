using AccessToHomes.Models.ViewModels;
using ATH.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccessToHomes.Controllers
{
    public class HomeController : Controller
    {

        public IListingService _lService;

        public HomeController(IListingService lService)
        {
            _lService = lService;
        }

        public ActionResult Index()
        {
            return View(new HomeVM());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}