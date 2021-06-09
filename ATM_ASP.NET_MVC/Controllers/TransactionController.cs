using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM_ASP.NET_MVC.Models;
namespace ATM_ASP.NET_MVC.Controllers
{
    public class TransactionController : Controller
    {

        private ApplicationDbContext db;
        public TransactionController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();    
        }
        // GET: Transaction

        [Authorize]
        public ActionResult Deposit(int checkingAccountId)
        {
            if (checkingAccountId==0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var checkAccount = db.CheckingAccounts.SingleOrDefault(m => m.Id == transaction.CheckingAccountId);
                checkAccount.Balance += transaction.Amount;
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [Authorize]
        public ActionResult Withdrawal(int checkingAccountId)
        {
            if (checkingAccountId == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Withdrawal(Transaction transaction)
        {

            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            else
            {
                var userAccount = db.CheckingAccounts.SingleOrDefault(account => account.Id == transaction.CheckingAccountId);
                if (userAccount == null || userAccount.Balance <= transaction.Amount)
                {
                    throw new Exception();
                }
                else
                {
                    userAccount.Balance = userAccount.Balance - transaction.Amount;
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }
            
            }

            return RedirectToAction("Index", "Home");
        }
        
    }
}