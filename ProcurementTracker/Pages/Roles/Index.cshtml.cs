using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;

namespace ProcurementTracker.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public IndexModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<IdentityRole>? Roles { get; set; }

        public async Task OnGetAsync()
        {
            Roles = await _context.Roles.ToListAsync();
        }
    }
}