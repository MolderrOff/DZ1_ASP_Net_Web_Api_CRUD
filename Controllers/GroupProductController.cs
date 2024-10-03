using Lcs10_Web_Api_sem.Data;
using Lcs10_Web_Api_sem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lcs10_Web_Api_sem.Controllers
{
    [ApiController]        
    [Route("[controller]")]
    public class GroupProductController : ControllerBase
    {
        [HttpPost("add_group_products")]
        public ActionResult<int> AddProductGroup(string name, string description)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                if (storageContext.ProductGroups.Any(pg => pg.Name == name))
                {
                    return StatusCode(409);
                }

                var productGroup = new ProductGroup() { Name = name, Description = description };
                storageContext.ProductGroups.Add(productGroup);
                storageContext.SaveChanges();
                return Ok(productGroup.Id);
            }
        }
        [HttpGet("get_group_products")]
        public ActionResult<IEnumerable<Product>> GetGroupProducts()
        {
            IEnumerable<ProductGroup> list;
            using (StorageContext storageContext = new StorageContext())
            {
                list = storageContext.ProductGroups.Select(p => new ProductGroup { Name = p.Name, Description = p.Description }).ToList();

                return Ok(list);
            }

        }

    }
}
