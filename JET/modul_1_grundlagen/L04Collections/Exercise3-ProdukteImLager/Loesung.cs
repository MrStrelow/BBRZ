using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

class Program
{
    static string blue = "\u001B[34m";
    static string red = "\u001B[31m";
    static string reset = "\u001B[0m";

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
        // c#, hier wird ein Object Initializer verwendet
        Dictionary<string, List<List<string>>> warehouse = new Dictionary<string, List<List<string>>>
        {
            { "big", new List<List<string>> { bigBox, anotherBigBox } },   
            { "med", new List<List<string>> { mediumBox } },            
            { "small", new List<List<string>> { smallBox } }               
        };

        // JAVA notation (welche hier auf funktioniert)
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


        // Box-Inhalte ausgeben
        Console.WriteLine("\nBox-Inhalte ausgeben:");
        FindBoxesInWarehouse(warehouse, "big");
        FindBoxesInWarehouse(warehouse, "med");
        FindBoxesInWarehouse(warehouse, "small");
        FindBoxesInWarehouse(warehouse, "drüLb");

        // Produktinhalte ausgeben
        Console.WriteLine("\nProduktinhalte mit dessen Boxen ausgeben:");
        FindProductCategoriesOfWarehouse(warehouse, "Fahrrad");
    }

    static void FindBoxesInWarehouse(Dictionary<string, List<List<string>>> warehouse, string boxType) 
    {
        if (boxType == "big" || boxType == "med" || boxType == "small")
        {
            //foreach (List<string> box in warehouse[boxType]) 
            foreach (var box in warehouse[boxType]) 
            {
                Console.WriteLine($"box ({boxType}): ");
                
                foreach (var productType in box)
                { 
                    Console.WriteLine($"\t{productType}");
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.Write($"BoxType is Wrong!");

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    static void FindProductCategoriesOfWarehouse(Dictionary<string, List<List<string>>> warehouse, string productType)
    {
        int boxId = 0;

        if (productType == "Fahrrad" || productType == "Tisch" || productType == "Kulli")
        {
            foreach (var boxes in warehouse)
            {
                foreach (var box in boxes.Value)
                {
                    boxId++;

                    foreach (var productTypeOfBox in box)
                    {
                        if (productTypeOfBox == productType)
                        {
                            Console.WriteLine($"{blue}{productType}{reset}\t - was found in a {red}{boxes.Key}{reset} Box, with id {red}{boxId}{reset}");
                        }
                    }
                }

                boxId = 0;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.Write("ProductType is Wrong!");

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    static void addProductToBoxInWarehouse(Dictionary<string, List<List<string>>> warehouse, int boxId, string productType, string destination)
    {
        // Wir behandeln hier keine Exceptions.

        // ################  Als Mehrfachverzweigung ################ 

        //if (destination == "big" && (productType == "Fahrrad" || productType == "Tisch" || productType == "Kulli"))
        //{
        //    warehouse["big"][boxId].Add(productType);
        //}
        //else if (destination == "med" && (productType == "Fahrrad" || productType == "Kulli"))
        //{
        //    warehouse["med"][boxId].Add(productType);
        //}
        //else if (destination == "small" && productType == "Kulli")
        //{
        //    warehouse["small"][boxId].Add(productType);
        //} 
        //else
        //{
        //    Console.ForegroundColor = ConsoleColor.Cyan;
        //    Console.BackgroundColor = ConsoleColor.DarkRed;

        //    Console.WriteLine("Box zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])");

        //    Console.ResetColor();
        //    return;
        //}

        // ################ Als eine logische Formel: ################ 

        //if (
        //    (destination == "big" && (productType == "Fahrrad" || productType == "Tisch" || productType == "Kulli")) ||
        //    (destination == "med" && (productType == "Fahrrad" || productType == "Kulli")) ||
        //    (destination == "small" && productType == "Kulli")
        //)
        //{
        //    warehouse[destination][boxId].Add(productType);
        //}
        //else
        //{
        //    Console.ForegroundColor = ConsoleColor.Cyan;
        //    Console.BackgroundColor = ConsoleColor.DarkRed;

        //    Console.WriteLine("Box zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])");

        //    Console.ResetColor();
        //    return;
        //}

        // ################ Als guard clause: ################ 
        if (
            (destination == "small" && productType != "Kulli") ||
            (destination == "med" && productType == "Tisch")
        )
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("Box zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])");

            Console.ResetColor();
            return;
        }

        warehouse[destination][boxId].Add(productType);

        Console.WriteLine($"ProductType: {blue}{productType}{reset}\t wurde in {red}{destination}{reset}\t hinzugefügt.");

        Console.ResetColor();
    }
}