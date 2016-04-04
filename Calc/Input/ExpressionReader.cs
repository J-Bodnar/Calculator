using Calc.Output;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calc.Input
{
    class ExpressionReader
    {
        private static ExpressionReader instance;
        private ExpressionReader() { }

        public static ExpressionReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExpressionReader();
                }
                return instance;
            }
        }

        public string Read()
        {
            string input;
            Start:
            MessageManager.AskForInput();
            input = Console.ReadLine().ToLower().Trim();
            if (input.Trim().Equals("help"))
            {
                MessageManager.PrintHelp();
                goto Start;
            }
            return input;
        }

        public List<string> Read(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            List<string> expressions = new List<string>();
            while (!streamReader.EndOfStream)
            {
                expressions.Add(streamReader.ReadLine().ToLower().Trim());
            }
            return expressions;
        }
    }
}