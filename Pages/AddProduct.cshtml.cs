using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BakeryApp.Data;
using BakeryApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace BakeryApp.Pages
{
    public class AddProductModel : PageModel
    {
        private IHostEnvironment _env;
        private readonly BakeryContext _db;


        public AddProductModel(IHostEnvironment env, BakeryContext db)
        {
            _env = env;
            _db = db;
        }
        



        
        private BakeryContext db;
       
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public IFormFile ImageName { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {

                string FileName = Path.GetFileNameWithoutExtension(ImageName.FileName);
                var wwwRoot = _env.ContentRootPath+ "\\wwwroot\\Images\\Products\\Thumbnails";
                //var productfolder = _env.ContentRootPath + "\\wwwroot\\Images\\Products";
                //FileName = GetUniqueFileName(FileName);
                string Extension = Path.GetExtension(ImageName.FileName);
                FileName = FileName + Extension;
                var uploads = Path.Combine(wwwRoot, FileName);
                
                var productfolder = _env.ContentRootPath + "\\wwwroot\\Images\\Products";


                var filePath = Path.Combine(productfolder, FileName);
                ImageName.CopyTo(new FileStream(uploads, FileMode.Create));
                ImageName.CopyTo(new FileStream(filePath, FileMode.Create));

                var model = new Product();
                model.Name = Name;
                model.Description = Description;
                model.Price = Price;
                model.ImageName = FileName;
                


                _db.Add(model);
                _db.SaveChanges();



                return RedirectToPage("ProductSuccess");
            }
            return Page();
        }
    }
}