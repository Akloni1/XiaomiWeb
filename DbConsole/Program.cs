using Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace DbConsole
{
    //Фабрика для создания объекта контекста базы данных во время разработки
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Phone;Trusted_Connection=True;",
                b => b.MigrationsAssembly("Infrastructure"));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
    class Program
    {
        private static readonly AppDbContext _appContext;
        private static IPhoneRepository _phoneRepository;
        private static IShopRepository _shopRepository;
        static Program()
        {
            AppDbContextFactory factory = new AppDbContextFactory();
            _appContext = factory.CreateDbContext(null);
            _phoneRepository = new PhoneRepository(_appContext);
            _shopRepository = new ShopRepository(_appContext);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");

            Shop shop = new Shop("Москва", "Шереметивская", 6);
            _shopRepository.Add(shop);
            Phone phone = new Phone(shop.Id, "mi8", "телефон среднего ценового класса",
                "процессор: Qualcomm Snapdragon 439, 2000МГц, 8-ми ядерный...", 20000);
            _phoneRepository.Add(phone);
        }
    }
}
