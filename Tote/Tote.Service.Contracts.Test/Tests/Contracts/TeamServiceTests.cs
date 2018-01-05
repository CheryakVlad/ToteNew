using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service.Contracts.Contracts;
using Service.Contracts.Dto;
using Common.Models;
using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Common;
using Service.Contracts.Logger;
using System.Data;
using System.ServiceModel;
using Service.Contracts.Exception;

namespace Tote.Service.Contracts.Test.Tests.Contracts
{
    [TestClass]
    public class TeamServiceTests
    {
        //private Mock<IMatchService> matchService;
        private TeamService teamService;
        private Mock<ILogService<TeamService>> logService;
        private Mock<IConnection<SortDto>> connectionSortDto;

        private List<SortDto> GetSortDto()
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
            logService = new Mock<ILogService<TeamService>>();
            connectionSortDto = new Mock<IConnection<SortDto>>();

            connectionSortDto.Setup(m => m.GetConnection(It.IsAny<CommandType>(), It.IsAny<string>(), It.IsAny<List<Parameter>>()))
                .Returns((CommandType storedProcedure, string spName, List<Parameter> parameter) => {
                    IEnumerable<SortDto> sorts = GetSortDto();
                    
                    return sorts.ToArray();                    
                   
                });
            teamService = new TeamService(logService.Object, connectionSortDto.Object);
        }

        [TestMethod]

        public void TeamService_GetMatchBySportDateStatus_PassNullDate_CountValue()
        {            
            var actualResult = teamService.GetMatchBySportDateStatus(0, "", 0);
            Assert.IsTrue(actualResult.Length == GetSortDto().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<CustomException>))]
        public void TeamService_GetMatchBySportDateStatus_PassNegativeSportId_Exception()
        {
            var actualResult = teamService.GetMatchBySportDateStatus(-1, "", 0);            
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<CustomException>))]
        public void TeamService_GetMatchBySportDateStatus_PassNegativeStatus_Exception()
        {
            var actualResult = teamService.GetMatchBySportDateStatus(0, "", -1);            
        }

        [TestMethod]
        public void TeamService_GetMatchBySportDateStatus_PassFootball_CountValue()
        {
            connectionSortDto.Setup(m => m.GetConnection(It.IsAny<CommandType>(), It.IsAny<string>(), It.IsAny<List<Parameter>>()))
                .Returns((CommandType storedProcedure, string spName, List<Parameter> parameter) => {                  

                    return GetSortDto().Where(m => m.SportId == 1).ToArray();                   

                });

            teamService = new TeamService(logService.Object, connectionSortDto.Object);
            var actualResult = teamService.GetMatchBySportDateStatus(1, "", 0);
            Assert.IsTrue(actualResult.Length == 3);
        }

        [TestMethod]
        public void TeamService_GetMatchBySportDateStatus_PassStatus_CountValue()
        {
            connectionSortDto.Setup(m => m.GetConnection(It.IsAny<CommandType>(), It.IsAny<string>(), It.IsAny<List<Parameter>>()))
                .Returns((CommandType storedProcedure, string spName, List<Parameter> parameter) => {

                    return GetSortDto().Where(m => m.DateMatch > DateTime.Now).ToArray();

                });

            teamService = new TeamService(logService.Object, connectionSortDto.Object);
            var actualResult = teamService.GetMatchBySportDateStatus(0, "", 3);
            Assert.IsTrue(actualResult.Length == 2);
        }

        [TestMethod]
        public void TeamService_GetMatchBySportDateStatus_PassDateMatch_CountValue()
        {
            connectionSortDto.Setup(m => m.GetConnection(It.IsAny<CommandType>(), It.IsAny<string>(), It.IsAny<List<Parameter>>()))
                .Returns((CommandType storedProcedure, string spName, List<Parameter> parameter) => {

                    return GetSortDto().Where(m => m.DateMatch.Date == DateTime.Now.Date).ToArray();

                });

            teamService = new TeamService(logService.Object, connectionSortDto.Object);
            var actualResult = teamService.GetMatchBySportDateStatus(0, DateTime.Now.Date.ToString(), 0);
            var matches = GetSortDto().Where(m => m.DateMatch.Date == DateTime.Now.Date);
            Assert.IsTrue(actualResult.Length == matches.Count());
        }

        [TestMethod]
        public void TeamService_GetMatchBySportDateStatus_PassSportStatus_CountValue()
        {
            connectionSortDto.Setup(m => m.GetConnection(It.IsAny<CommandType>(), It.IsAny<string>(), It.IsAny<List<Parameter>>()))
                .Returns((CommandType storedProcedure, string spName, List<Parameter> parameter) => {

                    return GetSortDto().Where(m => m.SportId == 1 && m.DateMatch > DateTime.Now).ToArray();

                });

            teamService = new TeamService(logService.Object, connectionSortDto.Object);
            var actualResult = teamService.GetMatchBySportDateStatus(1, "", 3);
            Assert.IsTrue(actualResult.Length == 1);
        }

        [TestMethod]
        public void TeamService_GetMatchBySportDateStatus_PassSportStatus_Content()
        {
            connectionSortDto.Setup(m => m.GetConnection(It.IsAny<CommandType>(), It.IsAny<string>(), It.IsAny<List<Parameter>>()))
                .Returns((CommandType storedProcedure, string spName, List<Parameter> parameter) => {

                    return GetSortDto().Where(m => m.SportId == 1 && m.DateMatch > DateTime.Now).ToArray();

                });

            teamService = new TeamService(logService.Object, connectionSortDto.Object);
            var actualResult = teamService.GetMatchBySportDateStatus(1, "", 3);
            Assert.IsTrue(actualResult[0].MatchId == 1);
            Assert.IsTrue(actualResult[0].SportId == 1);
            Assert.IsTrue(actualResult[0].TeamHome == "AC Milan");
        }


    }
}
