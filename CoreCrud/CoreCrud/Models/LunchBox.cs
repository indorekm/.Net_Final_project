using System;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    /// <summary>
    /// Model for Lunch Box
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
        public string LunchBoxName { get; set; }

        /// <summary>
        /// Gets or sets the sold date of lunch box..
        /// </summary>
        /// <value>
        /// The sold date of lunch box.
        /// </value>
        [Display(Name = "Sold Date")]
        [DataType(DataType.Date)]
        public DateTime SoldDate { get; set; }

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
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the weight of lunch box.
        /// </summary>
        /// <value>
        /// The weight of lunch box.
        /// </value>
        public float Weight { get; set; }

        /// <summary>
        /// Gets or sets the description for the lunch box.
        /// </summary>
        /// <value>
        /// The description for the lunch box.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer identifier.
        /// </summary>
        /// <value>
        /// The manufacturer identifier.
        /// </value>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets the lunch box manufacturer.
        /// </summary>
        /// <value>
        /// The lunch box manufacturer.
        /// </value>
        public LunchBoxManufacturer Manufacturer { get; set; }
    }
}