using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.FileUploads
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        private IHostEnvironment _environment;

        public CreateModel(MegaDesk.Data.MegaDeskContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IFormFile Upload { get; set; }
        

        [BindProperty]
        public FileUpload FileUpload { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images", Upload.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }


            FileUpload.FilePath = filePath;

            _context.FileUpload.Add(FileUpload);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
