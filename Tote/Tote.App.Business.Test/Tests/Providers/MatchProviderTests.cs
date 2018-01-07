using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Clients;
using Business.Providers;
using Moq;
using System.Collections.Generic;
using Common.Models;
using System;
using System.Linq;
using Common.Logger;

namespace Tote.App.Business.Test
{
    [TestClass]
    public class MatchProviderTests
    {
        private Mock<IMatchClient> matchClient;
        private Mock<Data.Services.IMatchService> matchService;
        private IMatchProvider matchProvider;
        private Mock<ISportProvider> sportProvider;
        private Mock<ILogService<MatchProvider>> logService;

        private List<Common.Models.Match> GetMatches()
        {
            var matches = new List<Common.Models.Match>();            
            matches.Add(new Common.Models.Match()
            {
                MatchId = 1,
                Teams = new List<Team>() {
                    new Team() { Name = "AC Milan", Country = new Country() { Name = "Italy" } },
                    new Team() { Name = "Juventus", Country = new Country() { Name = "Italy" } }
                },
                Result = new Result() { ResultId = 1 },
                Score = "0:2",
                Tournament = new Tournament() { Name = "Seria A" },
                SportId = 1,
                Date = DateTime.Now.AddHours(1)
            });
            
            matches.Add(new Common.Models.Match()
            {
                MatchId = 2,
                Teams = new List<Team>() {
                    new Team() { Name = "Napoli", Country = new Country() { Name = "Italy" } },
                    new Team() { Name = "Juventus", Country = new Country() { Name = "Italy" } }
                },
                Result = new Result() { ResultId = 1 },
                Score = "2:1",
                Tournament = new Tournament() { Name = "Seria A" },
                SportId = 1,
                Date = DateTime.Now.AddHours(-10)
            });
            
            matches.Add(new Common.Models.Match()
            {
                MatchId = 3,
                Teams = new List<Team>() {
                    new Team() { Name = "Napoli", Country = new Country() { Name = "Italy" } },
                    new Team() { Name = "AC Milan", Country = new Country() { Name = "Italy" } }
                },
                Result = new Result() { ResultId = 1 },
                Score = "3:0",
                Tournament = new Tournament() { Name = "Seria A" },
                SportId = 1,
                Date = DateTime.Now
            });
            
            matches.Add(new Common.Models.Match()
            {
                MatchId = 4,
                Teams = new List<Team>() {
                    new Team() { Name = "Dinamo Minsk", Country = new Country() { Name = "Belarus" } },
                    new Team() { Name = "Dinamo Riga", Country = new Country() { Name = "Latvia" } }
                },
                Result = new Result() { ResultId = 3 },
                Score = "4:4",
                Tournament = new Tournament() { Name = "KHL" },
                SportId = 2,
                Date = DateTime.Now.AddHours(1)
            });
            
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
            matchClient = new Mock<IMatchClient>();
            matchService = new Mock<Data.Services.IMatchService>();
            sportProvider = new Mock<ISportProvider>();
            logService = new Mock<ILogService<MatchProvider>>();
            matchService.Setup(m => m.GetMatchBySportDateStatus(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int sport, string dateMatch, int status)=> {
                    IEnumerable<Common.Models.Match> matches = GetMatches();
                    if(sport==0 && dateMatch==""&&status==0)
                    {
                        return GetMatches().ToArray();
                        
                    }
                    if(sport>0)
                    {
                        matches = matches.Where(m=>m.SportId==sport);                        
                        return matches.ToArray();
                    }
                    if(status==3)
                    {
                        matches = matches.Where(m => m.Date > DateTime.Now);
                        return matches.ToArray();
                    }
                    if(dateMatch!="")
                    {
                        DateTime date = DateTime.Parse(dateMatch).Date;
                        matches = matches.Where(m => m.Date.Date == date);
                        return matches.ToArray();
                    }

                    throw new ArgumentException();
                });
            matchProvider = new MatchProvider(matchClient.Object, matchService.Object, sportProvider.Object, logService.Object);
        }

        
        [TestMethod]
        
        public void MatchProvider_GetMatchBySportDateStatus_PassNullDate_CountValue()
        {
            sportProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(0, "", 0);
            Assert.IsTrue(actualResult.Count == GetMatches().Count);           
        }

        [TestMethod]        
        public void MatchProvider_GetMatchBySportDateStatus_PassNegativeSportId_Exception()
        {
            sportProvider.Setup(bet => bet.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(-1, "", 0);            
            Assert.IsNull(actualResult);            
        }

        [TestMethod]        
        public void MatchProvider_GetMatchBySportDateStatus_PassNegativeStatus_Exception()
        {
            sportProvider.Setup(bet => bet.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(0, "", -1);
            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void MatchProvider_GetMatchBySportDateStatus_PassFootball_CountValue()
        {
            sportProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(1, "", 0);            
            Assert.IsTrue(actualResult.Count == 3);
        }

        [TestMethod]
        public void MatchProvider_GetMatchBySportDateStatus_PassStatus_CountValue()
        {
            sportProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(0, "", 3);
            Assert.IsTrue(actualResult.Count == 2);
        }

        [TestMethod]
        public void MatchProvider_GetMatchBySportDateStatus_PassDateMatch_CountValue()
        {
            sportProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(0, DateTime.Now.Date.ToString(), 0);           
            IEnumerable<Common.Models.Match> matches = GetMatches().Where(m => m.Date.Date == DateTime.Now.Date);
            Assert.IsTrue(actualResult.Count == matches.Count());
        }

        [TestMethod]
        public void MatchProvider_GetMatchBySportDateStatus_PassSportStatus_CountValue()
        {
            sportProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(1, "", 3);            
            Assert.IsTrue(actualResult.Count == 3);
        }
        [TestMethod]
        public void MatchProvider_GetMatchBySportDateStatus_PassSportStatus_Content()
        {
            sportProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(1, "", 3);
            Assert.IsTrue(actualResult[0].MatchId == 1);
            Assert.IsTrue(actualResult[0].SportId == 1);
            Assert.IsTrue(actualResult[0].Teams[0].Name == "AC Milan");
        }

                

    }
}
