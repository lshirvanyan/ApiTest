using APIAutomation;
using NUnit.Framework;
using RestSharp;

namespace Tests
{
    [TestFixture]
    public class UserEndpoint
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
    [TestFixture]
    public class TodoEndpoint
    {
        [Test]
        public void GetTodoListAsJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/todos", Method.GET);
        }
        [Test]
        public void GetTodoListAsXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/todos", Method.GET);
        }
        [Test]
        public void PostTodoListWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/todos", Method.POST, Utilities.GetTodoListFromDB(1));
        }
        [Test]
        public void PostTodoListWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/todos", Method.POST, Utilities.GetTodoListFromDB(1));
        }
        [Test]
        public void DeleteTodoWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/todos/1", Method.DELETE);
        }
        [Test]
        public void DeleteTodoWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/todos/1", Method.DELETE);
        }
        [Test]
        public void HeadRequestForTodoWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/todos", Method.HEAD);
        }
        [Test]
        public void HeadRequestForTodoWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/todos", Method.HEAD);
        }
        [Test]
        public void UpdateTodoListWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/todos/5", Method.PUT, Utilities.GetTodoListFromDB(5));
        }
        [Test]
        public void UpdateTodoListWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/todos/5", Method.PUT, Utilities.GetTodoListFromDB(5));
        }
        [Test]
        public void PatchRequestForTodoWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            jsonApiClient.ExecuteRequest("/public-api/todos/5", Method.PATCH, new { Id = 21, Title = "TestNew"});
        }
        [Test]
        public void PatchRequestForTodoWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            xmlApiClient.ExecuteRequest("/public-api/todos/5", Method.PATCH, new { Id = 21, Title = "TestNew" });
        }

    }
}
