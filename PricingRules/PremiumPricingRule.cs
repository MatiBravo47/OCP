using Interfaces;
using Models;

namespace PricingRules
{
    public class PremiumPricingRule : IPricingRule
    {
        public bool IsMatch(Product product) => product.Type == ProductType.Premium;
        public decimal Compute(Product product) => product.BasePrice * 1.10m * (1 - product.Discount);
    }
}
