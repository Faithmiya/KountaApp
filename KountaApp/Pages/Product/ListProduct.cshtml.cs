using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KountaApp.Pages.Product
{
    public class ListProductModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        public List<KountaApp.Areas.Identity.Data.Product> Products { get; set; }

        public ListProductModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }


        public void OnGet()
        {
            // get all Products
            Products = kountaDbContext.Products.ToList();


            // Filter based on UserId
            string currentUser = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Products = kountaDbContext.Products
                .Where(x => x.UserId == currentUser)
                .Include(y => y.ApplicationUsers)
                .ToList();

        }
    }
}
