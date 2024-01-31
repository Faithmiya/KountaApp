using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.Data
{
    public class Sale
    {
        [Key]
        public int SalesId { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalePrice { get; set; }

        public int? SaleQty { get; set; }

        public DateTime? SaleDate { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext

        public int? ClientId { get; set; }
        public Client? Client { get; set; } //Used in relationship configuration in the DbContext

        public int? ProductId { get; set; }
        public Product? Product { get; set; } //Used in relationship configuration in the DbContext
    }
}
