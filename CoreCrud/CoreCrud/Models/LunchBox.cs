using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreCrud.Models
{
    /// <summary>
    /// Model for Lunch Box as Collectibles
    /// </summary>
    public class LunchBox
    {
        /// <summary>
        /// Gets or sets the identifier of lunch box.
        /// </summary>
        /// <value>
        /// The identifier of lunch box.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the lunch box.
        /// </summary>
        /// <value>
        /// The name of the lunch box.
        /// </value>
        [Display(Name = "Lunch Box Name")]
        [RegularExpression("[A-Z][a-zA-Z][^#&<>\"~;$^%{}?]{1,20}$", ErrorMessage = "Please enter name properly")]
        [Required]
        public string LunchBoxName { get; set; }

        /// <summary>
        /// Gets or sets the sold date of lunch box..
        /// </summary>
        /// <value>
        /// The sold date of lunch box.
        /// </value>
        [Display(Name = "Sold Date")]
        [DataType(DataType.Date)]
        public DateTime? SoldDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the luch box is microwave safe.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the luch box is microwave safe; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Is Microwave Safe?")]        
        public bool? IsMicrowaveSafe { get; set; }

        /// <summary>
        /// Gets or sets the price of lunch box.
        /// </summary>
        /// <value>
        /// The price of lunch box.
        /// </value>
        [DataType(DataType.Currency)]
        [Required]
        [CustomValidation(typeof(LunchBox), "ValidatePrice")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the weight of lunch box.
        /// </summary>
        /// <value>
        /// The weight of lunch box.
        /// </value>
        [Required]
        [Range(0, 100, ErrorMessage = "Weight of standard lunch box is between 0 to 100")]
        public float? Weight { get; set; }

        /// <summary>
        /// Gets or sets the description for the lunch box.
        /// </summary>
        /// <value>
        /// The description for the lunch box.
        /// </value>
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer identifier.
        /// </summary>
        /// <value>
        /// The manufacturer identifier.
        /// </value>
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets the lunch box manufacturer.
        /// </summary>
        /// <value>
        /// The lunch box manufacturer.
        /// </value>
        public LunchBoxManufacturer Manufacturer { get; set; }

        // READONLY PROPERTIES

        /// <summary>
        /// Gets the weight category.
        /// </summary>
        /// <value>
        /// The weight category.
        /// </value>
        [NotMapped]
        [Display(Name = "Weight Category")]
        public string WeightCategory
        {
            get
            {
                if (this.Weight < 3)
                {
                    return "Light Weight";
                }
                else if (this.Weight < 6)
                {
                    return "Medium Weight";
                }
                else
                {
                    return "Heavy Weight";
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this lunch box is sold.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is sold; otherwise, <c>false</c>.
        /// </value>
        [NotMapped]
        [Display(Name = "Sold Date")]
        public string SoldDateStringFormat
        {
            get
            {
                if (this.SoldDate == null || this.SoldDate == new DateTime())
                {
                    return "N/A";
                }
                else
                {
                    return SoldDate?.ToString("MM-dd-yyyy");
                }
            }
        }

        // VALIDATION RULES

        public static ValidationResult ValidatePrice(decimal? price, ValidationContext context)
        {
            if(price == null)
            {
                return ValidationResult.Success;
            }

            LunchBox instance = context.ObjectInstance as LunchBox;
            if(instance == null)
            {
                return ValidationResult.Success;
            }

            // Price should not be negative
            if (price < 0)
            {
                return new ValidationResult("Enter valid price");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}