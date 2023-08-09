using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace OnlineBankingApp.Models
{
    /// <summary>
    /// Represents a customer of the online banking system.
    /// </summary>
    public class Customer
    {
        //private const string PhoneNumberFormat = "{0:(61)- ### ### ###}";
        //private string _phone;

        /// <summary>
        /// Unique identifier for the customer.
        /// </summary>
        [Required, Key]
        public Guid CustomerId { get; set; }
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        [Required, MaxLength(50), RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only letters of the alphabet")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// The tax file number of the customer for identification purposes.
        /// </summary>
        [StringLength(9), RegularExpression(@"^[\d]+$", ErrorMessage = "An Individual TFN can only be 9 digits long")]
        [Display(Name = "Tax File Number")]
        public string Tfn { get; set; }

        /// <summary>
        /// The address of the customer.
        /// </summary>
        [MaxLength(50), RegularExpression(@"^\b[\dA-Za-z\s\-\\]+\b$", ErrorMessage = "Only letters and numbers")]
        public string Address { get; set; }

        /// <summary>
        /// The city of the customer's address.
        /// </summary>
        [MaxLength(40), RegularExpression(@"^\b[A-Za-z\s]+$", ErrorMessage = "Please only use names.")]
        public string City { get; set; }

        /// <summary>
        /// The state of the customer's address.
        /// Must be a 3 lettered Australian state, WA, NT???
        /// </summary>
        [MaxLength(3)]
        [RegularExpression(@"(?i)\b(vic|qld|sa|act|nsw|wa|tas|nt|)\b", ErrorMessage = "Abbreviated names only")]
        public string State { get; set; }

        /// <summary>
        /// The postal code of the customer's address.
        /// Must be a 4 digit number.
        /// </summary>
        [RegularExpression(@"\b\d{4}\b", ErrorMessage = "Four digits only")]
        public string PostCode { get; set; }

        /// <summary>
        /// The phone number of the customer in the format (61)- xxxx xxxx.
        /// </summary>
        //[RegularExpression(@"^0{1}[\d]{9}$", ErrorMessage = "Must be an Australian Mobile number")]
        public string Phone { get; set; }

        /// <summary>
        /// Displays the phone number of the customer.
        /// </summary>
        //[NotMapped]
        //public string DisplayPhoneNumber => _phone;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password did not match")]
        public string ConfirmPassword { get; set; }
        public bool Status { get; set; } = true;


        public ICollection<Account> Accounts { get; set; }
        public ICollection<Payee> Payees { get; set; }
        public ICollection<PaymentHistory> PaymentHistories { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; } = 2;

        // Navigation property to the Roles entity
        public Roles Roles { get; set; }
    }
}
