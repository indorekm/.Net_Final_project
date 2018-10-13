using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymManagementSystem.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "FITNESS IS A LIFESTYLE AND NOT A ROUTINE TO BE PERFORMED AS A CHORE";
        }
    }
}
