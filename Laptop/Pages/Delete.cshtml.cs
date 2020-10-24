using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop.Core;
using Laptop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laptop.Pages.Shared
{
    public class DeleteModel : PageModel
    {
        private readonly ILaptopData laptopData;
        public LaptopObjects LaptopObjects { get; set; }
        public DeleteModel(ILaptopData laptopData)
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

        public IActionResult OnPost(int laptopId)
        {
            var lap = laptopData.Delete(laptopId);
            laptopData.Commit();
            if (lap == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                TempData["Message"] = $"{lap.Name} deleted.";
                return RedirectToPage("./List");
            }
        }
    }
}
