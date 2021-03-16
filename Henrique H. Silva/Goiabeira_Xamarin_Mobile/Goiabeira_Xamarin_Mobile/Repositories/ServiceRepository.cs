using Goiabeira_Xamarin_Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Goiabeira_Xamarin_Mobile.Repositories
{
    public class ServiceRepository
    {
        public async Task<string> Cadastrar(Usuario NovoUsuario)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    Uri uri = new Uri(string.Format("http://IP_V4_ADRESS:8000/api/Usuario"));
                    var content = new StringContent(JsonConvert.SerializeObject(NovoUsuario), Encoding.UTF8, "application/json");
                
                    HttpResponseMessage response = await client.PostAsync(uri, content);

                    return response.ReasonPhrase;    
                }
                catch (Exception)
                {
                    return "Bad Request";
                }
            }
        }

        public async Task<List<Usuario>> Listar()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    Uri uri = new Uri(string.Format("http://IP_V4_ADRESS:8000/api/Usuario"));

                    HttpResponseMessage response = await client.GetAsync(uri);

                    if (response.ReasonPhrase == "OK")
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<List<Usuario>>(content); 
                    }
                    else 
                        return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
