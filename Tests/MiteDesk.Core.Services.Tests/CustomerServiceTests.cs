using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {

        #region Setup

        private CustomerService CustomerService;
        private MockRepository MockRepository;
        private ICustomerRepository CustomerRepository;

        [TestInitialize]
        public void Setup()
        {

            MockRepository = new MockRepository();
            CustomerRepository = MockRepository.DynamicMock<ICustomerRepository>();
            CustomerService = new CustomerService(CustomerRepository);

            using (MockRepository.Record())
            {
                Expect.Call(CustomerRepository.GetAllActiveCustomers()).Return(new List<Customer>(new[] { new Customer(), new Customer { ID = 2 }, new Customer() })).Repeat.Any();
                Expect.Call(CustomerRepository.GetAllArchivedCustomers()).Return(new List<Customer>(new[] { new Customer() })).Repeat.Any();
                Expect.Call(CustomerRepository.GetCustomerByID(1234)).Return(new Customer { ID = 1234 }).Repeat.Any();
            }

        }

        #endregion

        [TestMethod]
        public void GetAllActiveCustomers_liefert_alle_aktiven_Kunden_aus_dem_CustomerRepository()
        {
            var result = CustomerService.GetAllActiveCustomers();
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(2, result[1].ID);
        }

        [TestMethod]
        public void GetAllArchivedCustomers_liefert_alle_archivierten_Kunden_aus_dem_CustomerRepository()
        {
            var result = CustomerService.GetAllArchivedCustomers();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void DeleteCustomer_ruft_das_Repository_zum_Löschen_des_gewählten_Kunden_auf()
        {
            CustomerService.DeleteCustomer(123456);
            CustomerRepository.AssertWasCalled(r => r.DeleteCustomer(123456));
        }

        [TestMethod]
        public void GetCustomerByID_liefert_einen_bestimmten_Kunden_aus_dem_Repository_anhand_seiner_ID()
        {
            var result = CustomerService.GetCustomerByID(1234);
            Assert.IsNotNull(result);
            Assert.AreEqual(1234, result.ID);
        }

        [TestMethod]
        public void CreateCustomer_liefert_einen_Fehler_wenn_der_name_des_Kunden_nicht_angegeben_wurde()
        {
            var customer = new Customer { Name = "" };
            var result = CustomerService.CreateCustomer(customer);
            Assert.IsTrue(result.ContainsKey("Name"));
        }

        [TestMethod]
        public void CreateCustomer_liefert_keinen_Fehler_wenn_alles_okay()
        {
            var customer = new Customer { Name = "Testkunde" };
            var result = CustomerService.CreateCustomer(customer);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CreateCustomer_speichert_den_Kunden_im_Repository_wenn_alles_okay()
        {
            var customer = new Customer { Name = "Testkunde" };
            CustomerService.CreateCustomer(customer);
            CustomerRepository.AssertWasCalled(r => r.CreateCustomer(customer));
        }

        [TestMethod]
        public void UpdateCustomer_liefert_einen_Fehler_wenn_der_Name_des_Kunden_nicht_angegeben_wurde()
        {
            var customer = new Customer { ID = 3, Name = "" };
            var result = CustomerService.UpdateCustomer(customer);
            Assert.IsTrue(result.ContainsKey("Name"));
        }

        [TestMethod]
        public void UpdateCustomer_wirft_eine_ArgumentException_wenn_die_ID_des_Kunden_nicht_angegeben_wurde()
        {
            Exception exception = null;
            var customer = new Customer { ID = 0 };
            try
            {
                CustomerService.UpdateCustomer(customer);
            }
            catch(Exception e)
            {
                exception = e;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
        }

        [TestMethod]
        public void UpdateCustomer_liefert_keinen_Fehler_wenn_alles_okay()
        {
            var customer = new Customer { ID = 3, Name = "Testkunde" };
            var result = CustomerService.UpdateCustomer(customer);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void UpdateCustomer_speichert_den_Kunden_im_Repository_wenn_alles_okay()
        {
            var customer = new Customer { ID = 3, Name = "Testkunde" };
            CustomerService.UpdateCustomer(customer);
            CustomerRepository.AssertWasCalled(r => r.UpdateCustomer(customer));
        }

    }
}
