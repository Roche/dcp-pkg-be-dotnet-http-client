using System;

namespace OpenDCP.Framework.HttpClient.Extensions
{
    internal static class UriExtensions
    {
        internal static Uri Append(this Uri uri, string relativePath)
        {
            var baseUri = uri.AbsoluteUri.EndsWith("/") ? uri : new Uri(uri.AbsoluteUri + '/');
            var relative = relativePath.StartsWith("/") ? relativePath.Substring(1) : relativePath;
            return new Uri(baseUri, relative);
        }

    }
}
