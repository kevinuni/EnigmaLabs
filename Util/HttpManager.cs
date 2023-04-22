using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Util
{
    public class HttpManager
    {
        private static HttpManager _instance;

        private static object syncLock = new object();

        /// <summary>
        /// HttpClient should have only one instance over all application
        /// </summary>
        public readonly HttpClient httpClient = new HttpClient();

        protected HttpManager()
        {
        }

        public static HttpManager Instance()
        {
            // thread safe singleton
            lock (syncLock)
            {
                if (_instance == null)
                {
                    _instance = new HttpManager();
                }
            }
            return _instance;
        }

        public string CurrToken { get; set; }

        public void Authenticate(string baseAdress, string login, string password)
        {
            baseAdress = baseAdress.TrimEnd('/') + "/";
            Uri uri = new Uri(baseAdress);

            httpClient.BaseAddress = uri;
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = GetToken(uri.AbsoluteUri, login, password);

            CurrToken = JsonConvert.DeserializeObject<string>(json);

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + CurrToken);
        }

        public string GetToken(string url, string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "username", userName ),
                        new KeyValuePair<string, string> ( "password", password )
                    };
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var response = httpClient.PostAsync(url + "login/authenticate", content).GetAwaiter().GetResult();
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public async Task<T> GenericRequest<W, T>(HttpMethod method, string uri, W objW, Dictionary<string, string> queryParams = null, Dictionary<string, string> headers = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(method, uri);

            if (queryParams != null && queryParams.Count > 0)
            {
                StringBuilder query = new StringBuilder();
                foreach (var item in queryParams)
                {
                    query.Append($"{item.Key}={item.Value}&");
                }

                uri = uri + "?" + query.ToString().TrimEnd('&');
            }

            if (objW != null) 
            {
                string bodyContent = JsonConvert.SerializeObject(objW);
                requestMessage.Content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
            }


            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    requestMessage.Headers.Add(item.Key, item.Value);
                }
            }

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            if (typeof(T) == typeof(byte[]))
            {
                byte[] data = await response.Content.ReadAsByteArrayAsync();
                return (T)(object)data;
            }
            else
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);                
            }
        }

        public async Task<T> Get<T>(string uri, Dictionary<string, string> queryParams = null, Dictionary<string, string> headers = null)
        {
            return await GenericRequest<object, T>(HttpMethod.Get, uri, null, queryParams, headers);
        }

        public async Task<T> Post<W, T>(string uri, W objW, Dictionary<string, string> headers = null) 
        {
            return await GenericRequest<W, T>(HttpMethod.Post, uri, objW, null, headers);
        }

        public async Task<T> Put<T>(string uri, T objW, Dictionary<string, string> headers = null)
        {            
            return await GenericRequest<T, T>(HttpMethod.Put, uri, objW, null, headers);
        }

        public async Task<int> Delete<T>(string uri, Dictionary<string, string> headers = null)
        {
            return await GenericRequest<object, int>(HttpMethod.Delete, uri, null, null, headers);
        }
    }
}