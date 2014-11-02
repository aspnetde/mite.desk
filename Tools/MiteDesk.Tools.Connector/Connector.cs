using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Tools.Connector
{
    public class Connector
    {

        public Connector(AppSettings settings)
        {
            Settings = settings;
        }

        private readonly AppSettings Settings;

        private string MiteAPIBaseURL
        {
            get { return "https://" + Settings.AccountName + ".mite.yo.lk/"; }
        }

        private void Authenticate(ref HttpWebRequest request)
        {

            if (!string.IsNullOrEmpty(Settings.APIKey))
                request.Headers.Add("X-MiteApiKey", Settings.APIKey);
            else
                request.Credentials = new NetworkCredential(Settings.Email, Settings.Password);

            if (Settings.UseProxy && !string.IsNullOrEmpty(Settings.ProxyServer))
            {
                WebProxy proxy = new WebProxy(Settings.ProxyServer, Settings.ProxyPort);
                if (!string.IsNullOrEmpty(Settings.ProxyUser) && !string.IsNullOrEmpty(Settings.ProxyPassword))
                {
                    proxy.UseDefaultCredentials = false;
                    proxy.Credentials = new NetworkCredential(Settings.ProxyUser, Settings.ProxyUser);
                }
                else
                {
                    proxy.UseDefaultCredentials = false;
                    proxy.Credentials = null;
                }
                request.Proxy = proxy;
            }

            // User-Agent
            request.UserAgent = "mite.desk/1.2.14";

        }

        public XElement HttpGet(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MiteAPIBaseURL + url);
                Authenticate(ref request);
                request.Timeout = 15000;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return XElement.Parse(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception exception)
            {
                throw new MiteConnectorException(exception.Message);
            }
        }

        public XElement HttpPost(string url, string xml)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MiteAPIBaseURL + url);
                Authenticate(ref request);
                request.Timeout = 5000;
                request.Method = "POST";
                request.ContentType = "application/xml";

                byte[] data = Encoding.UTF8.GetBytes(xml);

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return XElement.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
                }
            }
            catch (Exception exception)
            {
                throw new MiteConnectorException(exception.Message);
            }
        }

        public void HttpDelete(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MiteAPIBaseURL + url);
                Authenticate(ref request);
                request.Timeout = 5000;
                request.Method = "DELETE";
                request.ContentType = "application/xml";
                using (request.GetResponse()) { }
            }
            catch (Exception exception)
            {
                throw new MiteConnectorException(exception.Message);
            }
        }

        public void HttpPut(string url, string xml)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MiteAPIBaseURL + url);
                Authenticate(ref request);
                request.Timeout = 5000;
                request.Method = "PUT";
                request.ContentType = "application/xml";

                byte[] data = Encoding.UTF8.GetBytes(xml);

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }

                using (request.GetResponse()) { }
            }
            catch (Exception exception)
            {
                throw new MiteConnectorException(exception.Message);
            }
        }

    }
}