using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM_ASP.NET_MVC.Models;
using ATM_ASP.NET_MVC.ViewModels;
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
        public ActionResult TransferFund(int checkingAccountId)
        {
            if (checkingAccountId == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult TransferFund(int checkingAccountId ,TransferViewModel transfer)
        {
            var sourceAccount = db.CheckingAccounts.SingleOrDefault(account => account.Id == checkingAccountId);
            var destinationAccount = db.CheckingAccounts.
                SingleOrDefault(account => account.AccountNo == transfer.CheckingAccount.AccountNo);
            if (destinationAccount == null || sourceAccount.Balance < transfer.Transaction.Amount 
                || sourceAccount==null || destinationAccount.AccountNo == sourceAccount.AccountNo)
            {
                throw new Exception();
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