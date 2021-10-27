using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProcurementTracker.Models;

namespace ProcurementTracker.Areas.Identity.Pages.Account.Manage
{
	[Authorize(Policy = "IsAdmin")]
	public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
		public string? Username { get; set; }

		[BindProperty]
        public InputModel? Input { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string? NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string? username)
        {
            ApplicationUser? user;
            Username = username;

			if (Username is null)
			{
                user = await _userManager.GetUserAsync(User);
            }
            else
			{
                user = await _userManager.FindByNameAsync(Username);
            }
            
            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user;
            if (Username is null)
            {
                user = await _userManager.GetUserAsync(User);
            }
            else
            {
                user = await _userManager.FindByNameAsync(Username);
            }

            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

			if (string.Equals(Input?.NewPassword, Input?.ConfirmPassword))
            {
                IdentityResult removeUserPasswordResult = await _userManager.RemovePasswordAsync(user);
				if (removeUserPasswordResult.Succeeded)
				{
					var addPasswordResult = await _userManager.AddPasswordAsync(user, Input?.NewPassword);
					if (!addPasswordResult.Succeeded)
					{
						foreach (var error in addPasswordResult.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);
						}
						return Page();
					}

					StatusMessage = "User password has been changed.";

					return RedirectToPage(); 
				}
                else
				{
                    ModelState.AddModelError(string.Empty, "Changing user password failed.");
                    return Page();
                }
            }
            else
			{
                ModelState.AddModelError(string.Empty, "Please confirm password the new password.");
                return Page();
			}
        }
    }
}
