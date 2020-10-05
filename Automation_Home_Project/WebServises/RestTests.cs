using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.WebServises
{ 
    [TestClass]
    public class RestTests
    {
        private RestClient client;
        private RestRequest request;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/");
        }

        [TestMethod]
        public void TestGet()
        {
            request = new RestRequest("api/users");
            request.Method = Method.GET;
            var response = client.Execute<List<UserGet>>(request);
            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreNotEqual(0, response.Data.Count);
        }

        [TestMethod]
        public void TestPost()
        {
            var newUser = new UserGet
            {
                name = "Test name",
                job = "Test job"
            };
            request = new RestRequest("api/users");
            request.Method = Method.POST;
            request.AddJsonBody(newUser);
            var response = client.Execute<UserGet>(request);
            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(newUser.name, response.Data.name);
        }

        [TestMethod]
        public void TestPut()
        {
            var newUser = new UserGet
            {
                name = "Test name",
                job = "Test job"
            };

            request = new RestRequest("api/users/2");
            request.Method = Method.POST;
            request.AddJsonBody(newUser);
            var response = client.Execute<UserGet>(request);
            request = new RestRequest("api/users/2");
            request.AddUrlSegment("id", response.Data.id);
            request.Method = Method.PUT;
            request.AddJsonBody(new UserGet
            {
                job = "New job"
            });
            var result = client.Execute<UserGet>(request);
            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(result.Data.job, "New job");
        }

        [TestMethod]
        public void TestDelete()
        {
            var newUser = new UserGet
            {
                name = "Test name",
                job = "Test job"
            };
            request = new RestRequest("api/users/2");
            request.Method = Method.POST;
            request.AddJsonBody(newUser);
            var response = client.Execute<UserGet>(request);
            Assert.AreEqual(true, response.IsSuccessful);
            request = new RestRequest("api/users/2");
            request.AddUrlSegment("id", response.Data.id);
            request.Method = Method.DELETE;
            var result = client.Execute<UserGet>(request);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NoContent);
        }
    }
}
