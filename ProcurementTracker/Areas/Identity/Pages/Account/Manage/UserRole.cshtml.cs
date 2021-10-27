using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Areas.Identity.Pages.Account.Manage
{
	[Authorize(Policy = "IsAdmin")]
	public class UserRoleModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ILogger<ChangePasswordModel> _logger;
		private readonly ProcurementTrackerContext _context;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserRoleModel(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			ILogger<ChangePasswordModel> logger,
			ProcurementTrackerContext context,
			RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_context = context;
			_roleManager = roleManager;
		}

		[BindProperty]
		public string? Username { get; set; }

		[Display(Name = "Assigned Role")]
		public string? AssignedRole { get; set; }

		public List<SelectListItem>? RoleSelectList { get; set; }

		[BindProperty]
		public InputModel? Input { get; set; }

		[TempData]
		public string? StatusMessage { get; set; }

		public class InputModel
		{
			[Required]
			[Display(Name = "Select role to assign")]
			public string? RoleId { get; set; }
		}

		public async Task<IActionResult> OnGetAsync(string? username)
		{
			ApplicationUser user;
			Username = username;

			if (Username is null)
				user = await _userManager.GetUserAsync(User);
			else
				user = await _userManager.FindByNameAsync(Username);

			if (user == null)
			{
				return NotFound($"Unable to load user.");
			}

			IList<string>? userRoles = await _userManager.GetRolesAsync(user);
			if (userRoles is not null && userRoles.Count > 0)
			{
				AssignedRole = userRoles.First();
				Input = new InputModel
				{
					RoleId = await _roleManager.GetRoleIdAsync(new IdentityRole { Name = AssignedRole })
				};
			}

			List<IdentityRole>? roles = await _context.Roles.ToListAsync();
			RoleSelectList = roles.Select(r => new SelectListItem(r.Name, r.Id, IsDefaultOption(r.Name, userRoles))).ToList();

			return Page();
		}

		private static bool IsDefaultOption(string name, IList<string>? roles)
		{
			if (roles == null || roles.Count < 1)
			{
				return name == "Procurement Officer PDU";
			}
			else
			{
				return name == roles.First();
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || Username is null)
			{
				return Page();
			}

			var user = await _userManager.FindByNameAsync(Username);
			if (user == null)
			{
				return NotFound($"Unable to load user.");
			}

			IEnumerable<string> userAssignedRoles = await _userManager.GetRolesAsync(user);
			IdentityResult clearRoleMembershipResult = await _userManager.RemoveFromRolesAsync(user, userAssignedRoles);

			if (clearRoleMembershipResult.Succeeded)
			{
				var selectedRole = await _roleManager.FindByIdAsync(Input?.RoleId);
				var userRoleAssignmentResult = await _userManager.AddToRoleAsync(user, selectedRole.Name);
				if (userRoleAssignmentResult.Succeeded)
				{
					_logger.LogInformation($"User has been assigned to role {selectedRole.Name} successfully.");
					StatusMessage = $"User has been assigned to role {selectedRole.Name}.";

					return RedirectToPage(new { username = Username });
				}
				else
				{
					foreach (var error in userRoleAssignmentResult.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
					return Page();
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Error assigning user to role selected");
				return Page();
			}
		}
	}
}
