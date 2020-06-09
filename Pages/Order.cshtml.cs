using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BakeryApp.Data;
using BakeryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using Microsoft.Extensions.Hosting;

namespace BakeryApp.Pages
{
    public class OrderModel : PageModel
    {
        private BakeryContext db;
        private IHostEnvironment _env;
        private BakeryContext _db;

        public OrderModel(IHostEnvironment env, BakeryContext db)
        {
            _env = env;
            _db = db;
        }


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        public Product Product { get; set; }

        [BindProperty, EmailAddress, Required, Display(Name = "Your Email Address")]
        public string OrderEmail { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a shipping address"), Display(Name = "Shipping Address")]
        public string OrderShipping { get; set; }
        [BindProperty, Display(Name = "Quantity")]
        public int OrderQuantity { get; set; } = 1;


        public async Task OnGetAsync() => Product = await _db.Products.FindAsync(Id);

        public async Task<IActionResult> OnPostAsync()
        {
            Product = await _db.Products.FindAsync(Id);
            if (ModelState.IsValid)
            {
                var body = $@"<p>Thank you, we have received your order for {OrderQuantity} unit(s) of {Product.Name}!</p>
                <p>Your address is: <br/>{OrderShipping.Replace("\n", "<br/>")}</p>
                Your total is ${Product.Price * OrderQuantity}.<br/>
                We will contact you if we have questions about your order.  Thanks!<br/>";
                using (var smtp = new SmtpClient())
                {

                    var wwwRoot = _env.ContentRootPath + "\\wwwroot\\";
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = wwwRoot;
                    var message = new MailMessage();
                    message.To.Add(OrderEmail);
                    message.Subject = "Fourth Coffee - New Order";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress("sales@fourthcoffee.com");
                    await smtp.SendMailAsync(message);
                }

                return RedirectToPage("OrderSuccess");
            }
            return Page();
        }


    }
}