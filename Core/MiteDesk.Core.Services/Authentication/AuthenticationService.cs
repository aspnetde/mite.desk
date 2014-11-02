using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        public AuthenticationService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        private readonly IUserRepository UserRepository;

        public User GetAuthenticatedUser()
        {
            return UserRepository.GetAuthenticatedUser();
        }
    }
}
