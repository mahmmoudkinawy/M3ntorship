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
    public class DetailModel : PageModel
    {
        private readonly ILaptopData laptopData;

        public LaptopObjects LaptopObjects { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(ILaptopData laptopData)
        {
            this.laptopData = laptopData;
        }
        public IActionResult OnGet(int laptopId)
        {
            LaptopObjects = laptopData.GetById(laptopId);
            if(LaptopObjects == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
