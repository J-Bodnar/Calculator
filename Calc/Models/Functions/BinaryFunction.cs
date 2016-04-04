using System;


namespace Calc.Models.Functions
{
    class BinaryFunction : IFunction
    {
        private readonly string _action;
        private readonly double _firstOperand;
        private readonly double _secondOperand;
       

        public BinaryFunction(string action, double firstOperand, double secondOperand)
        {
            _firstOperand = firstOperand;
            _secondOperand = secondOperand;
            _action = action;
        }

        public double GetResult()
        {
            switch (_action)
            {
                case "+":
                    return _firstOperand + _secondOperand;
                case "-":
                    return _firstOperand - _secondOperand;
                case "*":
                    return _firstOperand * _secondOperand;
                case "/":
                    if (_secondOperand == 0)
                    {
                        throw new ArithmeticException("error: division by zero");
                    }
                    return _firstOperand / _secondOperand;
                case "%":
                    return _firstOperand % _secondOperand;
                case "^":
                    return Math.Pow(_firstOperand, _secondOperand);
                case "min":
                    return Math.Min(_firstOperand, _secondOperand);
                case "max":
                    return Math.Max(_firstOperand, _secondOperand);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
