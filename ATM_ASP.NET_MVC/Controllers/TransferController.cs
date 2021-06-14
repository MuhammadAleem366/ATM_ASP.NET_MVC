using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM_ASP.NET_MVC.Models;
using ATM_ASP.NET_MVC.ViewModels;
using Microsoft.AspNet.Identity;
namespace ATM_ASP.NET_MVC.Controllers
{
    public class TransferController : Controller
    {
        private ApplicationDbContext db;
        public TransferController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: Transfer/TransferFund
        
        [Authorize]
        public ActionResult TransferFund()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TransferFund(TransferViewModel transfer)
        {
            var userId = User.Identity.GetUserId();
            var sourceAccount = db.CheckingAccounts.SingleOrDefault(account => account.ApplicationUserId == userId);
            var destinationAccount = db.CheckingAccounts.
                SingleOrDefault(account => account.AccountNo == transfer.CheckingAccount.AccountNo);
            if ( sourceAccount.Balance < transfer.Transaction.Amount )
            {
                ModelState.AddModelError("Transaction.Amount","Your balance is insufficient To make this Transaction");
                return View();
            }
            else if(destinationAccount.AccountNo == sourceAccount.AccountNo)
            {
                ModelState.AddModelError("CheckingAccount.AccountNo", "OOPS!! You are Tranfering Funds to Your own Account");
                return View();
            }
            else
            {
                destinationAccount.Balance = destinationAccount.Balance + transfer.Transaction.Amount;
                sourceAccount.Balance -= transfer.Transaction.Amount;
                var transaction1 = new Transaction
                {
                    Amount = transfer.Transaction.Amount,
                    TransactionType = "Withdrawal",
                    TransactionDate=DateTime.Now,
                    CheckingAccountId = sourceAccount.Id

                };
                var transaction2 = new Transaction
                {
                    Amount = transfer.Transaction.Amount,
                    TransactionType = "Deposit",
                    TransactionDate = DateTime.Now,
                    CheckingAccountId = destinationAccount.Id
                };
                db.Transactions.Add(transaction1);
                db.Transactions.Add(transaction2);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }   
        
    }
}