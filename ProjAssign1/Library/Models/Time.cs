using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Time
    {
        private int projectid = 0;
        private int employeeid = 0;
        private double hours = 0.0;
        private DateTime OpenDate, ClosedDate;
        private bool isActive = true;
        private string narrative = "";


        public int ProjectId { get; set; } 
        public int EmployeeId { get; set; }
        public double Hours { get; set; }
        public string Narrative { get; set; }
        public DateTime OpenDATE { get; set; }
        public DateTime ClosedDATE { get; set; }
        public bool IsActive { get; set; }

    }
}
