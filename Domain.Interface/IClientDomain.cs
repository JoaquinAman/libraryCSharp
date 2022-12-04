using Domain.Model;

namespace Domain.Interface
{
    public interface IClientDomain
    {
        Task<Client> GetClientById(int id);
        List<Client> GetClients();
        string Create(string clientName);

        Client Update(int id, Client client);
        void Delete(int id);
    }
}
