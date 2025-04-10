Welche ``Konzepte`` der Programmiersprache üben wir hier?
* For-Each-Schleife
* Anwendung von Listen und Dictionaries.

Welche ``Denkweisen`` üben wir hier?
* Schachtelungen von ``Collections`` in ``Collections``

Bei Unklarheiten hier nachlesen:
* [Collections](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_grundlagen/L03CollectionsTreesAndEnumerators/L03CollectionsTreesAndEnumerators/L03.0ListenUndDictionaries.md)

## 1. Einfaches Lagerverwaltungssystem
**`Achtung! Wir verwenden hier keine Klassen für die ProduktTypen.`** Wir verzichten auf Identität eines Objektes und sagen, z.B. ein `string` mit dem Wert `Fahrrad` ist ein Fahrrad.
Auch wenn wir abfragen ob ein `Fahrrad` in eine `kleine Box` passt, greifen wir **`nicht`** auf eigenschaften eines Objektes zu (z.B. schreiben wir nicht, `if(fahrrad.laenge > box.capacity`), sondern merken uns dass ein `Fahrrad` nicht in eine `kleine Box` passt. Wir tun das mit ``boxType == "small" and productType != "Kulli"`` gib  ``Box zu klein!`` aus.

Hier nochmal in Code:
```csharp
void MyMethod(... , string productType, string boxType)) {
        if (boxType == "small" && productType == "Fahrrad" ...) {...erlaube keinen Zugriff auf die Box...}
        ...
}
```

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
- Das System sollte in der Lage sein, auf das Lager zugreifen zu können,
  -  um eine spezifische Box mit dessen Inhalt auszugeben: Damit ist gemeint, dass ich zu z.B. alle großen Boxen und dessen darin befindlichen Produkte ausgeben kann. Die Frage ist also "welche Produkte befinden sich in großen Boxen"?
  -  um eine Produktkategorie mit dessen Boxen auszugeben: Damit ist gemeint, dass ich zu `einer` Produktkategorie, die Boxen gefunden werden, in denen sich die Produkte befinden. Die Frage ist also "welche Boxen beinhalten z.B. die Kategorie Fahhrad"?


Optional: Erweitere die bestehende Funktionalität für mehrere Lager `aut` und `ger`.

Verwende dazu:
```csharp
List<string> großeBox;
...
Dictionary<string, List<List<string>>> lager;
// Dictionary<string, List<List<string>>> lager_aut;
// Dictionary<string, List<List<string>>> lager_ger;

void FindBoxesInWarehouse(Dictionary<string, List<List<string>>> warehouse, string boxType) { ... }
void FindProductCategoriesOfWarehouse(Dictionary<string, List<List<string>>> warehouse, string productType) { ... }

// Hilfsmethode um Boxen ins Warenhaus zu geben.
void addProductToBoxInWarehouse(Dictionary<string, List<List<string>>> warehouse, int boxId, string productType, string key) { ... }
```

Beispiel-Aufruf in der Main-Methode:
```csharp

// ProduktTypen
string fahrrad = "Fahrrad";
string tisch = "Tisch";
string kulli = "Kulli";
...
...
// Überprüfe beim hinufügen ob die ProduktTypen den Größen der Boxen entsprechen
// Das geht einfacher mit einer Methode. Das haben wir nicht speziell spezifiziert in der Angabe (mit Absicht!).
addProductToBoxInWarehouse(warehouse, 0, fahrrad, "big");
addProductToBoxInWarehouse(warehouse, 0, kulli, "big");

addProductToBoxInWarehouse(warehouse, 1, fahrrad, "big");
addProductToBoxInWarehouse(warehouse, 1, fahrrad, "big");
addProductToBoxInWarehouse(warehouse, 1, fahrrad, "big");
addProductToBoxInWarehouse(warehouse, 1, tisch, "big");
addProductToBoxInWarehouse(warehouse, 1, tisch, "big");

addProductToBoxInWarehouse(warehouse, 0, fahrrad, "med");
addProductToBoxInWarehouse(warehouse, 0, fahrrad, "med");
addProductToBoxInWarehouse(warehouse, 0, kulli, "med");
addProductToBoxInWarehouse(warehouse, 0, kulli, "med");

addProductToBoxInWarehouse(warehouse, 0, fahrrad, "small"); // Fügt es nicht hinzu, da eine Box welche small zu für ein Fahrrad nicht passend ist.
addProductToBoxInWarehouse(warehouse, 0, kulli, "small");
addProductToBoxInWarehouse(warehouse, 0, kulli, "small");


// Box-Inhalte ausgeben
FindBoxesInWarehouse(warehouse, "big");
FindBoxesInWarehouse(warehouse, "med");
FindBoxesInWarehouse(warehouse, "small");
FindBoxesInWarehouse(warehouse, "drüLb");

// Produktinhalte ausgeben
FindProductCategoriesOfWarehouse(warehouse, "Fahrrad");
```

Beispiel-Ausgabe des Beispiel-Aufrufs:
```
ProductType: Fahrrad     wurde in big    hinzugefügt.
ProductType: Kulli       wurde in big    hinzugefügt.
ProductType: Fahrrad     wurde in big    hinzugefügt.
ProductType: Fahrrad     wurde in big    hinzugefügt.
ProductType: Fahrrad     wurde in big    hinzugefügt.
ProductType: Tisch       wurde in big    hinzugefügt.
ProductType: Tisch       wurde in big    hinzugefügt.
ProductType: Fahrrad     wurde in med    hinzugefügt.
ProductType: Fahrrad     wurde in med    hinzugefügt.
ProductType: Kulli       wurde in med    hinzugefügt.
ProductType: Kulli       wurde in med    hinzugefügt.
Box zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])
ProductType: Kulli       wurde in small  hinzugefügt.
ProductType: Kulli       wurde in small  hinzugefügt.

Box-Inhalte ausgeben:
box (big):
        Fahrrad
        Kulli

box (big):
        Fahrrad
        Fahrrad
        Fahrrad
        Tisch
        Tisch

box (med):
        Fahrrad
        Fahrrad
        Kulli
        Kulli

box (small):
        Kulli
        Kulli

BoxType is Wrong!

Produktinhalte mit dessen Boxen ausgeben:
Fahrrad  - was found in a big Box, with id 1
Fahrrad  - was found in a big Box, with id 2
Fahrrad  - was found in a big Box, with id 2
Fahrrad  - was found in a big Box, with id 2
Fahrrad  - was found in a med Box, with id 1
Fahrrad  - was found in a med Box, with id 1
```