public static class RestaurantDbContext
{
    public static List<Customer> Customers { get; private set; } = new();
    public static List<Ingredient> Ingredients { get; private set; } = new();
    public static List<PreparationStep> PreparationSteps { get; private set; } = new();
    public static List<Table> Tables { get; private set; } = new();
    public static List<Dish> Dishes { get; private set; } = new();
    public static List<Menu> Menus { get; private set; } = new();
    public static List<Visit> Visits { get; private set; } = new();
    public static List<Order> Orders { get; private set; } = new();
    public static List<Bill> Bills { get; private set; } = new();

    public static void Initialize() => Seed();

    // Hilfsmethode zur Vergabe fortlaufender IDs
    // Verwendet noch nicht bekannte Syntax und Generizität.
    // Ist nicht Testrelevant, jedoch für besonders interessierte hier der Code.
    public static int GetNextId(string key)
    {
        return key switch
        {
            "Customers" => CalculateNextId(Customers),
            "Bills" => CalculateNextId(Bills),
            "Dishes" => CalculateNextId(Dishes),
            "Ingredients" => CalculateNextId(Ingredients),
            "Menus" => CalculateNextId(Menus),
            "Orders" => CalculateNextId(Orders),
            "PreparationSteps" => CalculateNextId(PreparationSteps),
            "Tables" => CalculateNextId(Tables),
            "Visits" => CalculateNextId(Visits),
    
            // default case:
            _ => throw new ArgumentException($"Der Schlüssel '{key}' ist keine valide Entität.", nameof(key))
        };
    }

    private static int CalculateNextId<T>(IEnumerable<T> collection) where T : IEntity
    {
        var maxId = collection.Select(item => item.Id).DefaultIfEmpty(0).Max();
        return maxId + 1;
    }

