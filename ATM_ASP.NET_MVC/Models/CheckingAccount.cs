using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ATM_ASP.NET_MVC.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        
       
        [Required]
        [Display(Name="Account No :")]
        
        //[StringLength(10)]

        [RegularExpression(@"\d{6,10}",ErrorMessage ="The Account Number must be between 6 and 10")]
        public string AccountNo  { get; set; }
        
        
        
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        
        
        
        [Display(Name = "Last Name :")]
        [Required]
        public string LastName { get; set; }
        
        
        [Display(Name="Account Holder :")]
        public string Name { get {
                return String.Format("{0} {1}", this.FirstName, this.LastName);
            }  }

        
        
        [Display(Name="Account Balance :")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}