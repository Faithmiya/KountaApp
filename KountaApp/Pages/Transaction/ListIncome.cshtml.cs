using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KountaApp.Pages.Transaction
{
    public class ListIncomeModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        public List<KountaApp.Areas.Identity.Data.Income> Income { get; set; }

        public ListIncomeModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }

        public void OnGet()
        {
            // get all incomes
            Income = kountaDbContext.Incomes.ToList();


            // Filter based on UserId
            string currentUser = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Income = kountaDbContext.Incomes
                .Where(x => x.UserId == currentUser)
                .Include(y => y.ApplicationUsers)
                .ToList();

        }
    }
}
