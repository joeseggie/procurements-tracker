using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProcurementTracker.Data;

namespace ProcurementTracker.Pages.Admin
{
	[Authorize(Policy = "IsAdmin")]
	public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}