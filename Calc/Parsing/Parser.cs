using Calc.Models;
using System.Collections.Generic;


namespace Calc.Parsing
{
    class Parser
    {
        private string _parsedString;

        public Parser(string parsedString)
        {
            _parsedString = parsedString;
        }

        public Expression getExpressionWithPriority(string parsedString, int priority)
        {
            int index = parsedString.Substring(1).IndexOfAny(
                FunctionRepository.Instance.OperationWithPriority[priority]) + 1;
            if (index == 0)

            {
                return null;
            }
                int indexOfPrivious = parsedString.Substring(0, index - 1).LastIndexOfAny(
                FunctionRepository.Instance.OperationCharacters);
            

            int indexOfNext = parsedString.Substring(index + 1).IndexOfAny(
                FunctionRepository.Instance.OperationCharacters) + index + 1;
            if (indexOfNext == index)
            {
                indexOfNext = parsedString.Length;
            }
            return new Expression(parsedString.Substring(indexOfPrivious + 1, indexOfNext- indexOfPrivious -1));
        }

        public List<Expression> GetFunctionExpressions()
        {
            List<Expression> functionsList = new List<Expression>();
            string parsedString = _parsedString;
            Expression expression = GetFunctionExpression(parsedString);
            while (expression != null)
            {
                functionsList.Add(expression);
                int index = parsedString.IndexOf(expression.ExpressionString) + expression.ExpressionString.Length;
                if (parsedString.Length < index)
                {
                    break;
                }
                parsedString = parsedString.Substring(index);
                expression = GetFunctionExpression(parsedString);
            }

            return functionsList;
        }

        public List<Expression> GetExpressionsInBrackets()
        {
            List<Expression> inBracketsExpressionsList = new List<Expression>();
            string parsedString = _parsedString;
            Expression expression = GetExpressionInBrackets(parsedString);
            while (expression != null)
            {
                inBracketsExpressionsList.Add(expression);
                int index = parsedString.IndexOf(expression.ExpressionString) + expression.ExpressionString.Length;
                if (parsedString.Length < index)
                {
                    break;
                }
                parsedString = parsedString.Substring(index);
                expression = GetFunctionExpression(parsedString);
            }

            return inBracketsExpressionsList;
        }

        private Expression GetFunctionExpression(string parsedString)
        {
            foreach (string functionName in FunctionRepository.Instance.FunctionNames)
            {
                if (parsedString.Contains(functionName))
                {
                    int openIndex = parsedString.IndexOf(functionName);
                    int closeIndex = parsedString.Substring(openIndex).IndexOf(")");
                    return new Expression(parsedString.Substring(openIndex, closeIndex - openIndex + 1));
                }
            }
            return null;
        }

        private Expression GetExpressionInBrackets(string parsedString)
        {
            int indexOfOpeningBreaket = parsedString.IndexOf("(");
            if (indexOfOpeningBreaket == -1)
            {
                return null;
            }
            int indexOfClosingBreaket = parsedString.IndexOf(")");
            string expressionString = parsedString.Substring(
                indexOfOpeningBreaket + 1, indexOfClosingBreaket - indexOfOpeningBreaket - 1);
            return new Expression(expressionString);
        }

    }
}

