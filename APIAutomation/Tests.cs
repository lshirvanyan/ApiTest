using APIAutomation;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Tests
{
    [TestFixture]
    public class UserEndpoint
    {
        [Test]
        public void TestGetUserReturnsRightJson()
        {
            var jsonApiClient = new JsonApiClient();
            var res = jsonApiClient.ExecuteGet<User>("/public-api/users/88", Method.GET);
            Assert.AreEqual(200, res.code);
            Assert.IsNotNull(res.data);
            Assert.AreEqual("prajapat_lila@sanford.com", res.data.email);
            Assert.AreEqual("Dawid",res.data.name);
            Assert.AreEqual(88, res.data.id);
            Assert.AreEqual("Female",res.data.gender);
        }
        [Test]
        public void TestGetUserReturnsRightXml()
        {
            var xmlApiClient = new XmlApiClient();
            var res = xmlApiClient.ExecuteGet<User>("/public-api/users/88", Method.GET);
            Assert.AreEqual(200, res.code);
        }
        [Test]
        public void TestUserCreatedWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            var statusCode = jsonApiClient.ExecutePost("/public-api/users", Method.POST, Utilities.GetUserFromDB(1));
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            var res = jsonApiClient.ExecuteGet<User>("/public-api/users/1", Method.GET);
            Assert.AreEqual(200, res.code);
            Assert.IsNotNull(res.data);
            Assert.AreEqual("Mary@mail.com", res.data.email);
            Assert.AreEqual("Mary", res.data.name);
            Assert.AreEqual(1, res.data.id);
            Assert.AreEqual("Male", res.data.gender);
        }
        [Test]
        public void TestUserCreatedWithXml()
        {
            var xmlApiClient = new XmlApiClient();
            var statusCode = xmlApiClient.ExecutePost("/public-api/users", Method.POST, Utilities.GetUserFromDB(2));
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        [Test]
        public void TestUserUpdatedWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            var statusCode = jsonApiClient.ExecutePost("/public-api/users/7", Method.PUT, Utilities.GetUserFromDB(7));
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            var res = jsonApiClient.ExecuteGet<User>("/public-api/users/7", Method.GET);
            Assert.AreEqual(200, res.code);
            Assert.IsNotNull(res.data);
            Assert.AreEqual("John@mail.com", res.data.email);
            Assert.AreEqual("John", res.data.name);
        }
        [Test]
        public void TestUserUpdatedWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            var statusCode = xmlApiClient.ExecutePost("/public-api/users/7", Method.PUT, Utilities.GetUserFromDB(7));
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        [Test]
        public void TestUserDeletedWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            var statusCode = jsonApiClient.ExecuteDelete("/public-api/users/54", Method.DELETE);
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            var res = jsonApiClient.ExecuteGet<User>("/public-api/users/54", Method.GET);
            Assert.AreEqual(404, res.code);
        }
        [Test]
        public void TestUserDeletedWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            var statusCode = xmlApiClient.ExecuteDelete("/public-api/users/9", Method.DELETE);
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            var res = xmlApiClient.ExecuteGet<User>("/public-api/users/9", Method.GET);
            Assert.AreEqual(404, res.code);
        }
        [Test]
        public void TestUserPatchedWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            var statusCode = jsonApiClient.ExecutePost("/public-api/users/20", Method.PATCH, new { Id = 20, Name = "Mary" });
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            var res = jsonApiClient.ExecuteGet<User>("/public-api/users/20", Method.GET);
            Assert.IsNotNull(res.data);
            Assert.AreEqual("Mary", res.data.name);
        }
        [Test]
        public void TestUserPatchesWithXml()
        {
            var xmlApiClient = new XmlApiClient();
            var statusCode = xmlApiClient.ExecutePost("/public-api/users/21", Method.PATCH, new { Id = 21, Name = "Anna" });
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        [Test]
        public void TestUserHeadWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            var statusCode = jsonApiClient.ExecuteHead("/public-api/users/21", Method.HEAD);
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        [Test]
        public void HeadUserRequestWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            var statusCode = xmlApiClient.ExecuteHead("/public-api/users/21", Method.HEAD);
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
    }
    [TestFixture]
    public class TodoEndpoint
    {
        [Test]
        public void TestGetTodoListReturnsRightJson()
        {
            var jsonApiClient = new JsonApiClient();
            var res = jsonApiClient.ExecuteGet<Todo>("/public-api/todos/9", Method.GET);
            Assert.AreEqual(200, res.code);
            Assert.IsNotNull(res.data);
            Assert.AreEqual(9, res.data.id);
            Assert.AreEqual("Cavus talis vilicus defaeco thema conicio sto.", res.data.title);
        }
        [Test]
        public void TestGetTodoListReturnsRightXML()
        {
            var xmlApiClient = new XmlApiClient();
            var res = xmlApiClient.ExecuteGet<Todo>("/public-api/todos/9", Method.GET);
            Assert.AreEqual(200, res.code);
        }
        [Test]
        public void TestTodoListCreatedWithJson()
        {
            var jsonApiClient = new JsonApiClient();
            var statusCode = jsonApiClient.ExecutePost("/public-api/todos", Method.POST, Utilities.GetTodoListFromDB(1));
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            var res = jsonApiClient.ExecuteGet<Todo>("/public-api/todos/1", Method.GET);
            Assert.AreEqual(200, res.code);
            Assert.IsNotNull(res.data);
            Assert.AreEqual(1, res.data.id);
            Assert.AreEqual("Test1", res.data.title);
        }
        [Test]
        public void TestTodoListCreatedWithXML()
        {
            var xmlApiClient = new XmlApiClient();
            var statusCode = xmlApiClient.ExecutePost("/public-api/todos", Method.POST, Utilities.GetTodoListFromDB(1));
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
    }
}
