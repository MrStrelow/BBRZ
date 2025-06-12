* Finde die Fehler in diesem Code und markiere diese. 
* Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionell falschen ``Property``(Eigenschaft) führen. Falls dir konzeptionelle Probleme auffallen, merke diese an.  

```csharp
// Fehler - modifier für property selbst (links) darf nicht einschränkender als jene bei den get und set sein.
private string Name { get; protected set; }

// Fehler - nur ein modifier für get und set möglich.
public string Name { protected get; private set; }

// Fehler
public int AnzahlKoffer
{
    get;
    set
    {
        if (value <= 2_000)
        {
            throw new ArgumentException("Anzahl der Koffer muss größer als 2000 sein.");
            value = AnzahlKoffer; // FEHLER 1: Wir rufen mit value = AnzahlKoffer, anstatt AnzahlKoffer = value auf.
            // Erklärung zu AnzahlKoffer = value: Es Fehlt das backing field, wenn wir AnzahlKoffer = value verwenden. Wir rufen damit immer wieder die set-methode auf. Da wir in der set-methode sind, gibt es eine Endlosschleife.
        }
    }
}

// Korrekt - jedoch ist es ein "silent" exit, wenn wir value einen Wert kleiner als 21 verwenden.
private int _anzahlKunden;
public int AnzahlKunden
{
    get => _anzahlKunden;
    set => _anzahlKunden = value > 20 ? value : _anzahlKunden; // Wird hier das System benachtichtigt wenn etwas schief geht?
}
```