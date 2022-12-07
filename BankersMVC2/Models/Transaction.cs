using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankersMVC2.Models
{
    public class Transaction
    {
        public int IdTrans { get; set; }
        public int IdBalance { get; set; }
        public double Withdraw { get; set; }
        public double Deposit { get; set; }
        public double newBalance { get; set; }
    }
}
