

using Core.Entities;

namespace Entities.Concrete
{
    // Veri Tabanı tablosu olduğunu belirtmek için IEntity interfaceni verdik.
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
