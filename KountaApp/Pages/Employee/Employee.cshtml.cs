using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace KountaApp.Pages.Employee
{
    public class EmployeeModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;


        [Required]
        [BindProperty]
        public string? Position { get; set; }

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
        public EmployeeModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
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
                // Create a new employee object and set its properties
                var employee = new KountaApp.Areas.Identity.Data.Employee()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Phone = Phone,
                    Position = Position,
                    UserId = user.Id
                };
                kountaDbContext.Add(employee);
                kountaDbContext.SaveChanges();


                return Redirect("/Employee/ListEmployee");
            }


        }
    }
}
