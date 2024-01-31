using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KountaApp.Pages.Vendor
{
    public class VendorModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        [Required]
        [BindProperty]
        public string? VendorName { get; set; }


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
        public string? City { get; set; }

        public VendorModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
        {
            this.kountaDbContext = kountaDbContext;
            _userManager = userManager;
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
                // Create a new vendor object and set its properties
                var vendor = new KountaApp.Areas.Identity.Data.Vendor()
                {
                    Email = Email,
                    Phone = Phone,
                    City = City,
                    VendorName = VendorName,
                    Address = Address,
                    UserId = user.Id
                };
                kountaDbContext.Add(vendor);
                kountaDbContext.SaveChanges();


                return Redirect("/Vendor/ListVendor");
            }


        }
    }
}
