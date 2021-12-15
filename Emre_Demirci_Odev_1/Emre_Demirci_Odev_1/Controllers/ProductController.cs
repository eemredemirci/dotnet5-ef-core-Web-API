using Emre_Demirci_Odev_1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        NORTHWNDContext context = new NORTHWNDContext();

        public IActionResult GetProduct()
        {

            List<Product> products = context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductByID(int productId)
        {
            List<Product> products = context.Products.Where(product => product.ProductId == productId).ToList();
            if (products.Count != 0)
            {
                return Ok(products);
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return CreatedAtAction("GetProductByID", "Product", new { productId = product.ProductId }, product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            Product updated = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updated.ProductName = product.ProductName;
            updated.QuantityPerUnit = product.QuantityPerUnit;
            context.SaveChanges();
            return CreatedAtAction("GetProductByID", "Product", new { productId = product.ProductId }, product);
        }



    }
}
