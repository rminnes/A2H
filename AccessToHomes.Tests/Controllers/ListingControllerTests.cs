using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ATH.Services;
using ATH.Models;
using AccessToHomes.Controllers;
using System.Web.Mvc;
using AccessToHomes.Models.ViewModels;

namespace AccessToHomes.Tests.Controllers
{
    [TestClass]
    public class ListingControllerTests
    {

        protected List<Listing> TestListings()
        {
            return new List<Listing> { new Listing { Id = 1, Title = "listing one", Images = new List<ListingImage>() },new Listing { Id=2,Title="listing ttwo", Images = new List<ListingImage>() } };
        }

        [TestMethod]
        public void View_FindListing_found()
        {
            Mock<IListingService> _service = new Mock<IListingService>();
            _service.Setup(f => f.GetById(1)).Returns(new Listing { Id = 1, Title = "listing one", Images = new List<ListingImage>(), Price = 900 });

            var lController = new ListingController(_service.Object);

          var viewReturn = lController.View(1) as ViewResult;

            var model = (DisplayListingVM)viewReturn.Model;
            Assert.AreEqual("listing one", model.Title);
            Assert.AreEqual(900, model.Price );
        }

        [TestMethod]
        public void ListingsController_testGetAll_GetsAllListings()
        {
            var contextMock = new Mock<ATHContext>();
            Mock<IListingService> _service = new Mock<IListingService>();

           // var listingsController = new ListingController();

        }

    }
}
