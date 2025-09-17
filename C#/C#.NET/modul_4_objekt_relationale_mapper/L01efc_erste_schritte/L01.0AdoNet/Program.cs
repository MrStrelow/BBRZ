using FruehstuecksrestaurantADO.Models;
using Microsoft.Data.SqlClient; //Install-Package Microsoft.Data.SqlClient

string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=FruehstuecksrestaurantADO;Trusted_Connection=True;";

// Stellt sicher, dass die Tabelle existiert, bevor wir darauf zugreifen.
EnsureTableExists();

// NEUES GERICHT HINZUFÜGEN
Console.WriteLine("Füge ein neues Gericht hinzu...");
var newPancakes = new Dish
{
    Name = "Pancakes",
    Description = "Mit Ahornsirup und Früchten",
    Price = 7.50
};
AddDish(newPancakes);
Console.WriteLine("Gericht hinzugefügt!");
Console.WriteLine();

// ALLE GERICHTE AUSLESEN UND ANZEIGEN
Console.WriteLine("Alle Gerichte in der Datenbank:");
List<Dish> dishes = GetAllDishes();
foreach (var dish in dishes)
{
    Console.WriteLine($"ID: {dish.Id} - {dish.Name}: {dish.Description} ({dish.Price:C})");
}
Console.WriteLine();

// EIN GERICHT AKTUALISIEREN
Console.WriteLine("Aktualisiere Pancakes...");
var dishToUpdate = dishes.Find(d => d.Name == "Pancakes");
if (dishToUpdate != null)
{
    dishToUpdate.Price = 8.00;
    UpdateDish(dishToUpdate);
    Console.WriteLine("Preis aktualisiert!");
}
Console.WriteLine();

// EIN GERICHT LÖSCHEN
Console.WriteLine("Lösche Pancakes...");
var dishToDelete = GetAllDishes().Find(d => d.Name == "Pancakes");
if (dishToDelete != null)
{
    DeleteDish(dishToDelete.Id);
    Console.WriteLine("Gericht gelöscht!");
}

Console.WriteLine("\nVerbleibende Gerichte:");
dishes = GetAllDishes();
foreach (var dish in dishes)
{
    Console.WriteLine($"ID: {dish.Id} - {dish.Name}: {dish.Description} ({dish.Price:C})");
}


Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden.");
Console.ReadKey();

void AddDish(Dish dish)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        // SQL-Injection wird durch Verwendung von Parametern verhindert!
        string sql = "INSERT INTO Dishes (Name, Description, Price) VALUES (@Name, @Description, @Price)";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Name", dish.Name);
        command.Parameters.AddWithValue("@Description", dish.Description);
        command.Parameters.AddWithValue("@Price", dish.Price);

        connection.Open();
        command.ExecuteNonQuery();
    }
}

List<Dish> GetAllDishes()
{
    var dishes = new List<Dish>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string sql = "SELECT Id, Name, Description, Price FROM Dishes";
        SqlCommand command = new SqlCommand(sql, connection);

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            dishes.Add(new Dish
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Price = reader.GetDouble(3)
            });
        }
    }

    return dishes;
}

void UpdateDish(Dish dish)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string sql = "UPDATE Dishes SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Name", dish.Name);
        command.Parameters.AddWithValue("@Description", dish.Description);
        command.Parameters.AddWithValue("@Price", dish.Price);
        command.Parameters.AddWithValue("@Id", dish.Id);

        connection.Open();
        command.ExecuteNonQuery();
    }
}

void DeleteDish(int id)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string sql = "DELETE FROM Dishes WHERE Id = @Id";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        command.ExecuteNonQuery();
    }
}

// Hilfsmethode, um die Tabelle zu erstellen, falls sie nicht existiert.
void EnsureTableExists()
{
    using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        string sql = @"
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dishes]') AND type in (N'U'))
        BEGIN
            CREATE TABLE [dbo].[Dishes](
	            [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	            [Name] [nvarchar](max) NOT NULL,
	            [Description] [nvarchar](max) NULL,
	            [Price] [float] NOT NULL
            )
        END";
        var command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }
}
