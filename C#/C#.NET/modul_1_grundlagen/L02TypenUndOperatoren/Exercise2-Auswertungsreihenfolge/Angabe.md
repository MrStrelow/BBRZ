Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Operatoren händisch auswerten 
* Auswertungsreihenfolge der Operatoren nachbauen

Welche ``Denkweisen`` üben wir hier?
* strukturiertes Denken 
* Anweisungen in einer informellen Sprache (Deutsch) und diese anwenden.

Bei Unklarheiten hier nachlesen: 
* [Wie verwende ich Operatoren?](../Skripten/L02.1Operatoren.md)
* [Was ist die Auswertungsreihenfolge mehrere Operatoren?](../Skripten/L02.2AuswertungsreihenfolgeVonOperatoren.md)

## Ausführungsreihenfolge von Ausdrücken bestimmen  

### Hilfestellung
Verwende folgende Regel für die Bestimmung der Auswertungsreihenfolge.
>0. Setze eine Klammer-auf ganz *links* und eine Klammer-zu ganz *rechts* um den ``Ausdruck``.
>1. Verwende die linkeste ``Variable`` oder ``Wert`` und betrachte dessen ``Operator``. Betrachte nun die ``Werte`` links und rechts dieses ``Operators``.
>2. Wenn einer der beiden ``Werte`` des ``Operators`` eine ``Klammer`` besitzt, gehe in diese ``Klammer`` hinein und starte bei der linkesten ``Operation``.
>    1. Wiederhole bis **3.** passiert.
>3. Ansonsten, berücksichtige alle ``Operatoren`` innerhalb der ``Klammer`` ohne eine **weitere** ``Klammer`` zu öffnen. Füre jene ``Operation`` durch welche am stärksten bindet und erzeuge einen neuen ``Wert``. Entferne die ``Klammer`` falls die ``Operation`` die letzte innerhalb dieser war. Falls die ``Klammer`` entfernt wurde, berücksichtige alle ``Operatoren`` innerhalb der neuen ``Klammer``. Wähle den stärkst bindenden ``Operator``.
>    1. Wiederhole bis **2.** passiert **oder** nur mehr ein ``Wert`` übrig ist. Das ist unser ``Ergebnis``.

---

### Zugriffskontrolle mit Zeitbeschränkung
Ein Benutzer erhält Zugriff, wenn er entweder **Admin ist** oder **sich zwischen 8:00 und 18:00 Uhr anmeldet UND von einer erlaubten IP-Adresse kommt**.  

```csharp
bool isAdmin = false;
int currentHour = 18;
bool ipAllowed = true; 

bool access = isAdmin || (currentHour >= 8 && currentHour <= 18 && ipAllowed);
```

* Gib die Auswertungsreihenfolge an und begründe wieso diese gewählt wurde.
* Was hat access für einen ``Wert``? Erzeuge ``Werte`` entlang der ``Auswertungsreihenfolge`` wenn ein ``Operator`` die benachbarten ``Werte`` bzw. ``Variablen`` verarbeitet.  

---

### Frachtzulassung basierend auf Gewicht und Gefahrgut 
Ein Paket darf **nur transportiert werden**, wenn es entweder **kein Gefahrgut ist** oder **unter 50 kg wiegt UND eine Sondergenehmigung hat**.  

```csharp
bool isHazardous = true;
bool hasPermit = false;
double weight = 50; 

bool transportAllowed = !isHazardous || (weight < 50 && hasPermit);
```

* Gib die Auswertungsreihenfolge an und begründe wieso diese gewählt wurde.
* Was hat *transportAllowed* für einen ``Wert``? Erzeuge ``Werte`` entlang der ``Auswertungsreihenfolge`` wenn ein ``Operator`` die benachbarten ``Werte`` bzw. ``Variablen`` verarbeitet.   

---

### Even/Odd-Check - Schachbrett 
Bestimme die Reihenfolge der Auswertung für den folgenden Ausdruck:  

```csharp
int x = 17;
int y = 24;

bool isWhite = (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1)
```

* Gib die Auswertungsreihenfolge an und begründe wieso diese gewählt wurde.
* Was hat *istFeldWeiß* für einen ``Wert``? Erzeuge ``Werte`` entlang der ``Auswertungsreihenfolge`` wenn ein ``Operator`` die benachbarten ``Werte`` bzw. ``Variablen`` verarbeitet.  

---

### Sensorabweichung  
Ein System überwacht **5 Sensoren** (`s1`, `s2`, `s3`, `s4`, `s5`). Ein Alarm soll ausgelöst werden, wenn **mindestens 2 Sensoren** um mehr als **10% vom Mittelwert aller 5 Sensoren** (`s1, s2, s3, s4, s5`) abweichen.  

Der Ausdruck dafür lautet:  

```csharp
int s1 = 15;
int s2 = 16;
int s3 = -4968;
int s4 = 15;
int s5 = 15;

double m = (s1 + s2 + s3 + s4 + s5) / 5.0;
Console.WriteLine($"Die durchschnittliche Temperatur ist: {m}");

int c = (s1 < 0.9 * m || s1 > 1.1 * m ? 1 : 0) +
        (s2 < 0.9 * m || s2 > 1.1 * m ? 1 : 0) +
        (s3 < 0.9 * m || s3 > 1.1 * m ? 1 : 0) +
        (s4 < 0.9 * m || s4 > 1.1 * m ? 1 : 0) +
        (s5 < 0.9 * m || s5 > 1.1 * m ? 1 : 0);
Console.WriteLine($"Anzahl abweichender Sensoren: {c}");

bool a = 2 <= c;
Console.WriteLine($"Alarm? - {a}");
```

1) Gib die Auswertungsreihenfolge an. Erzeuge ``Werte`` entlang der ``Auswertungsreihenfolge`` wenn ein ``Operator`` die benachbarten ``Werte`` bzw. ``Variablen`` verarbeitet.
2) Wird ein Alarm ausgelöst? Wie viele Sensoren sin außerhalb der Toleranz? Vergleiche dein Ergebnis mit dem des Programms.
3) *Sind die Sensorwerte bedenklich? Soll ein Alarm überhaupt ausgelöst werden, wenn ein Sensor eine große Abweichung hat? Wir wollten doch sicher sein, dass erst wenn zwei Sensoren stark abweichen, ein Alarm ausgelöst wird.
4) Schreib das Programm um und gib den ``Variablen`` sinnvolle Namen.
5) Ist hier ein ``If-Ausdruck`` oder eine ``If-Anweisung`` sinnvoller? 
6) Gib die ``Variablen`` in ein ``Array`` und arbeite mit einer ``If-Anweisung`` innerhalb einer ``Schleife`` um doppelten Code zu vermeiden. Überdenke die Antwort auf 2., was ist lesbarer? 
