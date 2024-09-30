using ProjAssign1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAssign1.Database
{
    public class ClientDatabase
    {
        private static ClientDatabase? instance;

        public static  object _lock = new object();

        public static ClientDatabase Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientDatabase();
                    }
                }
                return instance;
            }
        }

        private List<Client> clientsRegistered;
        private ClientDatabase()
        {
            clientsRegistered = new List<Client>
            {
            new Client{Id = 1, Name = "Joe", Notes = "Hello"},
            new Client { Id = 2, Name = "Jack", Notes = "Hello" },
            new Client { Id = 3, Name = "Jane", Notes = "Hello" },
            new Client { Id = 4, Name = "Jeff", Notes = "Hello" },
            };
        }

        public List<Client> Clients
        {
            get { return clientsRegistered; }
        }

        //gets
        public Client? Get(int id)
        {
            return clientsRegistered.FirstOrDefault(c => c.Id == id);
        }

        //add
        public void Add(Client? client)
        {
            if (client != null)
            {
                clientsRegistered.Add(client);
            }
        }

        //delete
        public void Delete(int id)
        {
            var clientToRemove = Get (id);
            if (clientToRemove != null)
            {
                clientsRegistered.Remove(clientToRemove);
            }
        }

        //read
        public void Read()
        {
            clientsRegistered.ForEach(Console.WriteLine);
        }
    }
}
