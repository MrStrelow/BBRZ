
```csharp
public class Hamster
{
    // ...
    private Plane plane;
    // ...
    private static string _hungryRepresentation = "😡";
    // ...
    private List<Seedling> mouth = new List<Seedling>();
    // ...
    public string Representation { get; private set; }
    // ...
    private static string _fedRepresentation = "🐹";
    // ...
    public bool IsHungry { get; private set; }
    // ...
    public (int x, int y) Position { get; set; }
    // ...
    public Hamster(Plane plane)
    {
        IsHungry = false;
        Representation = _fedRepresentation;
        this.plane = plane;
    }
}

public class Programm
{
    static void Main(string[] args)
    {
        Plane plane = new Plane();
        Hamster hempter = new Hamster(plane);
    }
}
```





- a) Finde die Fehler in diesem Code und markiere diese.
- b) Erkläre wieso diese Fehler zu einer nicht gültigen `Guard Clause` führen. 

a) 💢 
b) Wir fragen den verkehrten Zustand ab. Wenn Kunde null ist, sollten wir auf ``Kunde is null`` oder ``Kunde == null`` abfragen.
```csharp
if (kunde is not null)
    throw new ArgumentNullException("Kunde darf nicht null sein.");
```

---

a) ✅ 
b) ✅
```csharp
if (!kunde.IstAktiv)
{
    Console.WriteLine("Der Kunde ist nicht aktiv.");
    return;
}
```

---

a) 💢 
b) Exit der Methode ist vor der Ausgabe.

```csharp
if (string.IsNullOrEmpty(kunde.Kundenkarte))
{
    return;
    Console.WriteLine("Der Kunde hat keine Kundenkarte.");
}
```

---

a) 💢
b) Wir werfen ein ``Objekt`` welches keine ``Exception`` ist und fragen den verkehrten Zustand ab (der else Zweig ist zudem unnötig).
* Wir könnne nur mit ``throw`` arbeiten, wenn dahinter ein ``Objekt`` einer ``Klasse`` steht, welche eine ``Exception`` **ist**. Das **"ist"** hier ist als ``Ist-Beziehung`` zu sehen.
* Den Zustand den wir wollen ist ``kunde.MitgliedschaftGueltigBis < DateTime.Now`` und nicht ``kunde.MitgliedschaftGueltigBis >= DateTime.Now``

```csharp
if (kunde.MitgliedschaftGueltigBis >= DateTime.Now)
    throw new User("Die Mitgliedschaft des Kunden ist abgelaufen.");
else 
    Console.WriteLine("Die Mitgliedschaft des Kunden ist gültig.");


Console.WriteLine("Alle Überprüfungen bestanden. Der Kunde darf einkaufen!");
```