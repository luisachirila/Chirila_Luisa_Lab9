using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirila_Luisa_Lab9.Models
{
    public class Manufacture
    {
        public int ID { get; set; }
        public string ManufactureName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
