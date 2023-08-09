using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
   public class Customer
    {
        public int customerID { get; set; }
        public int addressID { get; set; }
        public string customerName { get; set; }
        public bool active { get; set; }
    }
}
