using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.Data
{
    public class Quota
    {
        [Key]
        public int QuotaId { get; set; }

        public DateTime? DateCollected { get; set; }

        public int? QuotaQty { get; set; }
        [Column(TypeName = "money")]
        public decimal? QuotaPrice { get; set; }

        // Add FKs

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext

        public int? VendorId { get; set; }
        public Vendor? Vendor { get; set; } //Used in relationship configuration in the DbContext

        public int? ProductId { get; set; }
        public Product? Product { get; set; } //Used in relationship configuration in the DbContext

    }
}
