using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankersMVC2.Models
{
    public class User
    {
        public User()
        { }
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int IdBalance { get; set; }
       // public string UserEmail { get; set; }
        //public string UserPass { get; set; }

    }
}

