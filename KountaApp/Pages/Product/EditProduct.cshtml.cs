using KountaApp.Areas.Identity.Data;
using KountaApp.Areas.Identity.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KountaApp.Pages.Product
{
    public class EditProductModel : PageModel
    {
        private readonly KountaDbContext kountaDbContext;

        [BindProperty]
        public EditProduct EditProduct { get; set; }

        public EditProductModel(KountaDbContext kountaDbContext)
        {
            this.kountaDbContext = kountaDbContext;
        }
        public void OnGet(int id)
        {
            var product = kountaDbContext.Products.Find(id);

            if (product != null)
            {
                // convert to view model
                EditProduct = new EditProduct()
                {
                    // Map all fields from data model to view model
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    // Include the fks
                    UserId = product.UserId
                };
            }


        }
        public void OnPostUpdate()
        {
            if (EditProduct != null)
            {
                var existingProduct = kountaDbContext.Products.Find(EditProduct.ProductId);

                if (existingProduct != null)
                {
                    // Convert view model back to data model
                    // Dont include any ids pks or fks



                    existingProduct.ProductId = EditProduct.ProductId;
                    existingProduct.ProductName = EditProduct.ProductName;
                    existingProduct.ProductDescription = EditProduct.ProductDescription;
                    existingProduct.ProductPrice = EditProduct.ProductPrice;

                    kountaDbContext.SaveChanges();

                    // Message

                    ViewData["Message"] = "Product Updated Successfully!";

                    Response.Redirect("/Product/ListProduct");



                }

            }
        }

        public IActionResult OnPostDelete()
        {
            // find employee 
            var existingProduct = kountaDbContext.Products.Find(EditProduct.ProductId);

            if (existingProduct != null)
            {
                kountaDbContext.Products.Remove(existingProduct);
                kountaDbContext.SaveChanges();

                return RedirectToPage("/Product/ListProduct");
            }

            return Page();

        }
    }
}
