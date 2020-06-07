using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryApp.Data;
using BakeryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BakeryApp.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly BakeryContext _db;

        public EditProductModel(BakeryContext db)
        {
            _db = db;
        }
        [BindProperty(SupportsGet = true)]
        public Product Product { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _db.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var productToUpdate = await _db.Products.FindAsync(Id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }


            productToUpdate.Description = Product.Description;
            productToUpdate.Price = Product.Price;



            _db.Entry(productToUpdate).Property(x => x.Name).IsModified = true;
            _db.Entry(productToUpdate).Property(x => x.Description).IsModified = true;

            await _db.SaveChangesAsync();
            return RedirectToPage("./Index");

        }


    }
}