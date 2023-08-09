using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
    public class Appointment
    {
        public int appointmentID { get; set; }
        public int customerID { get; set; }
        public int userID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string contact { get; set; }
        public string location { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
