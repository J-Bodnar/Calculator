
namespace Calc.Parsing
{
    class FunctionRepository
    {
        private static FunctionRepository instance;
        private FunctionRepository() { }

        public static FunctionRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FunctionRepository();
                }
                return instance;
            }
        }

        public string[] FunctionNames {
            get
            {
                return new string[] { "asin", "acos", "sin", "cos", "exp", "abs", "sqrt", "min", "max" };
            }
        }

        public string[] UnaryFunctionNames
        {
            get
            {
                return new string[] { "sin", "cos", "asin", "acos", "exp", "abs", "sqrt" };
            }
        }

        public string[] BinaryFunctionNames
        {
            get
            {
                return new string[] { "min", "max" };
            }
        }

        public char[] OperationCharacters
        {
            get
            {
                return new char[] { '+', '-', '*', '/', '%', '^' };
            }
        }

        public char[][] OperationWithPriority
        {
            get
            {
                return new char[][]
                {
                    new char[] { '+', '-' },
                    new char[] { '*', '/', '%' },
                    new char[] { '^' }
                };

            }
        }
    }
}
