using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    public abstract class Client
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public abstract void Process();
    }

    public class ClientA : Client
    {
        public override void Process()
        {
            Console.WriteLine("Processing for Client A");
        }
    }

    public class ClientB : Client
    {
        public override void Process()
        {
            Console.WriteLine("Processing for Client B");
        }
    }

    public abstract class ClientFactory
    {
        public abstract Client CreateClient(string name, string ID);
    }

    public class ClientAFactory : ClientFactory
    {
        public override Client CreateClient(string name, string ID)
        {
            return new ClientA { Name = name, ID = ID };
        }
    }

    public class ClientBFactory : ClientFactory
    {
        public override Client CreateClient(string name, string ID)
        {
            return new ClientB { Name = name, ID = ID };
        }
    }

    public class ClientManager
    {
        private Dictionary<string, Client> clients = new Dictionary<string, Client>();
        private Dictionary<string, ClientFactory> factories = new Dictionary<string, ClientFactory>();

        public void AddFactory(string type, ClientFactory factory)
        {
            factories[type] = factory;
        }

        public void AddClient(string type, string name, string ID)
        {
            if (factories.ContainsKey(type))
            {
                Client client = factories[type].CreateClient(name, ID);
                clients.Add(name, client);
            }
            else
            {
                Console.WriteLine("Factory for type '{0}' not registered.", type);
            }
        }

        public void RemoveClient(string ID)
        {
            if (clients.ContainsKey(ID))
            {
                clients.Remove(ID);
            }
            else
            {
                Console.WriteLine("Client '{0}' not found.", ID);
            }
        }

        public void EditClientName(string oldName, string newName)
        {
            if (clients.ContainsKey(oldName))
            {
                Client client = clients[oldName];
                client.Name = newName;
                clients.Remove(oldName);
                clients.Add(newName, client);
            }
            else
            {
                Console.WriteLine("Client '{0}' not found.", oldName);
            }
        }

        public void ProcessClient(string name)
        {
            if (clients.ContainsKey(name))
            {
                clients[name].Process();
            }
            else
            {
                Console.WriteLine("Client '{0}' not found.", name);
            }
        }
    }
}
