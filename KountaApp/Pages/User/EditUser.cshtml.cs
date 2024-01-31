using KountaApp.Areas.Identity.Data;
using KountaApp.Areas.Identity.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace KountaApp.Pages.User
{
    public class EditUserModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        [BindProperty]
        public EditUser EditUser { get; set; }

        public EditUserModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }
        public void OnGet(string id)
        {
            var user = kountaDbContext.ApplicationUsers.Find(id);

            if (user != null)
            {
                
                EditUser = new EditUser()
                {
                    
                      
                    Address = user.Address,
                    LastName = user.LastName,
                    CompanyName = user.CompanyName,
                    FirstName = user.FirstName,
                    City = user.City,
                    
                    
                };
            }
        }
        public void OnPostUpdate(string id)
        {
            if (EditUser != null)
            {
                
                var existingUser = kountaDbContext.ApplicationUsers.Find(id);

                if (existingUser != null)
                {

                    
                    existingUser.FirstName = EditUser.FirstName;
                    existingUser.LastName = EditUser.LastName;
                    existingUser.Address = EditUser.Address;
                    existingUser.City = EditUser.City;
                    existingUser.CompanyName = EditUser.CompanyName;
                    kountaDbContext.SaveChanges();

                    // Message

                    ViewData["Message"] = "User Information Updated Successfully!";

                    Response.Redirect("/User/ListUser");



                }

            }
        }
    }
}
