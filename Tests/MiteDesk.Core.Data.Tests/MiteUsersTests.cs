using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Data.Tests
{
    [TestClass]
    public class MiteUsersTests
    {

        private MiteUsers Repository;

        [TestInitialize]
        public void Setup()
        {
            var mockRepository = new MockRepository();
            var configurationService = mockRepository.DynamicMock<IConfigurationService>();
            using (mockRepository.Record())
            {
                Expect.Call(configurationService.GetAppSettings()).Return(new AppSettings { AccountName = "win", Email = "bandt@69grad.de", Password = "winmite" }).Repeat.Any();
            }
            Repository = new MiteUsers(configurationService);
        }

        [TestMethod]
        public void GetAuthenticatedUser_liefert_den_aktuell_angemeldeten_Benutzer()
        {
            // Benutzer 18352, bandt@69grad.de
            var result = Repository.GetAuthenticatedUser();
            Assert.AreEqual(18352, result.ID);
        }

    }
}
