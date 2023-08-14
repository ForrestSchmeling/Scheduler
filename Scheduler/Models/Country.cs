using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
  public  class Country
    {
        public int countryID { get; set; }
        public string country { get; set; }
        public string createdBy { get; set; }
        public string lastUpdateBy { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}
