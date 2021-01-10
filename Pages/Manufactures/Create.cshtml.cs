using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chirila_Luisa_Lab9.Data;
using Chirila_Luisa_Lab9.Models;

namespace Chirila_Luisa_Lab9.Pages.Manufactures
{
    public class CreateModel : PageModel
    {
        private readonly Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context _context;

        public CreateModel(Chirila_Luisa_Lab9.Data.Chirila_Luisa_Lab9Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manufacture Manufacture { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Manufacture.Add(Manufacture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
