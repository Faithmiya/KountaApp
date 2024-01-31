using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace KountaApp.Pages.Product
{
    public class ProductModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        [Required]
        [BindProperty]
        public string? ProductName { get; set; }

        [Required]
        [BindProperty]
        public string? ProductDescription { get; set; }

        [Required]
        [BindProperty]
        public decimal? ProductPrice { get; set; }

        public ProductModel(KountaDbContext kountaDbContext, UserManager<ApplicationUser> userManager)
        {
            this.kountaDbContext = kountaDbContext;
            _userManager = userManager; ;
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
                // Create a new client object and set its properties
                var product = new KountaApp.Areas.Identity.Data.Product()
                {
                    ProductName = ProductName,
                    ProductDescription = ProductDescription,
                    ProductPrice = ProductPrice,
                    UserId = user.Id
                };
                kountaDbContext.Add(product);
                kountaDbContext.SaveChanges();


               return Redirect("/Product/ListProduct");
            }


        }
    }
}
