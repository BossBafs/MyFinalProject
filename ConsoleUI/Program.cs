using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            ProductManager productManager1 = new ProductManager(new EFProductDal());
            foreach (var item in productManager1.GetByUnitPrice(40,100))
            {
                Console.WriteLine(item.ProductName);
            }

            Console.WriteLine("---------    ---    ---      ---    ---   ---------");

            foreach (var item in productManager1.GetAllByCategoryId(2))
            {
                Console.WriteLine(item.ProductName);
            }

            Console.WriteLine("---------    ---    ---      ---    ---   ---------");

            var product = productManager1.Get(1);
            Console.WriteLine(product.ProductName);
        }
    }
}