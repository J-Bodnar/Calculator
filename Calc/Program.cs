
using Calc.Calculation;
using Calc.Input;
using Calc.Output;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                //console mode
                case 0:
                    string inputString = ExpressionReader.Instance.Read();
                    try
                    {
                        if (inputString.ToString().Equals("exit"))
                        {
                            Environment.Exit(0);
                        }
                        else Printer.Instance.PrintResult(new Calculator(inputString).Calculate().ToString());
                    }
                    catch (ArithmeticException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    goto case 0;

                //file-console mode
                case 1:
                    string path = args[0];
                    List<string> inputStrings;
                    try
                    {
                        inputStrings = ExpressionReader.Instance.Read(path);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("input file does not exist\n\nWELCOME To the concole mode:)");
                        goto case 0;

                    }
                    foreach (string parsedString in inputStrings)
                    {
                        try
                        {
                            Printer.Instance.PrintResult(new Calculator(parsedString).Calculate().ToString());
                        }
                        catch (ArithmeticException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.ReadKey();
                        }
                    }
                    break;

                //File mode
                case 2:
                    string pathToInput = args[0];
                    string pathToOutput = args[1];
                    try
                    {
                        inputStrings = ExpressionReader.Instance.Read(pathToInput);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("input file does not exist\n\nWELCOME To the concole mode:)");
                        goto case 0;
                    }
                    List<string> results = new List<string>();
                    foreach (string parsedString in inputStrings)
                    {
                        try
                        {
                            results.Add(new Calculator(parsedString).Calculate().ToString());
                        }
                        catch (ArithmeticException e)
                        {
                            results.Add(e.Message);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Done");
                            Console.ReadKey();
                        }
                    }
                    try
                    {
                        Printer.Instance.PrintResult(results , pathToOutput);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("output file does not exist\n\nWELCOME To the concole mode:)");
                        goto case 0;
                    }
                    break;
                default:
                    MessageManager.PrintHelp();
                    break;

            }
        }
    }
}