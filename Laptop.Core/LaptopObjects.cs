using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Laptop.Core
{
    public class LaptopObjects
    {
        public int Id { get; set; }

        [Required,StringLength(40)]
        public string Name { get; set; }

        [Required, StringLength(40)]
        public string Color { get; set; }

        [Required]
        public int Generation { get; set; }

        [Required]
        public int Model { get; set; }

        [Required]
        [Range(0,256)]
        public int Ram { get; set; }

        [Required]
        [Range(0,10000)]
        [Display(Name="Hard Disk")]
        public int HardDisk { get; set; }
    }
}
