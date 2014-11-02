using System.Xml.Linq;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public class MiteUsers : IUserRepository
    {

        public MiteUsers(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        private readonly IConfigurationService ConfigurationService;

        private Connector Connector
        {
            get { return new Connector(ConfigurationService.GetAppSettings());}
        }
       
        public User GetAuthenticatedUser()
        {
            return CreateUser(Connector.HttpGet("myself.xml"));
        }

        private User CreateUser(XElement source)
        {
            return new User
                       {
                           ID = int.Parse(source.Element(XName.Get("id")).Value),
                           Name = source.Element(XName.Get("name")).Value,
                           Email = source.Element(XName.Get("email")).Value,
                           Role = GetRole(source.Element(XName.Get("role")).Value)
                       };
        }

        private UserRole GetRole(string text)
        {
            switch (text)
            {
                case "coworker":
                    return UserRole.CoWorker;
                case "time_tracker":
                    return UserRole.TimeTracker;
                case "admin":
                    return UserRole.Admin;
                case "owner":
                    return UserRole.Owner;
                default:
                    throw new UserRoleInvalidException();
            }
        }

    }
}