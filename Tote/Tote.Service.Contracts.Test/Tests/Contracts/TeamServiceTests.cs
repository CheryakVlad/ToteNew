using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service.Contracts.Contracts;
using Service.Contracts.Dto;

namespace Tote.Service.Contracts.Test.Tests.Contracts
{
    [TestClass]
    public class TeamServiceTests
    {
        private MatchDto[] products = {
            new MatchDto {MatchId=1, TeamHome="AC Milan", TeamGuest="Juventus", CountryHome="Italy", CountryGuest="Italy",
            ResultId=1, Score="0:2", Tournament="Seria A"},
            new MatchDto {MatchId=2, TeamHome="Napoli", TeamGuest="Juventus", CountryHome="Italy", CountryGuest="Italy",
            ResultId=1, Score="2:1", Tournament="Seria A"},
            new MatchDto {MatchId=3, TeamHome="Napoli", TeamGuest="AC Milan", CountryHome="Italy", CountryGuest="Italy",
            ResultId=1, Score="3:0", Tournament="Seria A"},
            new MatchDto {MatchId=4, TeamHome="Dinamo Minsk", TeamGuest="Dinamo Riga", CountryHome="Belarus", CountryGuest="Latvia",
            ResultId=2, Score="4:4", Tournament="KHL"}
        };


        [TestInitialize]
        public void TestInitialize()
        {
            
        }



    }
}
