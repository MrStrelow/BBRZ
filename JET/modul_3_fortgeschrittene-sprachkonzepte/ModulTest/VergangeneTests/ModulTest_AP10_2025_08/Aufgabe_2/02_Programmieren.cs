void async CalculateStuff() {
    for(int i = 0; i < 1000; i++) {
    Console.Write($"ich bin von Task: {} und berechne i = {i}");
}
}

await CalculateStuff();
await CalculateStuff();