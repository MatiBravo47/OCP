using SolidWorkshop.OCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public string Sku { get; init; }
        public ProductType Type { get; init; }
        public decimal BasePrice { get; init; }
        public decimal Discount { get; init; } // 0..1
    }
}
