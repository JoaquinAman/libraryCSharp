using Domain.Interface;
using Domain.Model;
using Domain.Service.Common.Errors;
using MySql.Data.MySqlClient;
using System.Data;

namespace Domain.Service
{
    public class ClientDomainService : IClientDomain
    {
        MyConnection connection = new MyConnection();
        public Client Create(Client client)
        {
            string query = "insert into client (id, name)" + "values('" + client.Id + "','" +
              client.Name + "');";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            connection.cerrarConexion();
            return client;
        }

        public void Delete(string id)
        {
            string query = "delete from client where client.id=" + id + ";";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            connection.cerrarConexion();
        }

        public async Task<Client> GetClientById(string id)
        {
            List<Client> clientList = GetClients();
            List<string> idList = new();

            
            try
            {
                foreach (var clientInList in clientList)
                {
                    idList.Add(clientInList.Id);
                }
                int numericValue;
                bool isNumber = int.TryParse(id, out numericValue);
                if (!isNumber)
                {
                    throw new FormatErrorException();
                }
                if (!idList.Contains(id))
                {
                    throw new EntityNotFoundException();
                }


            }
            catch(Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    throw new EntityNotFoundException();
                }
                if (ex is FormatErrorException)
                {
                    throw new FormatErrorException();
                }
            }
            
            string query = "select * from client where client.id =" + id + ";";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            Client client = null;

            if (myDataReader.Read())
            {
                client = new Client
                {
                    Id = myDataReader["id"].ToString(),
                    Name = myDataReader["name"].ToString()
                };
            }
            connection.cerrarConexion();
            return client;
        }

        public List<Client> GetClients()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from client;", connection.establecerConexion());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "clients");

            var clientList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new Client
                {
                    Id = dataRow.Field<string>("id"),
                    Name = dataRow.Field<string>("name")
                }).ToList();

            connection.cerrarConexion();

            return clientList;
        }

        public Client Update(string clientId, Client client)
        {
            string id = client.Id;
            string name = client.Name;
            
            string query = "UPDATE `client` SET `id`='" + id + "' , `name`='" + name 
                + "' where client.id=" + clientId + ";";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            myCommand.ExecuteNonQuery();

            connection.cerrarConexion();
            return client;
        }
    }
}
