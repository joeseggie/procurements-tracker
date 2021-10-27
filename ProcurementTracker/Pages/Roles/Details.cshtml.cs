using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;

namespace ProcurementTracker.Pages.Roles
{
    [Authorize(Policy = "IsAdmin")]
    public class DetailsModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public DetailsModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdentityRole? Role { get; set; }

        public List<RoleApplicationAction>? ProcurementActions { get; set; }

        public List<RoleApplicationAction>? BidActions { get; set; }

        public List<RoleApplicationAction>? SupplierActions { get; set; }

        public List<RoleApplicationAction>? UserActions { get; set; }

        public List<RoleApplicationAction>? RoleActions { get; set; }

        [BindProperty]
        public List<string>? SelectedActions { get; set; }

        public List<Guid?>? SelectedActionsIdsAsGuid { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id.Value.ToString());
            if(Role == null) return NotFound();

            if (_context.ApplicationActions != null)
            {
                Guid roleId = Guid.Parse(Role.Id);

                var roleApplicationActions = await (from a in _context.ApplicationActions
                from r in _context.RoleApplicationActions!.Where(r => r.ApplicationActionId == a.Id && r.RoleId == roleId).DefaultIfEmpty()
                select new RoleApplicationAction{
                    ApplicationAction = new ApplicationAction{
                        Id = a.Id,
                        Action = a.Action,
                        Description = a.Description,
                        Area = a.Area
                    },
                    Id = (Guid?)r.Id,
                    ApplicationActionId = (Guid?)r.ApplicationActionId,
                    RoleId = (Guid?)r.RoleId
                }).ToListAsync();


                ProcurementActions = roleApplicationActions.Where(a => a.ApplicationAction?.Area == "PROCUREMENTS").ToList();
                BidActions = roleApplicationActions.Where(a => a.ApplicationAction?.Area == "BIDS").ToList();
                SupplierActions = roleApplicationActions.Where(a => a.ApplicationAction?.Area == "SUPPLIERS").ToList();
                UserActions = roleApplicationActions.Where(a => a.ApplicationAction?.Area == "USERS").ToList();
                RoleActions = roleApplicationActions.Where(a => a.ApplicationAction?.Area == "ROLES").ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            Role!.NormalizedName = Role.Name.ToUpper();
            _context.Attach(Role).State = EntityState.Modified;

            Guid roleId = Guid.Parse(Role.Id);
            var roleApplicationActions = await _context.RoleApplicationActions!.Where(r => r.RoleId == roleId).ToListAsync();

            try
            {
                if (roleApplicationActions is not null && SelectedActions is not null)
                {
                    foreach (string id in SelectedActions)
                    {
                        Guid applicationActionId = Guid.Parse(id);
                        if (!roleApplicationActions.Any(r => r.ApplicationActionId == applicationActionId))
                        {
                            var roleApplicationActionAssignment = new RoleApplicationAction{
                                RoleId = roleId,
                                ApplicationActionId = applicationActionId
                            };

                            await _context.RoleApplicationActions!.AddAsync(roleApplicationActionAssignment);
                        }
                    }

                    SelectedActions.ForEach(ConvertStringIdToGuid);
                    if (SelectedActionsIdsAsGuid is not null)
                    {
                        var roleApplicationActionsToRemove = _context.RoleApplicationActions?.Where(r => !SelectedActionsIdsAsGuid.Contains(r.ApplicationActionId));
                        _context.RoleApplicationActions?.RemoveRange(roleApplicationActionsToRemove);
                    }
                }
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

        private void ConvertStringIdToGuid(string input)
        {
            if (SelectedActionsIdsAsGuid is null)
                SelectedActionsIdsAsGuid = new List<Guid?>();

            SelectedActionsIdsAsGuid.Add(Guid.Parse(input));
        }
    }
}