
namespace Calc.Models.Functions
{
    interface IFunction
    {
        /// <summary>
        /// Discribes method for function value calculation.
        /// </summary>
        /// <returns>result of calculations</returns>
        double GetResult();
    }
}
