a) Begründe warum die Anwendung von ``Referenzdaten`` wie hier mit *string* in den 4 Fällen ein verschiedenes Verhalten hat. Gehe dazu 
* auf die Idee von ``Referenzdaten`` ein (was liegt meistens im ``Stack``, was liegt im ``Heap``) und 
    * (Daumenregel) Erste Referenz (Pfeil) liegt am Stack, die Objekte auf die gezeigt wird, am heap.
* wie werden ``Referenzen`` grafisch dargstellt? 
    * Ffeil ist Referenz. Kugeln sind Objekte auf denen Rerferenzen zeigen.
* Sparen wir uns Speicher wenn alle ``Referenzen`` auf ein Ziel zeigen? 
    * Ja. Denn wir haben nur ein Objekt am heap, egal wie viele Objekte wir erzeugen. Nicht 100 mal, wenn wir 100 Objekte anlegen.
* Ist *string* ein ``Wertdatentyp`` oder ein ``Referenzdatentyp``? 
    * ``Referenzdatentyp``, jedoch ist dieser immutable (kann keine werte ändern, nur neu anlegen).
* Es gibt bei einem *string* eine spezielle Speicherung, diese heißt ``internal string pool``, welche bei Version 2 verwendet wird. Wie wirkt sich dieser ``internal string pool`` in unserem Programm aus?
    * Der Compiler merkt sicht, dass wir 100 mal den gleichen String verwenden (wenn dieser z.B. readonly ist oder ``string a = "🐹";`` als Wert zugewiesen wird, nicht z.B. von außen wie ein Datenbankzugriff). Dadurch haben wir den Fall dass alle Referenzen auf das gleiche Objekt zeigen und wir Speicher sparen.

b) Begründe warum die GB im Arbeitspeicher ca. Sinn machen. Berechne dazu überschalgsmäßig die Größen welche im Programm angegeben sind.

Denke an:
* Die Größe eines ``Objektes`` vom ``Typ`` *string* ist ca. 
    * ``16 bytes`` (leeres objekt) + 
    * ``04 bytes = 2 * 2 bytes`` (der/die Character selbst) + 
    * ``04 bytes`` (speziell für string, hat ein Feld Länge, Typ int = 32 bit = 4 byte) + 
    * ``02 bytes`` (details, nicht relevant hier) 
    * = ``26 bytes`` > ``24 bytes`` also **``32 byte`` pro string objekt**. 
* Die Größe eines beliebigen ``Objekts`` mindestens ``24 byte`` ist, jedoch ``16 byte`` für unsere Basis zum rechnen ist. Falls wir ein leeres Objekt haben ist es ``24 byte`` und falls wir z.B. ein ``Feld`` in einem Objekt haben welches nur eine ``Referenz`` ist, haben wir ``16 byte`` + ``8 byte``, also auch ``24 byte``.
* Die Größe einer ``Referenz`` selbst ist ``8 byte``.

Rechnungen siehe Kommentare im Code.

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

c) 
* Warum haben wir **``2 * 2 bytes`` (der/die Character selbst) +**? Reichen nicht *2* bytes = *16* bit für einen *Character*?
    * Emojis haben oft 24 bits, manchmal auch 32 bits. Wir haben immer 16 bit pro Character zur Verfügung und brauchen dadurch 2 * 16 Bit, auch wenn z.B. nur 24 bit notwendig wären. (wird surrogates genannt)