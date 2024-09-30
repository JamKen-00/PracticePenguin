using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Client
    {
        private int id = 0;
        private DateTime OpenDate, ClosedDate;
        private bool isActive = true;
        private string name = "";
        private string notes = "";
        private List<Project> clientProjects;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime OpenDATE { get; set; }
        public DateTime ClosedDATE { get; set; }
        public bool IsActive { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public List<Project> ClientProjects
        {
            get { return clientProjects; }
        }













    }
}
