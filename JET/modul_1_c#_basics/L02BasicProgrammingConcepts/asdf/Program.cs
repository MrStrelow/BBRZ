// Set output encoding to UTF-8
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Optional: Set Console color (not for emojis but for text output)
Console.ForegroundColor = ConsoleColor.Green;

// Test different symbols
Console.WriteLine("Full color squares:");
Console.WriteLine("🟩 🟦 🟥 🟧 🟨 🟩");

// Check for symbol rendering issues
Console.WriteLine("Geometric symbols (may not show color):");
Console.WriteLine("◽ ▫️ ⬜ 🌯");
Console.ReadLine();
