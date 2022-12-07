using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;

namespace BankersMVC2.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ITransRepository repoTrans;
        public TransactionController(ITransRepository repoTrans)
        {
            this.repoTrans = repoTrans;
        }
        public IActionResult Index()
        {
            return View();
        }

       /* public IActionResult UpdateDepositToDatabase(Balance balance, Transaction transInsert)
        {
           
            /*var updatedBalance = new Balance()
            {
                IdBalance = balance.IdBalance,
                Deposit = balance.Deposit,
                TotalBalance = totalBalance.TotalBalance
            };

            repoTrans.InsertTransaction(transInsert);
            return RedirectToAction("ViewBalance", new { id = balance.IdBalance });
        }*/
    }
}
