using Google.DataTable.Net.Wrapper;
using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KountaApp.Pages.Invoice
{
    public class InvoiceModel : PageModel
    {
        public List<string> Customers { get; } = new List<string>
        {
        "John Smith",
        "Mary Johnson",
        "Michael Williams",
        "Linda Brown",
        "Robert Jones",
        "Sarah Davis",
        "William Wilson",
        "Patricia Evans",
        "James Anderson",
        "Jennifer Clark",
         };

        public void OnGet()
        {

        }
    }
}
