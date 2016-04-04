using System;


namespace Calc.Models.Functions
{
    class UnaryFunction: IFunction
    {
        private readonly string _action;
        private readonly double _argument;

        public UnaryFunction( string action, double argument)
        {
            _action = action;
            _argument = argument;
        }
        public double GetResult()
        {
            switch (_action)
            {
                case "sin":
                    return Math.Sin(_argument);
                case "cos":
                    return Math.Cos(_argument);
                case "asin":
                    if (Math.Abs(_argument) > 1)
                    {
                        throw new ArithmeticException("error: the domain of the function is violated");
                    }
                    
                    return Math.Asin(_argument);
                case "acos":
                    if (Math.Abs(_argument) > 1)
                    {
                        throw new ArithmeticException("error: the domain of the function is violated");
                    }
                    return Math.Acos(_argument);
                case "exp":
                    return Math.Exp(_argument);
                case "abs":
                    return Math.Abs(_argument);
                case "sqrt":
                    if (_argument < 1)
                    {
                        throw new ArithmeticException("error: the domain of the function is violated");
                    }
                    return Math.Sqrt(_argument);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
