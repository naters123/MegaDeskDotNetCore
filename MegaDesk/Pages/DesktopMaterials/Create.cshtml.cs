using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.DesktopMaterials
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public CreateModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DesktopMaterial DesktopMaterial { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DesktopMaterial.Add(DesktopMaterial);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
