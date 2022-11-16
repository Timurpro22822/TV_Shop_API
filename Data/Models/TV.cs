using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TV
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Diagonal { get; set; }

        public string Resolution { get; set; }

        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
