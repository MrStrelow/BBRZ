using System;

namespace Aufgabe1
{
    class Program
    {
        static void Main()
        {
            CallByValue();
            CallByReference();
        }

        static void CallByValue()
        {
            int alter = 10;
            int um = 13;
            Console.WriteLine($"Vor dem Aufruf: {alter}");
            Altere(alter, um);
            Console.WriteLine($"Nach dem Aufruf: {alter}");
        }

        static void CallByReference()
        {
            int alter = 10;
            int um = 13;
            Console.WriteLine($"Vor dem Aufruf: {alter}");
            Altere(ref alter, um);
            Console.WriteLine($"Nach dem Aufruf: {alter}");
        }

        static void Altere(int aktuellesAlter, int zaehleHinzu)
        {
            aktuellesAlter += 5;
            Console.WriteLine($"In der Methode: {aktuellesAlter}");
        }

        static void Altere(ref int aktuellesAlter, int zaehleHinzu)
        {
            aktuellesAlter += 5;
            Console.WriteLine($"In der Methode: {aktuellesAlter}");
        }
    }
}

namespace Aufgabe2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Value Style ---");
            ArraySideEffectExampleValueStyle();
            Console.WriteLine("--- Reference Style ---");
            ArraySideEffectExampleReferenceStyle();
        }

        static void ArraySideEffectExampleValueStyle()
        {
            int[] numbers = { 10, 20, 30 };
            Console.WriteLine("Array vor dem Aufruf: " + string.Join(", ", numbers));

            ModifyArrayValueStyleStyle(numbers);

            Console.WriteLine("Array nach dem Aufruf: " + string.Join(", ", numbers));
        }

        static void ArraySideEffectExampleReferenceStyle()
        {
            int[] numbers = { 10, 20, 30 };
            Console.WriteLine("Array vor dem Aufruf: " + string.Join(", ", numbers));

            ModifyArrayReferenceStyle(numbers);

            Console.WriteLine("Array nach dem Aufruf: " + string.Join(", ", numbers));
        }

        static void ModifyArrayValueStyle(int[] arr)
        {
            // Kopiere arr in ein neues Array mit namen kopie.
            int[] kopie = new int[arr.Length];  
            for (int i = 0; i < arr.Length; i++)
            {
                kopie[i] = arr[i];
            }

            // Diese Änderung wirkt sich auf das Original-Array aus,
            // da 'arr' auf dasselbe Objekt im Speicher zeigt wie 'numbers'.
            if (kopie.Length > 0)
            {
                kopie[0] = 99;
            }
        }

        static void ModifyArrayReferenceStyle(int[] arr)
        {
            // Diese Änderung wirkt sich auf das Original-Array aus,
            // da 'arr' auf dasselbe Objekt im Speicher zeigt wie 'numbers'.
            if (arr.Length > 0)
            {
                arr[0] = 99;
            }
        }
    }
}

namespace Aufgabe3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("---- mit If ----");
            TryParseIntExampleIf();
            Console.WriteLine("---- mit If - und verwendung der out variable außerhalb des if ----");
            TryParseIntExampleIfMitVerwendungDerVariableAußerhalbDerIf();
            Console.WriteLine("---- mit While ----");
            TryParseIntExampleWhile();
            Console.WriteLine("---- mit While - und verwendung der out variable außerhalb der while ----");
            TryParseIntExampleWhileMitVerwendungDerVariableAußerhalbDerWhile();
        }

        static void TryParseIntExampleIf()
        {
            Console.WriteLine("Bitte gib dein Alter ein: ");
            string alterAlsString = Console.ReadLine();

            if (int.TryParse(alterAlsString, out int aterAlsInt))
            {
                Console.WriteLine($"Parse erfolgreich: {aterAlsInt}");
            }
            else
            {
                //Console.WriteLine($"Geht das? {alterAlsInt}"); 
                Console.WriteLine($"Parse fehlgeschlagen.");
            }
            //Console.WriteLine($"Geht das? {alterAlsInt}");
        }

        static void TryParseIntExampleIfMitVerwendungDerVariableAußerhalbDerIf()
        {
            Console.WriteLine("Bitte gib dein Alter ein: ");
            string alterAlsString = Console.ReadLine();

            int alterAlsInt;
            if (int.TryParse(alterAlsString, out alterAlsInt))
            {
                Console.WriteLine($"Parse erfolgreich: {alterAlsInt}");
            }
            else
            {
                Console.WriteLine($"Parse von {alterAlsInt} fehlgeschlagen."); // was steht inalterAlsInt, wenn TyParse fehlschlägt?
            }

            Console.WriteLine($"Ah, der Scope der Variable {alterAlsInt}, ist nun in der gesamten Methode.");
        }

        static void TryParseIntExampleWhile()
        {
            Console.WriteLine("Bitte gib dein Alter ein: ");
            string alterAlsString = Console.ReadLine();

            while (int.TryParse(alterAlsString, out int alterAlsInt))
            {
                Console.WriteLine($"Parse erfolgreich: {alterAlsInt}");
            }

            //Console.WriteLine($"Geht das? {alterAlsInt}");
        }

        static void TryParseIntExampleWhileMitVerwendungDerVariableAußerhalbDerWhile()
        {
            Console.WriteLine("Bitte gib dein Alter ein: ");
            string alterAlsString = Console.ReadLine();

            int alterAlsInt;
            while (!int.TryParse(alterAlsString, out alterAlsInt))
            {
                Console.WriteLine($"Parse erfolgreich: {alterAlsInt}");
            }

            Console.WriteLine($"Ah, der Scope der Variable {alterAlsInt}, ist nun in der gesamten Methode.");
        }
    }

    namespace Aufgabe4
    {
        public enum Richtung
        {
            North,
            East,
            West,
            South
        }

        class Program
        {
            static void Main()
            {
                TryParseEnumExample();
            }

            static void TryParseEnumExample()
            {
                string input = "wESt";
                Richtung richtung;

                // Der zweite Parameter 'true' ignoriert Groß-/Kleinschreibung
                if (Enum.TryParse(input, true, out richtung)) // wir wollen hier keinen int sondern einen Enum umwandeln!
                {
                    Console.WriteLine($"Parse erfolgreich: Die Richtung ist {richtung}");
                }
                else
                {
                    Console.WriteLine("Parse fehlgeschlagen.");
                }

                Console.WriteLine($"Wir können wieder {richtung} verwenden, da es außerhalb der If-Verzweigung definiert wurde.");
            }
        }
    }
}