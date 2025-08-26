using Interfaces;
using Models;

namespace PricingRules
{
    public class StandardPricingRule: IPricingRule
    {
        public bool IsMatch(Product product) => product.Type == ProductType.Standard;
        public decimal Compute(Product product) => product.BasePrice * (1 - product.Discount);
    }
}