    // Befüllt die Datenbank mit den Daten aus der SeedData-Vorlage
    private static void Seed()
    {
        // -- Customers --
        Customers.AddRange(new Customer[]
        {
            new Customer { Id = 1, Name = "Anna Weber" },
            new Customer { Id = 2, Name = "Markus Huber" }
        });
        
        // -- Ingredients --
        var ingredientList = new List<Ingredient>
        {
            new Ingredient { Id = 1, Name = "Salz" }, new Ingredient { Id = 2, Name = "Pfeffer" }, new Ingredient { Id = 3, Name = "Olivenöl" },
            new Ingredient { Id = 4, Name = "Butter" }, new Ingredient { Id = 5, Name = "Ei" }, new Ingredient { Id = 6, Name = "Milch" },
            new Ingredient { Id = 7, Name = "Mehl" }, new Ingredient { Id = 8, Name = "Zucker" }, new Ingredient { Id = 9, Name = "Brot" },
            new Ingredient { Id = 10, Name = "Semmel" }, new Ingredient { Id = 11, Name = "Toast" }, new Ingredient { Id = 12, Name = "Croissant" },
            new Ingredient { Id = 13, Name = "Bagel" }, new Ingredient { Id = 14, Name = "Schinken" }, new Ingredient { Id = 15, Name = "Speck (Bacon)" },
            new Ingredient { Id = 16, Name = "Wurst (Sausage)" }, new Ingredient { Id = 17, Name = "Käse (Gouda)" }, new Ingredient { Id = 18, Name = "Frischkäse" },
            new Ingredient { Id = 19, Name = "Mozzarella" }, new Ingredient { Id = 20, Name = "Feta" }, new Ingredient { Id = 21, Name = "Räucherlachs" },
            new Ingredient { Id = 22, Name = "Tomate" }, new Ingredient { Id = 23, Name = "Gurke" }, new Ingredient { Id = 24, Name = "Zwiebel" },
            new Ingredient { Id = 25, Name = "Paprika" }, new Ingredient { Id = 26, Name = "Avocado" }, new Ingredient { Id = 27, Name = "Spinat" },
            new Ingredient { Id = 28, Name = "Champignons" }, new Ingredient { Id = 29, Name = "Kartoffel" }, new Ingredient { Id = 30, Name = "Blattsalat" },
            new Ingredient { Id = 31, Name = "Rucola" }, new Ingredient { Id = 32, Name = "Orange" }, new Ingredient { Id = 33, Name = "Zitrone" },
            new Ingredient { Id = 34, Name = "ErdbContexteere" }, new Ingredient { Id = 35, Name = "Heidelbeere" }, new Ingredient { Id = 36, Name = "Banane" },
            new Ingredient { Id = 37, Name = "Apfel" }, new Ingredient { Id = 38, Name = "Naturjoghurt" }, new Ingredient { Id = 39, Name = "Honig" },
            new Ingredient { Id = 40, Name = "Kaffeebohnen" }
        };

        Ingredients.AddRange(ingredientList);
        
        // -- PreparationSteps --
        var stepList = new List<PreparationStep>
        {
            new PreparationStep { Id = 1, Description = "Gemüse waschen und trocknen", StepOrder = 1 }, new PreparationStep { Id = 2, Description = "In Scheiben schneiden", StepOrder = 2 },
            new PreparationStep { Id = 3, Description = "In kleine Würfel schneiden", StepOrder = 2 }, new PreparationStep { Id = 4, Description = "Eier in einer Schüssel verquirlen", StepOrder = 1 },
            new PreparationStep { Id = 5, Description = "Speck in der Pfanne knusprig anbraten", StepOrder = 1 }, new PreparationStep { Id = 6, Description = "Brot goldbContextraun toasten", StepOrder = 1 },
            new PreparationStep { Id = 7, Description = "Kaffeebohnen frisch mahlen", StepOrder = 1 }, new PreparationStep { Id = 8, Description = "Kaffee aufbrühen", StepOrder = 2 },
            new PreparationStep { Id = 9, Description = "Früchte auspressen", StepOrder = 1 }, new PreparationStep { Id = 10, Description = "Butter in einer Pfanne schmelzen", StepOrder = 1 },
            new PreparationStep { Id = 11, Description = "Auf einem Teller anrichten", StepOrder = 10 }, new PreparationStep { Id = 12, Description = "Mit frischen Kräutern garnieren", StepOrder = 11 },
            new PreparationStep { Id = 13, Description = "Mit Salz und Pfeffer würzen", StepOrder = 9 }, new PreparationStep { Id = 14, Description = "Aufstrich gleichmäßig verteilen", StepOrder = 3 },
            new PreparationStep { Id = 15, Description = "Zutaten schichten", StepOrder = 4 }, new PreparationStep { Id = 16, Description = "Im Ofen bei 180°C backen", StepOrder = 5 },
            new PreparationStep { Id = 17, Description = "Ei für 3 Minuten pochieren", StepOrder = 3 }, new PreparationStep { Id = 18, Description = "Gemüse in der Pfanne sautieren", StepOrder = 3 },
            new PreparationStep { Id = 19, Description = "Früchte in mundgerechte Stücke schneiden", StepOrder = 1 }, new PreparationStep { Id = 20, Description = "Alle Zutaten in einer Schüssel vermengen", StepOrder = 4 }
        };

        PreparationSteps.AddRange(stepList);
        
        // -- Tables --
        Tables.AddRange(new Table[]
        {
            new Table { Id = 1, TableNumber = "S1", Seats = 8 }, new Table { Id = 2, TableNumber = "S2", Seats = 4 },
            new Table { Id = 3, TableNumber = "G1", Seats = 4 }, new Table { Id = 4, TableNumber = "G2", Seats = 4 },
            new Table { Id = 5, TableNumber = "B1", Seats = 6 }
        });

        // -- Dishes --
        var wienerFruehstueck = new Dish { Id = 1, Name = "Wiener Frühstück", Price = 8.50m, Ingredients = { ingredientList[9], ingredientList[3], ingredientList[13], ingredientList[16] }, PreparationSteps = { stepList[10] } };
        var englishBreakfast = new Dish { Id = 2, Name = "English Breakfast", Price = 14.00m, Ingredients = { ingredientList[4], ingredientList[14], ingredientList[15], ingredientList[10], ingredientList[27] }, PreparationSteps = { stepList[4], stepList[5], stepList[17], stepList[10] } };
        var avocadoToast = new Dish { Id = 3, Name = "Avocado Toast mit pochiertem Ei", Price = 11.50m, Ingredients = { ingredientList[10], ingredientList[25], ingredientList[4], ingredientList[32], ingredientList[0], ingredientList[1] }, PreparationSteps = { stepList[5], stepList[16], stepList[12], stepList[10], stepList[11] } };
        var lachsBagel = new Dish { Id = 4, Name = "Lachs-Bagel", Price = 12.00m, Ingredients = { ingredientList[12], ingredientList[20], ingredientList[17], ingredientList[23] }, PreparationSteps = { stepList[5], stepList[1], stepList[13], stepList[14], stepList[10] } };
        var joghurtBowl = new Dish { Id = 5, Name = "Joghurt Bowl mit Früchten", Price = 9.00m, Ingredients = { ingredientList[37], ingredientList[38], ingredientList[33], ingredientList[34], ingredientList[35] }, PreparationSteps = { stepList[18], stepList[19], stepList[10] } };
        var bauernomelett = new Dish { Id = 6, Name = "Bauernomelett", Price = 10.50m, Ingredients = { ingredientList[4], ingredientList[28], ingredientList[23], ingredientList[14], ingredientList[0], ingredientList[1] }, PreparationSteps = { stepList[2], stepList[4], stepList[3], stepList[17], stepList[12], stepList[10] } };
        var croissantDeluxe = new Dish { Id = 7, Name = "Croissant Deluxe", Price = 7.50m, Ingredients = { ingredientList[11], ingredientList[13], ingredientList[16], ingredientList[21] }, PreparationSteps = { stepList[1], stepList[14], stepList[15], stepList[10] } };
        var caprese = new Dish { Id = 8, Name = "Caprese-Sticks", Price = 6.00m, Ingredients = { ingredientList[21], ingredientList[18], ingredientList[2], ingredientList[1] }, PreparationSteps = { stepList[0], stepList[1], stepList[14], stepList[10], stepList[11] } };
        var kaffeeCrema = new Dish { Id = 9, Name = "Kaffee Crema", Price = 3.50m, Ingredients = { ingredientList[39] }, PreparationSteps = { stepList[6], stepList[7] } };
        var frischGepressterOJ = new Dish { Id = 10, Name = "Frisch gepresster Orangensaft", Price = 4.50m, Ingredients = { ingredientList[31] }, PreparationSteps = { stepList[8] } };
        
        Dishes.AddRange(new[] { wienerFruehstueck, englishBreakfast, avocadoToast, lachsBagel, joghurtBowl, bauernomelett, croissantDeluxe, caprese, kaffeeCrema, frischGepressterOJ });

        // -- Menus --
        Menus.AddRange(new Menu[]
        {
            new Menu { Id = 1, Name = "Menü 'Klassiker'", Price = 11.00m, Dishes = { wienerFruehstueck, kaffeeCrema } },
            new Menu { Id = 2, Name = "Menü 'Vital'", Price = 14.50m, Dishes = { joghurtBowl, frischGepressterOJ } }
        });
    }
}