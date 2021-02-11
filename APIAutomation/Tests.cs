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
        [Test]
        public void UpdateUserWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/users/7", Method.PUT, Utilities.GetUserFromDB(7));
        }
        [Test]
        public void UpdateUserWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/users/7", Method.PUT, Utilities.GetUserFromDB(7));
        }
        [Test]
        public void DeleteUserWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/users/54", Method.DELETE);
        }
        [Test]
        public void DeleteUserWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/users/9", Method.DELETE);
        }
        [Test]
        public void PatchUserRequestWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/users/20", Method.PATCH, new { Id = 20, Name = "Mary" });
        }
        [Test]
        public void PatchUserRequestWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/users/21", Method.PATCH, new { Id = 21, Name = "Anna" });
        }
        [Test]
        public void HeadUserRequestWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/users/21", Method.HEAD);
        }
        [Test]
        public void HeadUserRequestWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/users/21", Method.HEAD);
        }
    }
}