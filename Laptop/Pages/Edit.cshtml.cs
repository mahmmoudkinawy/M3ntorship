using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop.Core;
using Laptop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laptop.Pages.Laptops
{
    public class EditModel : PageModel
    {
        private readonly ILaptopData laptopData;

        [BindProperty]
        public LaptopObjects LaptopObjects { get; set; }

        public EditModel(ILaptopData laptopData)
        {
            this.laptopData = laptopData;
        }
        public IActionResult OnGet(int? laptopId)
        {
            if(laptopId.HasValue)
            {
                LaptopObjects = laptopData.GetById(laptopId.Value);
            }
            else
            {
                LaptopObjects = new LaptopObjects();
            }
            if (LaptopObjects == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else if(LaptopObjects.Id > 0)
            {
                LaptopObjects = laptopData.Update(LaptopObjects);
            }
            else
            {
                LaptopObjects = laptopData.Add(LaptopObjects);
            }

            laptopData.Commit();
            TempData["Message"] = "The Laptop Has been Saved.";
            return RedirectToPage("./Detail", new { laptopId = LaptopObjects.Id });
        }
    }
}
