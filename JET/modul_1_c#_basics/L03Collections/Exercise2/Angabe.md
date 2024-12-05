# Eigene ArrayList und LinkedList

- Schreibe selbst eine ArrayList bzw. LinkedList welche strings beinhalten kann.
- Optional: Verwende einen Typparameter T um dies f�r alle Typen zu erstellen.

---

## Hinweise zur LinkedList:

1. **Node-Klasse**: 
   - Erstellen Sie eine `Node`-Klasse, die ein Feld f�r die gespeicherten Daten und einen Zeiger (Referenz) auf das n�chste Element enth�lt.
2. **LinkedList-Klasse**: 
   - Implementieren Sie eine `LinkedList`-Klasse mit Methoden zum Hinzuf�gen (`Add`) und Ausgeben (`PrintList`) von Elementen.

### Beispielcode f�r die `Main`-Methode (LinkedList):

```csharp
public static void Main(string[] args) {
    LinkedList list = new LinkedList();
    list.Add("Apfel");
    list.Add("Banane");
    list.Add("Kirsche");
    
    list.PrintList();
}
```

### Erwarteter Output:
```Apfel Banane Kirsche```

---

## Hinweise zur ArrayList:

1. **Array-Verwaltung**: 
   - Erstellen Sie eine `ArrayList`-Klasse, die ein internes Array zur Speicherung der Elemente verwendet.
   - Implementieren Sie eine Resize-Methode, um das Array dynamisch zu vergr��ern, wenn es voll ist.
2. **Methoden**: 
   - Implementieren Sie Methoden zum Hinzuf�gen (`Add`) und Ausgeben (`PrintList`) von Elementen.

### Beispielcode f�r die `Main`-Methode (ArrayList):

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

# Erweiterung: Verwendung von Generizit�t

## Ziel:
Passen Sie die oben implementierten Klassen so an, dass sie generisch sind und einen beliebigen Datentyp `T` speichern k�nnen.

### Hinweise:
- �ndern Sie die `Node`- und `LinkedList`-Klassen sowie die `ArrayList`, um einen generischen Typparameter `T` zu verwenden.
- Die Methoden sollten weiterhin korrekt funktionieren, unabh�ngig davon, welchen Datentyp der Benutzer speichert.

### Beispielcode f�r die `Main`-Methode (Generische LinkedList):

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

### Beispielcode f�r die `Main`-Methode (Generische ArrayList):

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
