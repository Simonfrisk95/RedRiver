using BookQuotes.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookQuotes.Api.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await db.Database.MigrateAsync();

            if (!db.Users.Any())
            {
                db.Users.Add(new User { UserName = "demo", Password = "demo" });
                await db.SaveChangesAsync();
            }

            if (!db.Books.Any())
            {
                db.Books.AddRange(
                    new Book { Title = "Clean Code", Author = "Robert C. Martin", Published = new DateTime(2008, 8, 1) },
                    new Book { Title = "Domain‑Driven Design", Author = "Eric Evans", Published = new DateTime(2003, 8, 30) }
                );
                await db.SaveChangesAsync();
            }
        }
    }
}
