using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chirila_Luisa_Lab9.Data;
using Chirila_Luisa_Lab9.Models;

namespace Chirila_Luisa_Lab9.Pages.Cars
{
    public class EditModel : CarCategoriesPageModel
    {
        private readonly Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context _context;

        public EditModel(Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Car = await _context.Car
           .Include(b => b.Manufacture)
           .Include(b => b.CarCategories).ThenInclude(b => b.Category)
           .AsNoTracking()
           .FirstOrDefaultAsync(m => m.ID == id);


            if (Car == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Car);

            ViewData["ManufactureID"] = new SelectList(_context.Set<Manufacture>(), "ID", "ManufactureName");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carToUpdate = await _context.Car
            .Include(i => i.Manufacture)
            .Include(i => i.CarCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (carToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Car>(
            carToUpdate,
            "Car",
            i => i.Name, i => i.Company,
            i => i.Price, i => i.ManufacturingDate, i => i.Manufacture))
            {
                UpdateCarCategories(_context, selectedCategories, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCarCategories(_context, selectedCategories, carToUpdate);
            PopulateAssignedCategoryData(_context, carToUpdate);
            return Page();
        }
    }
}