using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;
using Dapper;
using System.Data;

namespace BankersMVC2
{
    public class TransRepository: ITransRepository
    {
        private readonly IDbConnection _conn;

        //constructor
        public TransRepository(IDbConnection conn)
        {
            //connector
            _conn = conn;
        }
        public void InsertTransaction(Transaction transInsert)
        {
            _conn.Execute("INSERT INTO transsction (IDTRANSACTION, TRANSWITHDRAW, TRANSDEPOSIT, TRANSNEWBALANCE) VALUES (@idtransaction, @newwithdraw, @newdeposit, @newbalance);",
                 new
                 {
                     idtransaction = transInsert.IdTrans,
                     newwithdraw = transInsert.Withdraw,
                     newdeposit = transInsert.Deposit,
                     newBalance = transInsert.newBalance
                 });
         }        
    }
}
