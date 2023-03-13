using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            // ProductManager newlendiğinde IProductDal referansını vermesi için bunu yapıyoruz.
            _productDal = productDal;
        }

        public Product Get(int productId)
        {
            var product = _productDal.Get(p => p.ProductId == productId);
            return product;
        }

        public List<Product> GetAll()
        {
            // İş kuralları buraya yazılır.
            // İş kurallarını geçtikten sonra GetAll ile bütün ürünleri verir.
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=> p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=> p.UnitPrice>= min && p.UnitPrice<= max);
        }
    }
}
