using System;
using System.Collections.Generic;
using System.Linq;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    /// <summary>
    /// Model for Index page
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The context
        /// </summary>
        private CoreCrudContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public IndexModel(CoreCrudContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets or sets the lunch box manufacturers.
        /// </summary>
        /// <value>
        /// The lunch box manufacturers.
        /// </value>
        public List<LunchBoxManufacturer> LunchBoxManufacturers { get; set; }

        /// <summary>
        /// Gets or sets the count of lunch box.
        /// </summary>
        /// <value>
        /// The count of lunch box.
        /// </value>
        public int CountOfLunchBox { get; set; }
        /// <summary>
        /// Gets or sets the count of lunch box sold.
        /// </summary>
        /// <value>
        /// The count of lunch box sold.
        /// </value>
        public int CountOfLunchBoxSold { get; set; }

        /// <summary>
        /// Gets or sets the count of lunch box not sold.
        /// </summary>
        /// <value>
        /// The count of lunch box not sold.
        /// </value>
        public int CountOfLunchBoxNotSold { get; set; }

        /// <summary>
        /// Gets or sets the count of manufacturer.
        /// </summary>
        /// <value>
        /// The count of manufacturer.
        /// </value>
        public int CountOfManufacturer { get; set; }

        /// <summary>
        /// Gets or sets the count of manufacturer selling online.
        /// </summary>
        /// <value>
        /// The count of manufacturer selling online.
        /// </value>
        public int CountOfManufacturerSellingOnline { get; set; }



        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {
            LunchBoxManufacturers = _context.LunchBoxManufacturer.ToList();

            // for lunch boxes
            CountOfLunchBox = _context.LunchBox.Count();
            CountOfLunchBoxSold = _context.LunchBox
                .Where(lunchBox => lunchBox.SoldDate != new DateTime())
                .Count();
            CountOfLunchBoxNotSold = _context.LunchBox
                .Where(lunchBox => lunchBox.SoldDate == new DateTime())
                .Count();

            // for manufacturers
            CountOfManufacturer = _context.LunchBoxManufacturer.Count();
            CountOfManufacturerSellingOnline = _context.LunchBoxManufacturer
                .Where(manufacturer => manufacturer.IsSellingOnline)
                .Count();
        }
    }
}
