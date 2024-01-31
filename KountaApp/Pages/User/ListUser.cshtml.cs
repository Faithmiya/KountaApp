using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KountaApp.Pages.User
{
    public class ListUserModel : PageModel
    {

        private readonly KountaDbContext kountaDbContext;

        public List<KountaApp.Areas.Identity.Data.ApplicationUser> ApplicationUsers { get; set; }

        public ListUserModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }
        public void OnGet()
        {
            ApplicationUsers = kountaDbContext.ApplicationUsers.ToList();


            // Filter based on UserId
            string currentUser = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            ApplicationUsers = kountaDbContext.ApplicationUsers
                .Where(x => x.Id == currentUser)               
                .ToList();
        }
    }
}
