
using System.Collections.Generic;

namespace NS_Product
{
    public class ProductListServices
    {
        public List<Product> products { get; set; }
        public ProductListServices()
        {
            products = new List<Product>{
    new Product() { Name = "sp1", Description = "Smpartphone", Price = 1986 },
    new Product() { Name = "sp2", Description = "Smpartphone", Price = 10020 },
    new Product() { Name = "sp3", Description = "Smpartphone", Price = 34521 }
    };
        }
    }
}