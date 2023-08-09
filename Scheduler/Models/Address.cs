using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
  public  class Address
    {
        public int addressID { get; set; }
        public int cityID { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
    }
}
