* Finde die Fehler in diesem Code und markiere diese. 
* Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionell falschen ``Property``(Eigenschaft) führen. Falls dir konzeptionelle Probleme auffallen, merke diese an.  

1) Fehler - modifier für property selbst (links) darf nicht einschränkender als jene bei den get und set sein.
```csharp
private string Name { get; protected set; }
```

2) Fehler - private get macht wenig Sinn - private für die Property und private für die set/get geht nicht. Siehe erste Aufgabe.
```csharp
private int Id { private get; private set; }
```

3) Korrekt - wir verwenden das keyword field um ein automatisch generiertes backingfield anzusprechen.
```csharp
public int TäglicherUmsatzMitKommazahlen
{
    set
    {
        if (value > 2_000_000)
        {
            throw new ArgumentException("Der Umsatz ist nicht glaubwürdig");
        }
        field = value;
    }
    get;
}
```

4) Korrekt - wir verwenden ein von uns angelegtes backingfield um die set-guard umzusetzen.
```csharp
private int _täglicherUmsatzMitKommazahlen;
public int TäglicherUmsatzMitKommazahlen
{
    set
    {
        if (value > 2_000_000)
        {
            throw new ArgumentException("Der Umsatz ist nicht glaubwürdig");
        }
        _täglicherUmsatzMitKommazahlen = value;
    }
    get => _täglicherUmsatzMitKommazahlen;
}
```