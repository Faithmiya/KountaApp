using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KountaApp.Pages.Employee
{
    public class ListEmployeeModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        public List<KountaApp.Areas.Identity.Data.Employee> Employees { get; set; }

        public ListEmployeeModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }

        public void OnGet()
        {
            // get all Employees
            Employees = kountaDbContext.Employees.ToList();


            // Filter based on UserId
            string currentUser = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Employees = kountaDbContext.Employees
                .Where(x => x.UserId == currentUser)
                .Include(y => y.ApplicationUsers)
                .ToList();

        }
        
    }
}
