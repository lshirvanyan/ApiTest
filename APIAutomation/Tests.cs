using APIAutomation;
using NUnit.Framework;
using RestSharp;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void GetUserDetailsAsJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/users", Method.GET);
        }
        [Test]
        public void GetUserDetailsAsXml()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/users", Method.GET);
        }
        [Test]
        public void CreateUserWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/users", Method.POST, Utilities.GetUserFromDB(1));
        }
        [Test]
        public void CreateUserWithXml()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/users", Method.POST, Utilities.GetUserFromDB(1));
        }
    }
}