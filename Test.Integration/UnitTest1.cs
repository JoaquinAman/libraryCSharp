using Microsoft.AspNetCore.Builder;
using BackendLibrary;
using Google.Protobuf.WellKnownTypes;
using BackendLibrary.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Domain.Model;

namespace Test.Integration
{
    //public class UnitTest1 : IClassFixture<WebApplicationFactory<ClientController>>
    //{
    //    private readonly WebApplicationFactory<ClientController> _webApplicationFactory;
    //    public UnitTest1(WebApplicationFactory<ClientController> webApplicationFactory)
    //    {
    //        _webApplicationFactory = webApplicationFactory;
    //    }
    //    [Theory]
    //    [InlineData("api/v1/clients")]
    //    public async Task GetHttpRequest(string url)
    //    {
    //        var client = _webApplicationFactory.CreateClient();
    //        var response = await client.GetAsync(url);
    //        response.EnsureSuccessStatusCode();
    //        Assert.Equal("text/html; charset=utf-8",
    //            response.Content.Headers.ContentType.ToString());
    //    }
    //}

    public class UnitTest1
    {
        [Fact]
        public async void TestRoute_ReturnsHelloWorld()
        {
            var webAppFactory = new WebApplicationFactory<Startup>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("api/v1/clients/tests");
            var stringResult = await response.Content.ReadAsStringAsync();

            //Assert.AreEqual("Hello World", stringResult);
            Assert.Equal("Hello World", stringResult);
        }

        [Fact]
        public async void GetClientByIdTest()
        {
            var webAppFactory = new WebApplicationFactory<Startup>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("api/v1/clients/1");
            string stringResult = await response.Content.ReadAsStringAsync();
            Client client = JsonConvert.DeserializeObject<Client>(stringResult);

            Assert.Equal("joaquin", client.Name);
        }

        [Fact]
        public async void GetAllClientsTest()
        {
            var webAppFactory = new WebApplicationFactory<Startup>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("api/v1/clients/");
            string stringResult = await response.Content.ReadAsStringAsync();
            List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(stringResult);

            Assert.Equal("joaquin", clients[0].Name);
            Assert.Equal("Gaia", clients[1].Name);
        }
    }
    /*

     investigar.
     
     paso un valor a un endpoint y 
     verificar q se guarda en la BD
    
     verifica q se haya creado, una vez q se creo lo borro, 
     sino va a romper la proxima vez el test.
 
     */
}