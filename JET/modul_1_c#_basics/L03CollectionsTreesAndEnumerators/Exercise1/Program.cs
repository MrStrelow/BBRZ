using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

class Program
{
    static void Main()
    {
        // ProduktTypen
        string fahrrad = "Fahrrad";
        string tisch = "Tisch";
        string kulli = "Kulli";

        // Boxen erstellen
        List<string> bigBox = new List<string>(); 
        List<string> anotherBigBox = new List<string>(); 
        List<string> mediumBox = new List<string>(); 
        List<string> smallBox = new List<string>();


        // Lager als Dictionary, das die Boxen nach Größe kategorisiert
        Dictionary<string, List<List<string>>> warehouse = new Dictionary<string, List<List<string>>>
        {
            { "big", new List<List<string>> { bigBox, anotherBigBox } },   
            { "med", new List<List<string>> { mediumBox } },            
            { "small", new List<List<string>> { smallBox } }               
        };

        // JAVA notation
        //Dictionary<string, List<List<string>>> warehouse = new Dictionary<string, List<List<string>>>();

        //List<List<string>> lagerBigList = new List<List<string>>();
        //lagerBigList.Add(bigBox);
        //lagerBigList.Add(anotherBigBox);        

        //List<List<string>> lagerMediumList = new List<List<string>>();
        //lagerBigList.Add(mediumBox);

        //List<List<string>> lagerSmallList = new List<List<string>>();
        //lagerBigList.Add(smallBox);

        //warehouse["big"] = lagerBigList;
        //warehouse["medium"] = lagerMediumList;
        //warehouse["big"] = lagerSmallList;


        // Überprüfe beim hinufügen ob die ProduktTypen den Größen der Boxen entsprechen
        // Das geht einfacher mit einer Methode. Das haben wir nicht speziell spezifiziert in der Angabe (mit Absicht!).
        addProductToBoxInWarehouse(warehouse, 0, fahrrad, "big");
        addProductToBoxInWarehouse(warehouse, 0, kulli, "big");

        addProductToBoxInWarehouse(warehouse, 1, fahrrad, "big");
        addProductToBoxInWarehouse(warehouse, 1, fahrrad, "big");
        addProductToBoxInWarehouse(warehouse, 1, fahrrad, "big");
        addProductToBoxInWarehouse(warehouse, 1, tisch, "big");
        addProductToBoxInWarehouse(warehouse, 1, tisch, "big");

        addProductToBoxInWarehouse(warehouse, 0, fahrrad, "med");
        addProductToBoxInWarehouse(warehouse, 0, fahrrad, "med");
        addProductToBoxInWarehouse(warehouse, 0, kulli, "med");
        addProductToBoxInWarehouse(warehouse, 0, kulli, "med");

        addProductToBoxInWarehouse(warehouse, 0, fahrrad, "small"); // Fügt es nicht hinzu, da eine Box welche small zu für ein Fahrrad nicht passend ist.
        addProductToBoxInWarehouse(warehouse, 0, kulli, "small");
        addProductToBoxInWarehouse(warehouse, 0, kulli, "small");


        // Lager-Inhalte ausgeben
        Console.WriteLine("Inhalt des Lagers:");
        foreach (var box in warehouse)
        {
            Console.WriteLine($"Box-Größe: {box.Key}");
            foreach (var produkt in box.Value)
            {
                Console.WriteLine($" - {produkt}");
            }
        }
    }

    static void FindBoxesInWarehouse(Dictionary<string, List<List<string>>> warehouse, string BoxType) 
    {
        warehouse[]
    }

    static void FindProductCategoriesOfWarehousen(Dictionary<string, List<List<string>>> warehouse, string productType)
    {

    }

    static void addProductToBoxInWarehouse(Dictionary<string, List<List<string>>> warehouse, int boxId, string productType, string destination)
    {
        // Wir behandeln hier keine Exceptions.
        if (destination == "big" && (productType == "Fahrrad" || productType == "Tisch" || productType == "Kulli"))
        {
            warehouse["big"][boxId].Add(productType);
        }
        else if (destination == "med" && (productType == "Fahrrad" || productType == "Kulli"))
        {
            warehouse["med"][boxId].Add(productType);
        }
        else if (destination == "small" && productType == "Kulli")
        {
            warehouse["small"][boxId].Add(productType);
        } 
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("Box zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])");

            Console.ResetColor();
            return;
        }

        string blue = "\u001B[34m";
        string red = "\u001B[31m";
        string reset = "\u001B[0m";

        Console.WriteLine($"ProductType: {blue}{productType}{reset}\t wurde in {red}{destination}{reset}\t hinzugefügt.");

        Console.ResetColor();
    }
}