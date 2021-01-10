using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chirila_Luisa_Lab9.Data;
using Chirila_Luisa_Lab9.Models;

namespace Chirila_Luisa_Lab9.Pages.Manufactures
{
    public class DetailsModel : PageModel
    {
        private readonly Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context _context;

        public DetailsModel(Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context context)
        {
            _context = context;
        }

        public Manufacture Manufacture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacture = await _context.Manufacture.FirstOrDefaultAsync(m => m.ID == id);

            if (Manufacture == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
