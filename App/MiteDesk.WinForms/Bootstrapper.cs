using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Services;
using StructureMap;
using StructureMap.Configuration.DSL;
using System.Windows.Forms;

namespace SixtyNineDegrees.MiteDesk.WinForms
{

    public class Bootstrapper : IBootstrapper
    {

        public void BootstrapStructureMap()
        {
            const string applicationID = "22b622bd-9a87-4bc8-b3b3-1d6bcd7084f9";
            ObjectFactory.Initialize(c =>
            {
                c.AddRegistry(new InfraStructureRegistry(applicationID));
                c.AddRegistry(new ServicesRegistry());
                c.AddRegistry(new RepositoriesRegistry());
            });
        }

        public static void Initialize()
        {
            new Bootstrapper().BootstrapStructureMap();
        }

    }

    public class InfraStructureRegistry : Registry
    {
        public InfraStructureRegistry(string applicationID)
        {
            ForRequestedType<IRegistryService>().TheDefaultIsConcreteType<RegistryService>();
            ForRequestedType<IEncryptionService>().TheDefaultIsConcreteType<EncryptionService>();
            ForRequestedType<IConfigurationService>()
                .TheDefault.Is.OfConcreteType<ConfigurationService>()
                .WithCtorArg("applicationID").EqualTo(applicationID)
                .WithCtorArg("executablePath").EqualTo(Application.ExecutablePath);
        }
    }

    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            ForRequestedType<ICustomerService>().TheDefaultIsConcreteType<CustomerService>();
            ForRequestedType<IProjectService>().TheDefaultIsConcreteType<ProjectService>();
            ForRequestedType<IActivityService>().TheDefaultIsConcreteType<ActivityService>();
            ForRequestedType<ITimeEntryService>().TheDefaultIsConcreteType<TimeEntryService>();
            ForRequestedType<IAuthenticationService>().TheDefaultIsConcreteType<AuthenticationService>();
        }
    }

    public class RepositoriesRegistry : Registry
    {
        public RepositoriesRegistry()
        {
            ForRequestedType<IProjectRepository>().TheDefaultIsConcreteType<MiteProjects>();
            ForRequestedType<ICustomerRepository>().TheDefaultIsConcreteType<MiteCustomers>();
            ForRequestedType<IActivityRepository>().TheDefaultIsConcreteType<MiteServices>();
            ForRequestedType<ITimeEntryRepository>().TheDefaultIsConcreteType<MiteTimeEntries>();
            ForRequestedType<IUserRepository>().TheDefaultIsConcreteType<MiteUsers>();
        }
    }

}
