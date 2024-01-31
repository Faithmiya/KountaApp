using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.Net;

namespace KountaApp.Pages.Transaction
{
    public class IncomeModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        [Required]
        [BindProperty]
        public decimal? Amount { get; set; }
        [Required]
        [BindProperty]
        public string? Category { get; set; }
        [Required]
        [BindProperty]
        public string? Description { get; set; }
        [Required]
        [BindProperty]
        public DateTime? Date { get; set; }

        [BindProperty]
        public List<string> categories { get; set; }


        public IncomeModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
        {
            this.kountaDbContext = kountaDbContext;
            _userManager = userManager;

            // add income categories to the list

            categories = new List<string>
            {
                "Commission",
                "Tips",
                "Donation",
                "Sales",
                "Grants",
                "Rental income",
                "Disposal of Fixed Assests",
            };
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
                // Create a new income object and set its properties
                var income = new KountaApp.Areas.Identity.Data.Income()
                {
                    Amount = Amount,
                    Category = Category,
                    Description = Description,
                    Date = Date,
                    UserId = user.Id
                };
                kountaDbContext.Add(income);
                kountaDbContext.SaveChanges();


                return Redirect("/Transaction/ListIncome");
            }


        }
    }
}
