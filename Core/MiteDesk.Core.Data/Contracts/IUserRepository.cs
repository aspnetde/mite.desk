using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public interface IUserRepository
    {
        User GetAuthenticatedUser();
    }
}