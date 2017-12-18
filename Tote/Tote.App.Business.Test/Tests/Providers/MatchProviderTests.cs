using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Clients;
using Business.Providers;
using Moq;
using System.Collections.Generic;
using Common.Models;
using System;

namespace Tote.App.Business.Test
{
    [TestClass]
    public class MatchProviderTests
    {
        private Mock<IMatchClient> matchClient;
        private Mock<Data.Services.IMatchService> matchService;
        private IMatchProvider matchProvider;
        private Mock<IBetListProvider> betListProvider;

        private List<Common.Models.Match> GetMatches()
        {
            var matches = new List<Common.Models.Match>();
            var teams = new List<Team>();
            teams.Add(new Team() { Name = "AC Milan", Country = new Country() { Name = "Italy" } });
            teams.Add(new Team() { Name = "Juventus", Country = new Country() { Name = "Italy" } });
            matches.Add(new Common.Models.Match()
            {
                MatchId = 1,
                Teams = teams,
                Result = new Result() { ResultId = 1 },
                Score = "0:2",
                Tournament = new Tournament() { Name = "Seria A" }
            });
            teams.RemoveAt(0);
            teams.RemoveAt(1);

            teams.Add(new Team() { Name = "Napoli", Country = new Country() { Name = "Italy" } });
            teams.Add(new Team() { Name = "Juventus", Country = new Country() { Name = "Italy" } });
            matches.Add(new Common.Models.Match()
            {
                MatchId = 2,
                Teams = teams,
                Result = new Result() { ResultId = 1 },
                Score = "2:1",
                Tournament = new Tournament() { Name = "Seria A" }
            });

            teams.RemoveAt(0);
            teams.RemoveAt(1);

            teams.Add(new Team() { Name = "Napoli", Country = new Country() { Name = "Italy" } });
            teams.Add(new Team() { Name = "AC Milan", Country = new Country() { Name = "Italy" } });
            matches.Add(new Common.Models.Match()
            {
                MatchId = 3,
                Teams = teams,
                Result = new Result() { ResultId = 1 },
                Score = "3:0",
                Tournament = new Tournament() { Name = "Seria A" }
            });

            teams.RemoveAt(0);
            teams.RemoveAt(1);

            teams.Add(new Team() { Name = "Dinamo Minsk", Country = new Country() { Name = "Belarus" } });
            teams.Add(new Team() { Name = "Dinamo Riga", Country = new Country() { Name = "Latvia" } });
            matches.Add(new Common.Models.Match()
            {
                MatchId = 4,
                Teams = teams,
                Result = new Result() { ResultId = 3 },
                Score = "4:4",
                Tournament = new Tournament() { Name = "KHL" }
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
            betListProvider = new Mock<IBetListProvider>();
            matchService.Setup(m => m.GetMatchBySportDateStatus(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int sport, string dateMatch, int status)=> {
                    if(sport==0 && dateMatch==""&&status==0)
                    {
                        return GetMatches().ToArray();
                        
                    }

                    throw new ArgumentException();
                });
            matchProvider = new MatchProvider(matchClient.Object, matchService.Object, betListProvider.Object);
        }

        
        [TestMethod]
        
        public void MatchProvider_GetMatchBySportDateStatus_PassNullDate_CountValue()
        {            
            betListProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(0, "", 0);
            Assert.IsTrue(actualResult.Count == GetMatches().Count);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatchProvider_GetMatchBySportDateStatus_PassNegativeSportId_Exception()
        {
            betListProvider.Setup(bet => bet.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(-1, "", 0);
            Assert.IsNotNull(actualResult);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatchProvider_GetMatchBySportDateStatus_PassNegativeStatus_Exception()
        {
            betListProvider.Setup(bet => bet.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(0, "", -1);
            Assert.IsNotNull(actualResult);

        }

        public void MatchProvider_GetMatchBySportDateStatus_PassFootball_CountValue()
        {
            betListProvider.Setup(s => s.GetSports()).Returns(GetSports());
            var actualResult = matchProvider.GetMatchBySportDateStatus(1, "", 0);
            Assert.IsTrue(actualResult.Count == GetMatches().Count);

        }


    }
}
