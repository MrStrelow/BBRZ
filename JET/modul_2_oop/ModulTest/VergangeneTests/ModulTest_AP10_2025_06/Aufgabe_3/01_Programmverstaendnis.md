```csharp
// Beginne hier zu lesen!
using System.Diagnostics;
using System.Text;

public class Programm
{
    public class Hamster // mindestens 24 byte für ein Objekt 100_000_000 mal
    {
        // Version 1
        // Objekt: 24 byte 100_000_000 mal ...
        static string darstellung_static_fed = "🐹";     // + 8 byte Referenz auf string ein mal + 32 byte string ein mal
        static string darstellung_static_hungry = "😡";  // + 8 byte Referenz auf string ein mal + 32 byte string ein mal
        // ergibt ca. 2.4 GB + 8 byte * 100_000_000 Referenzen in der Liste = 3.2 GB

        // Version 2
        // Objekt: 16 byte 100_000_000 mal ... da wir mit den folgenden referenezn über 24 Byte pro Objekt kommen.
        //string darstellung_instance_interned_fed = "🐹";       // 8 byte Referenz auf string 100_000_000 mal + 32 byte string ein mal
        //string darstellung_instance_interned_hungry = "😡";    // 8 byte refernez auf string 100_000_000 mal + 32 byte string ein mal
        // ergibt ca. 3.2 GB + 8 byte * 100_000_000 Referenzen in der Liste = 4.0 GB

        // Version 3
        // Objekt: 16 byte 100_000_000 mal ... da wir mit den folgenden referenezn über 24 Byte pro Objekt kommen.
        //string darsellung_instance_new_fed = new string("🐹");     // 8 byte refernez 100_000_000 auf string mal + 32 byte für string im heap 100_000_000 mal
        //string darsellung_instance_new_hungry = new string("😡");  // 8 byte refernez 100_000_000 auf string mal + 32 byte für string im heap 100_000_000 mal
        // ergibt ca. 9.6 GB + 8 byte * 100_000_000 Referenzen in der Liste = 10.4 GB

        // Version 4
        // kommentiere alles oben aus und definiere damit eine leere Klasse. 
        // (16 ist zu klein, mindestens 24... deshalb) 24 byte für ein Objekt 100_000_000 mal
        // ergibt ca. 2.4 GB + 8 byte * 100_000_000 Referenzen in der Liste = 3.2 GB
    }

    static void Main(string[] args)
    {
        // Beende hier zu lesen!
        Console.OutputEncoding = Encoding.UTF8;

        long memoryBefore = GC.GetTotalMemory(true);
        long privateBytesBefore = Process.GetCurrentProcess().PrivateMemorySize64;

        // Beginne hier zu lesen!
        var hamsters = new List<Hamster>();
        for (int i = 0; i < 100_000_000; i++)
        {
            hamsters.Add(new Hamster());
        }

        // Beende hier zu lesen!
        long memoryAfter = GC.GetTotalMemory(true);
        long privateBytesAfter = Process.GetCurrentProcess().PrivateMemorySize64;

        long memoryUsedByGC = memoryAfter - memoryBefore;
        long privateBytesUsed = privateBytesAfter - privateBytesBefore;

        Console.WriteLine($"Approximate managed memory used by hamsters and list (GC.GetTotalMemory): {memoryUsedByGC / (1024.0 * 1024.0):F2} MB");
        Console.WriteLine($"Approximate private bytes increase (Process): {privateBytesUsed / (1024.0 * 1024.0):F2} MB");

        GC.KeepAlive(hamsters); // Kein Hamster wird vom Gargabe Collector entfernt! Tierschutz++; :)
    }
}
```