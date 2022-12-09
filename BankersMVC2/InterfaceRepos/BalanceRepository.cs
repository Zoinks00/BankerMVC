using Dapper; // added to use sql quary statments
using System;
using System.Collections.Generic;
using System.Data; // added to us IDbConnection
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models; //ref models folders

namespace BankersMVC2
{
    public class BalanceRepository: IBalanceRepository
    {
        private readonly IDbConnection _conn;

        //constructor
        public BalanceRepository(IDbConnection conn)
        {
            //connector
            _conn = conn;
        }
        public IEnumerable<Balance> GetAllBalances()
        {
            return _conn.Query<Balance>("SELECT * FROM BALANCE");
        }

        public Balance GetBalance(int id)
        {
            return _conn.QuerySingle<Balance>("SELECT * FROM BALANCE WHERE IDBALANCE = @id",
        new { id = id });
        }
       /* public void UpdateBalance(Balance balance)
        {
            _conn.Execute("UPDATE BALANCE SET TOTALBALANCE = @newBalance WHERE IDBALANCE = @id",
                new { newBalance = balance.TotalBalance, id = balance.IdBalance});
        }*/

      // public void UpdateWithdraw(int id, double newBalance)
        public void UpdateWithdraw(int id, Balance balance)
        {
            _conn.Query("UPDATE balance SET TotalBalance = @totalbalance WHERE IdBalance = @id",
                  new {  totalbalance = balance.TotalBalance, id = balance.IdBalance });
        }

        //method to update balance with deposit
        public void UpdateDeposit(int id,Balance balance)
        {
            _conn.Query("UPDATE balance SET TotalBalance = @totalbalance WHERE IdBalance = @id",
                  new { totalbalance = balance.TotalBalance, id = balance.IdBalance });
        }
        //updataes balance for transaction table
        public void InsertTransaction(Balance transInsert)
        {
            _conn.Query("INSERT INTO transaction (IDTRANSACTION, IDBALANCE, TRANSWITHDRAW, TRANSDEPOSIT, TRANSNEWBALANCE) VALUES (@idtrans, @idbalance, @newwithdraw, @newdeposit, @newbalance);",
                 new
                 {
                     idtrans = transInsert.IdTrans,
                     idbalance = transInsert.IdBalance,
                     newwithdraw = transInsert.Withdraw,
                     newdeposit = transInsert.Deposit,
                     newBalance = transInsert.newBalance
                 });
        }

            public void CallWithdraw(Balance balance)
        {
           
            GetBalance(balance.IdBalance);
            balance.TotalBalance -= balance.Withdraw;
            //used to update transaction table
            balance.newBalance = balance.TotalBalance;

            UpdateWithdraw(balance.IdBalance, balance);
        }
        //method to deposit money to balance
    public void CallDeposit(Balance balance)
        {
            GetBalance(id: balance.IdBalance);

            balance.TotalBalance += balance.Deposit;
            // usd to update transaction table
            balance.newBalance = balance.TotalBalance;
            UpdateDeposit(balance.IdBalance, balance);
        }
    }
}
