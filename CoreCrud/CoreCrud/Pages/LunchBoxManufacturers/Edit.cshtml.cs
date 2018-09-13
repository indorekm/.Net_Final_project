using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.LunchBoxManufacturers
{
    public class EditModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public EditModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LunchBoxManufacturer LunchBoxManufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LunchBoxManufacturer = await _context.LunchBoxManufacturer.FirstOrDefaultAsync(m => m.Id == id);

            if (LunchBoxManufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LunchBoxManufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LunchBoxManufacturerExists(LunchBoxManufacturer.Id))
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

        private bool LunchBoxManufacturerExists(int id)
        {
            return _context.LunchBoxManufacturer.Any(e => e.Id == id);
        }
    }
}
