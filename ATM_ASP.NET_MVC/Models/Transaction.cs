using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ATM_ASP.NET_MVC.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Display(Name="Amount ")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionType { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        [Required]
        public int CheckingAccountId { get; set; }
    }
}