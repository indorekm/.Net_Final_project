using System.Collections.Generic;
using System.Linq;
using GymManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Pages
{
    public class SearchCustomerModel : PageModel
    {
        private GymDbContext _context;

        public SearchCustomerModel(GymDbContext context)
        {
            _context = context;
        }
            
        [BindProperty]
        public string SearchCustomerName { get; set; }        

        // WE WILL USE THIS PROPERTY TO TRACK IF A SEARCH HAS BEEN PERFORMED
        public bool SearchCompleted { get; set; }

        // WE WILL STORE THE RESULTS IN THIS PROPERTY
        public ICollection<Models.Customer> SearchResults { get; set; }

        public void OnGet()
        {            
            SearchCompleted = false;
        }

        public void OnPost()
        {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(SearchCustomerName))
            {
                // EXIT EARLY IF THERE IS NO SEARCH TERM PROVIDED                
                return;
            }

            SearchResults = _context.Customers
                                    .Include(c => c.Membership)
                                    .Include(c => c.Schedule)
                                    .Where(s => s.Name.ToLower().Contains(SearchCustomerName.ToLower()))
                                    .ToList();
            SearchCompleted = true;            
        }
    }
}