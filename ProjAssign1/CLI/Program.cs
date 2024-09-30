using Library.Database;
using Library.Models;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    static public async Task Main(string[] args)
    {
        var clientList = new List<Client>();
        var projectList = new List<Project>();
        var clientsDatabase = ClientDatabase.Current;
        var projectsDatabase = ProjectDatabase.Current;

        Console.WriteLine("Welcome!");
        Console.WriteLine("Please Select the platform");
        Console.WriteLine("C| Clients");
        Console.WriteLine("P| Projects");

        var choice = Console.ReadLine();

        if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
        {
            bool isRunning = true;
            while (isRunning != false)
            {
                Console.WriteLine("== CLIENTS ==");
                Console.WriteLine("C| Create Client Information");
                Console.WriteLine("R| Read Client Information");
                Console.WriteLine("U| Update Client Information");
                Console.WriteLine("D| Delete Client Information");
                Console.WriteLine("Q| Quit");
                var innerChoices = Console.ReadLine();
                //Create
                if (innerChoices.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Write the Client ID Numbers: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Write the Client Name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Write notes on the Client: ");
                    var notes = Console.ReadLine();
                    clientsDatabase.Add(
                        new Client
                        {
                            Id = id,
                            Name = name ?? "John Doe",
                            Notes = notes ?? "This is a default line of words"
                        }
                        );

                }
                //Read
                else if (innerChoices.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientsDatabase.Read();

                }
                //Update
                else if (innerChoices.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientUpdate = clientsDatabase.Get(updateChoice);

                    if (clientUpdate != null)
                    {
                        Console.WriteLine("Write the Client ID Numbers: ");
                        clientUpdate.Id = int.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("Write the Client Name: ");
                        clientUpdate.Name = Console.ReadLine() ?? "John Doe";
                        Console.WriteLine("Write notes on the Client: ");
                        clientUpdate.Notes = Console.ReadLine() ?? "This is a default line of words";
                        //await clientsDatabase.UpdateClient(clientUpdate);
                    }
                }
                //Delete
                else if (innerChoices.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientsDatabase.Read();
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");
                    clientsDatabase.Delete(deleteChoice);
                    //await clientsDatabase.DeleteClient(deleteChoice);
                }
                //Quit
                else if (innerChoices.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Exiting!");
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }


        }
        if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
        {
            bool isRunning = true;
            while (isRunning != false)
            {
                Console.WriteLine("== PROJECTS ==");
                Console.WriteLine("C| Create Project Information");
                Console.WriteLine("R| Read Project Information");
                Console.WriteLine("U| Update Project Information");
                Console.WriteLine("D| Delete Project Information");
                Console.WriteLine("Q| Quit");
                var innerChoices = Console.ReadLine();
                //Create
                if (innerChoices.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Write the Project ID Numbers: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Write the Project Short Name: ");
                    var shortName = Console.ReadLine();
                    Console.WriteLine("Write the Project Long Name: ");
                    var longName = Console.ReadLine();
                    projectsDatabase.Add(
                        new Project
                        {
                            Id = id,
                            ShortName = shortName ?? "JohnWorks",
                            LongName = longName ?? "JohnWorks Inc.",
                            //Notes = notes ?? "This is a default line of words"
                        }
                        );

                }
                //Read
                else if (innerChoices.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectsDatabase.Read();
                }
                //Update
                else if (innerChoices.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectsUpdate = projectsDatabase.Get(updateChoice);
                    if (projectsUpdate != null)
                    {
                        Console.WriteLine("Write the Client ID Numbers: ");
                        projectsUpdate.Id = int.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("Write the Client Name: ");
                        projectsUpdate.ShortName = Console.ReadLine() ?? "JohnWorks";
                        Console.WriteLine("Write notes on the Client: ");
                        projectsUpdate.LongName = Console.ReadLine() ?? "JohnWorks Inc";
                    }
                }
                //Delete
                else if (innerChoices.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectsDatabase.Read();
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");
                    projectsDatabase.Delete(deleteChoice);
                }
                //Quit
                else if (innerChoices.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Exiting!");
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

    }
        

    
    
}