using Models;

namespace Interfaces
{
    public interface IPricingRule
    {
        //para decidir si la regla aplica a ese producto
        bool IsMatch(Product product);
        //para calcular el precio según la regla
        decimal Compute(Product product);
    }
}
