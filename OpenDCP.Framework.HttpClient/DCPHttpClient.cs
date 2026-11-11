using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenDCP.Framework.HttpClient.Extensions;


namespace OpenDCP.Framework.HttpClient
{
    public class DCPHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;
        private readonly IConfiguration _configuration;
        public string OriginHeader { get; set; }
        /// <summary>
        /// Initiating HttpClient using the default credentials.
        /// This can be used with Kerberos authentication for PI Web API.
        /// </summary>
        public DCPHttpClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = GlobalHttpClient.GlobalHttpClientObj;
        }

        public async Task<HttpResponseMessage> GetAsync(string uri, Action<HttpRequestHeaders> configureHeaders = null)
        {
            var response = await _client.GetAsyncExtended(
                uri,
                AddMicroserviceHeaders(configureHeaders)
             ).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri, Action<HttpRequestHeaders> configureHeaders = null)
        {
            var response = await _client.DeleteAsyncExtended(
                uri,
                AddMicroserviceHeaders(configureHeaders)
             ).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, string data, Action<HttpRequestHeaders> configureHeaders = null)
        {
            var response = await _client.PostAsyncExtended(
                url: uri,
                content: new StringContent(data.ToString(), Encoding.UTF8, "application/json"),
                AddMicroserviceHeaders(configureHeaders)
             ).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, HttpContent data, Action<HttpRequestHeaders> configureHeaders = null)
        {
            var response = await _client.PostAsyncExtended(
                url: uri,
                content: data,
                AddMicroserviceHeaders(configureHeaders)
             ).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, Action<HttpRequestHeaders> configureHeaders = null)
        {
            var response = await _client.PostAsyncExtended(
                url: uri,
                content: null,
                AddMicroserviceHeaders(configureHeaders)
             ).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string uri, string data, Action<HttpRequestHeaders> configureHeaders = null)
        {
            var response = await _client.PutAsyncExtended(
                url: uri,
                content: new StringContent(data.ToString(), Encoding.UTF8, "application/json"),
                AddMicroserviceHeaders(configureHeaders)
             ).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string uri, HttpContent data, Action<HttpRequestHeaders> configureHeaders = null)
        {
            var response = await _client.PutAsyncExtended(
                url: uri,
                content: data,
                AddMicroserviceHeaders(configureHeaders)
             ).ConfigureAwait(false);

            return response;
        }

        private Action<HttpRequestHeaders> AddMicroserviceHeaders(Action<HttpRequestHeaders> configureHeaders = null)
        {
            var microserviceHeaderName = _configuration["Headers:Microservice:Name"];

            if (microserviceHeaderName != null
                || _configuration["Headers:Microservice:Value"] != null)
            {
                configureHeaders += (h) => h.Add(
                    microserviceHeaderName,
                    _configuration["Headers:Microservice:Value"]
                 );
            }

            return configureHeaders;
        }
    }
}
