using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreCrud.Pages.Auction
{
    /// <summary>
    /// Model for Auction
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class AuctionModel : PageModel
    {
        /// <summary>
        /// The context
        /// </summary>
        private CoreCrudContext _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionModel" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AuctionModel(CoreCrudContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets or sets the collectibles.
        /// </summary>
        /// <value>
        /// The collectibles.
        /// </value>
        public IList<LunchBox> Collectibles { get; set; }

        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {
            // get collectibles which are not sold 
            // and sort by price
            Collectibles = _context.LunchBox
                .OrderBy(lunchBox => lunchBox.LunchBoxName)
                .Where(lunchBox => lunchBox.SoldDate == new System.DateTime())
                .Include(lunchBox => lunchBox.Manufacturer)                
                .ToList();
        }
    }
}