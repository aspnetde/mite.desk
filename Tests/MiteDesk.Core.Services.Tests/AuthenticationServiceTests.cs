using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Data;

namespace SixtyNineDegrees.MiteDesk.Core.Services.Tests
{
    [TestClass]
    public class AuthenticationServiceTests
    {

        #region Setup

        private IAuthenticationService AuthenticationService;
        private MockRepository MockRepository;
        private IUserRepository UserRepository;

        [TestInitialize]
        public void Setup()
        {
            MockRepository = new MockRepository();
            UserRepository = MockRepository.DynamicMock<IUserRepository>();
            using (MockRepository.Record())
            {
            }
            AuthenticationService = new AuthenticationService(UserRepository);
        }

        #endregion

        [TestMethod]
        public void GetAuthenticatedUser_holt_den_aktuellen_Benutzer_aus_dem_Repository()
        {
            AuthenticationService.GetAuthenticatedUser();
            UserRepository.AssertWasCalled(r => r.GetAuthenticatedUser());
        }

    }
}
