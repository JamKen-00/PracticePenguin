using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Models
{
    public class Project
    {
        private int id = 0;
        private DateTime OpenDate, ClosedDate;
        private bool isActive = true;
        private string shortName = "";
        private string longName = "";
        private int clientId = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime OpenDATE { get; set; }
        public DateTime ClosedDATE { get; set; }
        public bool IsActive { get; set; }
        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }
        public string LongName
        {
            get { return longName; }
            set { longName = value; }
        }
        public Client? Client { get; set; }
        public int ClientId { get; set; }
    }
}
