using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KountaApp.Pages.Client
{
    public class ClientModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        [Required]
        [BindProperty]
        public string? FirstName { get; set; }

        [Required]
        [BindProperty]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string? Email { get; set; }


        [Required]
        [Phone]
        [BindProperty]
        public string? Phone { get; set; }

        [Required]
        [BindProperty]
        public string? Address { get; set; }


        [Required]
        [BindProperty]
        public DateTime? StartDate { get; set; }


        public ClientModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
        {
            this.kountaDbContext = kountaDbContext;
            _userManager = userManager; ;
        }
        public void OnGet()
        {
        }

        public System.Security.Claims.ClaimsPrincipal GetUser()
        {
            return User;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the page with validation errors
            }




            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();

            }
            else
            {
                // Create a new client object and set its properties
                var client = new KountaApp.Areas.Identity.Data.Client()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Phone = Phone,
                    Address = Address,
                    StartDate = StartDate,
                    UserId = user.Id
                };
                kountaDbContext.Add(client);
                kountaDbContext.SaveChanges();


                return Redirect("/Client/ListClient");
            }


        }
    }
}
