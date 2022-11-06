﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.ShippingDaysOrders
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public DetailsModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

      public ShippingDaysOrder ShippingDaysOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShippingDaysOrder == null)
            {
                return NotFound();
            }

            var shippingdaysorder = await _context.ShippingDaysOrder.FirstOrDefaultAsync(m => m.ID == id);
            if (shippingdaysorder == null)
            {
                return NotFound();
            }
            else 
            {
                ShippingDaysOrder = shippingdaysorder;
            }
            return Page();
        }
    }
}
