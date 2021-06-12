using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATM_ASP.NET_MVC.Models;
namespace ATM_ASP.NET_MVC.Services
{
    public class CheckingAccountService
    {
        private ApplicationDbContext db;
        public CheckingAccountService(ApplicationDbContext context)
        {
            db = context;
        }

        public void CreateAccount(string FName,string LName,decimal balance,string appUserId)
        {
            var accountNo = (123457 + db.CheckingAccounts.Count()).ToString().PadLeft(10, '0');
            var checkingAccount = new CheckingAccount
            {
                AccountNo = accountNo,
                FirstName = FName,
                LastName = LName,
                Balance = balance,
                ApplicationUserId = appUserId
            };
            db.CheckingAccounts.Add(checkingAccount);
            db.SaveChanges();
        }
    }
}