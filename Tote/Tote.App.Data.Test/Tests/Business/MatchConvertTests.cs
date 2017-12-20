using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Data.Business;
using Common.Models;

namespace Tote.App.Data.Test.Tests.Business
{
    [TestClass]
    class MatchConvertTests
    {
        private Mock<IMatchConvert> matchConvert;
        

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
                Tournament = new Tournament() { Name = "Seria A" },
                SportId = 1,
                Date = DateTime.Now.AddHours(1)
            });
            teams.RemoveAt(0);
            teams.RemoveAt(0);

            teams.Add(new Team() { Name = "Napoli", Country = new Country() { Name = "Italy" } });
            teams.Add(new Team() { Name = "Juventus", Country = new Country() { Name = "Italy" } });
            matches.Add(new Common.Models.Match()
            {
                MatchId = 2,
                Teams = teams,
                Result = new Result() { ResultId = 1 },
                Score = "2:1",
                Tournament = new Tournament() { Name = "Seria A" },
                SportId = 1,
                Date = DateTime.Now.AddHours(-10)
            });

            teams.RemoveAt(0);
            teams.RemoveAt(0);

            teams.Add(new Team() { Name = "Napoli", Country = new Country() { Name = "Italy" } });
            teams.Add(new Team() { Name = "AC Milan", Country = new Country() { Name = "Italy" } });
            matches.Add(new Common.Models.Match()
            {
                MatchId = 3,
                Teams = teams,
                Result = new Result() { ResultId = 1 },
                Score = "3:0",
                Tournament = new Tournament() { Name = "Seria A" },
                SportId = 1,
                Date = DateTime.Now
            });

            teams.RemoveAt(0);
            teams.RemoveAt(0);

            teams.Add(new Team() { Name = "Dinamo Minsk", Country = new Country() { Name = "Belarus" } });
            teams.Add(new Team() { Name = "Dinamo Riga", Country = new Country() { Name = "Latvia" } });
            matches.Add(new Common.Models.Match()
            {
                MatchId = 4,
                Teams = teams,
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

        /*[TestInitialize]
        public void TestInitialize()
        {
            matchConvert = new Mock<IMatchConvert>();
            
            matchService.Setup(m => m.GetMatchBySportDateStatus(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int sport, string dateMatch, int status) => {
                    IEnumerable<Common.Models.Match> matches = GetMatches();
                    if (sport == 0 && dateMatch == "" && status == 0)
                    {
                        return GetMatches().ToArray();

                    }
                    if (sport > 0)
                    {
                        matches = matches.Where(m => m.SportId == sport);
                        return matches.ToArray();
                    }
                    if (status == 3)
                    {
                        matches = matches.Where(m => m.Date > DateTime.Now);
                        return matches.ToArray();
                    }
                    if (dateMatch != "")
                    {
                        DateTime date = DateTime.Parse(dateMatch).Date;
                        matches = matches.Where(m => m.Date.Date == date);
                        return matches.ToArray();
                    }

                    throw new ArgumentException();
                });
            matchProvider = new MatchProvider(matchClient.Object, matchService.Object, betListProvider.Object);
        }*/

    }
}
