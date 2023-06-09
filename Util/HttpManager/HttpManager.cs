﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private readonly HttpClient httpClient = new HttpClient();

        protected HttpManager()
        {
        }

        public static HttpManager Instance()
        {
            lock(syncLock)
            {
                if (_instance == null)
                {
                    _instance = new HttpManager();
                }
            }
            return _instance;
        }

        public Uri InitializeClient(string baseAdress)
        {
            baseAdress = baseAdress.TrimEnd('/') + "/";

            Uri uri = new Uri(baseAdress);
            httpClient.BaseAddress = uri;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return uri;
        }

        public string Token { get; set; }

        public void Authenticate(string baseAdress, string login, string password)
        {
            Uri uri = InitializeClient(baseAdress);

            var json = GetToken(uri.AbsoluteUri, login, password);

            Token = JsonConvert.DeserializeObject<string>(json);

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
        }

        public string GetToken(string tokenUrl, string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "username", userName ),
                        new KeyValuePair<string, string> ( "password", password )
                    };
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var response = httpClient.PostAsync(tokenUrl, content).GetAwaiter().GetResult();
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public async Task<Reply<T>> GenericRequestAsync<T>(HttpMethod method, string uri, object objW, Dictionary<string, string> queryParams = null, Dictionary<string, string> headers = null)
        {
            uri = uri.Trim('/');

            Reply<T> reply = new Reply<T>();
            try
            {
                if (queryParams != null && queryParams.Count > 0)
                {
                    StringBuilder query = new StringBuilder();
                    foreach (var item in queryParams)
                    {
                        query.Append($"{item.Key}={item.Value}&");
                    }

                    uri = uri + "?" + query.ToString().TrimEnd('&');
                }

                string bodyContent = JsonConvert.SerializeObject(objW);
                var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(bodyContent));
                bytecontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage requestMessage = new HttpRequestMessage(method, uri)
                {
                    Content = (method == HttpMethod.Post || method == HttpMethod.Put) ? bytecontent : null
                };

                if (headers != null && headers.Count > 0)
                {
                    foreach (var item in headers)
                    {
                        requestMessage.Headers.Add(item.Key, item.Value);
                    }
                }

                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpResponseMessage response = await httpClient.SendAsync(requestMessage))
                {
                    response.EnsureSuccessStatusCode();
                    //Console.WriteLine(response.ReasonPhrase);

                    using (HttpContent content = response.Content)
                    {
                        reply.Response = response;
                        reply.StatusCode = response.StatusCode.ToString();
                        
                        if (typeof(T) == typeof(byte[]))
                        {
                            byte[] data = await content.ReadAsByteArrayAsync();
                            reply.Data = (T)(object)data;
                        }
                        else
                        {
                            string json = await content.ReadAsStringAsync();
                            reply.Data = JsonConvert.DeserializeObject<T>(json);
                        }
                        return reply;
                    }
                }
            }
            catch (WebException ex)
            {
                reply.StatusCode = "ServerError";
                var response = (HttpWebResponse)ex.Response;
                if (response != null)
                {
                    reply.StatusCode = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                reply.StatusCode = "AppError";
                Console.WriteLine(ex.Message);
            }
            return reply;
        }

        public async Task<Reply<T>> Get<T>(string uri, Dictionary<string, string> queryParams = null, Dictionary<string, string> headers = null)
        {
            return await GenericRequestAsync<T>(HttpMethod.Get, uri, null, queryParams, headers);
        }

        public async Task<Reply<T>> Post<T>(string uri, object objW, Dictionary<string, string> headers = null)
        {
            return await GenericRequestAsync<T>(HttpMethod.Post, uri, objW, null, headers);
        }

        public async Task<Reply<T>> PutAsync<T>(string uri, object objW, Dictionary<string, string> headers = null)
        {
            return await GenericRequestAsync<T>(HttpMethod.Put, uri, objW, null, headers);
        }

        public async Task<Reply<int>> DeleteAsync<T>(string uri, Dictionary<string, string> headers = null)
        {
            return await GenericRequestAsync<int>(HttpMethod.Delete, uri, null, null, headers);
        }
    }
}