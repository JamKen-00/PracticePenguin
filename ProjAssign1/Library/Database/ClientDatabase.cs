using Library.Models;
using Newtonsoft.Json;
using PP.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Database
{
    public class ClientDatabase
    {
        private static ClientDatabase? instance;
        private List<Client> clientsRegistered = new List<Client>();
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


        private List<Client> clients;
        private ClientDatabase()
        {
            FetchClientsFromAPI();
            /*clientsRegistered = new List<Client>
            {
            new Client { Id = 1, Name = "Joe", Notes = "Hello", IsActive = true, },
            new Client { Id = 2, Name = "Jack", Notes = "Hello", IsActive = true },
            new Client { Id = 3, Name = "Jane", Notes = "Hello", IsActive = true },
            new Client { Id = 4, Name = "Jeff", Notes = "Hello", IsActive = true }
            };

            var response = new WebRequestHandler()
                    .Get("/Client/GetClients/")
                    .Result;
            //clients = JsonConvert
                    //.DeserializeObject<List<Client>>(response) ?? new List<Client>();*/
            
        }
        public List<Client> Clients
        {
            get
            {
                return clients ?? new List<Client>();
            }

        }

        private async void FetchClientsFromAPI()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync("https://localhost:7118/Client/GetClients");

                    if (!string.IsNullOrEmpty(response))
                    {
                        clientsRegistered = JsonConvert.DeserializeObject<List<Client>>(response) ?? new List<Client>();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log or display an error message)
                Console.WriteLine($"Error during API request or deserialization: {ex.Message}");
            }
        }

        public List<Client> ClientsRegistered
        {
            get {
                return clientsRegistered;
            }
                    
        }

        //gets
        public Client? Get(int id)
        {
            return clientsRegistered.FirstOrDefault(c => c.Id == id);
        }

        /*//add
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
        */
        //read
        public void Read()
        {
            clientsRegistered.ForEach(Console.WriteLine);
        }


        // Add a new client to the server database
        public async Task Add(Client newClient)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var serializedClient = JsonConvert.SerializeObject(newClient);
                    var content = new StringContent(serializedClient, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7118/Client/AddClient", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // If the server successfully adds the client, update the local client list
                        clientsRegistered.Add(newClient);
                    }
                    else
                    {
                        // Handle the case when the client was not added on the server
                        // Display an error message or handle the failure appropriately
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log or display an error message)
                Console.WriteLine($"Error during API request: {ex.Message}");
            }
        }

        // Update an existing client on the server database
        public async Task Update(Client updatedClient)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var serializedClient = JsonConvert.SerializeObject(updatedClient);
                    var content = new StringContent(serializedClient, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7118/Client/UpdateClient/{updatedClient.Id}", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        // Handle the case when the client was not updated on the server
                        // Display an error message or handle the failure appropriately
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log or display an error message)
                Console.WriteLine($"Error during API request: {ex.Message}");
            }
        }

        // Delete a client from the server database
        public async Task Delete(int clientId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7118/Client/DeleteClient/{clientId}");

                    if (!response.IsSuccessStatusCode)
                    {
                        // Handle the case when the client was not deleted on the server
                        // Display an error message or handle the failure appropriately
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log or display an error message)
                Console.WriteLine($"Error during API request: {ex.Message}");
            }
        }




    }
}
