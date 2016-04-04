using Calc.Calculation;
using Calc.Models.Functions;
using Calc.Parsing;
using System;


namespace Calc.Models
{
    class Expression
    {
        public string ExpressionString { get; private set; }
        
        public Expression(string expressionString)
        {
            ExpressionString = expressionString;
        }

        public IFunction AsFunction()
        {
            foreach (string functionName in FunctionRepository.Instance.UnaryFunctionNames)
            {
                if (!ExpressionString.StartsWith(functionName))
                {
                    continue;
                }
                int indexOfArgument = functionName.Length + 1;
                int lengthOfArgument = ExpressionString.Length - functionName.Length - 2;
                double argument = GetValue(ExpressionString.Substring(indexOfArgument, lengthOfArgument));
                return new UnaryFunction(functionName, argument);
            }
            foreach (string functionName in FunctionRepository.Instance.BinaryFunctionNames)
            {
                if (!ExpressionString.StartsWith(functionName))
                {
                    continue;
                }
                int indexOfArgument1 = functionName.Length + 1;
                int indexOfArgument2 = ExpressionString.IndexOf(",") + 1;
                int lengthOfArgument1 = ExpressionString.IndexOf(",") - ExpressionString.IndexOf("(") - 1;
                int lengthOfArgument2 = ExpressionString.IndexOf(")") - ExpressionString.IndexOf(",") - 1;
                double argument1 = GetValue(ExpressionString.Substring(indexOfArgument1, lengthOfArgument1));
                double argument2 = GetValue(ExpressionString.Substring(indexOfArgument2, lengthOfArgument2));
                return new BinaryFunction(functionName, argument1, argument2);
            }
            throw new NotSupportedException();
        }

        public IFunction AsBinaryOperation()
        {
            int index = ExpressionString.IndexOfAny(FunctionRepository.Instance.OperationCharacters);
            double operand1;
            double operand2;
            operand1 = GetValue(ExpressionString.Substring(0, index));
            operand2 = GetValue(ExpressionString.Substring(index + 1));
            return new BinaryFunction(ExpressionString[index].ToString(), operand1, operand2);
        }

        private double GetValue(string variableString)
        {
            double result;
            try
            {
                result = double.Parse(variableString.Replace('.', ','));
            }
            catch (FormatException)
            {

                Calculator.VariableRepsitory.Add(variableString);
                result = Calculator.VariableRepsitory.getValueByName(variableString);
            }
            return result;
        }
    }
}
