Welche ``Konzepte`` der Programmiersprache üben wir hier?
* For-Each-Schleife
* Anwendung von Listen und Dictionaries.

Welche ``Denkweisen`` üben wir hier?
* keine

Bei Unklarheiten hier nachlesen:
* [Collections]()

## 1. Einfaches Lagerverwaltungssystem
**`Achtung! Wir verwenden hier keine Klassen für die ProduktTypen.`** Wir verzichten auf Identität eines Objektes und sagen, z.B. ein `string` mit dem Wert `Fahrrad` ist ein Fahrrad.
Auch wenn wir abfragen ob ein `Fahrrad` in eine `kleine Box` passt, greifen wir **`nicht`** auf eigenschaften eines Objektes zu (z.B. schreiben wir nicht, `if(fahrrad.laenge > box.capacity`), sondern merken uns dass ein `Fahrrad` nicht in eine `kleine Box` passt.

Hier nochmal in Code:
```python
def my_method(..., product_type, box_type):
    if box_type == "small" and product_type == "Fahrrad":
        # Erlaube keinen Zugriff auf die Box
        pass
    # Weitere Logik folgt hier...

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
```python
# Definition von Listen und Dictionaries
large_box = []
# Dictionary in Python
warehouse = {}
# warehouse_aut = {}
# warehouse_ger = {}

def find_boxes_in_warehouse(warehouse, box_type):
    # Implementierung der Methode
    pass

def find_product_categories_in_warehouse(warehouse, product_type):
    # Implementierung der Methode
    pass

def add_product_to_box_in_warehouse(warehouse, box_id, product_type, destination):
    # Hilfsmethode, um Boxen ins Warenhaus zu geben
    pass

```

Beispiel-Aufruf in der Main-Methode:
```python
# Produkt-Typen
fahrrad = "Fahrrad"
tisch = "Tisch"
kulli = "Kulli"
# ...

# Überprüfe beim Hinzufügen, ob die Produkt-Typen den Größen der Boxen entsprechen
# Das geht einfacher mit einer Methode. Das haben wir nicht speziell spezifiziert in der Angabe (mit Absicht!).

add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "big")
add_product_to_box_in_warehouse(warehouse, 0, kulli, "big")

add_product_to_box_in_warehouse(warehouse, 1, fahrrad, "big")
add_product_to_box_in_warehouse(warehouse, 1, fahrrad, "big")
add_product_to_box_in_warehouse(warehouse, 1, fahrrad, "big")
add_product_to_box_in_warehouse(warehouse, 1, tisch, "big")
add_product_to_box_in_warehouse(warehouse, 1, tisch, "big")

add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "med")
add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "med")
add_product_to_box_in_warehouse(warehouse, 0, kulli, "med")
add_product_to_box_in_warehouse(warehouse, 0, kulli, "med")

add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "small")  # Fügt es nicht hinzu, da eine Box "small" für ein Fahrrad nicht passend ist.
add_product_to_box_in_warehouse(warehouse, 0, kulli, "small")
add_product_to_box_in_warehouse(warehouse, 0, kulli, "small")

# Box-Inhalte ausgeben
find_boxes_in_warehouse(warehouse, "big")
find_boxes_in_warehouse(warehouse, "med")
find_boxes_in_warehouse(warehouse, "small")
find_boxes_in_warehouse(warehouse, "drüLb")

# Produktinhalte ausgeben
find_product_categories_in_warehouse(warehouse, "Fahrrad")

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