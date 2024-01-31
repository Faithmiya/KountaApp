using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KountaApp.Pages.Vendor
{
    public class ListVendorModel : PageModel
    {

        private readonly KountaDbContext kountaDbContext;

        public List<KountaApp.Areas.Identity.Data.Vendor> Vendors { get; set; }

        public ListVendorModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }

        public void OnGet()
        {
            // get all vendors
            Vendors = kountaDbContext.Vendors.ToList();


            // Filter based on UserId
            string currentUser = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Vendors = kountaDbContext.Vendors
                .Where(x => x.UserId == currentUser)
                .Include(y => y.ApplicationUsers)
                .ToList();

        }
    }
}
