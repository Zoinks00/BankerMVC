using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankersMVC2.Models
{
    public class Balance
    {//constuctor

        public Balance ()
        {

        }
        public Balance(double totalBalance, double withdraw)
        { TotalBalance = totalBalance;
            Withdraw = withdraw;
        }
        public int IdBalance { get; set;}
        public double Withdraw { get; set;}
        public double Deposit { get; set;}
        public double TotalBalance { get; set; }
        
        public double newBalance { get; set; }
        public int IdTrans { get; set; }
           //gives access to trans model
       public IEnumerable<Transaction> trans { get; set; }

    }
       
}
