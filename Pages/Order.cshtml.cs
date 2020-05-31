using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BakeryApp.Data;
using BakeryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BakeryApp.Pages
{
    public class OrderModel : PageModel
    {
        private BakeryContext db;
        public OrderModel(BakeryContext db) => this.db = db;


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        public Product Product { get; set; }

        [BindProperty, EmailAddress, Required, Display(Name = "Your Email Address")]
        public string OrderEmail { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a shipping address"), Display(Name = "Shipping Address")]
        public string OrderShipping { get; set; }
        [BindProperty, Display(Name = "Quantity")]
        public int OrderQuantity { get; set; } = 1;


        public async Task OnGetAsync() => Product = await db.Products.FindAsync(Id);

        public async Task<IActionResult> OnPostAsync()
        {
            Product = await db.Products.FindAsync(Id);
            if (ModelState.IsValid)
            {
                return RedirectToPage("OrderSuccess");
            }
            return Page();
        }


    }
}