using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM_ASP.NET_MVC.Models;
namespace ATM_ASP.NET_MVC.Controllers
{
    public class CheckingAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CheckingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckingAccount/Details/5
        public ActionResult Details( int id)
        {
            var accoutDetails = db.CheckingAccounts.SingleOrDefault(account => account.Id == id);
            if (accoutDetails == null)
                return Content("No result TO Show");
            return View(accoutDetails);
        }
        // GET: CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PrintStatement(int checkingAccountId)
        {

            var accountHolder = db.CheckingAccounts.Find(checkingAccountId);
            if (accountHolder == null)
            {
                return HttpNotFound();
            }
            return View(accountHolder);
        }
    }
}
