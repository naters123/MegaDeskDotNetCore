using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.FileUploads
{
    public class EditModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public EditModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FileUpload == null)
            {
                return NotFound();
            }

            var fileupload =  await _context.FileUpload.FirstOrDefaultAsync(m => m.ID == id);
            if (fileupload == null)
            {
                return NotFound();
            }
            FileUpload = fileupload;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FileUpload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileUploadExists(FileUpload.ID))
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

        private bool FileUploadExists(int id)
        {
          return _context.FileUpload.Any(e => e.ID == id);
        }
    }
}
