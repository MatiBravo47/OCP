using Interfaces;
using Models;

namespace Services
{
    public class PriceCalculator
    {
        private readonly IEnumerable<IPricingRule> _rules;

        public PriceCalculator(IEnumerable<IPricingRule> rules)
        { 
            _rules = rules;
        }
 
        public decimal Calculate(Product product)
        {
            var rule = _rules.FirstOrDefault(r => r.IsMatch(product));

            if (rule == null) {
                throw new NotSupportedException("Product type not supported.");
            }

            return rule.Compute(product);
        }
    }
}