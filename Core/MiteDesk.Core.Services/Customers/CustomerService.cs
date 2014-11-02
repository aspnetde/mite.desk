using System;
using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public class CustomerService : ICustomerService
    {

        public CustomerService(ICustomerRepository repository)
        {
            Repository = repository;
        }

        private readonly ICustomerRepository Repository;

        public IList<Customer> GetAllActiveCustomers()
        {
            return Repository.GetAllActiveCustomers();
        }

        public IList<Customer> GetAllArchivedCustomers()
        {
            return Repository.GetAllArchivedCustomers();
        }

        public Dictionary<string, string> CreateCustomer(Customer customer)
        {
            var errors = ValidateCustomer(customer);
            if (errors.Count == 0)
                Repository.CreateCustomer(customer);
            return errors;
        }

        public Dictionary<string, string> UpdateCustomer(Customer customer)
        {
            if (customer.ID == 0)
                throw new ArgumentException(Localization.Customers.IDException, "customer");

            var errors = ValidateCustomer(customer);
            if (errors.Count == 0)
                Repository.UpdateCustomer(customer);

            return errors;
        }

        private static Dictionary<string, string> ValidateCustomer(Customer customer)
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(customer.Name) || customer.Name.Trim().Length == 0)
            {
                errors.Add("Name", Localization.Customers.NameEmpty);
            }
            return errors;
        }

        public Customer GetCustomerByID(int customerID)
        {
            return Repository.GetCustomerByID(customerID);
        }

        public void DeleteCustomer(int customerID)
        {
            Repository.DeleteCustomer(customerID);
        }

    }
}
