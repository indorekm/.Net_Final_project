using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCrud.Models;

namespace CoreCrud.Pages.LunchBoxes
{
    public class CreateModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public CreateModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerName"] = new SelectList(_context.LunchBoxManufacturer, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public LunchBox LunchBox { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            // Handle NULL cases
            if (LunchBox.SoldDate == null)
            {
                LunchBox.SoldDate = new DateTime();
            }

            if (LunchBox.IsMicrowaveSafe == null)
            {
                LunchBox.IsMicrowaveSafe = false;
            }

            _context.LunchBox.Add(LunchBox);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}