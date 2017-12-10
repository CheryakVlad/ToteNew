using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Clients;
using Data.Services;
using Service.Contracts.Contracts;
using Business.Providers;
using Moq;

namespace Tote.App.Business.Test
{
    [TestClass]
    public class MatchProviderTests
    {
        private Mock<IMatchClient> matchClient;
        private Mock<Data.Services.IMatchService> matchService;
        private IMatchProvider matchProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            matchClient = new Mock<IMatchClient>();
            matchService = new Mock<Data.Services.IMatchService>();
            matchProvider = new MatchProvider(matchClient.Object, matchService.Object);
        }

        [TestMethod]
        public void MatchProvider_GetMatchBySportDateStatus_PassNull_Exception()
        {
            //matchProvider.GetMatchBySportDateStatus(0,null,0);
        }


    }
}
