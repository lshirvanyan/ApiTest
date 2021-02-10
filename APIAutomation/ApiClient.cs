using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;

namespace APIAutomation
{
    public abstract class ApiClientBase
    {
        private string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        protected string Token
        {
            get
            {
                return ConfigurationManager.AppSettings["Token"];
            }
        }

        protected abstract void AddRequestBody(object body, RestRequest req);
        protected abstract void AddRequestHeaders(RestRequest req);
        public void ExecuteRequest(string resource, Method requestType, object body)
        {
            try
            {
                var restClient = new RestClient(baseUrl);
                restClient.ClearHandlers();
                var request = new RestRequest(resource, requestType);
                AddRequestHeaders(request);
                AddRequestBody(body, request);
                var response = restClient.Execute(request);
                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    Assert.Fail($"Failed {request.GetType()} Request with {response.StatusCode} code");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
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
}
