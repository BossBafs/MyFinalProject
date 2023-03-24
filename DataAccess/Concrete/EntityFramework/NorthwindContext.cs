using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Database ile proje classlarını(Customer, Product, Category, ...vs) bağlamak
    public class NorthwindContext : DbContext
    {
        // Bu method projenin hangi veritabanı ile ilişkiliyi belirteceğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = 175.45.2.25");     Gerçek projede Ip uzantılı olur.
            // @ kullanmak string ("") içinde yazılan ters slash'ı normal olarak algıla. Ters slash normalde string içinde bile olsa C# da bir anlamı vardır.
            
            // Development ortamında olduğumuz için SQLServe uzantısını alırız.
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        // Hangi class hangi tabloya karşılık geleceğini belirtmek için prop kullanıyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
