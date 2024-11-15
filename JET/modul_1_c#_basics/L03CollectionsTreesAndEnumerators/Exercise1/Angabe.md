Welche ``Konzepte`` der Programmiersprache üben wir hier?
* For-Each-Schleife
* Anwendung von Listen und Dictionaries.

Welche ``Denkwweisen`` üben wir hier?
* keine

Lies davor:
* [java vs. c#](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_c%23_basics/L02BasicProgrammingConcepts/L03BasicProgrammingConcepts/L02.0C%23_vs_Java_Syntax.md)

## 1. Einfaches Lagerverwaltungssystem

Ein kleines Unternehmen hat ein Lager, in dem verschiedene Produkte in Boxen unterschiedlicher Größe gelagert werden. Das Lager soll `effizient organisiert sein, um die Produkte schnell nach Boxgröße und -inhalt `finden` zu können.

**Produkte**: Es gibt drei verschiedene Produkte im Lager:
   - **Fahrrad**: hoehe: 1m breite: 0.5m länge: 1.5m
   - **Tisch**: hoehe: 1.5m breite: 1.5m länge: 2.5m
   - **Kulli**: hoehe: 12cm breite: 5mm länge: 5mm

**Boxen**: Die Produkte werden in drei verschiedene Boxgrößen aufgeteilt:
   - **Große Boxen**: kann alle Produkte enthalten.
   - **Mittlere Boxen**: kann Produkte bis zu 2m in allen abmaßen enthalten.
   - **Kleine Boxen**: kann Produkte bis zu 200mm in allen abmaßen enthalten.

**Lagerstruktur**: Das Lager selbst wird als eine Sammlung von Boxen organisiert, die Boxen werden nach ihrer Größe (`groß`, `mittel`, `klein`) kategorisiert.

- Entwickeln Sie ein einfaches System zur Verwaltung der Produkte im Lager, das auf den Einsatz von `Dictionary` und `List` beschränkt ist, um die Lagerstruktur ohne den Einsatz komplexer OOP-Konzepte darzustellen. 
- Das System sollte in der Lage sein:
  -  alle Boxen sortiert mit deren Inhalten auszugeben: Damit ist gemeint, dass ich zu z.B. `allen` großen Boxen, alle darin befindlichen Produkte ausgeben kann. Die Frage ist also "welche Produkte befinden sich in einer großen Box"?
  -  alle Produkte sortiert mit deren Boxen auszugeben: Damit ist gemeint, dass ich zu `allen` Produkten, die Boxen finden kann in denen sie sich befinden. Die Frage ist also "welche Boxen beinhalten z.B. ein Fahhrad"?


**Beispielausgabe**:
Das Programm sollte den Inhalt jeder Box im Lager anzeigen, etwa wie folgt:

```
Inhalt des Lagers:
Box-Größe: groß
 - Fahrrad
 - Tisch
Box-Größe: mittel
 - Fahrrad
 - Kulli
Box-Größe: klein
 - Kulli
```

**Zusätzliche Hinweise**:
- Das System soll nur die grundlegende Struktur für das Lager bereitstellen, ohne auf komplexere Funktionalitäten wie Hinzufügen oder Entfernen von Produkten einzugehen.
- Verwenden Sie in Ihrer Lösung einfache `string`-Variablen für die Produkte und minimalen Code zur Organisation des Lagers in einer `Dictionary`-Struktur.


In diesem Beispiel haben wir:
- Einfache Produktbezeichnungen (`Fahrrad`, `Tisch`, `Kulli`)
- **Boxen** als Listen, die jeweils bestimmte Produkte enthalten können und in drei Größen (`groß`, `mittel`, `klein`) organisiert sind
- Ein **Lager**, das ein `Dictionary` ist und die Boxen enthält

## C#-Code

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Produkte
        string fahrrad = "Fahrrad";
        string tisch = "Tisch";
        string kulli = "Kulli";

        // Boxen erstellen (jede Box ist eine Liste von Produkten)
        List<string> großeBox = new List<string> { fahrrad, tisch };
        List<string> mittlereBox = new List<string> { tisch, kulli };
        List<string> kleineBox = new List<string> { kulli };

        // Lager als Dictionary, das die Boxen nach Größe kategorisiert
        Dictionary<string, List<string>> lager = new Dictionary<string, List<string>>
        {
            { "groß", großeBox },
            { "mittel", mittlereBox },
            { "klein", kleineBox }
        };

        // Lager-Inhalte ausgeben
        Console.WriteLine("Inhalt des Lagers:");
        foreach (var box in lager)
        {
            Console.WriteLine($"Box-Größe: {box.Key}");
            foreach (var produkt in box.Value)
            {
                Console.WriteLine($" - {produkt}");
            }
        }
    }
}
```

## Erklärung

1. **Produkte** werden als einfache `string`-Variablen definiert, ohne Klassen oder Objekte.
2. **Boxen** werden als `List<string>`-Sammlungen definiert, die die Produktnamen enthalten.
3. **Lager** wird als `Dictionary<string, List<string>>` definiert, wobei der Schlüssel (`string`) die Box-Größe angibt und der Wert (`List<string>`) die jeweilige Liste der Produkte in der Box enthält.
4. Die Ausgabe zeigt den Inhalt jeder Box nach Größe.

---

### Ausgabe des Programms

Das Programm gibt den Inhalt jeder Box im Lager aus:

```
Inhalt des Lagers:
Box-Größe: groß
 - Fahrrad
 - Tisch
Box-Größe: mittel
 - Tisch
 - Kulli
Box-Größe: klein
 - Kulli
```


## 2. Gleiches aber verwende OOP
TODO und in anderem file.