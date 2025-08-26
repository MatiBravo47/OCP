/*
1.2.Principio Abierto / Cerrado(OCP)
Establece que las entidades de software deben estar abiertas
para extensión pero cerradas para modificación. En la práctica, esto significa que debemos
poder agregar nuevas funcionalidades sin tener que modificar el código existente. Se logra
mediante abstracciones (interfaces, clases abstractas) y la aplicación de polimorfismo.
Una violación típica de OCP ocurre cuando necesitamos modificar una clase existente cada
vez que surge un nuevo requerimiento. Por ejemplo, una clase 'CalculadoraImpuestos' que
requiere ser editada para soportar cada nuevo tipo de impuesto.
*/
/*
Consignas de refactorización
● Introducir abstracción: IPricingRule con bool IsMatch(Product) y decimal
Compute(Product).
● PriceCalculator pasa a componer una lista de reglas (IEnumerable<IPricingRule>) y
aplicar la que corresponda (o un pipeline si combinan).
● Agregar un tipo nuevo (p. ej., Seasonal) sin modificar código existente: solo añadir
una nueva regla.Criterios de aceptación
● Eliminar el switch/if…else por polimorfismo.
● Soportar múltiples reglas o una regla por tipo, según diseño elegido.
● La incorporación de nuevos tipos no modifica PriceCalculator (solo registra
reglas).
(Opcional: agregar un test donde, al introducir Seasonal, no se toca PriceCalculator.)
*/

/*
using System;

namespace OCP
{
    public enum ProductType
    {
        Standard,
        Premium,
        Clearance
    }

    public class Product2
    {
        public string Sku { get; init; }
        public ProductType Type { get; init; }
        public decimal BasePrice { get; init; }
        public decimal Discount { get; init; } // 0..1
    }

    //Hay diferentes categorías de productos con reglas de precio. Cada nuevo tipo obliga a editar
    //la misma clase.
    public class PriceCalculator
    {
        // Cada nuevo tipo → modifico este método
        public decimal Calculate(Product product)
        {
            switch (product.Type)
            {
                case ProductType.Standard:
                    return product.BasePrice * (1 - product.Discount);

                case ProductType.Premium:
                    // Premium tiene fee extra del 10%
                    return (product.BasePrice * 1.10m) * (1 - product.Discount);

                case ProductType.Clearance:
                    // Liquidación: descuento adicional del 30% fijo
                    var price = product.BasePrice * (1 - product.Discount);
                    return price * 0.70m;

                default:
                    throw new NotSupportedException("Product type not supported.");
            }
        }
    }
}
*/

/*
==================================================================================
MODIFICACIONES REALIZADAS - RESUMEN DE CAMBIOS
==================================================================================

✅ CAMBIO 1: CREACIÓN DE INTERFAZ
   - Archivo: Interfaces/IPricingRule.cs
   - Contenido: Interfaz con IsMatch() y Compute()
   - Propósito: Abstracción para diferentes reglas de precio

✅ CAMBIO 2: SEPARACIÓN DE MODELOS
   - Archivo: Models/Product.cs (renombrado de Product2)
   - Archivo: Models/ProductType.cs
   - Propósito: Separar entidades de dominio

✅ CAMBIO 3: IMPLEMENTACIÓN DE REGLAS ESPECÍFICAS
   - Archivo: ReglasDePrecios/StandardPricingRule.cs
   - Archivo: ReglasDePrecios/PremiumPricingRule.cs  
   - Archivo: ReglasDePrecios/ClearancePricingRule.cs
   - Propósito: Una clase por cada regla (Single Responsibility)

✅ CAMBIO 4: REFACTORIZACIÓN DE PRICECALCULATOR
   - Archivo: Servicios/PriceCalculator.cs
   - ANTES: switch/case con lógica hardcodeada
   - DESPUÉS: Lista de reglas + polimorfismo
   - Código eliminado: Todo el switch/case
   - Código agregado: Inyección de dependencias con IEnumerable<IPricingRule>

✅ CAMBIO 5: ACTUALIZACIÓN DEL PROGRAMA PRINCIPAL
   - Archivo: Program.cs
   - Cambio: Registro de reglas en lista
   - Beneficio: Configuración centralizada

✅ CAMBIO 6: ORGANIZACIÓN EN CARPETAS
   - AntesDeRefactorizar/ (este archivo)
   - Models/
   - Interfaces/
   - ReglasDePrecios/
   - Servicios/

==================================================================================
BENEFICIOS OBTENIDOS
==================================================================================

🎯 PRINCIPIO OCP CUMPLIDO:
   ✅ ABIERTO para extensión: Agregar SeasonalPricingRule sin tocar código existente
   ✅ CERRADO para modificación: PriceCalculator no se modifica nunca más

🔧 MEJORAS TÉCNICAS:
   ✅ Eliminado switch/case
   ✅ Implementado polimorfismo
   ✅ Separación de responsabilidades
   ✅ Código más testeable
   ✅ Inyección de dependencias

📈 EXTENSIBILIDAD:
   Para agregar un nuevo tipo de producto:
   1. Crear nueva clase que implemente IPricingRule
   2. Agregar a la lista en Program.cs
   3. ¡Listo! Sin tocar PriceCalculator

==================================================================================
EJEMPLO DE EXTENSIÓN (SIN MODIFICAR CÓDIGO EXISTENTE)
==================================================================================

// ✅ Agregar nuevo tipo es súper fácil:
public class SeasonalPricingRule : IPricingRule
{
    public bool IsMatch(Product product) => product.Type == ProductType.Seasonal;
    public decimal Compute(Product product) => product.BasePrice * (1 - product.Discount) * 0.75m;
}

// En Program.cs solo agregar:
// rules.Add(new SeasonalPricingRule());

// ¡PriceCalculator no se toca! ✅ OCP cumplido

==================================================================================
*/