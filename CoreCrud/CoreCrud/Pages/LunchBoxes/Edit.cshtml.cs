using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.LunchBoxes
{
    public class EditModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public EditModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LunchBox LunchBox { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LunchBox = await _context.LunchBox
                .Include(l => l.Manufacturer).FirstOrDefaultAsync(m => m.Id == id);

            if (LunchBox == null)
            {
                return NotFound();
            }
           ViewData["ManufacturerName"] = new SelectList(_context.LunchBoxManufacturer, "Id", "Name");
            return Page();
        }

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

            _context.Attach(LunchBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LunchBoxExists(LunchBox.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LunchBoxExists(int id)
        {
            return _context.LunchBox.Any(e => e.Id == id);
        }
    }
}
