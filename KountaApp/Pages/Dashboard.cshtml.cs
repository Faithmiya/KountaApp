using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KountaApp.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        // Inject Table you want a list from
        public List<Expense> Expenses { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Salary> Salaries { get; set; }

        public DashboardModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
        {
            this.kountaDbContext = kountaDbContext;
            _userManager = userManager;
        }



        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetChartDataAsync()
        {
            /*var pizzaToppings = purpleDbContext.Pizzas.ToList();

            var json = pizzaToppings.ToGoogleDataTable()
                .NewColumn(new Column(ColumnType.String, "Topping"), x => x.Name)
                .NewColumn(new Column(ColumnType.Number, "Slices"), x => x.Count)
                .Build()
                .GetJson();

            return Content(json);*/

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            var expense = kountaDbContext.Expenses
                .Where(expense => expense.UserId == user.Id)
                .ToList();

            var json = expense.ToGoogleDataTable()
                .NewColumn(new Column(ColumnType.String, "Category"), x => x.Category)
                .NewColumn(new Column(ColumnType.Number, "Amount"), x => x.Amount)
                .Build()
                .GetJson();

            return Content(json);
        }


        // Income
        public async Task<IActionResult> OnGetIncomeChartDataAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            var income = kountaDbContext.Incomes
                .Where(income => income.UserId == user.Id)
                .ToList();

            var json = income.ToGoogleDataTable()
                .NewColumn(new Column(ColumnType.String, "Category"), x => x.Category)
                .NewColumn(new Column(ColumnType.Number, "Amount"), x => x.Amount)
                .Build()
                .GetJson();

            return Content(json);
        }

        // Salary
        public async Task<IActionResult> OnGetSalaryChartDataAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            var wage = kountaDbContext.Salaries
                .Where(wage => wage.UserId == user.Id)
                .ToList();

            var json = wage.ToGoogleDataTable()
                .NewColumn(new Column(ColumnType.String, "Date"), x => x.PayDate)
                .NewColumn(new Column(ColumnType.Number, "Wage"), x => x.Wage)
                .Build()
                .GetJson();

            return Content(json);
        }
    }
}
