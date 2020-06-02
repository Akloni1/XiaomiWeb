using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebPhone.DataAccess;
using WebPhone.Entities;

namespace WebPhone
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PhonesStore;Trusted_Connection=True;", b => b.MigrationsAssembly("Infrastructure"));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
    public class Program
    {
        private static readonly AppDbContext _appContext;
        private static IPhoneRepository _phoneRepository;
        private static IShopRepository _shopRepository;
        static Program()
        {
            AppDbContextFactory factory = new AppDbContextFactory();
            _appContext = factory.CreateDbContext(null);
            _shopRepository = new ShopRepository(_appContext);
            _phoneRepository = new PhoneRepository(_appContext);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Start!");

            Shop shop = new Shop("Москва", "Шереметивская", 6);
            _shopRepository.Add(shop);
            Phone phone = new Phone(shop.Id, "mi8", "телефон среднего ценового класса",
                "процессор: Qualcomm Snapdragon 439, 2000МГц, 8-ми ядерный...",20000);
            _phoneRepository.Add(phone);
            //  CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
