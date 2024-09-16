using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEfCore.Models;

class Product
{
    // [Key]
    public int Id { get; set; }

    // [Required] annotation für kein null in der datenbank speichern, aber C# erlaubt diesen Wert beim Programmieren.
    // ?string Name : "attribute ist nullable: Name kann null sein."
    // string Name = null!; : Null-forgiving Operator: unterdrücke null warnings.

    // EF-Core erlaubt null wenn wir den Null-forgiving Operator verwenden.
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}";
    }
}

