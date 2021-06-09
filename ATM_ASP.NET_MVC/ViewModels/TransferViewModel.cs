using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATM_ASP.NET_MVC.Models;
namespace ATM_ASP.NET_MVC.ViewModels
{
    public class TransferViewModel
    {
        public CheckingAccount CheckingAccount { get; set; }
        public Transaction Transaction { get; set; }

    }
}