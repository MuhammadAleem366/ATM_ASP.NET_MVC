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

        private ApplicationDbContext db = new ApplicationDbContext();
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
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}