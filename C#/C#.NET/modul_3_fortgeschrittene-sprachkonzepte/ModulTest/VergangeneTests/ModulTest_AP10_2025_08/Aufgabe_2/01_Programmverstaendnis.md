Wird folgender Code ``gleichzeitg`` (concurrent) oder ``hintereinander`` (sequential) ausgeführt?
```csharp
async Task CalculateStuff() 
{
    for(int i = 0; i < 100; i++) 
    {
        await Task.Delay(1);
        Console.WriteLine($"Ich bin von Task: {Task.CurrentId ?? -1} welche auf Thread: {Thread.CurrentThread.ManagedThreadId} gestartet worden und berechne i = {i}");
    }
}

Task firstTask = CalculateStuff();
Task secondTask = CalculateStuff();

var tasks = new List<Task> { firstTask, secondTask };
await Task.WhenAll(tasks);
```

**Anwort**: ``Gleichzeitig``. Denn wir starten mit ``await Task.WhenAll(tasks)`` alle Tasks gleichzeig und warten bis alle fertig sind.

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
**Anwort**: ``Hintereinander``. Denn wir starten mit ``await CalculateStuff()`` die 1. Aufruf der ``Methode`` und warten durch ``await`` bis diese fertig ist. Danach erst die 2.
