using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace KountaApp.Pages.Employee
{
    public class PayModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        [Required]
        [BindProperty]
        public DateTime? PayDate { get; set; }

        [Required]
        [BindProperty]
        public decimal? Wage { get; set; }

        [BindProperty]
        public int? EmployeeId { get; set; }
        public PayModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
        {
            this.kountaDbContext = kountaDbContext;
            _userManager = userManager;

        }

        public async Task OnGet(int employeeId)
        {
            // passing employeeid in the url 
            EmployeeId = employeeId;



            // Fetch the list of companies from the database
            //  var companies = zuriDbContext.Companies.ToList();
            // Store the companies in the model for rendering in the view
            // Assuming you have a property called "Companies" in your EmployeeModel class


            // Companies = zuriDbContext.Companies.ToList();

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return;
            }

        
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
                var pay = new KountaApp.Areas.Identity.Data.Salary()
                {
                    PayDate = PayDate,
                    Wage = Wage,
                    EmployeeId = EmployeeId,
                    UserId = user.Id
                };
                kountaDbContext.Add(pay);
                kountaDbContext.SaveChanges();


                return Redirect("/Employee/PaySlip");
            }


        }

    }
}
