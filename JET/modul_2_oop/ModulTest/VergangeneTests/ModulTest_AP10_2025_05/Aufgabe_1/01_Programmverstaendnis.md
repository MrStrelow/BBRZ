- a)
    1) Finde die Fehler in diesem Code und markiere diese.
    2) Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionell falschen ``Property``(Eigenschaft) führen. 

```csharp
// Korrekt
protected string Name { get; private set; } 

// Fehler - modifier für property selbst (links) darf nicht einschränkender als jene bei den get und set sein.
private string Name { get; protected set; } 

// Fehler - nur ein modifier für get und set möglich.
public string Name { protected get; private set; } 

// Fehler
public int Id
{
    get;
    set
    {
        if (value > 20)
        {
            Id = value; // <--- FEHLER 1, wir rufen mit Id = value immer wieder die set-methode auf. Da wir in der set-methode sind, gibt es eine Endlosschleife.
        }
    }
}

// Fehler
private int _inGameCash;
public int InGameCash
{
    get { return _inGameCash; }
    set
    {
        if (value >= Game.SmallestPossibleAmount)
        {
            _inGameCash = value; 
        }
        else
        {
            SaveStateOfUser(this); 
            _games_won_by_User = 9651; // <--- Fehler, es wird nicht im kommentar ausgeführt was gefragt ist.          
            flagForScam(this);    
        }
    }
}

// Korrekt.
private int _anzahlKursTeilnehmer;
public int AnzahlKursTeilnehmer
{
    get
    {
        return _anzahlKursTeilnehmer;
    }
    set
    {
        if (value > 20)
        {
            _anzahlKursTeilnehmer = value; 
        } // wir gehen nicht auf das "stille" Verhalten ein, welches passiert wenn value <= 20
    }
}

// Korrekt
private int _anzahlKunden;
public int AnzahlKunden
{
    get => _anzahlKunden;
    set => _anzahlKunden = value > 20 ? value : _anzahlKunden; // wir gehen nicht auf das "stille" Verhalten ein, welches passiert wenn value <= 20
}

// Korrekt
private int _anzahlKoffer;
public int AnzahlKoffer
{
    get => _anzahlKoffer;
    set
    {
        if (value <= 2_000)
        {
            throw new ArgumentException("Anzahl der Koffer muss größer als 2000 sein.");
        }

        _anzahlKoffer = value;
    }
}

// komisch - jedoch Korrekt
private int? _x;
public int? X
{
    get => _x < 0 ? (-5) * _x : _x; 
    set => _x = _x ?? value * (25 / 3) - 25; 
}

// komisch - jedoch Korrekt
private int? _x; 
public int? X 
{
    get => _x < 0 ? (-5) * _x : _x; 
    set => _x ??= value * (25 / 3) - 25; 
}
```

- b) Was bedeuten ``??`` und ``??=``? Schreibe dazu es in ein ``If-Statement`` um. Verwende dazu folgendes Beispiel:

    * ``??``: 
```csharp
variable = links ?? rechts;
```

Umschreibung in eine ``If-Verzweigung``:
```csharp
if (links == null)
{
    variable = rechts;
}
else
{
    variable = links;
}
```

    * ``??=``: 
```csharp
variable ??= rechts;
```

Umschreibung in eine ``If-Bedingung``:
```csharp
if (variable == null)
{
    variable = rechts;
}
```
