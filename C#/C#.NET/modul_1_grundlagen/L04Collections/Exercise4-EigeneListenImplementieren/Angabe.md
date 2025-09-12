Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* Arrays und eigene Klasse für Nodes
* Collections
* Operatoren
* Methoden und Konsturktoren
* Erstellung von Klassen
* hat und ist Beziehungen
* Erstellung von Felder

Welche ``Denkweisen`` üben wir hier?
* Algorithmisches denken und Umsetzung von diesem in Programmcode

Bei Unklarheiten hier nachlesen:
* [Collections](../Skripten/L04.1ListenUndDictionaries.md)
* [Klassen, Methoden und Felder](../../L05KlassenMethoden/Skripten/L04.0KlassenErstellenUndBeziehungenModellieren.md)

# Eigene ArrayList und LinkedList

- Schreibe selbst eine `ArrayList` bzw. LinkedList welche `strings` beinhaltet.
- `Optional`: Verwende einen `Typparameter T` um dies für alle Typen zu erstellen.

---

## Hinweise zur LinkedList:

1. **Node-Klasse**: 
   - Erstellen Sie eine `Node`-Klasse, die ein Feld für die gespeicherten Daten und einen Zeiger (Referenz) auf das nächste Element enthält.
2. **LinkedList-Klasse**: 
   - Implementieren Sie eine `LinkedList`-Klasse mit Methoden zum Hinzufügen (`Add`), Entfernen (`Remove`), Suchen (`Find`) und Ausgeben (`PrintList`) von Elementen.

### Beispielcode für die `Main`-Methode (LinkedList):

```csharp
public static void Main(string[] args)
{
    // LinkedList Beispiel
    LinkedList<string> linkedList = new LinkedList<string>();
    linkedList.Add("Apfel");
    linkedList.Add("Banane");
    linkedList.Add("Kirsche");

    Console.WriteLine("LinkedList vor Entfernen:");
    linkedList.PrintList();

    linkedList.Remove("Banane");

    Console.WriteLine("LinkedList nach Entfernen:");
    linkedList.PrintList();

    Console.WriteLine("Gefundenes Element: " + linkedList.Find("Kirsche"));

    // ArrayList Beispiel
    ArrayList<int> arrayList = new ArrayList<int>(2);
    arrayList.Add(10);
    arrayList.Add(20);
    arrayList.Add(30);

    Console.WriteLine("ArrayList vor Entfernen:");
    arrayList.PrintList();

    arrayList.Remove(20);

    Console.WriteLine("ArrayList nach Entfernen:");
    arrayList.PrintList();

    Console.WriteLine("Gefundenes Element: " + arrayList.Find(30));
}
```

### Erwarteter Output:
```Apfel Banane Kirsche```

---

## Hinweise zur ArrayList:

1. **Array-Verwaltung**: 
   - Erstellen Sie eine `ArrayList`-Klasse, die ein internes Array zur Speicherung der Elemente verwendet.
   - Implementieren Sie eine Resize-Methode, um das Array dynamisch zu vergrößern, wenn es voll ist.
2. **Methoden**: 
   - Implementieren Sie Methoden zum Hinzufügen (`Add`) und Ausgeben (`PrintList`) von Elementen.

### Beispielcode für die `Main`-Methode (ArrayList):

```csharp
public static void Main(string[] args) {
    ArrayList arrayList = new ArrayList(2);
    arrayList.Add("Hund");
    arrayList.Add("Katze");
    arrayList.Add("Vogel");
    
    arrayList.PrintList();
}
```

### Erwarteter Output:
Hund Katze Vogel

---

# Erweiterung: Verwendung von Generizität

## Ziel:
Passen Sie die oben implementierten Klassen so an, dass sie generisch sind und einen beliebigen Datentyp `T` speichern k�nnen.

### Hinweise:
- Ändern Sie die `Node`- und `LinkedList`-Klassen sowie die `ArrayList`, um einen generischen Typparameter `T` zu verwenden.
- Die Methoden sollten weiterhin korrekt funktionieren, unabhängig davon, welchen Datentyp der Benutzer speichert.

### Beispielcode für die `Main`-Methode (Generische LinkedList):

```csharp
public static void Main(string[] args) {
    LinkedList<string> list = new LinkedList<string>();
    list.Add("Eins");
    list.Add("Zwei");
    list.Add("Drei");
    
    list.PrintList();
}
```

### Erwarteter Output:

Eins Zwei Drei


---

### Beispielcode für die `Main`-Methode (Generische ArrayList):

```csharp
public static void Main(string[] args) {
    ArrayList<int> arrayList = new ArrayList<int>(3);
    arrayList.Add(10);
    arrayList.Add(20);
    arrayList.Add(30);
    
    arrayList.PrintList();
}
```

### Erwarteter Output:

10 20 30
