using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lcs10_Web_Api_sem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? ProductGroupId  { get; set; }
        public virtual List<Storage> Storages { get; set; }
        public virtual ProductGroup? ProductGroup { get; set; }


    }
}
