using System;
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
    public class IndexModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public IndexModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public IList<ShippingDaysOrder> ShippingDaysOrder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ShippingDaysOrder != null)
            {
                ShippingDaysOrder = await _context.ShippingDaysOrder.ToListAsync();
            }
        }
    }
}
