using KountaApp.Areas.Identity.Data;
using KountaApp.Areas.Identity.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KountaApp.Pages.Vendor
{
    public class EditVendorModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;


        [BindProperty]
        public EditVendor EditVendor { get; set; }

        public EditVendorModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }

        public void OnGet(int id)
        {
            var vendor = kountaDbContext.Vendors.Find(id);

            if (vendor != null)
            {
                // convert to view model
                EditVendor = new EditVendor()
                {
                    // Map all fields from data model to view model
                    VendorId = vendor.VendorId,
                    VendorName = vendor.VendorName,
                    Email = vendor.Email,
                    Phone = vendor.Phone,
                    Address = vendor.Address,
                    City = vendor.City,
                    // Include the fks
                    UserId = vendor.UserId
                };
            }


        }
        public void OnPostUpdate()
        {
            if (EditVendor != null)
            {
                var existingVendor = kountaDbContext.Vendors.Find(EditVendor.VendorId);

                if (existingVendor != null)
                {
                    // Convert view model back to data model
                    // Dont include any ids pks or fks



                    existingVendor.VendorName = EditVendor.VendorName;
                    existingVendor.Email = EditVendor.Email;
                    existingVendor.Phone = EditVendor.Phone;
                    existingVendor.Address = EditVendor.Address;
                    existingVendor.City = EditVendor.City;

                    kountaDbContext.SaveChanges();

                    // Message

                    ViewData["Message"] = "Vendor Updated Successfully!";

                    Response.Redirect("/Vendor/ListVendor");



                }

            }
        }
        public IActionResult OnPostDelete()
        {
            // find vendor 
            var existingVendor = kountaDbContext.Vendors.Find(EditVendor.VendorId);

            if (existingVendor != null)
            {
                kountaDbContext.Vendors.Remove(existingVendor);
                kountaDbContext.SaveChanges();

                return RedirectToPage("/Vendor/Vendor");
            }

            return Page();

        }

    }
}
