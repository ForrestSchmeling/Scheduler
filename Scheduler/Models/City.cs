using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
   public class City
    {
        public int cityID { get; set; }
        public int countryID { get; set; }
        public string city { get; set; }
        public string createdBy { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
        

        }
    }
    

