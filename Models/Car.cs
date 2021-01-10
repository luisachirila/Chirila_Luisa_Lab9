using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chirila_Luisa_Lab9.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Car Name")]
        public string Name { get; set; }
        [RegularExpression (@"^[A-Z][a-z]+\s[A-Z][a-z]+$"), Required, StringLength(50, MinimumLength = 3)]
        public string Company { get; set; }
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ManufacturingDate { get; set; }

        public int ManufactureID { get; set; }
        public Manufacture Manufacture { get; set; }
        public ICollection<CarCategory> CarCategories { get; set; }
        public object ManufactureDate { get; internal set; }
    }
}
