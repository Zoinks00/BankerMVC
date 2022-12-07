using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;

namespace BankersMVC2.Controllers
{
    public class BalanceController : Controller
    {
       

        private readonly IBalanceRepository repo;
        public BalanceController(IBalanceRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var balances = this.repo.GetAllBalances();
            return View(balances);
        }


        public IActionResult ViewBalance(int id)
        {
              var balance = repo.GetBalance(id);

            return View(balance);
        }

        public IActionResult WithdrawAmount (int id)
        {
             Balance balance = repo.GetBalance(id);
            return View(balance);
        }
        public IActionResult DepositAmount (int id)
        {
            Balance balance = repo.GetBalance(id);
            return View(balance);
        }
      /* public IActionResult Withdraw(Balance balance)
        {
           // balance.TotalBalance = balance.TotalBalance - balance.Withdraw;
            //repo.CallWithdraw(balance.IdBalance, balance.Withdraw, balance.newBalance);
           repo.UpdateBalance(balance);
            return RedirectToAction("ViewBalance", new {id = balance.IdBalance });
        }*/ 

       public IActionResult UpdateWithdraw(int id)
        {
            //
            Balance bal = repo.GetBalance(id);
            if (bal == null)
            {
                return View("Incorret Account or Account doesn't Exhist");
            }
            return View(bal);
        }
        public IActionResult UpdateDeposit(int id)
        {
            //
            Balance bal = repo.GetBalance(id);
            if (bal == null)
            {
                return View("Incorret Account or Account doesn't Exhist");
            }
            return View(bal);
        }
        public IActionResult UpdateWithdrawToDatabase(Balance balance,Balance transInsert )
        {
            // get the total balance from the database
            var totalBalance = repo.GetBalance(balance.IdBalance);

            var updatedBalance = new Balance()
            {
                IdBalance = balance.IdBalance,
                Withdraw = balance.Withdraw,
                TotalBalance = totalBalance.TotalBalance,
                newBalance = balance.newBalance
            };

            repo.CallWithdraw(updatedBalance);
            repo.InsertTransaction(transInsert);
            
            return RedirectToAction("ViewBalance", new { id = balance.IdBalance });
        }

        public IActionResult UpdateDepositToDatabase(Balance balance, Transaction transInsert)
        {
            // get the total balance from the database
            var totalBalance = repo.GetBalance(balance.IdBalance);

            var updatedBalance = new Balance()
            {
                IdBalance = balance.IdBalance,
                Deposit = balance.Deposit,
                TotalBalance = totalBalance.TotalBalance
            };

            repo.CallDeposit(updatedBalance);
            return RedirectToAction("ViewBalance", new { id = balance.IdBalance });
        }
    }
}
