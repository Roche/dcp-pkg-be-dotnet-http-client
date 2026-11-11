namespace OpenDCP.Framework.HttpClient
{
    public sealed class GlobalHttpClient
    {
        private static readonly System.Net.Http.HttpClient globalHttpClient = new System.Net.Http.HttpClient();
        static GlobalHttpClient() { }
        private GlobalHttpClient() { }


        public static System.Net.Http.HttpClient GlobalHttpClientObj
        {
            get
            {
                return globalHttpClient;
            }
        }
    }
}
