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
        public List<Client> GetClients()
        {
            return clientDomain.GetClients();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Client> GetClientById(string id)
        {
            return await clientDomain.GetClientById(id);
        }
        [HttpPost]
        public Client CreateClient(Client client)
        {
            return clientDomain.Create(client);
        }
        [HttpPut]
        public Client UpdateClient(string id, Client client)
        {
            return clientDomain.Update(id, client);
        }
        [HttpDelete]
        public void DeleteClient(string id)
        {
            clientDomain.Delete(id);
        }

    }
}
