using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    /// <summary>
    /// Model for Manufacturer
    /// </summary>
    public class LunchBoxManufacturer
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selling online.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selling online; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Is Selling Online?")]
        public bool IsSellingOnline { get; set; }

        /// <summary>
        /// Gets or sets the company established on.
        /// </summary>
        /// <value>
        /// The company established on.
        /// </value>
        [Display(Name = "Established On")]
        [DataType(DataType.Date)]
        [Required]
        [CustomValidation(typeof(LunchBoxManufacturer), "ValidateEstablishedOn")]
        public DateTime EstablishedOn { get; set; }

        /// <summary>
        /// Gets or sets the sales revenue.
        /// </summary>
        /// <value>
        /// The sales revenue.
        /// </value>
        [Display(Name = "Sales Revenue")]
        [DataType(DataType.Currency)]
        public decimal SalesRevenue { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [Required]
        public string Location { get; set; }

        // RELATIONSHIPS

        /// <summary>
        /// Gets or sets the lunch boxes.
        /// </summary>
        /// <value>
        /// The lunch boxes.
        /// </value>
        public ICollection<LunchBox> LunchBoxes { get; set; }

        // VALIDATION RULES
        public static ValidationResult ValidateEstablishedOn(DateTime? establishedDate, ValidationContext context)
        {
            if (establishedDate == null)
            {
                return ValidationResult.Success;
            }

            LunchBoxManufacturer instance = context.ObjectInstance as LunchBoxManufacturer;
            if (instance == null)
            {
                return ValidationResult.Success;
            }

            if(establishedDate.Value.Date < DateTime.Today)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Enter valid date");
        }
    }
}
