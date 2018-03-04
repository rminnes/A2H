using AccessToHomes.Tests.Setup;
using ATH.Models;
using ATH.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToHomes.Tests.Services.Agent
{   [TestClass]
    public class ListingServiceTests
    {
        FakeDbSet<Listing> testListings;

        public ListingServiceTests()
        {
            Setup();
        }
        public void Setup()
        {
            testListings = new FakeDbSet<Listing>();
            testListings.Add(new Listing { Id = 1 });
            testListings.Add(new Listing { Id = 2 });
            testListings.Add(new Listing { Id = 3 });
            testListings.Add(new Listing { Id = 4 });
            testListings.Add(new Listing { Id = 5 });
            testListings.Add(new Listing { Id = 6 });
            testListings.Add(new Listing { Id = 7 });
            testListings.Add(new Listing { Id = 8 });

            //var listings = new List<Listing>() {
            //    new Listing() {  Id = 1},
            //    new Listing() { Id=2 }
            //    };
            //var queryable = listings.AsQueryable();
        }

        [TestMethod]
        public void ListingService_GetTest_ReturnsObject()
        {
            var contextMock = new Mock<ATHContext>();
            contextMock.Setup(db => db.Listings).Returns(testListings);
            //arrange
            var lService = new ListingService(contextMock.Object);
            //act 
            var results = lService.GetListings();
            
            //assert
            Assert.AreEqual(testListings.Count(), results.Count());
        }

        [TestMethod]
        public void ListingService_GetListingsSpecificCount_ReturnsCorrectAmount()
        {
            var contextMock = new Mock<ATHContext>();
            contextMock.Setup(db => db.Listings).Returns(testListings);
            //arrange
            var lService = new ListingService(contextMock.Object);
            //act 
            var listings = lService.GetListings(0, 2);

            Assert.AreEqual(2, listings.Count());

        }

    }
}
