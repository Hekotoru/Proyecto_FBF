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
            //intacia del objeto que maneja el llamado al archivo InputTXT
            FBF_Project.INFILE infile = new FBF_Project.INFILE();


            System.Console.Write("NOMBRE DEL ARCHIVO DE ENTRADA: ");

            string inputname = Console.ReadLine();

            ///ESTO ES UNA PRUEBA PARA IMPRIMIR LA LISTA DE PROPOSICIONES
            foreach (string value in infile.LoadFile(inputname.ToString()))
            {
                System.Console.WriteLine(value);
            }

            System.Console.ReadKey();
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
