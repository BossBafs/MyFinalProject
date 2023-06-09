﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        // Class ın içinde ama metodların dışında tanımlanan değişkenlere global değişken denir.
        // İsimlendirme yapıldığında alt çizgi kullanılır. Bu isimlendirmeye Naming Conventions denir.
        // Bu referans tip tek başına bir anlam ifade etmez. Sadece değişken oluşturur.
        List<Product> _products;
        // ctor Bellekte referans aldığı zaman çalışacak olan bloktur.
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product{ ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product{ ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product{ ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product{ ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // Referans tip olduğu için bu şekilde ürün silinmez. Ama değer tipler silinir. 
            // _products.Remove(product);

            // Return edecek şekilde uzun yazmak isteseydik;

            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            // Aynı şekilde LINQ(Language Integrated Query) ile yazılmak istenirse;
            // SingleOrDefault tek bir ürün bulmaya yarar. Genelde Id aramalarında kullanılır.

            Product? productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }


        public void Update(Product product)
        {
            // Gönderdiğim ürün Id sine ait listedeki ürünü bul
            Product? productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // İçindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve döndürür.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
