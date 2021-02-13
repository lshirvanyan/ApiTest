using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace APIAutomation
{
    public abstract class ApiClientBase
    {
        private string baseUrl;
        public string Token { get; set; }
        public ApiClientBase()
        {
            var config = new ConfigurationBuilder()
                          .AddJsonFile("appsettings.json")
                          .Build();
            baseUrl = config["BaseUrl"];
            Token = config["Token"];
        }

        protected abstract void AddRequestBody(object body, RestRequest req);
        protected abstract void AddRequestHeaders(RestRequest req);
        public ApiResponse<T> ExecuteGet<T>(string resource, Method requestType)
        {
            ApiResponse<T> res = null;
            try
            {
                var restClient = new RestClient(baseUrl);
                restClient.ClearHandlers();
                var request = new RestRequest(resource, requestType);
                AddRequestHeaders(request);
                var response = restClient.Execute(request);
                res = JsonSerializer.Deserialize<ApiResponse<T>>(response.Content);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return res;
        }
        public HttpStatusCode ExecutePost(string resource, Method requestType, object body)
        {
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            try
            {
                var restClient = new RestClient(baseUrl);
                restClient.ClearHandlers();
                var request = new RestRequest(resource, requestType);
                AddRequestHeaders(request);
                AddRequestBody(body, request);
                var response = restClient.Execute(request);
                statusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return statusCode;
        }
        public HttpStatusCode ExecuteDelete(string resource, Method requestType)
        {
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            try
            {
                var restClient = new RestClient(baseUrl);
                restClient.ClearHandlers();
                var request = new RestRequest(resource, requestType);
                AddRequestHeaders(request);
                var response = restClient.Execute(request);
                statusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return statusCode;
        }
        public HttpStatusCode ExecuteHead(string resource, Method requestType)
        {
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            try
            {
                var restClient = new RestClient(baseUrl);
                restClient.ClearHandlers();
                var request = new RestRequest(resource, requestType);
                AddRequestHeaders(request);
                var response = restClient.Execute(request);
                statusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return statusCode;
        }       
    }

    public class XmlApiClient : ApiClientBase
    {
        protected override void AddRequestBody(object body, RestRequest request)
        {
            request.AddXmlBody(body);
        }

        protected override void AddRequestHeaders(RestRequest request)
        {
            request.AddHeader("Accept", "application/xml");
            request.AddHeader("Content-Type", "application/xml");
            request.AddHeader("Authorization", this.Token);
        }
    }
    public class JsonApiClient : ApiClientBase
    {
        protected override void AddRequestBody(object body, RestRequest request)
        {
            request.AddJsonBody(body);
        }

        protected override void AddRequestHeaders(RestRequest request)
        {
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", this.Token);
        }
    }
    public class ApiResponse<T>
    {
        public int code { get; set; }
        public string meta { get; set; }
        public T data { get; set; }
    }
}
