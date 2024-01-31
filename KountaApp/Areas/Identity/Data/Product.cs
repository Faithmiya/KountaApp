using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.Data
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal? ProductPrice { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext

        // Relationships with (this model Exists as  fk in these models)

        public ICollection<Quota>? Quotas { get; set; }
        public ICollection<Sale>? Sales { get; set; }
    }
}
