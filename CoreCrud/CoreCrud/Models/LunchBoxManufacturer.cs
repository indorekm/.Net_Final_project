using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        [StringLength(25, MinimumLength = 2)]
        [CustomValidation(typeof(LunchBoxManufacturer), "NameValidation")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selling online.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selling online; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Is Selling Online?")]
        public bool? IsSellingOnline { get; set; }

        /// <summary>
        /// Gets or sets the company established on.
        /// </summary>
        /// <value>
        /// The company established on.
        /// </value>
        [Display(Name = "Established On")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required feild")]
        [CustomValidation(typeof(LunchBoxManufacturer), "EstablishDateValidation")]
        public DateTime? EstablishedOn { get; set; }

        /// <summary>
        /// Gets or sets the sales revenue.
        /// </summary>
        /// <value>
        /// The sales revenue.
        /// </value>
        [Display(Name = "Sales Revenue")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000)]
        public decimal? SalesRevenue { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [Required(ErrorMessage ="Required location feild")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        /// <value>
        /// The cell phone.
        /// </value>
        [Phone(ErrorMessage = "Please provide a valid US phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter 10 digit phone number.")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        // RELATIONSHIPS

        /// <summary>
        /// Gets or sets the lunch boxes.
        /// </summary>
        /// <value>
        /// The lunch boxes.
        /// </value>
        public ICollection<LunchBox> LunchBoxes { get; set; }

        // VALIDATION RULES

        /// <summary>
        /// Establishes the date validation.
        /// </summary>
        /// <param name="establishedDate">The established date.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static ValidationResult EstablishDateValidation(DateTime? establishedDate, ValidationContext context)
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

            if(establishedDate.Value.Date > DateTime.Today)
            {
                return new ValidationResult("Estabished date should be past date");
            }

            return ValidationResult.Success;
            
        }

        /// <summary>
        /// Names the validation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static ValidationResult NameValidation(string name, ValidationContext context)
        {
            if (name == null)
            {
                return ValidationResult.Success;
            }

            LunchBoxManufacturer instance = context.ObjectInstance as LunchBoxManufacturer;
            if (instance == null)
            {
                return ValidationResult.Success;
            }

            // Manufacturer's name should be unique

            // GET THE DATABASE
            var dbContext = context.GetService(typeof(CoreCrudContext)) as CoreCrudContext;

            var manufactuerWithSameName = dbContext.LunchBoxManufacturer.First(manufactuer => manufactuer.Name == name);
            if(manufactuerWithSameName != null)
            {
                return new ValidationResult($"Manufacturer Name: {name} already exists. Please enter diffrent name for Manufacturer");
            }

            return new ValidationResult("Enter valid date");
        }
    }
}
