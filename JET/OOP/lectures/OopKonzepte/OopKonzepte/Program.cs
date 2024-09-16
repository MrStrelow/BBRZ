using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte;

internal class Program
{

    // TODO: Beispiel falsches beispiel aufbauen und dann korrekter darstellen.
    // TODO: Bausteine besprechen
    //      - interfaces, classes, abstract classes
    //      - virtual, static, override
    // TODO: Kapselung, Koppelung und Zusammenhalt
    // TODO: Vererbung vs. Untertyp Beziehung
    // TODO: überschreiben vs. überladen

    // TODO: Beispiele:
    // - Zahlen:
    //   - Polymorphism durch:
    //     - virtual and override.
    //     - how to deal with arguments in methods?
    //   - Interfaces:
    //     - Explicit Interface vs. Interface, 
    //     - abstract class vs default implementation interface
    // - Buchhaltung:

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
