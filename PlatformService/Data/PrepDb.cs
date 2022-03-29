using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                System.Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                  new Models.Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                  new Models.Platform() {Name="SQL Server", Publisher="Microsoft", Cost="Free"},
                  new Models.Platform() {Name="Dot Net 6", Publisher="Microsoft", Cost="Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}