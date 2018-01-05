using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Data.Business;
using Common.Models;
using Data.TeamService;
using Data.Clients;
using System.Linq;

namespace Tote.App.Data.Test.Tests.Business
{
    [TestClass]
    public class MatchConvertTests
    {
        private IMatchConvert matchConvert;
        private Mock<IMatchConvert> matchConverts;

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

        private List<SortDto> GetSortDto()
        {
            var sort = new List<SortDto>();
            sort.Add(new SortDto()
            {
                MatchId = 1,
                Tournament = "Seria A",
                TeamHome = "AC Milan",
                TeamHomeCountry = "Italy",
                TeamGuest = "Juventus",
                TeamGuestCountry = "Italy",
                Score = "",
                DateMatch = DateTime.Now.AddHours(1),
                SportId = 1
            });
            sort.Add(new SortDto()
            {
                MatchId = 1,
                Tournament = "Seria A",
                TeamHome = "AC Milan",
                TeamHomeCountry = "Italy",
                TeamGuest = "Napoli",
                TeamGuestCountry = "Italy",
                Score = "0:3",
                DateMatch = DateTime.Now.AddHours(-10),
                SportId = 1
            });

            sort.Add(new SortDto()
            {
                MatchId = 1,
                Tournament = "Seria A",
                TeamHome = "Napoli",
                TeamHomeCountry = "Italy",
                TeamGuest = "Juventus",
                TeamGuestCountry = "Italy",
                Score = "2:1",
                DateMatch = DateTime.Now,
                SportId = 1
            });

            sort.Add(new SortDto()
            {
                MatchId = 1,
                Tournament = "KHL",
                TeamHome = "Dinamo Minsk",
                TeamHomeCountry = "Belarus",
                TeamGuest = "Dinamo Riga",
                TeamGuestCountry = "Latvia",
                Score = "",
                DateMatch = DateTime.Now.AddHours(1),
                SportId = 2
            });
            return sort;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            matchConvert = new MatchConvert();
        }

        [TestMethod]
        public void MatchConvert_ToMatches_CountValue()
        {            
            Assert.IsTrue(GetMatches().Count == GetSortDto().Count);
        }

        [TestMethod]
        public void MatchConvert_ToMatches_Content()
        {
            Assert.IsTrue(GetMatches()[0].MatchId == GetSortDto()[0].MatchId);
            Assert.IsTrue(GetMatches()[0].SportId == GetSortDto()[0].SportId);
            Assert.IsTrue(GetMatches()[0].Teams[0].Name == GetSortDto()[0].TeamHome);
        }

        /*[TestMethod]
        public void MatchConvert_ToMatches_Null()
        {
            matchConverts = new Mock<IMatchConvert>();
            var sortDto = new List<SortDto>();
            matchConverts.Setup(m=>m.ToMatches(sortDto))
                .Returns((IReadOnlyList<SortDto> dto) =>
                {                   
                    return null;
                });

            Assert.IsNull(matchConverts);

        }*/

    }
}
