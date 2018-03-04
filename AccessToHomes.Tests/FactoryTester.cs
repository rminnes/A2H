using AccessToHomes.Code.Factory;
using ATH.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToHomes.Tests
{
    [TestClass]
    public class FactoryTester
    {
        public void ModelFactory_DisplayListingVMCreate_Creates()
        {
            var listing = new Listing { Id=1, Address="add1", AvaiableDate=DateTime.Now, Bedrooms=2, Furnished=true, Postcode="g1 3na", LatLong="123,1234", Price=800, LongDescription="longsdesc", ShortDescription="short desc", Title="title 1"};

            var result = ModelFactory.Create(listing);

            Assert.AreEqual(listing.Address, result.Address);
            Assert.AreEqual(listing.Bedrooms, result.Bedrooms);
            Assert.AreEqual(listing.Furnished, result.Furnished);
            Assert.AreEqual(listing.Id, result.Id);
            Assert.AreEqual(listing.LongDescription, result.LongDescription);
            Assert.AreEqual(listing.LatLong, result.LongLat);
            Assert.AreEqual(listing.Postcode, result.Postcode);
            Assert.AreEqual(listing.Price, result.Price);
            Assert.AreEqual(listing.ShortDescription, result.ShortDescription);
            Assert.AreEqual(listing.Title, result.Title);
        }


    }
}
