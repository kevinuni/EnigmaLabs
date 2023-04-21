﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<T> Get<T>(string uri, Dictionary<string, string> queryString)
        {
            StringBuilder query = new StringBuilder();
            foreach (var item in queryString) 
            {
                query.Append($"{item.Key}={item.Value}&");
            }

            if (queryString.Count > 0) 
            {
                uri = uri + "?" +query.ToString().TrimEnd('&');
            }

            //string bodyContent = string.Empty;
            //HttpContent content = bodyContent != null ? new StringContent(bodyContent, Encoding.UTF8, "application/json") : null;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);            
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


        //public async Task<T> Post<T>(string uri, T objT)
        //{
        //    uri = uri.Trim('/') + "/";

        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
        //    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(objT), Encoding.UTF8, "application/json");
        //    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        //    HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        //    response.EnsureSuccessStatusCode();
        //    T model = await response.Content.ReadAsAsync<T>();

        //    return model;
        //}

        //public async Task<T> Put<T>(string uri, T objT, int id)
        //{
        //    uri = uri.Trim('/') + "/";

        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, uri + id.ToString());
        //    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(objT), Encoding.UTF8, "application/json");
        //    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        //    HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        //    response.EnsureSuccessStatusCode();
        //    T model = await response.Content.ReadAsAsync<T>();

        //    return model;
        //}

        //public async Task<bool> Delete(string uri, int id)
        //{
        //    uri = uri.Trim('/') + "/";

        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri + id.ToString());
        //    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        //    HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        //    response.EnsureSuccessStatusCode();
        //    var result = await response.Content.ReadAsAsync<bool>();

        //    return result;
        //}
    }
}