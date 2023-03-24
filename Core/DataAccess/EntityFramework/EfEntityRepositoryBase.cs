using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // Bir class newlendiğinde o bellekten garbage collector belli zamanda düzenli gelir ve onu bellekten atar.
            // Using içine yazılan nesneler using bitince anında garbage collectora gelir ve bellekten atılır.

            // IDisposable pattern imlementation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);    // Referansı yakalamak
                addedEntity.State = EntityState.Added;      // Eklenecek nesne

                // Üsttekilerin yerine şu yazılabilir.
                //context.Products.Add(entity);

                context.SaveChanges();                      // Ekle
            }

        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;

                //context.Products.Remove(context.Products.SingleOrDefault(p=> p.ProductId == entity.ProductId));

                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
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


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null                                 // Filtre boş mu 
                    ? context.Set<TEntity>().ToList()                   // Filtre yok ise 
                    : context.Set<TEntity>().Where(filter).ToList();      // Filtre var ise filtreler
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
    }
}
