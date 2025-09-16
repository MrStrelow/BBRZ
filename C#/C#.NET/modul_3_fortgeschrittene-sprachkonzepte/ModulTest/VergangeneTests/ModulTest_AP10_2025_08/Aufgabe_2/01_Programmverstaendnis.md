Wird folgender Code ``gleichzeitg`` (concurrent) oder ``hintereinander`` (sequential) ausgeführt?
```csharp
async Task CalculateStuff(int id)
{
    for (int i = 0; i < 100; i++)
    {
        await Task.Delay(1);
        Console.WriteLine($"Ich bin die Methode mit id: {id}, welche auf Thread: {Thread.CurrentThread.ManagedThreadId} gestartet worden und berechne i = {i}");
    }
}

await CalculateStuff(1);
await CalculateStuff(2);
```
**Anwort**: ``Hintereinander`` (sequential) aber ``asynchron`` (asynchronous). Denn wir starten mit ``await CalculateStuff()`` den 1. Aufruf der ``Methode`` und warten durch ``await`` bis diese fertig ist. Danach erst die 2. Es kann jedoch Während des Wartens auf ``await CalculateStuff()`` die Rechenleistung für andere Aufgaben verwendet werden. Ohne ``async`` und ``await`` würden wir erstarren und "nichts" tun bis wir das Ergebnis haben.
