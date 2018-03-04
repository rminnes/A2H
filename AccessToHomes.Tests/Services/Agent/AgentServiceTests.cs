using AccessToHomes.Tests.Setup;
using ATH.Models;
using ATH.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToHomes.Tests.Services.Agent
{
    [TestClass]
    public class AgentServiceTests
    {
        public AgentServiceTests()
        {
            Setup();
        }
        FakeDbSet<LettingAgent> testListings;
        public void Setup()
        {
            testListings = new FakeDbSet<LettingAgent>();
            testListings.Add(new LettingAgent { Id = 1 });

            //var listings = new List<Listing>() {
            //    new Listing() {  Id = 1},
            //    new Listing() { Id=2 }
            //    };
            //var queryable = listings.AsQueryable();
        }

        [TestMethod]
        public void AgentService_GetTest_ReturnsObject()
        {
            var contextMock = new Mock<ATHContext>();
            contextMock.Setup(db=> db.LettingAgents).Returns(testListings);
            //arrange
            AgentService aService = new AgentService(contextMock.Object);
            //act 
            var results = aService.GetAll();

            //assert
            Assert.AreEqual(1, results.Count());
        }
    }
}
