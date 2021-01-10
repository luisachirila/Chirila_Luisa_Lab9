using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chirila_Luisa_Lab9.Data;
using Chirila_Luisa_Lab9.Models;

namespace Chirila_Luisa_Lab9.Pages.Cars
{

    public class CreateModel : CarCategoriesPageModel
    {
        private readonly Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context _context;

        public CreateModel(Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufactureID"] = new SelectList(_context.Manufacture, "ID", "ManufactureName");

            var car = new Car();
            car.CarCategories = new List<CarCategory>();
            PopulateAssignedCategoryData(_context, car);


            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCar = new Car();
            if (selectedCategories != null)
            {
                newCar.CarCategories = new List<CarCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CarCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCar.CarCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Car>(
                newCar,
                "Car",
                i => i.Name, i => i.Company,
                i => i.Price, i => i.ManufactureDate, i => i.ManufactureID))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCar);
            return Page();
        }

    }
}
