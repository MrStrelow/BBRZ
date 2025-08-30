async Task CalculateStuff()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Ich bin von Task: {Task.CurrentId ?? -1} welche auf Thread: {Thread.CurrentThread.ManagedThreadId} gestartet worden und berechne i = {i}");
        await Task.Delay(1);
    }
}

await CalculateStuff();
await CalculateStuff();