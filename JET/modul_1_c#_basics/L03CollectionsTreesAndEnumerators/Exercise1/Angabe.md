Welche ``Konzepte`` der Programmiersprache üben wir hier?
* For-Each-Schleife
* Anwendung von Listen und Dictionaries.

Welche ``Denkwweisen`` üben wir hier?
* keine

Lies davor:
* [java vs. c#](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_c%23_basics/L02BasicProgrammingConcepts/L03BasicProgrammingConcepts/L02.0C%23_vs_Java_Syntax.md)

## 1. Einfaches Lagerverwaltungssystem

Ein kleines Unternehmen hat ein Lager, in dem verschiedene Produkte in Boxen unterschiedlicher Größe gelagert werden. Das Lager soll `effizient organisiert sein, um die Produkte schnell nach Boxgröße und -inhalt `finden` zu können.

**Produktkategorien**: Es gibt drei verschiedene Produktkategorien im Lager:
   - **Fahrrad**: hoehe: 1m breite: 0.5m länge: 1.5m
   - **Tisch**: hoehe: 1.5m breite: 1.5m länge: 2.5m
   - **Kulli**: hoehe: 12cm breite: 5mm länge: 5mm

**Boxen**: Die Produkte werden in drei verschiedene Boxgrößen aufgeteilt:
   - **Große Boxen**: kann alle Produktkategorien enthalten.
   - **Mittlere Boxen**: kann Produktkategorien bis zu 2m in allen abmaßen enthalten.
   - **Kleine Boxen**: kann Produktkategorien bis zu 200mm in allen abmaßen enthalten.


**Lagerstruktur**: Das Lager selbst wird als eine Sammlung von Boxen organisiert, die Boxen werden nach ihrer Größe (`groß`, `mittel`, `klein`) kategorisiert.
Es kann mehrere große, mittlere und kleine Boxen in einem Lager geben.

- Entwickeln Sie ein einfaches System zur Verwaltung der Produktkategorien im Lager, das auf den Einsatz von `Dictionary` und `List` beschränkt ist, um die Lagerstruktur ohne den Einsatz komplexer OOP-Konzepte darzustellen. 
- Das System sollte in der Lage sein, auf das Lager zugreifen zu können und:
  -  alle Boxen mit deren Inhalten auszugeben: Damit ist gemeint, dass ich zu z.B. alle großen Boxen und dessen darin befindlichen Produkte ausgeben kann. Die Frage ist also "welche Produkte befinden sich in großen Boxen"?
  -  ein Produktkategorie mit deren Boxen auszugeben: Damit ist gemeint, dass ich zu `einer` Produktkategorie, die Boxen finden kann in denen sie sich befinden. Die Frage ist also "welche Boxen beinhalten z.B. die Kategorie Fahhrad"?


Erweitere bestehendes für mehrere Lager `aut` und `ger`.

Verwende dazu:
```csharp
List<string> großeBox;
...
Dictionary<string, List<List<string>>> lager_aut;
Dictionary<string, List<List<string>>> lager_ger;

void FindBoxesInWarehouse( TODO: Parameter überlegen ) { ... }
void SucheProduktkategorieImLagerInAllenBoxen( TODO: Parameter überlegen ) { ... }
```