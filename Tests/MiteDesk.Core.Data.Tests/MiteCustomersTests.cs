using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data.Tests
{
    [TestClass]
    public class MiteCustomersTests
    {

        private MiteCustomers Repository;

        [TestInitialize]
        public void Setup()
        {
            var mockRepository = new MockRepository();
            var configurationService = mockRepository.DynamicMock<IConfigurationService>();
            using (mockRepository.Record())
            {
                Expect.Call(configurationService.GetAppSettings()).Return(new AppSettings { AccountName = "win", Email = "bandt@69grad.de", Password = "winmite" }).Repeat.Any();
            } 
            Repository = new MiteCustomers(configurationService);
        }

        [TestMethod]
        public void GetAllActiveCustomers_liefert_eine_Liste_aller_aktiven_Kunden_zurück()
       { 
            var result = Repository.GetAllActiveCustomers();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GetAllArchivedCustomers_liefert_eine_Liste_aller_archivierten_Kunden_zurück()
        {
            // 1 Kunde, 17.08.2009
            var result = Repository.GetAllArchivedCustomers();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetCustomerByID_liefert_einen_bestimmten_Kunden_anhand_seiner_ID_zurück()
        {
            // 54054, Microsoft, 17.08.2009
            var result = Repository.GetCustomerByID(54054);
            Assert.IsNotNull(result);
            Assert.AreEqual("Microsoft", result.Name);
        }

        [TestMethod]
        public void UpdateCustomer_aktualisiert_einen_Kunden_in_der_Mite_Datenbank()
        {

            // 54054, Microsoft, 17.08.2009
            var id = 54054;
            var note = Guid.NewGuid().ToString();
            
            var customer = Repository.GetCustomerByID(id);

            Assert.AreNotEqual(note, customer.Note);

            customer.Note = note;
            Repository.UpdateCustomer(customer);

            customer = Repository.GetCustomerByID(id);
            Assert.AreEqual(note, customer.Note);

        }

        [TestMethod]
        public void DeleteCustomer_löscht_einen_Benutzer_anhand_seiner_ID_aus_der_mite_Datenbank()
        {

            var customer = new Customer();
            customer.Note = Guid.NewGuid().ToString();
            customer.Name = Guid.NewGuid().ToString();

            Repository.CreateCustomer(customer);

            var result = Repository.GetAllActiveCustomers().SingleOrDefault(c => c.Name == customer.Name);

            Assert.IsNotNull(result);
            Repository.DeleteCustomer(result.ID);

            Exception exception = null;
            try
            {
                Repository.GetCustomerByID(result.ID);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(MiteConnectorException));
            Assert.IsTrue(exception.Message.IndexOf("404") > -1);

        }

        [TestMethod]
        public void CreateCustomer_legt_einen_neuen_Kunden_in_der_Mite_Datenbank_an()
        {

            var customer = new Customer();
            customer.Note = Guid.NewGuid().ToString();
            customer.Name = Guid.NewGuid().ToString();

            Repository.CreateCustomer(customer);

            var result = Repository.GetAllActiveCustomers().SingleOrDefault(c => c.Name == customer.Name);

            Assert.IsNotNull(result);
            Assert.AreEqual(customer.Note, result.Note);

            Repository.DeleteCustomer(result.ID);

        }

    }
}
