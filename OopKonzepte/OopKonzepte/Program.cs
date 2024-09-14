using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            BinaereZahl binaryNumber = new BinaereZahl("101");
            Zahl zahlAberInEchtBinary = new BinaereZahl("101");
            Zahl decimalNumber = new DezimaleZahl("101");

            Summierbar<Zahl> summierbar = new BinaereZahl("101");
            Writable schreibbar = new BinaereZahl("101");

            //binaryNumber.writeToDisk();
            //zahlAberInEchtBinary.writeToDisk();
            //decimalNumber.writeToDisk();

            Console.WriteLine(binaryNumber.sum(decimalNumber).Wert);
            Console.WriteLine(binaryNumber.sum(binaryNumber).Wert);
            Console.WriteLine(decimalNumber.sum(zahlAberInEchtBinary).Wert);


            //decimalNumber.sum(summierbar);
        }
    }
}
