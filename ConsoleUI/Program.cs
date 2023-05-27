﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProductTestInMemoryProductDal();
            //ProductTestEFProductDal();

            ProductTestGetProductDetails();

            //CategoryTest();

        }

        private static void ProductTestGetProductDetails()
        {
            ProductManager productManager = new ProductManager(new EFProductDal(), new CategoryManager(new EFCategoryDal()));
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        //private static void ProductTestInMemoryProductDal()
        //{
        //    ProductManager productManager = new ProductManager(new InMemoryProductDal());
        //    foreach (var product in productManager.GetAll())
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //}

        //private static void ProductTestEFProductDal()
        //{
        //    ProductManager productManager1 = new ProductManager(new EFProductDal());
        //    foreach (var item in productManager1.GetByUnitPrice(40, 100))
        //    {
        //        Console.WriteLine(item.ProductName);
        //    }

        //    Console.WriteLine("---------    ---    ---      ---    ---   ---------");

        //    foreach (var item in productManager1.GetAllByCategoryId(2))
        //    {
        //        Console.WriteLine(item.ProductName);
        //    }

        //    Console.WriteLine("---------    ---    ---      ---    ---   ---------");

        //    var product = productManager1.Get(1);
        //    Console.WriteLine(product.ProductName);
        //}
    }
}