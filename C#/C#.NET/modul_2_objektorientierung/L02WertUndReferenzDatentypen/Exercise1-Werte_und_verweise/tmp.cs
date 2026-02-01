// nullable operator bei variablen erstellung - (null conditional operator)

// ... bei referenzdaten
using System.Numerics;

string? a = null;


if (a is not null)
{
    string b = a;       // keine warning hier.
    a.Contains("b");    // keine warning hier.
}

// ... bei wertdaten
int? alter = null;

if (alter is not null)
{

}

// merke:
// integer können wie referenzdaten syntaktisch verwendetet werden -> siehe webprogrammierung.
// der compiler denkt solange mit, bis wir ein ? in den typ schreiben. 


// nullable operator ? bei methodenaufrufe in kombination mit dem null coalescing operator ??
List<string> namen = null;//new List<string>();

int? anzahl = namen?.Count ?? 0;

anzahl ??= 0;
//anzahl ??= 0; // das gleiche wie anzahl = anzahl ?? 0;

//anzahl = anzahl + 10;
//anzahl += 10;

anzahl = namen is not null ? anzahl : 0;


// gleich wie ? mit ?? oder ? :
if (namen is not null)
{
    anzahl = namen.Count;
} 
else
{
    anzahl = 0;
}



Order order = new List<Order>()
    .FirstOrDefault(o => o.Id == 8);

if (order == null) throw new Exception();

new OrderDto
{
    OrderId = order.Id,
    CustomerName = order.Customer!.FullName
};

public class Order
{
    public int Id { get; set; }
    public Customer? Customer { get; set; }
}

public class Customer
{
    public required string FullName { get; set; }
}

public class OrderDto
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
}