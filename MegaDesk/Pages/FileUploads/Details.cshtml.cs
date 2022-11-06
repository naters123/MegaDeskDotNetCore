using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.FileUploads
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public DetailsModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

      public FileUpload FileUpload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FileUpload == null)
            {
                return NotFound();
            }

            var fileupload = await _context.FileUpload.FirstOrDefaultAsync(m => m.ID == id);
            if (fileupload == null)
            {
                return NotFound();
            }
            else 
            {
                FileUpload = fileupload;
            }
            return Page();
        }
    }
}
