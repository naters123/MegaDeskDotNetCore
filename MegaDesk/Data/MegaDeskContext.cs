using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Models;

namespace MegaDesk.Data
{
    public class MegaDeskContext : DbContext
    {
        public MegaDeskContext (DbContextOptions<MegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk.Models.DeskQuote> DeskQuote { get; set; } = default!;

        public DbSet<MegaDesk.Models.DesktopMaterial> DesktopMaterial { get; set; }

        public DbSet<MegaDesk.Models.ShippingDaysOrder> ShippingDaysOrder { get; set; }

        public DbSet<MegaDesk.Models.FileUpload> FileUpload { get; set; }
    }
}
