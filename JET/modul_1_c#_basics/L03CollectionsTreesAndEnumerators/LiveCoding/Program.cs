
class Program
{
    static string blue = "\u001B[34m";
    static string red = "\u001B[31m";
    static string reset = "\u001B[0m";

    static void Main(string[] args)
    {
        // ProduktTypen
        string fahrrad = "Fahrrad";
        string tisch = "Tisch";
        string kulli = "Kulli";

        // Boxen
        var bigBox = new List<string>();
        var anotherBigBox = new List<string>();
        var mediumBox = new List<string>();
        var smallBox = new List<string>();

        //var warehouse = new Dictionary<string, List<List<string>>>();
        //var lagerBigList = new List<List<string>>();
        //lagerBigList.Add(bigBox);
        //lagerBigList.Add(anotherBigBox);

        //warehouse["big"] = lagerBigList;

        var warehouse = new Dictionary<string, List<List<string>>>
        {
            { "big", new List<List<string>> { bigBox, anotherBigBox } },
            { "med", new List<List<string>> { mediumBox } },
            { "small", new List<List<string>> { smallBox } }
        };

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

    private static void FindProductCategoriesOfWarehouse(Dictionary<string, List<List<string>>> warehouse, string productType)
    {
        int boxId = 0;

        if (productType == "Fahrrad" || productType == "Kulli" || productType == "Tisch")
        {
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
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.Write("ProductType is Wrong!");

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    private static void FindBoxesInWarehouse(Dictionary<string, List<List<string>>> warehouse, string boxType)
    {
        if (boxType == "big" || boxType == "med" || boxType == "small")
        {
            foreach ( var box in warehouse[boxType])
            {
                Console.WriteLine($"box ({boxType}): ");

                foreach (var productType in box)
                {
                    Console.WriteLine($"\t{productType}");
                }
            }
        } 
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.Write($"BoxType: {boxType} is Wrong!");

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    private static void addProductToBoxInWarehouse(Dictionary<string, List<List<string>>> warehouse, int boxId, string productType, string boxType)
    {
        if (
            boxType == "med" && productType == "Tisch" ||
            boxType == "small" && productType != "Kulli")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("Box zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])");

            Console.ResetColor();
            return;
        }

        warehouse[boxType][boxId].Add(productType);

        Console.WriteLine($"ProductType: {blue}{productType}{reset}\t wurde in {red}{boxType}{reset}\t hinzugefügt.");

        Console.ResetColor();
    }
}