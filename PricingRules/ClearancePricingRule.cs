using Interfaces;
using Models;

namespace PricingRules
{
    public class ClearancePricingRule: IPricingRule
    {
        public bool IsMatch(Product product) => product.Type == ProductType.Clearance;

        public decimal Compute(Product product)
        {
            var price = product.BasePrice * (1 - product.Discount);
            return price * 0.70m;
        }
    }
}
