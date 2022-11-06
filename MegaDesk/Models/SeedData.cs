using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDesk.Data;
using System;
using System.Linq;

namespace MegaDesk.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskContext>>()))
            {
                // Look for any quotes.
                if (context.DeskQuote.Any())
                {
                    return;   // DB has been seeded
                }

                context.DeskQuote.AddRange(
                    new DeskQuote("Nate", 3, 24, 12, 0, "Laminate", DateTime.Now, 0),
                    new DeskQuote("Pavel", 5, 50, 24, 2, "Rosewood", DateTime.Parse("2022-2-12"), 0), 
                    new DeskQuote("Clayton", 7, 70, 36, 4, "Pine", DateTime.Parse("2022-3-14"), 0), 
                    new DeskQuote("Michael", 14, 96, 48, 7, "Oak", DateTime.Parse("2022-5-25"), 0)
                );
                context.SaveChanges();
            }
        }
    }
}