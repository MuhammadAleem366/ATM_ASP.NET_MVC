using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM_ASP.NET_MVC.Models;
using Microsoft.AspNet.Identity;
namespace ATM_ASP.NET_MVC.Controllers
{
    public class CheckingAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: CheckingAccount/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var accoutHolder = db.CheckingAccounts.SingleOrDefault(account => account.ApplicationUserId == userId);
            if (accoutHolder == null)
                return Content("No result To Show");
            return View(accoutHolder);
        }

        public ActionResult PrintStatement()
        {
            var userId = User.Identity.GetUserId();
            var accountHolder = db.CheckingAccounts.Where(account=>account.ApplicationUserId == userId).First();
            if (accountHolder == null)
            {
                return HttpNotFound();
            }
            return View(accountHolder);
        }
        

    }
}
