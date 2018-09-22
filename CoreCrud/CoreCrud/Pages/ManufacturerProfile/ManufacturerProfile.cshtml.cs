using System.Collections.Generic;
using System.Linq;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages.ManufacturerProfile
{
    /// <summary>
    /// The Manufacturer Profile Model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ManufacturerProfileModel : PageModel
    {
        /// <summary>
        /// The context
        /// </summary>
        private CoreCrudContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerProfileModel" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ManufacturerProfileModel(CoreCrudContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets or sets the manufacturers.
        /// </summary>
        /// <value>
        /// The manufacturers.
        /// </value>
        public List<LunchBoxManufacturer> LunchBoxManufacturers { get; set; }

        /// <summary>
        /// Gets or sets the lunch box manufacturer.
        /// </summary>
        /// <value>
        /// The lunch box manufacturer.
        /// </value>
        public LunchBoxManufacturer LunchBoxManufacturer { get; set; }

        /// <summary>
        /// Gets or sets the lunch boxes.
        /// </summary>
        /// <value>
        /// The lunch boxes.
        /// </value>
        public List<LunchBox> LunchBoxes { get; set; }


        /// <summary>
        /// Called when [get].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LunchBoxManufacturer = _context.LunchBoxManufacturer.First(manufacturer => manufacturer.Id == id);

            if(LunchBoxManufacturer == null)
            {
                return NotFound();
            }

            if(LunchBoxManufacturer.LunchBoxes == null)
            {
                LunchBoxManufacturer.LunchBoxes = new List<LunchBox>();
            }

            LunchBoxes = _context.LunchBox.Where(lunchBox => lunchBox.ManufacturerId == id).ToList();

            return Page();
        }
    }
}