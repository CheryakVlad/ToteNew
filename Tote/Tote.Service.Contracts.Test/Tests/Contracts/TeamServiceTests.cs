using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service.Contracts.Contracts;
using Service.Contracts.Dto;
using Common.Models;
using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Common;

namespace Tote.Service.Contracts.Test.Tests.Contracts
{
    [TestClass]
    public class TeamServiceTests
    {
        private Mock<IMatchService> matchService;
        private IMatchService teamService;
        
        private List<SortDto> GetSort()
        {
            var sort = new List<SortDto>();
            sort.Add(new SortDto()
            {
                MatchId = 1,
                Tournament = "Seria A",
                TeamHome= "AC Milan",
                TeamHomeCountry="Italy",
                TeamGuest="Juventus",
                TeamGuestCountry="Italy",
                Score= "",
                DateMatch= DateTime.Now.AddHours(1),
                SportId=1
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
            matchService = new Mock<IMatchService>();            
            matchService.Setup(m => m.GetMatchBySportDateStatus(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int sport, string dateMatch, int status) => {
                    IEnumerable<SortDto> sorts = GetSort();
                    if (sport == 0 && dateMatch == "" && status == 0)
                    {
                        return GetSort().ToArray();

                    }
                    if (sport > 0)
                    {
                        sorts = sorts.Where(m => m.SportId == sport);
                        return sorts.ToArray();
                    }
                    if (status == 3)
                    {
                        sorts = sorts.Where(m => m.DateMatch > DateTime.Now);
                        return sorts.ToArray();
                    }
                    if (dateMatch != "")
                    {
                        DateTime date = DateTime.Parse(dateMatch).Date;
                        sorts = sorts.Where(m => m.DateMatch.Date == date);
                        return sorts.ToArray();
                    }

                    throw new ArgumentException();
                });
            //teamService = new TeamService();
        }

        [TestMethod]

        public void MatchProvider_GetMatchBySportDateStatus_PassNullDate_CountValue()
        {
            var connection = new Connection<SortDto>();
            var actualResult = teamService.GetMatchBySportDateStatus(0, "", 0);
            Assert.IsTrue(actualResult.Length == GetSort().Count);

        }



    }
}
