using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
  public  class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public bool active { get; set; }

        public User()
        {
            userName = string.Empty;
        }

        public User(string username, string password)
        {
            userName = username;
            passWord = password;
            active = true;
        }
    }
}
