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
    public class ListModel : PageModel
    {
        public readonly ILaptopData laptopData;

        public IEnumerable<LaptopObjects> laptopObjects1 { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public ListModel(ILaptopData laptopData)
        {
            this.laptopData = laptopData;
        }
        public void OnGet()
        {
            laptopObjects1 = laptopData.GetLaptopByName(SearchTerm);
        }
    }
}
