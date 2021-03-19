using AppMobile.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobile.Service
{
    class HttpConnection
    {

        public async Task<string> AddEntidade(string firstName, string surName, int age)
        {
            try
            {

                Entidade entidade = new Entidade();

                HttpClient client = new HttpClient();
          
                var result = await client.PostAsync("http://192.168.1.2:5000/api/entidade", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(
                    new Entidade()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FirstName = firstName,
                        SurName = surName,
                        Age = age,
                        CreationDate = DateTime.Now
                    }),
                        Encoding.UTF8, "application/json"
                     ));
                return await result.Content.ReadAsStringAsync();

            }

            catch 
            {
                return "error";
            }

        }
    }
}
