using Common.Logger;
using Common.Models;
using Data.Business;
using Data.Clients;
using Data.Services;
using Data.TeamService;
using Data.ToteService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tote.App.Data.Test.Tests.Services
{
    [TestClass]
    public class MatchServiceTests
    {
        private Mock<IMatchClient> matchClient;
        private Mock<IMatchConvert> convert;
        private Mock<ILogService<MatchService>> logService;
        private MatchService matchService;

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

        private IReadOnlyList<SportDto> GetSportsDto()
        {
            var sports = new List<SportDto>
            {
                new SportDto() {SportId=1,Name="Football"},
                new SportDto() {SportId=2,Name="Hockey"},
                new SportDto() {SportId=3,Name="Basketball"}
            };
            return sports;
        }

        private IReadOnlyList<SortDto> GetSortDto()
        {
            var sortDto = new List<SortDto>()
            {
                new SortDto()
                {
                    MatchId =1,
                    DateMatch =DateTime.Now.AddHours(1),
                    Tournament="Seria A",
                    TeamHome="AC Milan",
                    TeamGuest="Juventus",
                    TeamHomeCountry="Italy",
                    TeamGuestCountry="Italy",
                    Score="0:2",
                    SportId=1
                },
                new SortDto()
                {
                    MatchId =2,
                    DateMatch =DateTime.Now.AddHours(-10),
                    Tournament="Seria A",
                    TeamHome="Napoli",
                    TeamGuest="Juventus",
                    TeamHomeCountry="Italy",
                    TeamGuestCountry="Italy",
                    Score="2:1",
                    SportId=1
                },
                new SortDto()
                {
                    MatchId = 3,
                    DateMatch =DateTime.Now,
                    Tournament="Seria A",
                    TeamHome="Napoli",
                    TeamGuest="AC Milan",
                    TeamHomeCountry="Italy",
                    TeamGuestCountry="Italy",
                    Score="3:0",
                    SportId=1
                },
                new SortDto()
                {
                    MatchId =4,
                    DateMatch =DateTime.Now.AddHours(1),
                    Tournament="KHL",
                    TeamHome="Dinamo Minsk",
                    TeamGuest="Dinamo Riga",
                    TeamHomeCountry="Belarus",
                    TeamGuestCountry="Latvia",
                    Score="4:4",
                    SportId=2
                },
            };
            return sortDto;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            matchClient = new Mock<IMatchClient>();
            convert = new Mock<IMatchConvert>();
            logService = new Mock<ILogService<MatchService>>();
            convert.Setup(c => c.ToMatches(It.IsAny<IReadOnlyList<SortDto>>()))
                .Returns((IReadOnlyList<SortDto> dto)=>
                {                    
                    return GetMatches().ToArray();

                });
            matchClient.Setup(m => m.GetMatchBySportDateStatus(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int sport, string dateMatch, int status) => {
                    IEnumerable<SortDto> matches = GetSortDto();
                    if (sport == 0 && dateMatch == "" && status == 0)
                    {
                        return GetSortDto();

                    }
                    if (sport > 0)
                    {
                        matches = matches.Where(m => m.SportId == sport);
                        return matches.ToArray();
                    }
                    if (status == 3)
                    {
                        matches = matches.Where(m => m.DateMatch > DateTime.Now);
                        return matches.ToArray();
                    }
                    if (dateMatch != "")
                    {
                        DateTime date = DateTime.Parse(dateMatch).Date;
                        matches = matches.Where(m => m.DateMatch.Date == date);
                        return matches.ToArray();
                    }

                    throw new ArgumentException();
                });
            matchService = new MatchService(matchClient.Object, convert.Object, logService.Object);
        }


        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassNullDate_CountValue()
        {            
            var actualResult = matchService.GetMatchBySportDateStatus(0, "", 0);
            Assert.IsTrue(actualResult.Count == GetMatches().Count);
        }

        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassNegativeSportId_Exception()
        {            
            var actualResult = matchService.GetMatchBySportDateStatus(-1, "", 0);
            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassNegativeStatus_Exception()
        {            
            var actualResult = matchService.GetMatchBySportDateStatus(0, "", -1);
            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassFootball_CountValue()
        {
            convert.Setup(c => c.ToMatches(It.IsAny<IReadOnlyList<SortDto>>()))
                 .Returns((IReadOnlyList<SortDto> dto) =>
                 {
                     
                     return GetMatches().Where(m => m.SportId == 1).ToArray();

                 });
            matchService = new MatchService(matchClient.Object, convert.Object, logService.Object);
            var actualResult = matchService.GetMatchBySportDateStatus(1, "", 0);
            Assert.IsTrue(actualResult.Count == 3);
        }

        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassStatus_CountValue()
        {
            convert.Setup(c => c.ToMatches(It.IsAny<IReadOnlyList<SortDto>>()))
                 .Returns((IReadOnlyList<SortDto> dto) =>
                 {

                     return GetMatches().Where(m => m.Date > DateTime.Now).ToArray();

                 });
            matchService = new MatchService(matchClient.Object, convert.Object, logService.Object);
            var actualResult = matchService.GetMatchBySportDateStatus(0, "", 3);
            Assert.IsTrue(actualResult.Count == 2);
        }

        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassDateMatch_CountValue()
        {
            var actualResult = matchService.GetMatchBySportDateStatus(0, DateTime.Now.Date.ToString(), 0);
            IEnumerable<Common.Models.Match> matches = GetMatches().Where(m => m.Date.Date == DateTime.Now.Date);
            Assert.IsTrue(actualResult.Count == matches.Count());
        }

        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassSportStatus_CountValue()
        {
            convert.Setup(c => c.ToMatches(It.IsAny<IReadOnlyList<SortDto>>()))
                 .Returns((IReadOnlyList<SortDto> dto) =>
                 {

                     return GetMatches().Where(m => m.SportId == 1 && m.Date > DateTime.Now).ToArray();

                 });
            matchService = new MatchService(matchClient.Object, convert.Object, logService.Object);
            var actualResult = matchService.GetMatchBySportDateStatus(1, "", 3);
            Assert.IsTrue(actualResult.Count == 1);
        }

        [TestMethod]
        public void MatchService_GetMatchBySportDateStatus_PassSportStatus_Content()
        {
            convert.Setup(c => c.ToMatches(It.IsAny<IReadOnlyList<SortDto>>()))
                 .Returns((IReadOnlyList<SortDto> dto) =>
                 {

                     return GetMatches().Where(m => m.SportId == 1 && m.Date > DateTime.Now).ToArray();

                 });
            matchService = new MatchService(matchClient.Object, convert.Object, logService.Object);
            var actualResult = matchService.GetMatchBySportDateStatus(1, "", 3);
            Assert.IsTrue(actualResult[0].MatchId == 1);
            Assert.IsTrue(actualResult[0].SportId == 1);
            Assert.IsTrue(actualResult[0].Teams[0].Name == "AC Milan");
        }



    }
}
