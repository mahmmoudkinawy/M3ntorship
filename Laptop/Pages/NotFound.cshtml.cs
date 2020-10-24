using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laptop.Pages.Laptops
{
    public class NotFoundModel : PageModel
    {
        public LaptopObjects LaptopObjects { get; set; }
        public void OnGet()
        {
            LaptopObjects = new LaptopObjects();
        }
    }
}
