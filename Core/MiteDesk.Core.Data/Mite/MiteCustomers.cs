using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public class MiteCustomers : ICustomerRepository
    {

        public MiteCustomers(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        private readonly IConfigurationService ConfigurationService;

        private Connector Connector
        {
            get { return new Connector(ConfigurationService.GetAppSettings());}
        }

        public IList<Customer> GetAllActiveCustomers()
        {
            var customersSource = Connector.HttpGet("customers.xml");
            IEnumerable<XElement> customers = from c in customersSource.Elements("customer")
                                              select c;

            var result = new List<Customer>();
            foreach (XElement c in customers)
            {
                result.Add(CreateCustomer(c));
            }
            return result;
        }

        public IList<Customer> GetAllArchivedCustomers()
        {
            var customersSource = Connector.HttpGet("customers/archived.xml");
            IEnumerable<XElement> customers = from c in customersSource.Elements("customer")
                                              select c;

            var result = new List<Customer>();
            foreach (XElement c in customers)
            {
                result.Add(CreateCustomer(c));
            }
            return result;
        }

        public Customer GetCustomerByID(int customerID)
        {
            return CreateCustomer(Connector.HttpGet(string.Format("customers/{0}.xml", customerID)));
        }

        public void DeleteCustomer(int customerID)
        {
            Connector.HttpDelete("customers/" + customerID + ".xml");
        }

        public void CreateCustomer(Customer customer)
        {
            var xml = new StringBuilder();
            xml.Append("<customer>");
            xml.AppendFormat("<name>{0}</name>", System.Web.HttpUtility.HtmlEncode(customer.Name));
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(customer.Note));
            xml.AppendFormat("<archived>{0}</archived>", customer.Archived ? "true" : "false");
            xml.Append("</customer>");
            Connector.HttpPost("customers.xml", xml.ToString());
        }

        public void UpdateCustomer(Customer customer)
        {
            var xml = new StringBuilder();
            xml.Append("<customer>");
            xml.AppendFormat("<name>{0}</name>", System.Web.HttpUtility.HtmlEncode(customer.Name));
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(customer.Note));
            xml.AppendFormat("<archived>{0}</archived>", customer.Archived ? "true" : "false");
            xml.Append("</customer>");
            Connector.HttpPut("customers/" + customer.ID + ".xml", xml.ToString());
        }

        private Customer CreateCustomer(XElement source)
        {
            return new Customer
                       {
                           ID = source.Element(XName.Get("id")) != null ? int.Parse(source.Element(XName.Get("id")).Value) : 0,
                           Name = source.Element(XName.Get("name")) != null ? source.Element(XName.Get("name")).Value : string.Empty,
                           Note = source.Element(XName.Get("note")) != null ? source.Element(XName.Get("note")).Value : string.Empty,
                           Archived = source.Element(XName.Get("archived")) != null ? bool.Parse(source.Element(XName.Get("archived")).Value) : false
                       };
        }
    }
}