using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NS_Product;

namespace CP_ProductBox
{
    // de dinh nghia la mot component thi phao co 1 trong 2 method:
    //  -- (string)/ (IViewComponentResult) Invoke(object m)
    //  -- InvokeAsync
    // [ViewComponent]
    public class ProductBox : ViewComponent
    {
        
        private readonly ProductListServices _product;
        public ProductBox(ProductListServices product)
        {
            _product = product;
        }
        public IViewComponentResult Invoke(bool order = true)
        {
            List<Product> product = null;
            if (order)
            {
                product = _product.products.OrderBy(p => p.Price).ToList();
            }
            else
            {
                product = _product.products.OrderByDescending(ps => ps.Price).ToList();
            }

            // return View("default1", a); // Default1.cshtml
            return View<List<Product>>(product); // default.cshtml
        }
    }
}