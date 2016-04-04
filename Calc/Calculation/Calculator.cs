using Calc.Models;
using Calc.Parsing;
using System;


namespace Calc.Calculation
{
    class Calculator
    {
        private readonly string _parsedString;
        private readonly Parser parser;

        public static VariableRepsitory VariableRepsitory { get; } = new VariableRepsitory();

        public Calculator(string parsedString)
        {
            _parsedString = parsedString.Replace("--","+");
            parser = new Parser(_parsedString);
        }

        public double Calculate()
        {
            
            if (_parsedString.Contains("="))
            {
                Variable variable = InitializeVariable(_parsedString);
                VariableRepsitory.Add(variable);
                return variable.Value;
            }
            Calculator calc = this
                .ReplaceFunctions()
                .ReplaceExpressionInBrackets()
                .ReplaceExpressionWithPriority(2)
                .ReplaceExpressionWithPriority(1)
                .ReplaceExpressionWithPriority(0);
            double result;
            try
            {
                result = double.Parse(calc._parsedString);
            }
            catch (FormatException)
            {
                Calculator.VariableRepsitory.Add(calc._parsedString);
                result = Calculator.VariableRepsitory.getValueByName(calc._parsedString);
            }
            return result;
        }

        private static Variable InitializeVariable(string variableString)
        {
            int equalsIndex = variableString.IndexOf("=");
            string beforeEquals = variableString.Substring(0, equalsIndex);
            string afterEquals = variableString.Substring(equalsIndex + 1);
            return new Variable(beforeEquals, new Calculator(afterEquals).Calculate());
        }

        private Calculator ReplaceFunctions()
        {
            string parsedString = _parsedString;
            foreach (Expression expression in parser.GetFunctionExpressions())
            {
                parsedString = parsedString.Replace(expression.ExpressionString
                    , expression.AsFunction().GetResult().ToString());
            }
            return new Calculator(parsedString);
        }

        private Calculator ReplaceExpressionInBrackets()
        {
            string parsedString = _parsedString;
            foreach (Expression expression in parser.GetExpressionsInBrackets())
            {
                string valueInBrackets = new Calculator(expression.ExpressionString).Calculate().ToString();
                parsedString = parsedString.Replace("(" + expression.ExpressionString + ")", valueInBrackets);
            }
            return new Calculator(parsedString);
        }

        private Calculator ReplaceExpressionWithPriority(int priority)
        {
            string parsedString = _parsedString;
            Expression expression = parser.getExpressionWithPriority(parsedString, priority);
            while (expression != null)
            {
                parsedString = parsedString.Replace(expression.ExpressionString
                    , expression.AsBinaryOperation().GetResult().ToString());
                expression = parser.getExpressionWithPriority(parsedString, priority);
            }
            return new Calculator(parsedString);
        }
    }
}
