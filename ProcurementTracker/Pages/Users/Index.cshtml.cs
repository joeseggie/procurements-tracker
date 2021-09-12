using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;

namespace ProcurementTracker.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public IndexModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<IdentityUser>? ApplicationUsers { get; set; }

        public async Task OnGet()
        {
            ApplicationUsers = await _context.Users.ToListAsync();
        }
    }
}