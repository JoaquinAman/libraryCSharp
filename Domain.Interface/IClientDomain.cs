using Domain.Model;

namespace Domain.Interface
{
    public interface IClientDomain
    {
        Task<Client> GetClientById(string id);
        List<Client> GetClients();
        Client Create(Client client);

        Client Update(string id, Client client);
        void Delete(string id);
    }
}
