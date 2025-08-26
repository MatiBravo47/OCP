using Interfaces;
using PricingRules;
using Models;
using Services;

namespace SolidWorkshop.OCP
{
    class Program 
    {
        static void Main(string[] args) 
        {

        var rules = new List<IPricingRule>
        {
            new StandardPricingRule(),
            new PremiumPricingRule(),
            new ClearancePricingRule()
        };

        var calculator = new PriceCalculator(rules);

        var product = new Product
        {
            Sku = "ABC123",
            Type = ProductType.Premium,
            BasePrice = 100m,
            Discount = 0.1m
        };

        var finalPrice = calculator.Calculate(product);
        Console.WriteLine($"Final price: {finalPrice}");
        }
    }
}
