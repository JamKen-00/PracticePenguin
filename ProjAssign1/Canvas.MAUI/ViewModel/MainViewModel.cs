
using Library.Database;
using Library.Models;
using PP.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.MAUI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //GETTERS
        public List<Client> Clients 
        {
        get
            {
                return ClientDatabase.Current.ClientsRegistered;
            }
        }

        public List<Project> Projects
        {
            get
            {
                return ProjectDatabase.Current.ProjectsRegistered;
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return EmployeeDatabase.Current.EmployeesRegistered;
            }
        }

        public List<Bill> standardBill;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*
        //To Add a Client
        public void AddClient(int id, string name, string notes)
        {
            Client newClient = new Client
            {
                Id = id,
                Name = name,
                Notes = notes
            };
            //Add the client
            ClientDatabase.Current.ClientsRegistered.Add(newClient);
            //ClientDatabase.Current.ClientsRegistered.AddClient(newClient);
            NotifyPropertyChanged(nameof(Clients));
        }
        public void UpdateClient(int id, string name, string notes)
        {
            //It must exist right
            Client existingClient = Clients.FirstOrDefault(c => c.Id == id);

            if (existingClient != null)
            {
                //Update properties
                existingClient.Name = name;
                existingClient.Notes = notes;

                //Notify 
                NotifyPropertyChanged(nameof(Clients));
            }
        }
        */

        public async void AddClient(int id, string name, string notes)
        {
            Client newClient = new Client
            {
                Id = id,
                Name = name,
                Notes = notes
            };

            // Add the client locally in the clientsRegistered list
            ClientDatabase.Current.ClientsRegistered.Add(newClient);
            NotifyPropertyChanged(nameof(Clients));

            // Send a POST request to add the client on the server
            await new WebRequestHandler().Post("https://localhost:7118/Client/AddClient/", newClient);
        }

        // To Update a Client
        public async void UpdateClient(int id, string name, string notes)
        {
            // Find the client to update in the clientsRegistered list
            var existingClient = ClientDatabase.Current.ClientsRegistered.FirstOrDefault(c => c.Id == id);
            if (existingClient != null)
            {
                // Update the existing client with the new data
                existingClient.Name = name;
                existingClient.Notes = notes;
                NotifyPropertyChanged(nameof(Clients));

                // Send a POST request to update the client on the server
                await new WebRequestHandler().Post($"https://localhost:7118/Client/UpdateClient/{id}", existingClient);
            }
        }


        //To Delete a Client
        public void DeleteClient(Client client)
        {
            //Remove the client
            ClientDatabase.Current.ClientsRegistered.Remove(client);

            //Notify
            NotifyPropertyChanged(nameof(Clients));
        }




















        
        //To Add a Project
        public void AddProject(int id, string shortName, string longName)
        {
            Project newProject= new Project
            {
                Id = id,
                ShortName = shortName,
                LongName = longName
            };
            //Add the project
            ProjectDatabase.Current.ProjectsRegistered.Add(newProject);
            NotifyPropertyChanged(nameof(Projects));
        }
        public void UpdateProject(int id, string shortName, string longName)
        {
            //It must exist right
            Project existingProject = Projects.FirstOrDefault(c => c.Id == id);

            if (existingProject != null)
            {
                //Update properties
                existingProject.ShortName = shortName;
                existingProject.LongName = longName;

                //Notify 
                NotifyPropertyChanged(nameof(Projects));
            }
        }
        //To Delete a Project
        public void DeleteProject(Project project)
        {
            //Remove the project
            ProjectDatabase.Current.ProjectsRegistered.Remove(project);

            //Notify
            NotifyPropertyChanged(nameof(Projects));
        }





    }
}
