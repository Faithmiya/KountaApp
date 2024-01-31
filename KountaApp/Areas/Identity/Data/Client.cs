using System.ComponentModel.DataAnnotations;

namespace KountaApp.Areas.Identity.Data
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime? StartDate { get; set; }

        // Add FKs

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext

        // Relationships with (this model Exists as  fk in these models)

        public ICollection<Sale>? Sales { get; set; }
    }
}
