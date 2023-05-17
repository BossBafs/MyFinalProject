using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Xml.Linq;

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


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid);
            //}
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //    // else gerek yok. Return çalışırsa zaten orada bitecektir.
            //}

            //var context = new ValidationContext<Product>(product);
            //ProductValidator productvalidator = new ProductValidator();
            //var result = productvalidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            //ValidationTool.Validate(new ProductValidator(), product);
            //Bunu yazmak yerine ValidationAspect attribute kullandık.

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş kuralları buraya yazılır.
            // İş kurallarını geçtikten sonra GetAll ile bütün ürünleri verir.

            if (DateTime.Now.Hour == 05)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            // Liste döndürüyoruz ama data da döndürmemiz gerektiğinden böyle yazdık.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.CategoryId == id));
        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.UnitPrice>= min && p.UnitPrice<= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
