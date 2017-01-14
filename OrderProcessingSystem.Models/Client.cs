using System;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Models
{
    /// <summary>
    ///     Client model
    /// </summary>
    public class Client : Entity<int>
    {
        /// <summary>
        ///     FirstName of client
        /// </summary>
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        ///     LastName of client
        /// </summary>
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        ///     Company name
        /// </summary>
        [Display(Name = "Company")]
        [Required]
        public string CompanyName { get; set; }

        /// <summary>
        ///     Email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        ///     Home or work phone number
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        ///     Contract date. The value can be null if no contract date exits
        /// </summary>
        [Display(Name = "Contract")]
        public DateTime? ContractDate { get; set; }

        /// <summary>
        ///     Type of client
        ///     possible values are : Small Business, Individual, Corporation
        /// </summary>
        [Display(Name = "Client Type")]
        public string ClientType { get; set; }

        /// <summary>
        ///     Extra notes
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Notes { get; set; }


        /// <summary>
        ///     Billing Address
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        ///     Mailing Address
        /// </summary>
        public Address MailingAddress { get; set; }
    }
}