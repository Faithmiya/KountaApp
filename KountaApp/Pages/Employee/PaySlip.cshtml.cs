using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KountaApp.Pages.Employee
{
    public class PaySlipModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        public List<KountaApp.Areas.Identity.Data.Salary> Salaries { get; set; }
        public PaySlipModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;

        }



        public void OnGet()
        {
            // retrieve salaries from database
            Salaries = kountaDbContext.Salaries.ToList();

            // Filter based on UserId
            string currentUser = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Salaries = kountaDbContext.Salaries
               .Where(x => x.UserId == currentUser)
               .Include(y => y.ApplicationUsers)
               .Include(z => z.Employee)
               .ToList();
        }
    }
}
