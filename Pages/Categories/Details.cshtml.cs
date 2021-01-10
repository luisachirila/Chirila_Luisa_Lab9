using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chirila_Luisa_Lab9.Data;
using Chirila_Luisa_Lab9.Models;

namespace Chirila_Luisa_Lab9.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context _context;

        public DetailsModel(Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
