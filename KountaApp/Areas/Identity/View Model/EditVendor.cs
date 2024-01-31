using KountaApp.Areas.Identity.Data;

namespace KountaApp.Areas.Identity.View_Model
{
    public class EditVendor
    {
        public int VendorId { get; set; }

        public string? VendorName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext
    }
}
