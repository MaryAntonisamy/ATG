using ATG.Data.Models;
using ATG.Repositories;
using ATG.Repositories.Contracts;
using ATG.Services;
using ATG.Web;
using Autofac;
using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATG.Tests
{
    public class GetLotTests
    {
        private TestContext testContextInstance;
        private Lot lotObj = new Lot();
        private FailoverLot lotObj1 = new FailoverLot();
        private Lot lotRes = new Lot();
        private readonly Mock<ILotService> _lotService;


        [Test]
        public async Task MainLotNameTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Setup
                mock.Mock<ILotRepository>().Setup(x => x.GetLotAsync(1)).ReturnsAsync(lotObj);          

                // Arrange - configure the mock
                var sut = mock.Create<LotRepository>();                
                var actual_GetValueOne = sut.GetLotAsync(1).Result.Name;
                
                Assert.AreEqual(actual_GetValueOne, "Main");
              
            }
        }
        
        [Test]
        public async Task FailoverLotNameTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Setup
                object cnt = mock.Mock<IFailoverLotRepository>().Setup(x => x.GetLotAsync(1)).ReturnsAsync(lotObj);

                // Arrange - configure the mock
                var sut = mock.Create<FailoverLotRepository>();
                var actual_GetValueOne = sut.GetLotAsync(1).Result.Name;

                Assert.AreEqual(actual_GetValueOne, "FailLot");

            }
        }

        [Test]
        public void FailoverLotsCountTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Setup
                object cnt = mock.Mock<IFailoverLotRepository>().Setup(x => x.GetLots()).Returns(new List<Lot>());

                // Arrange - configure the mock
                var sut = mock.Create<FailoverLotRepository>();
                var actual_GetValueOne = sut.GetLots().Count;

                Assert.AreEqual(actual_GetValueOne, 2);

            }
        }
        [Test]
        public async Task ArchivedLotDesTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Setup
                object cnt = mock.Mock<IArchiveLotRepository>().Setup(x => x.GetLotAsync(1)).ReturnsAsync(lotObj);

                // Arrange - configure the mock
                var sut = mock.Create<ArchiveLotRepository>();
                var actual_GetValueOne = sut.GetLotAsync(1).Result.Name;

                Assert.AreEqual(actual_GetValueOne, "a1");

            }
        }
    }
}
