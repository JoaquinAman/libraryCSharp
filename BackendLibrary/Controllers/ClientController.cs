using Microsoft.AspNetCore.Mvc;
using Domain.Interface;
using Domain.Model;

namespace BackendLibrary.Controllers
{
    [Route("api/v1/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientDomain clientDomain;
        public ClientController(IClientDomain clientDomain)
        {
            this.clientDomain = clientDomain;
        }
        [HttpGet]
        [Route("/api/v1/clients/tests")]
        public string IntegrationTest()
        {
            return "Hello World";
        }
        [HttpGet]
        public List<Client> GetClients()
        {
            return clientDomain.GetClients();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Client> GetClientById(int id)
        {
            return await clientDomain.GetClientById(id);
        }
        [HttpPost]
        public string CreateClient(string client)
        {
            return clientDomain.Create(client);
        }
        [HttpPut]
        public Client UpdateClient(int id, Client client)
        {
            return clientDomain.Update(id, client);
        }
        [HttpDelete]
        public void DeleteClient(int id)
        {
            clientDomain.Delete(id);
        }

    }
}
