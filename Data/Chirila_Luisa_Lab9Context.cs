using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chirila_Luisa_Lab9.Models;

namespace Chirila_Luisa_Lab9.Data
{
    public class Chirila_Luisa_Lab9Context : DbContext
    {
        public Chirila_Luisa_Lab9Context (DbContextOptions<Chirila_Luisa_Lab9Context> options)
            : base(options)
        {
        }

        public DbSet<Chirila_Luisa_Lab9.Models.Car> Car { get; set; }

        public DbSet<Chirila_Luisa_Lab9.Models.Manufacture> Manufacture { get; set; }

        public DbSet<Chirila_Luisa_Lab9.Models.Category> Category { get; set; }
    }
}
