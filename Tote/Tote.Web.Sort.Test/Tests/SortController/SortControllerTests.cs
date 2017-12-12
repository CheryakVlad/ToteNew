using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Tote.Controllers;
using Business.Providers;
using Microsoft.CSharp;
using Moq;
using Common.Models;
using System.Collections.Generic;
using System;


namespace Tote.Web.Sort.Test
{
    [TestClass]
    public class SortControllerTests
    {
        private SortController controller;
        private ViewResult result;
        private Mock<IBetListProvider> betListProvider;
        private Mock<IMatchProvider> matchProvider;

        private List<Common.Models.Match> GetMatches()
        {
            var matches = new List<Common.Models.Match>
            {
                new Common.Models.Match {MatchId=1, Teams= { new Team {Name="AC Milan", Country=new Country { Name= "Italy" } },
                    new Team { Name ="Juventus", Country = new Country { Name = "Italy" } } },Result=new Result {ResultId=1 },
                    Score="0:2", Tournament=new Tournament { Name="Seria A"} },
                new Common.Models.Match {MatchId=2, Teams= { new Team {Name="Napoli", Country=new Country { Name= "Italy" } },
                    new Team { Name ="Juventus", Country = new Country { Name = "Italy" } } },Result=new Result {ResultId=1 },
                    Score="2:1", Tournament=new Tournament { Name="Seria A"} },
                new Common.Models.Match {MatchId=3, Teams= { new Team {Name="Napoli", Country=new Country { Name= "Italy" } },
                    new Team { Name ="AC Milan", Country = new Country { Name = "Italy" } } },Result=new Result {ResultId=1 },
                    Score="3:0", Tournament=new Tournament { Name="Seria A"} },
                new Common.Models.Match {MatchId=4, Teams= { new Team {Name="Dinamo Minsk", Country=new Country { Name= "Belarus" } },
                    new Team { Name ="Dinamo Riga", Country = new Country { Name = "Latvia" } } },Result=new Result {ResultId=1 },
                    Score="4:4", Tournament=new Tournament { Name="KHL"} }
            };
            return matches;
        }
        
        private List<Sport> GetSports()
        {
            var sports = new List<Sport>
            {
                new Common.Models.Sport {SportId=1,Name="Football"},
                new Common.Models.Sport {SportId=2,Name="Hockey"},
                new Common.Models.Sport {SportId=3,Name="Basketball"}
            };
            return sports;
        }
                
    

        

        [TestInitialize]
        public void TestInitialize()
        {
            betListProvider = new Mock<IBetListProvider>();
            matchProvider = new Mock<IMatchProvider>();
            controller = new SortController(betListProvider.Object, matchProvider.Object);
            result = controller.Sort() as ViewResult;
        }        

        [TestMethod]
        public void SortViewResultNotNull()
        {
            // Arrange
            

            betListProvider = new Mock<IBetListProvider>();
            matchProvider = new Mock<IMatchProvider>();
            betListProvider.Setup(bet => bet.GetSports()).Returns(GetSports());
            matchProvider.Setup(match => match.GetMatchBySportDateStatus(0, "", 0)).Returns(GetMatches());
            //mock.Setup(repo => repo.GetAll()).Returns(GetTestPhones());
            var controller = new SortController(betListProvider.Object, matchProvider.Object);

            // Act
            var result = controller.Sort() as ViewResult;
            List<Sport> actual = result.ViewBag.Sports as List<Sport>;

            // Assert

            Assert.AreEqual(GetSports().Count,actual.Count);

            /*controller = new SortController(betListProvider.Object, matchProvider.Object);

            result = controller.Sort() as ViewResult;

            Assert.IsNotNull(result);*/
        }

        [TestMethod]
        public void SortViewEqualIndexCshtml()
        {
            betListProvider
                .Setup(b => b.GetSports())
                .Returns((IReadOnlyList<Sport> sports)=>
                {
                    if(sports==null)
                    {
                        throw new NullReferenceException();
                    }
                    return sports;
                });
                
            Assert.AreEqual("Sort", result.ViewName);
        }

        [TestMethod]
        public void SortStringInViewbag()
        {
            Assert.AreNotEqual(null, result.ViewBag.Sports);
        }
    }
}
