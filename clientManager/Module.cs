using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace clientManager
{
    [Serializable]
    public class ClientsList
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Date { get; set; } 
        public ClientsList(string date)
        {
            this.Date = date; 
        }
    }

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

        private static DateTime date = DateTime.Now;
        private List<Client> clients;

        public Client()
        {
            clients = new List<Client>();
        }

        public void GenerateIdNumber()
        {
            Id = clientNumber++;
        }
        public void AddClient(Client client)
        {
            clients.Add(client);

            ClientsList clientsList = new ClientsList(date.ToLongDateString());

            clientsList.Name = client.Name;
            clientsList.Id = client.Id;
            clientsList.Type = client.Type;

            string path = date.ToLongTimeString();
            path = path.Replace(":", "-");

            using (FileStream file = new FileStream($"..\\..\\{path}.json", FileMode.Create))
            {
                JsonSerializer.Serialize<ClientsList>(file, clientsList);
            }

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

        private static int clientNumber = 0;
    }
}
