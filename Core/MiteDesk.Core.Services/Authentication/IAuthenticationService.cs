using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public interface IAuthenticationService
    {
        User GetAuthenticatedUser();
    }
}
