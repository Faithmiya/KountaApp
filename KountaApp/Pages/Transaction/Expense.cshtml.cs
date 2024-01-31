using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KountaApp.Pages.Transaction
{
    public class ExpenseModel : PageModel
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

        public ExpenseModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
        {
            this.kountaDbContext = kountaDbContext;
            _userManager = userManager; 

            // add expense categories to the list

            categories = new List<string>
            {
                "Rent",
                "Utilities",
                "Transportation",
                "Insurance",
                "Administration",
                "Repairs and Maintenance",
                "Depreciation",
                "Marketing",
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
                // Create a new expense object and set its properties
                var expense = new KountaApp.Areas.Identity.Data.Expense()
                {
                    Amount = Amount,
                    Category = Category,
                    Description = Description,
                    Date = Date,
                    UserId = user.Id
                };
                kountaDbContext.Add(expense);
                kountaDbContext.SaveChanges();


                return Redirect("/Transaction/ListExpense");
            }


        }
    }
}
