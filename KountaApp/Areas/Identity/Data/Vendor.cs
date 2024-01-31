using System.ComponentModel.DataAnnotations;

namespace KountaApp.Areas.Identity.Data
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        public string? VendorName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext

        // Relationships with (this model Exists as  fk in these models)
        public ICollection<Quota>? Quotas { get; set; }


    }
}
