using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BLRI.Mvc.Models 
{
    public class RegistrationModel 
    {

        public RegistrationModel(){
            
            SubscriptionLookups = new List<SubscriptionTypeLookup>();

            SubscriptionLookups.Add(new SubscriptionTypeLookup { Description = "Free 30-Day Trial", Value = 1});
            SubscriptionLookups.Add(new SubscriptionTypeLookup { Description = "$9.95 for a Month-to-Month Membership", Value = 2 });
            SubscriptionLookups.Add(new SubscriptionTypeLookup { Description = "$26.85 for a Three-Month Membership", Value = 3 });
            SubscriptionLookups.Add(new SubscriptionTypeLookup { Description = "$69.95 for an Annual Membership (less than $6 per month)", Value = 4 });
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [Required(ErrorMessage = "Pleas enter First Name")]
        [DisplayName("First Name")]
        [MinLength(3, ErrorMessage = "The Study Name must be between 3 and 50 characters")]
        [StringLength(50, ErrorMessage = "The Study Name must be between 3 and 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please choose a Username")]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a e-mail address")]
        [DisplayName("E-Mail Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [DisplayName("Password")]
        [MinLength(8, ErrorMessage = "The password must be greater than 8 characers")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter the same password to confirm")]
        [DisplayName("Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please select a membership plan")]
        [DisplayName("Choose your Subscription Plan")]
        public int SubscriptionType {get; set;}
        [Required(ErrorMessage = "Enter your Credit Card Number")]
        [DisplayName("Credit Card Number")]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "Enter the name on the Credit Card")]
        [DisplayName("Cardholder Name")]
        public string CardholderName { get; set; }
        [Required(ErrorMessage = "Please enter your credit card's 3-digit security code")]
        [DisplayName("Security Code")]
        public string SecurityCode { get; set; }
        public bool TermsOfService {get;set;}
        public bool MembershipAutoRenew {get;set;}
        public bool Offers {get;set;}
        public List<SubscriptionTypeLookup> SubscriptionLookups {get; set;}
        public DateTime DateOfRegistration { get; set; }
    }

    public class SubscriptionTypeLookup {
        public int Id {get; set;}
        public string Description {get;set;}
        public int Value {get;set;}
    }
}

