using Lcs10_Web_Api_sem.Data;
using Lcs10_Web_Api_sem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lcs10_Web_Api_sem.Controllers
{
    [ApiController] //атрибут т к контроллер не будет возвращать вьюшку 
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProduct(string name, string description, decimal price)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                if (storageContext.Products.Any(p => p.Name == name))
                {
                    return StatusCode(409);
                }

                var product = new Product() { Name = name, Description = description, Price = price };
                storageContext.Products.Add(product);
                storageContext.SaveChanges();
                return Ok(product.Id);
            }           
        }
        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> list;
            using (StorageContext storageContext = new StorageContext())
            {
                list = storageContext.Products.Select(p => new Product { Name = p.Name, Description = p.Description, Price = p.Price }).ToList();

                return Ok(list);
            }

        }
        [HttpDelete("delete_products")]
        public ActionResult<IEnumerable<Product>> DeleteProduct(string name)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                if (storageContext.Products.Any(p => p.Name == name))
                {
                    Product product1 = storageContext.Products.Where(p => p.Name == name).FirstOrDefault(); 
                    storageContext.Products.Remove(product1);
                    storageContext.SaveChanges();
                }

                return Ok();
            }

        }
        //------------

    }
}
