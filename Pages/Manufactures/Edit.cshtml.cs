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

namespace Chirila_Luisa_Lab9.Pages.Manufactures
{
    public class EditModel : PageModel
    {
        private readonly Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context _context;

        public EditModel(Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Manufacture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufactureExists(Manufacture.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ManufactureExists(int id)
        {
            return _context.Manufacture.Any(e => e.ID == id);
        }
    }
}
