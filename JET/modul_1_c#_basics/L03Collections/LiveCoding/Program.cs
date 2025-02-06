class Program
{
    static string blue = "\u001B[34m";
    static string red = "\u001B[31m";
    static string reset = "\u001B[0m";

    static void Main(string[] args)
    {
        // ProduktTypen
        string fahrrad = "Fahrrad"; // hoehe: 1m breite: 0.5m länge: 1.5m
        string tisch = "Tisch";     // hoehe: 1.5m breite: 1.5m länge: 2.5m
        string kulli = "Kulli";     // hoehe: 12cm breite: 5mm länge: 5mm

        // Boxen erstellen
        List<string> bigBox = new List<string>();
        List<string> anotherBigBox = new List<string>();
        List<string> mediumBox = new List<string>();
        List<string> smallBox = new List<string>();

        // Lager erstellen
        Dictionary<string, List<List<string>>> warehouse = new Dictionary<string, List<List<string>>>
        {
            { "big", new List<List<string>> { bigBox, anotherBigBox } },
            { "med", new List<List<string>> { mediumBox } },
            { "small", new List<List<string>> { smallBox } }
        };

        // Aufrufe aus der Angabe:
        // Überprüfe beim hinufügen ob die ProduktTypen den Größen der Boxen entsprechen
        // Das geht einfacher mit einer Methode. Das haben wir nicht speziell spezifiziert in der Angabe (mit Absicht!).
        addProductToBoxInWarehouse(warehouse, 0, fahrrad, "big");
        addProductToBoxInWarehouse(warehouse, 0, kulli, "big"); // Fehler, sind jetzt umweltbewusst.

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
        //FindBoxesInWarehouse(warehouse, "drüLb");

        // Produktinhalte ausgeben
        Console.WriteLine("\nProduktinhalte mit dessen Boxen ausgeben:");
        FindProductCategoriesOfWarehouse(warehouse, "Fahrrad");
    }

    static void FindBoxesInWarehouse(Dictionary<string, List<List<string>>> warehouse, string boxType) 
    {
        foreach( var box in warehouse[boxType] )
        {
            Console.WriteLine($"box ({boxType}): ");

            foreach (var productType in box)
            {
                Console.WriteLine($"\t{productType}");
            }
        } 
    }
    static void FindProductCategoriesOfWarehouse(Dictionary<string, List<List<string>>> warehouse, string productType) 
    {
        int boxId = 0;
        foreach (var boxes in warehouse)
        {
            foreach (var box in boxes.Value)
            {
                boxId++;

                foreach (var productTypeInBox in box)
                {
                    if (productTypeInBox == productType)
                    {
                        Console.WriteLine($"{blue}{productType}{reset}\t - was found in a {red}{boxes.Key}{reset} Box, with id {red}{boxId}{reset}");
                    }
                }
            }

            boxId = 0;
        }
    }

    // Hilfsmethode um Boxen ins Warenhaus zu geben.
    static void addProductToBoxInWarehouse(Dictionary<string, List<List<string>>> warehouse, int boxId, string productType, string key) 
    { 
        if (
            (key == "big" && productType == "Kulli") ||
            (key == "med" && productType == "Tisch") ||
            (key == "small" && productType != "Kulli")
        )
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("Box zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])");

            Console.ResetColor();
            return;
        }

        warehouse[key][boxId].Add(productType);
    }
}