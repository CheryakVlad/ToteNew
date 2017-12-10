using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Tote.Controllers;
using Business.Providers;
using Microsoft.CSharp;

namespace Tote.Web.Sort.Test
{
    [TestClass]
    public class SortControllerTests
    {
        private SortController controller;
        private ViewResult result;
        private readonly IBetListProvider betListProvider;
        private readonly IMatchProvider matchProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            
            controller = new SortController(betListProvider, matchProvider);
            result = controller.Sort() as ViewResult;
        }        

        [TestMethod]
        public void SortViewResultNotNull()
        {
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SortViewEqualIndexCshtml()
        {
            Assert.AreEqual("Sort", result.ViewName);
        }

        [TestMethod]
        public void SortStringInViewbag()
        {
            Assert.AreNotEqual(null, result.ViewBag.Sports);
        }
    }
}
