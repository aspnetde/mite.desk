using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAllActiveCustomers();
        IList<Customer> GetAllArchivedCustomers();
        Customer GetCustomerByID(int customerID);
        void DeleteCustomer(int customerID);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}