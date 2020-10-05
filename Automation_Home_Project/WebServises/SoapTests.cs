using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.WebServises
{
    [TestClass]
    public class SoapTests
    {
        private string url;
        private string soapEnvelope;
        private string method;

        [TestInitialize]
        public void Setup()
        {
            //client = new RestClient("https://reqres.in/");
        }

        [TestMethod]
        public void TestPostSoap()
        {
            method = @"GetInfo​";
            soapEnvelope = File.ReadAllText(@"GetInfo.xml");
            url = @"https://www.dataaccess.com/webservicesserver/NumberConversion.wso";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.ContentLength = soapEnvelope.Length;
            request.Headers.Add("SOAPAction", "http://schemas.xmlsoap.org/soap/envelope/");
            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(soapEnvelope);
            streamWriter.Close();
            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            Assert.IsNotNull(streamReader.ReadToEnd());
        }

    }
}
