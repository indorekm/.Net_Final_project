using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.LunchBoxManufacturers
{
    public class IndexModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrudContext _context;

        public IndexModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }

        public IList<LunchBoxManufacturer> LunchBoxManufacturer { get;set; }

        public async Task OnGetAsync()
        {
            LunchBoxManufacturer = await _context.LunchBoxManufacturer.ToListAsync();
        }
    }
}
