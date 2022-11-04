using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace MegaDesk.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public IndexModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<DeskQuote> DeskQuote { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string date { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            var quotes = from d in _context.DeskQuote
                         select d;
            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(s => s.CustomerName.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    quotes = quotes.OrderByDescending(s => s.CustomerName);
                    break;
                case "Date":
                    quotes = quotes.OrderBy(s => s.quoteDate);
                    break;
                case "date_desc":
                    quotes = quotes.OrderByDescending(s => s.quoteDate);
                    break;
                default:
                    quotes = quotes.OrderBy(s => s.CustomerName);
                    break;
            }

            DeskQuote = await quotes.ToListAsync();
        }
    }
}
