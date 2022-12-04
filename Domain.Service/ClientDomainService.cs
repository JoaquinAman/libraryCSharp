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
        
        public string Create(string name)
        {
            string query = "insert into client (name)" + "values('" + name + "');";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            connection.cerrarConexion();
            return name;
        }

        public void Delete(int id)
        {
            string query = "delete from client where client.id='" + id + "';";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            connection.cerrarConexion();
        }

        public async Task<Client> GetClientById(int id)
        {
            List<Client> clientList = GetClients();
            List<int> idList = new();

            
            try
            {
                foreach (var clientInList in clientList)
                {
                    idList.Add(clientInList.Id);
                }
                int numericValue;
                
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
            
            string query = "select * from client where client.id ='" + id + "';";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            Client client = null;

            if (myDataReader.Read())
            {
                client = new Client
                {
                    Id = (int)myDataReader["id"],
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
                    Id = dataRow.Field<int>("id"),
                    Name = dataRow.Field<string>("name")
                }).ToList();

            connection.cerrarConexion();

            return clientList;
        }

        public Client Update(int clientId, Client client)
        {
            int id = client.Id;
            string name = client.Name;
            
            string query = "UPDATE `client` SET `id`='" + id + "' , `name`='" + name 
                + "' where client.id='" + clientId + "';";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            myCommand.ExecuteNonQuery();

            connection.cerrarConexion();
            return client;
        }
    }
}