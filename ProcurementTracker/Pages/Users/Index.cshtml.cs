using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;

namespace ProcurementTracker.Pages.Users
{
	[Authorize(Policy = "IsAdmin")]
	public class IndexModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public IndexModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser>? ApplicationUsers { get; set; }

        public async Task OnGetAsync()
        {
            ApplicationUsers = await _context.Users.ToListAsync();
        }
    }
}