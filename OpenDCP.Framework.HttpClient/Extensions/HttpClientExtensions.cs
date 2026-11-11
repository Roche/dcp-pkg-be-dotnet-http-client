using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenDCP.Framework.HttpClient.Extensions
{
    internal static class HttpClientExtensions
    {
        internal static async Task<HttpResponseMessage> PostAsyncExtended(
            this System.Net.Http.HttpClient client,
            string url,
            HttpContent content,
            Action<HttpRequestHeaders> beforeRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            beforeRequest?.Invoke(request.Headers);
            request.Content = content;
            return await client.SendAsync(request);
        }
        internal static async Task<HttpResponseMessage> PutAsyncExtended(
            this System.Net.Http.HttpClient client,
            string url,
            HttpContent content,
            Action<HttpRequestHeaders> beforeRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            beforeRequest?.Invoke(request.Headers);
            request.Content = content;
            return await client.SendAsync(request);
        }
        internal static async Task<HttpResponseMessage> GetAsyncExtended(
           this System.Net.Http.HttpClient client,
           string url,
           Action<HttpRequestHeaders> beforeRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            beforeRequest?.Invoke(request.Headers);

            return await client.SendAsync(request);
        }
        internal static async Task<HttpResponseMessage> DeleteAsyncExtended(
           this System.Net.Http.HttpClient client,
           string url,
           Action<HttpRequestHeaders> beforeRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            beforeRequest?.Invoke(request.Headers);

            return await client.SendAsync(request);
        }

    }
}
