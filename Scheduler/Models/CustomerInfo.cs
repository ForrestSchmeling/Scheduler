using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
   public class CustomerInfo
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }


        public CustomerInfo(){
            }
        public CustomerInfo(string CustomerName, string Address, string City, string Postalcode, string Country, string Phone)
        {
            customerName = CustomerName;
            address = Address;
            city = City;
            postalcode = Postalcode;
            country = Country;
            phone = Phone;
        }
    }
}
