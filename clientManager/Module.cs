using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace clientManager
{
    public class ClientBuilder
    {
        private Client client;

        public ClientBuilder()
        {
            client = new Client();
        }

        public ClientBuilder WithName(string name)
        {
            client.Name = name;
            return this;
        }

        public ClientBuilder WithType(string type)
        {
            client.Type = type;
            return this;
        }

        public Client Build()
        {
            client.GenerateIdNumber(); 
            return client;
        }
    }

    public class Client
    {
        public string Name { get; set; }
        public int Id { get; private set; }
        public string Type { get; set; }

        private static int clientNumber = 0;

        public Client()
        {
            clients = new List<Client>();
        }

        private List<Client> clients;

        public void GenerateIdNumber()
        {
            Id = clientNumber++;
        }
        public void AddClient(Client client)
        {
            clients.Add(client);
        }
        public void EditClient(int clientId, string newName, string newType)
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);

            if (client != null)
            {
                client.Name = newName;
                client.Type = newType;
            }
            else
            {
                throw new InvalidOperationException("Client not found.");
            }
        }
        public void RemoveClient(Client client)
        {
            clients.Remove(client);
        }

        public ListViewItem ToListViewItem()
        {
            string[] row = { Id.ToString(), Name, Type };
            return new ListViewItem(row);
        }
    }
}
