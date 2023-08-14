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
        public string createdBy { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastupdate { get; set; }
        public string lastupdateby { get; set; }
    
    public Customer()
    {
    }
        public Customer(int customerId,bool Active)
        {
            int customerID = customerId;
            bool active = Active;
        }
    }
}