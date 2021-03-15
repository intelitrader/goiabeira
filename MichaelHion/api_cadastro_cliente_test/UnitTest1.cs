using System;
using Xunit;

namespace api_cadastro_cliente_tests
{
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UnitTest1()
        {
            _server = new TestServer(new WebHostBuilder()
          .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task Get_Return_Not_Found()
        {

            var response = await _client.GetAsync(requestUri: "/api/clientes");

            Assert.Equal("Not Found", response.ReasonPhrase.ToString());
        }

        [Fact]
        public async Task Post_Return_Created_Create_user()
        {
            dynamic MyDynamic = new ExpandoObject();

            MyDynamic.firstName = "fulano";
            MyDynamic.surname = "silva";
            MyDynamic.age = 40;

            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(MyDynamic, options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(requestUri: "/api/Usuario", content: stringContent);

            Assert.Equal("Created", response.ReasonPhrase.ToString());
        }

        [Fact]
        public async Task Get_Return_OK_List_Users()
        {

            var response = await _client.GetAsync(requestUri: "/api/Usuario");
            string responseString = response.ReasonPhrase.ToString();

            Assert.Equal("OK", responseString);
        }

        [Fact]
        public async Task Put_Return_Accepted_Update_Name()
        {
            var responseMessage = await _client.GetAsync(requestUri: "/api/Usuario");
            var respost = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var objetoResposta = JsonSerializer.Deserialize<List<Usuarios>>(respost);

            objetoResposta[0].firstName = "fulano depois da alteração";
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(objetoResposta[0], options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(requestUri: "/api/Usuario", content: stringContent);

            Assert.Equal("Accepted", response.ReasonPhrase.ToString());
        }

        [Fact]
        public async Task Get_Return_OK_And_User()
        {
            var responseMessage = await _client.GetAsync(requestUri: "/api/Usuario");
            var respost = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var objetoResposta = JsonSerializer.Deserialize<List<Usuarios>>(respost);

            var response = await _client.GetAsync(requestUri: $"/api/Usuario/{objetoResposta[0].id}");

            Assert.Equal("OK", response.ReasonPhrase.ToString());
        }


        [Fact]
        public async Task Delete_Return_Forbidden_Id_Invalid()
        {
            var response = await _client.DeleteAsync(requestUri: "/api/Usuario/3929-323si23-jakc-osa");
            Assert.Equal("Forbidden", response.ReasonPhrase.ToString());
        }

        [Fact]
        public async Task Delete_Return_Accepted()
        {
            var responseMessage = await _client.GetAsync(requestUri: "/api/Usuario");
            var respost = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var objetoResposta = JsonSerializer.Deserialize<List<Usuarios>>(respost);

            var response = await _client.DeleteAsync(requestUri: $"/api/Usuario/{objetoResposta[0].id}");

            Assert.Equal("Accepted", response.ReasonPhrase.ToString());
        }

        [Fact]
        public async Task Post_Return_Bad_Rquest_Name_Invalid()
        {
            dynamic MyDynamic = new ExpandoObject();

            MyDynamic.firstName = "";
            MyDynamic.surname = "silva";
            MyDynamic.age = 40;

            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(MyDynamic, options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(requestUri: "/api/Usuario", content: stringContent);

            Assert.Equal("Bad Request", response.ReasonPhrase.ToString());
        }


        [Fact]
        public async Task Put_Return_BadRequest_Id_Invalid()
        {
            dynamic MyDynamic = new ExpandoObject();

            MyDynamic.id = "392944-32jdsds-3232-dsds2";
            MyDynamic.firstName = "fulano depois da alteração";
            MyDynamic.surname = "silva";
            MyDynamic.age = 40;

            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(MyDynamic, options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(requestUri: "/api/Usuario", content: stringContent);

            Assert.Equal("Bad Request", response.ReasonPhrase.ToString());
        }

        [Fact]
        public async Task Get_Return_BadRequest_Id_Invalid()
        {
            string id = "392944-32jdsds-3232-dsds2";

            var response = await _client.GetAsync(requestUri: $"/api/Usuario/{id}");

            Assert.Equal("Bad Request", response.ReasonPhrase.ToString());
        }
    }
}

