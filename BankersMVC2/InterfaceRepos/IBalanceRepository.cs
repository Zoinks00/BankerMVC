using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;

namespace BankersMVC2
{
    public interface IBalanceRepository
    {
        public IEnumerable<Balance> GetAllBalances();

        public Balance GetBalance(int id);
        //public void UpdateBalance(int id, double newBalance);
        public void UpdateWithdraw(int id, Balance balance);
        public void UpdateDeposit(int id, Balance balance);
        //public void UpdateWithdraw(int id, double newBalance);
        public void CallWithdraw(Balance balance);
       // public void CallWithdraw(Balance balance);
        //public void UpdateWithdraw(int id, double nAmount);
        public void CallDeposit(Balance balance);
        public void InsertTransaction(Balance transInsert);
    }
}
