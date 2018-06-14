using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities.Entities;
using BusinessEntities.Interfaces;
using BusinessLogic.Logic;
using DataLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestRepositories
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var roladexList = new List<Roladex>();
            var mockrepository = new Mock<IRoladexRepository>();
            roladexList.Add(new Roladex() { RoladexId = -1, City = "Toledo", State = "OH" });            
            mockrepository.Setup(m => m.GetItems()).Returns(roladexList);

            //act
            var logic = new RoladexLogic(mockrepository.Object);
            var result = logic.GetItems();

            //assert
            Assert.IsTrue(result.Any(r => r.State == "OH"));
            mockrepository.VerifyAll();
        }
    }
}
