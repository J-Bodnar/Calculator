using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Output
{
    class MessageManager
    {
        public const string Help = "How to use:\n\n"
       + "========================================================\n"
       + "The Calculator can execute\n\n"
       + "    the following operations:\n"
       + "-----------------------------------------\n"
       + "        operation       expression format \n"
       + "-----------------------------------------\n"
       + "           +                x + y\n"
       + "           -                x - y\n"
       + "           *                x * y\n"
       + "           /                x / y\n"
       + "           %                x % y\n"
       + "           ^                x ^ y\n\n"
       + "    and the following functions:\n"
       + "-----------------------------------------\n"
       + "        function       expression format \n"
       + "-----------------------------------------\n"
       + "           sin               sin(x)\n"
       + "           cos               cos(x)\n"
       + "           asin              asin(x)\n"
       + "           acos              acos(x)\n"
       + "           exp               exp(x)\n"
       + "           sqrt              sqrt(x)\n"
       + "           abs               abs(x)\n"
       + "           max               max(x, y)\n"
       + "           min               min(x, y)\n"
       + "-----------------------------------------\n"
       + "      * where x, y can be real numbers\n"
       + "        or variable name.\n"
       + "        if it is a variable its default value equals 0,\n"
       + "        it can be changed using expression in format: x = y\n\n"
       + "-----------------------------------------\n"
       + "There are three modes of using aplication\n\n"
       + "Console mode\n------------\n"
       + "    Use command:\n\n      calc\n\n    and then result will be displayed in console\n\n"
       + "File-console mode\n------------\n"
       + "    Use command:\n\n      calc  -i [path to file]\n\n"
       + "    example:    calc -i input.txt\n"
       + "    and then result will be displayed in console\n\n"
       + "File  mode\n------------\n"
       + "    Use command:\n\n      calc  -i [path to input-file] -o[path to output-file]\n\n"
       + "    example:    calc -i input.txt  -o output.txt\n"
       + "    and then result will be written into the file.\n\n";


        public static void PrintHelp()
        {
            Console.WriteLine(Help);
        }

        public static void AskForInput()
        {
            Console.WriteLine("waiting for expression...");
        }

    }
}
