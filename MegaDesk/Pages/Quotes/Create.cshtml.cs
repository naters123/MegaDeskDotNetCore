using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk.Data;
using MegaDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaDesk.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public List<SelectListItem> DesktopMaterials { get; set; }

        public SelectList? RushOrders { get; set; }


        public CreateModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            DesktopMaterials = _context.DesktopMaterial.Select(a =>
                            new SelectListItem
                            {
                                Value = a.DesktopMaterialName,
                                Text = a.DesktopMaterialName
                            }).ToList();


            IQueryable<int> rushOrders = from r in _context.ShippingDaysOrder
                                         select r.ShippingDaysOption;

            RushOrders = new SelectList(await rushOrders.Distinct().ToListAsync());

            return Page();
        }

        
        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

          DeskQuote.quoteDate = DateTime.Now;

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
