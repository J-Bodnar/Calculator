using System;
using System.Collections.Generic;

namespace Calc.Output
{
    class Printer
    {
        private static Printer instance;
        private Printer() { }

        public static Printer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Printer();
                }
                return instance;
            }

        }

        public void PrintResult(string result)
        {
                Console.WriteLine(result + "\n");
        }

        public void PrintResult(List<string> results, string pathToOutput)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(pathToOutput))
            {
                foreach (string result in results)
                {
                        file.WriteLine(result);
                }
            }
        }

        


    }
}

