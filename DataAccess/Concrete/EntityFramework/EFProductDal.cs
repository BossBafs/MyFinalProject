using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    // NuGet Harici paketlerin yönetimini sağlar. ".Net" de EntityFramework kullanmak gibi
    public class EFProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // Bir class newlendiğinde o bellekten garbage collector belli zamanda düzenli gelir ve onu bellekten atar.
            // Using içine yazılan nesneler using bitince anında garbage collectora gelir ve bellekten atılır.

            // IDisposable pattern imlementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);    // Referansı yakalamak
                addedEntity.State = EntityState.Added;      // Eklenecek nesne

                // Üsttekilerin yerine şu yazılabilir.
                //context.Products.Add(entity);

                context.SaveChanges();                      // Ekle
            }

        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;

                //context.Products.Remove(context.Products.SingleOrDefault(p=> p.ProductId == entity.ProductId));

                context.SaveChanges();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;

                //var productToUpdate = context.Products.SingleOrDefault(p => p.ProductId == entity.ProductId);
                //productToUpdate.ProductName = entity.ProductName;
                //productToUpdate.ProductId = entity.ProductId;
                //productToUpdate.CategoryId = entity.CategoryId;
                //productToUpdate.UnitPrice = entity.UnitPrice;
                //productToUpdate.UnitsInStock = entity.UnitsInStock;

                context.SaveChanges();
            }
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null                                 // Filtre boş mu 
                    ? context.Set<Product>().ToList()                   // Filtre yok ise 
                    : context.Set<Product>().Where(filter).ToList();      // Filtre var ise filtreler
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }
    }
}
