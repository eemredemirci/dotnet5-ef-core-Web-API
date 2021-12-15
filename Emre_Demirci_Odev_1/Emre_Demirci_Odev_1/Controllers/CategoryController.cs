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


    public class CategoryController : ControllerBase
    {
        NORTHWNDContext context = new NORTHWNDContext();
        // Get Cagetory Info All
        public IActionResult GetCategory()
        {

            List<Category> categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategoryByID(int categoryId)
        {
            List<Category> categories = context.Categories.Where(categories => categories.CategoryId == categoryId).ToList();
            if (categories.Count != 0)
            {
                return Ok(categories);
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return CreatedAtAction("GetCategoryByID", "Category", new { categoryId = category.CategoryId }, category);
        }

        [HttpGet("AllProductByID/{Id}")]
        public IActionResult AllProductByID(int Id)
        {
            List<Product> products = context.Products.Where(product => product.CategoryId == Id).ToList();
            if (products.Count != 0)
            {
                return Ok(products);
            }
            return NoContent();

        }

    }
}
