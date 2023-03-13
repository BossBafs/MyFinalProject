using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    // Burada artık değişken türünü classlara teker teker vermek yerine tek bir kısıma T tipi vererek tüm classlarda çağırmayı sağlıyoruz.
    // generic constraint : genel kısıtlama >> Burada T tipine kısıtlama getiriyoruz.
    // Burada ki class : referans tip dir.
    // IEntity : IEntity olabilir veya IEntity implamente eden bir nesne olabilir.
    // new() : new'lenebilir olmalı. Bu sebeple İnterfaceler newlenemediği için IEntity de kullanılamayacak. Çünkü soyut nesneye ihtiyacımız yok.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);   // Burada filtre boş olabileceği için null yazdık.
        T Get(Expression<Func<T, bool>> filter);    // Burada filtrelemek durumunda.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


        // Expression ve filtre yazdıktan sonra buna ihtiyacımız yok.
        //List<T> GetAllByCategory(int categoryId);
    }
}
