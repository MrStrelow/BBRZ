# 📝 Cheat Sheet: C# Basics für den Weltenbau

Dieser Spickzettel fasst die wichtigsten Programmier-Werkzeuge zusammen, die du für die Lösung der Aufgaben benötigst.

---

## 🎲 Zufallszahlen (`Random`)

**1. Generator erstellen (nur einmal pro Methode nötig):**
```csharp
Random generator = new Random();
```

**2. Eine zufällige ganze Zahl ziehen (z.B. für Koordinaten):**
```csharp
// Zieht eine Zahl von 0 bis 9! (Die 10 ist exklusive / nicht dabei)
int x = generator.Next(0, 10); 
```

**3. Eine zufällige Kommazahl ziehen (für Prozent-Chancen):**
```csharp
// Zieht eine Kommazahl zwischen 0.0 und 1.0
double wahrscheinlichkeit = generator.NextDouble(); 

// Beispiel: 5% Chance
if (wahrscheinlichkeit < 0.05) 
{
    // Passiert nur in 5 von 100 Fällen
}
```

---

## 🗺️ Arrays (speziell 2D-Arrays)
Unsere Karte ist ein Gitter aus Feldern (Zeilen und Spalten). Das programmieren wir als 2D-Array. Achte darauf, dass bei 2D-Arrays meistens zuerst die **Zeile (Y)** und dann die **Spalte (X)** angegeben wird: `karte[y, x]`.

**1. Einen Wert an einer Koordinate auslesen:**
```csharp
string aktuellesFeld = karte[y, x];
```

**2. Einen Wert an einer Koordinate überschreiben:**
```csharp
karte[y, x] = "🟨"; // Macht das Feld zu Sand
```

**3. Die Größe der Karte herausfinden:**
Damit wir nicht über den Rand der Karte hinauslesen (was zum Absturz führt), müssen wir wissen, wie groß sie ist.
```csharp
int anzahlZeilen  = karte.GetLength(0); // Höhe (Y)
int anzahlSpalten = karte.GetLength(1); // Breite (X)
```

---

## 🚦 Kontrollstrukturen
Kontrollstrukturen lenken den Ablauf des Programms. Wir brauchen sie, um Dinge zu wiederholen oder das Programm zu Verzweigen.

1) **``Bedingte Anweisung`` (*if* alleine):**
Führe ``Anweisungen`` nur aus, wenn eine Bedingung wahr (`true`) ist. Wenn nicht, passiert einfach nichts.
```csharp
if (feld == "🟦") 
{
    // Anweisungen: Mach etwas, wenn das Feld aus Wasser besteht
}
```

2) **``Verzweigung`` (*if* Zweig mit einem *else* Zweig):**
Eine Entweder-Oder-Entscheidung - die **zwei** Zweige schließen sich gegenseitig aus. Wenn die ``Bedingung`` (*feld == "🟦"*) wahr ist, mach das etwas. Ansonsten (wenn die ``Bedingung`` falsch ist), mach was anderes. 
```csharp
if (feld == "🟦") 
{
    // Mach etwas, wenn es Wasser ist
} 
else 
{
    // Mach etwas anderes für ALLES andere (Erde, Stein, Sand...)
}
```

3) **``Mehrfachverzweigung`` (*if* Zweig mit vielen *else if* Zweigen und abschließendem *else* Zweig):**
Prüft nacheinander mehrere, unterschiedliche Bedingungen ab. Entweder-Oder-Entscheidung - die **vielen** Zweige schließen sich gegenseitig aus.
```csharp
if (feld == "🟦") 
{
    // Mach etwas, wenn es Wasser ist
} 
else if (feld == "🟫") 
{
    // Mach etwas, wenn es Erde ist
}
else if (feld == "🗻")
{
    // Mach etwas, wenn es Stein ist
}
```

4) **`While`-``Schleife`` (Wiederholen, bis ein Ziel erreicht ist):**
Wir **wissen nicht** wie oft die Schleife sich wiederholen muss (z.B. weil du per Zufall manchmal auf Felder triffst, wo nichts wachsen kann).
```csharp
int gepflanzteBaeume = 0;
int ziel = 100;

while (gepflanzteBaeume < ziel) 
{
    // Versuche einen Baum zu pflanzen...
    // Wenn möglich: gepflanzteBaeume++;
}
```

5) **`For`-``Schleife`` (Zählen / Arrays durchlaufen):**
Wir **wissen** wie oft die Schleife sich wiederholen muss (z.B. alle Felder einer Karte oder eine feste Liste von Nachbarn).
```csharp
// Läuft von 0 bis anzahlZeilen - 1
for (int y = 0; y < anzahlZeilen; y++) 
{
    // Mache etwas mit der Zeile y
}
```

---

## ⚙️ Methoden
Methoden sind kleine Bauklötze (Unterprogramme), die eine bestimmte Aufgabe erledigen. Diese werden zuerst (wie Variablen) ``definiert`` und können danach ``aufgerufen`` werden. Sie nehmen Werte entgegen (``Eingangs-Parameter``) und geben am Ende meistens ein Ergebnis mit dem ``Keyword`` *return* zurück (``Rückgabe-Parameter``).

**1. Aufbau einer Methoden:**
```csharp
// Definition:
// Rückgabetyp | Name der Methode | (Parameter, die sie braucht)
static int BerechnePunkte(int anzahlBaeume, int anzahlInseln)
{
    int punkte = anzahlBaeume + (anzahlInseln * 5);
    return punkte; // Gibt das Ergebnis an den Aufrufer zurück
}

static void Main(string[] args)
{
    // Rufe hier die Methode BerechnePunkte auf und bekommen ein Ergebnis zurück.
    Console.WriteLine(BerechnePunkte(36, 15)); // mit Positions-Parameter
    Console.WriteLine(BerechnePunkte(anzahlInseln: 15, anzahlBaeume: 36)); // mit Benannten-Parameter
}
```

Wir brauchen *static* da die ``Main`` static ist.

**2. Array entgegennehmen und Array zurückgeben:**
In unserer Übung verändern wir oft die Karte und geben die veränderte Karte zurück.
```csharp
static string[,] MacheAllesZuSand(string[,] alteKarte)
{
    string[,] neueKarte = (string[,]) alteKarte.Clone(); // wird hier nicht erklärt.
    // ... neueKarte bearbeiten ...
    return neueKarte; 
}
```