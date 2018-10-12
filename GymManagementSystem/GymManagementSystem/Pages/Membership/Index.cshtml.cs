using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Data;
using GymManagementSystem.Models;

namespace GymManagementSystem.Pages.Membership
{
    public class IndexModel : PageModel
    {
        private readonly GymManagementSystem.Data.GymDbContext _context;

        public IndexModel(GymManagementSystem.Data.GymDbContext context)
        {
            _context = context;
        }

        public IList<Models.Membership> Membership { get;set; }

        public async Task OnGetAsync()
        {
            Membership = await _context.Membership.ToListAsync();
        }
    }
}
