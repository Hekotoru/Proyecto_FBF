using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBF_Proyect
{
    class Program
    {
        static void Main(string[] args)
        {
           /*Code to test the function AreParanthesesBalanced*/
            string expression;
            Analyzer_Syntax.Analyzer_Syntax Prueba = new Analyzer_Syntax.Analyzer_Syntax();
            Console.WriteLine("Enter an expression:  "); // input expression from STDIN/Console
            expression=Console.ReadLine();
            if (Prueba.AreParanthesesBalanced(expression))
            {
                Console.WriteLine("Balanced\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Not Balanced\n");
                Console.ReadKey();
            }

        }
    }
}
