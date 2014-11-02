using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public interface ICustomerService
    {
        IList<Customer> GetAllActiveCustomers();
        IList<Customer> GetAllArchivedCustomers();
        Dictionary<string, string> CreateCustomer(Customer customer);
        Dictionary<string, string> UpdateCustomer(Customer customer);
        Customer GetCustomerByID(int customerID);
        void DeleteCustomer(int customerID);
    }
}