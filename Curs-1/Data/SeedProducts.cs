using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Curs_1.Data
{
    public static class SeedProducts
    {
        private static string Characters = "abcdefghijklmnopqrstuvwxyz123456890";

        public static void Seed(IServiceProvider serviceProvider, int count)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            Random random = new Random();

            if (context.Products.Count() < 10)
            {
                for (int i = 0; i < count; ++i)
                {
                    string name = "";
                    for (int j = 0; j < random.Next(3, 10); ++j)
                    {
                        name += Characters[random.Next(Characters.Length)];
                    }
                    context.Products.Add(new Models.Product
                    {
                        Name = name,
                        Price = random.NextDouble() * random.Next(200, 5000)
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
