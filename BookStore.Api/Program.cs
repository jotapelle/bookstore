using BookStore.DataAccess.Context;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureServices(services =>
            {
                ServiceDescriptor descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BookStoreContext>));

                services.Remove(descriptor);

                SqliteConnection _connection = new("DataSource=:memory:");
                _connection.Open();

                services.AddDbContext<BookStoreContext>(options =>
                {
                    options.UseSqlite(_connection);
                });

                ServiceProvider sp = services.BuildServiceProvider();

                using IServiceScope scope = sp.CreateScope();
                IServiceProvider serviceProvider = scope.ServiceProvider;
                IWebHostEnvironment environment = serviceProvider.GetService<IWebHostEnvironment>();
                BookStoreContext db = serviceProvider.GetRequiredService<BookStoreContext>();

                db.Database.EnsureCreated();

                try
                {
                    InitializeBooks(db);
                    InitializeAuthors(db);
                }
                catch (Exception)
                {
                }
            });

        private static void InitializeBooks(BookStoreContext context)
        {
            context.Books.Add(new Book { Id = 1, Title = "Pride and Prejudice", ISBN = "0199535566", PublishDate = DateTime.Now.AddYears(-20) });
            context.Books.Add(new Book { Id = 2, Title = "OOTOOK Young Eskimo Girl", ISBN = "0483295566", PublishDate = DateTime.Now.AddYears(-10) });
            context.SaveChanges();
        }

        private static void InitializeAuthors(BookStoreContext context)
        {
            context.Authors.Add(new Author { Id = 1, Name = "Abraham Agnes" });
            context.Authors.Add(new Author { Id = 2, Name = "Marija Seweryna" });
            context.SaveChanges();
        }
    }
}
