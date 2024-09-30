using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Bill
    {
        public Bill() { }
        private double totalAmount;
        

        public double TotalAmount(double rate, double hours)
        {
            return rate * hours;
        }
        public DateTime DueDate { get; set; }



    }
}
