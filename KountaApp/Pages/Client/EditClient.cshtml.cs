using KountaApp.Areas.Identity.Data;
using KountaApp.Areas.Identity.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KountaApp.Pages.Client
{
    public class EditClientModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        [BindProperty]
        public EditClient EditClient { get; set; }

        public EditClientModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }



        public void OnGet(int id)
        {
            var client = kountaDbContext.Clients.Find(id);

            if(client != null)
            {
                // convert to view model
                EditClient = new EditClient()
                {
                    // Map all fields from data model to view model
                    ClientId = client.ClientId,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    Phone = client.Phone,
                    Address = client.Address,
                    StartDate = client.StartDate,
                    // Include the fks
                    UserId = client.UserId
                };
            }


        }
        public void OnPostUpdate()
        {
            if (EditClient != null)
            {
                var existingClient = kountaDbContext.Clients.Find(EditClient.ClientId);

                if (existingClient != null)
                {
                    // Convert view model back to data model
                    // Dont include any ids pks or fks



                    existingClient.FirstName = EditClient.FirstName;
                    existingClient.LastName = EditClient.LastName;
                    existingClient.Email = EditClient.Email;
                    existingClient.Phone = EditClient.Phone;
                    existingClient.Address = EditClient.Address;

                    kountaDbContext.SaveChanges();

                    // Message

                    ViewData["Message"] = "Client Updated Successfully!";

                    Response.Redirect("/Client/ListClient");



                }

            }
        }
        public IActionResult OnPostDelete()
        {
            // find client 
            var existingClient = kountaDbContext.Clients.Find(EditClient.ClientId);

            if (existingClient != null)
            {
                kountaDbContext.Clients.Remove(existingClient);
                kountaDbContext.SaveChanges();

                return RedirectToPage("/Client/ListClient");
            }

            return Page();

        }
    }
}
