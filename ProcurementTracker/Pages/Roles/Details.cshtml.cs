using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;

namespace ProcurementTracker.Pages.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public DetailsModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdentityRole? Role { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id.Value.ToString());
            if(Role == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            Role!.NormalizedName = Role.Name.ToUpper();
            _context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoleExistsAsync(Role)) return NotFound();
                else throw;
            }

            return RedirectToPage("Details", new { id = Role?.Id });
        }

        private async Task<bool> RoleExistsAsync(IdentityRole? role)
        {
            if (role == null || 
                   await _context.Roles.FirstOrDefaultAsync(e => e.Id == role.Id) == null)
                   return false;
            else
                return true;
        }
    }
}