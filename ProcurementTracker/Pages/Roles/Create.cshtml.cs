using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProcurementTracker.Data;
using ProcurementTracker.Shared;

namespace ProcurementTracker.Pages.Roles
{
    [Authorize(Policy = "IsAdmin")]
    public class CreateModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public CreateModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdentityRole? Role { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (Role != null && Role.Name != null)
            {
                Role.NormalizedName = Role.Name.ToUpper();
            }
            else
            {
                ModelState.AddModelError("Name", "Name is required");
                return Page();
            }

            _context.Roles.Add(Role);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}