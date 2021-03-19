﻿using mobile_app.Models;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace mobile_app.API
{
    public static class APIService
    {
        public const string apiUrl = "http://192.168.1.32:5000/";
        public static async Task<string> CadastrarUsuario(string name, string age, string surname = null)
        {
            try
            {
                var client = HttpClientFactory.Create();
                string _url = apiUrl + "Users/";
                var response = client.PostAsync<PostData>(_url, new PostData(name, age, surname), new JsonMediaTypeFormatter()).GetAwaiter().GetResult();
                return await response.Content.ReadAsStringAsync();
            } catch
            {
                return "error";
            }
        }
    }
}
