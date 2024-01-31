using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KountaApp.Pages.Transaction
{
    public class ListExpensecshtmlModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        public List<KountaApp.Areas.Identity.Data.Expense> Expense { get; set; }

        public ListExpensecshtmlModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }

        public void OnGet()
        {
            // get all Expense
            Expense = kountaDbContext.Expenses.ToList();


            // Filter based on UserId
            string currentUser = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Expense = kountaDbContext.Expenses
                .Where(x => x.UserId == currentUser)
                .Include(y => y.ApplicationUsers)
                .ToList();

        }
    }
}
