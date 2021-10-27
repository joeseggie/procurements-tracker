using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProcurementTracker.Models;
using ProcurementTracker.Shared.Extensions;

namespace ProcurementTracker.Areas.Identity.Pages.Account.Manage
{
	[Authorize(Policy = "IsAdmin")]
	public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public string? Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "First name")]
            public string? Firstname { get; set; }

            [Display(Name = "Last name")]
            public string? Lastname { get; set; }

            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
        }

        private void LoadUser(ApplicationUser user)
        {
            Username = user.UserName;
            Input = new InputModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
            };
        }

        public async Task<IActionResult> OnGetAsync(string? username)
        {
            ApplicationUser user;

            if(username is null)
                user = await _userManager.GetUserAsync(User);
            else
                user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            LoadUser(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByNameAsync(Username);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                LoadUser(user);
                return Page();
            }

            if (Input.Firstname != user.Firstname || Input.Lastname != user.Lastname || Input.Email != user.Email)
            {
                user.Firstname = Input.Firstname;
                user.Lastname = Input.Lastname;
                user.Email = Input.Email;

                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (userUpdateResult.Succeeded is not true)
                {
                    StatusMessage = "Unexpected error when trying to set first name or last name.";
                    return RedirectToPage(new { username = Username });
                }
            }
            StatusMessage = "Profile has been updated";
            return RedirectToPage(new { username = Username});
        }
    }
}
