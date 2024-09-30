using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Database
{
    public class ProjectDatabase
    {
        private static ProjectDatabase? instance;

        public static object _lock = new object();

        public static ProjectDatabase Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectDatabase();
                    }
                }
                return instance;
            }
        }

        private List<Project> projectsRegistered;
        private ProjectDatabase()
        {
            projectsRegistered = new List<Project>
            {
            new Project { Id = 1, ShortName = "ProjectX", LongName = "X Corporation", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 2, ShortName = "ProjectY", LongName = "Y Innovations", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 3, ShortName = "ProjectZ", LongName = "Z Enterprises", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 4, ShortName = "ProjectAlpha", LongName = "Alpha Solutions", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 5, ShortName = "ProjectBeta", LongName = "Beta Technologies", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 6, ShortName = "ProjectGamma", LongName = "Gamma Systems", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 7, ShortName = "ProjectDelta", LongName = "Delta Enterprises", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 8, ShortName = "ProjectSigma", LongName = "Sigma Innovations", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 9, ShortName = "ProjectOmega", LongName = "Omega Solutions", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 10, ShortName = "ProjectPhoenix", LongName = "Phoenix Systems", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 11, ShortName = "ProjectAurora", LongName = "Aurora Technologies", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 12, ShortName = "ProjectNeptune", LongName = "Neptune Enterprises", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 13, ShortName = "ProjectZeus", LongName = "Zeus Innovations", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 14, ShortName = "ProjectHermes", LongName = "Hermes Solutions", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 15, ShortName = "ProjectApollo", LongName = "Apollo Systems", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 16, ShortName = "ProjectGaia", LongName = "Gaia Enterprises", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 17, ShortName = "ProjectAthena", LongName = "Athena Innovations", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 18, ShortName = "ProjectAtlas", LongName = "Atlas Technologies", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 19, ShortName = "ProjectTitan", LongName = "Titan Solutions", IsActive = true, OpenDATE = new DateTime() },
            new Project { Id = 20, ShortName = "ProjectEclipse", LongName = "Eclipse Systems", IsActive = true, OpenDATE = new DateTime() }
            //new Client { Id = 2, Name = "Jack", Notes = "Hello", IsActive = true },
            //new Client { Id = 3, Name = "Jane", Notes = "Hello", IsActive = true },
            //new Client { Id = 4, Name = "Jeff", Notes = "Hello", IsActive = true }
            };
        }

        public List<Project> ProjectsRegistered
        {
            get { return projectsRegistered; }
        }

        //gets
        public Project? Get(int id)
        {
            return projectsRegistered.FirstOrDefault(c => c.Id == id);
        }

        //add
        public void Add(Project? project)
        {
            if (project != null)
            {
                projectsRegistered.Add(project);
            }
        }

        //delete
        public void Delete(int id)
        {
            var projectToRemove = Get(id);
            if (projectToRemove != null)
            {
                projectsRegistered.Remove(projectToRemove);
            }
        }

        //read
        public void Read()
        {
            projectsRegistered.ForEach(Console.WriteLine);
        }
    }
}
