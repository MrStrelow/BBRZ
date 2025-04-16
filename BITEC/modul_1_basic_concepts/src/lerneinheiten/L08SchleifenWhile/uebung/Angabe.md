# While-Schleife

### Wie schreibe ich die While-Schleife?
1. Schreiben Sie ein Programm, das 100 Mal "Hello World" auf die Konsole ausgibt.  
   Erweitern Sie das Programm, sodass 100 Mal "Hello World" in einer Zeile, mit ", " getrennt, ausgegeben wird.

2. Schreiben Sie eine While-Schleife, die von 1 bis 10 alle Zahlen ausgibt.  
   Erweitern Sie die Ausgabe um die Info, ob die Zahl gerade oder ungerade ist. (z.B.: 1 (ungerade), 2 (gerade), ...)
   Erweitern Sie das Programm, indem Sie vom Benutzer die untere und obere Grenze abfragen (z.B. 4 bis 12).

3. Schreiben Sie eine While-Schleife, die von 10 bis 1 alle Zahlen im Format "10-9-8-...-1" ausgibt.  
   Speichern Sie hierbei die Zahl 10 in der Konstante `bound`.  
   Ändern Sie `bound` auf 100.

4. Schreiben Sie ein Programm, das eine Zahl vom Benutzer einliest und die Summe aller Zahlen von 1 bis zur eingegebenen Zahl ausgibt.

5. Schreiben Sie ein Programm, das den Benutzer nach einer Zahl fragt und dann die Fakultät dieser Zahl berechnet.  
   Verwenden Sie dazu eine While-Schleife.  
   ``Hinweis: Fakultät von 3 = 1 * 2 * 3 = 6``

6. Erstellen Sie eine While-Schleife, die von 0 bis 26 hochzählt.
  - Erstellen Sie eine Variable `chVal` mit dem Wert 97
  - Wandeln Sie `chVal` in eine `char`-Variable um
  - Geben Sie die `char`-Variable aus und erhöhen Sie `chVal` in jedem Schleifendurchlauf um eins
  - Beispielausgabe: "a, b, c, d, ..."

7. Schreiben Sie ein Programm, das eine Schleife ausführt, die zufällige Zahlen zwischen 1 und 10 generiert, bis eine 7 generiert wird.  
   Zählen Sie die Anzahl der Schleifendurchläufe und geben Sie sie am Ende aus.

### Wie schreibe ich die do-While-Schleife?
1. Schreiben Sie eine do-while-Schleife, die so lange läuft, bis der Benutzer eine Zahl zwischen 1 und 10 eingibt.
2. Schreiben Sie eine do-while-Schleife, die so lange läuft, bis das Passwort "geheim" korrekt eingegeben wurde.
3. Schreiben Sie eine do-while-Schleife, die den Benutzer so lange nach Zahlen fragt, bis er "exit" eingibt.

### While oder Do-While?
**Anzahl Ziffern einer Zahl**  
Einlesen einer Integer-Zahl und Ausgabe der Anzahl ihrer Ziffern.  
Hinweis: Modulo-Operationen helfen beim Zerlegen in Stellen.

**Primzahlen berechnen**  
Einlesen der oberen Grenze `n` und Ausgabe aller Primzahlen bis `n`.  
Beachten Sie: 1 ist keine Primzahl.

### Teilbar durch 3
Programmieren Sie eine Schleife, die alle durch 3 teilbaren Ganzzahlen zwischen 10 und 40 ausgibt.  
Beispiel:
```
12 15 18 21 24 27 30 33 36 39
```

### Zahlen zwischen 0 und 100 raten
Der Benutzer muss eine geheime Zahl zwischen 0 und 100 am Terminal erraten. Nach jeder Eingabe gibt das Programm Hinweise, ob die Zahl zu hoch oder zu klein ist. Der Benutzer hat 5 Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit einer Niederlage.

Weiters soll folgendes gelten:

* Geheime Zahl:
  Das Programm wählt zu Beginn eine zufällige Zahl zwischen 0 und 100 aus.
  Verwenden dazu die ``Funktion`` *randint* aus dem ``Modul`` *random*. Um die ``Funktion`` verwenden zu können, schreibe folgendes in die erste Zeile des Programmes ``from random import randint``.

* Userinput:
  Ein:e Benutzer:in wird in jeder Runde aufgefordert, eine Zahl einzugeben. Die Eingabe muss überprüft werden, ob sie der geheimen Zahl entspricht.

* Interaktion mit Benutzer:innen:
  Wenn die Eingabe zu hoch ist, gibt das Programm die Nachricht *"Die Zahl ist zu hoch!"* aus.
  Wenn die Eingabe zu niedrig ist, gibt das Programm die Nachricht *"Die Zahl ist zu klein!"* aus.
  Bei korrekter Eingabe zeigt das Programm *"Herzlichen Glückwunsch, Sie haben die Zahl erraten!"* an und beendet das Spiel.

* Anzahl der Versuche:
  Ein:e Benutzer:in hat ``5`` Leben. Bei jeder falschen Eingabe verliert diese:r ein Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit der Nachricht: *"Game Over! Die geheime Zahl war: ``<Geheime Zahl>``".

* ``optional``: Gib am Ende die Anzahl der Versuche aus, die ein:e Benutzer:in benötigt um die Zahl zu erraten. Füge eine Möglichkeit hinzu, das Spiel nach einem Durchgang erneut zu starten.

#### Hilfestellung:
* Nutzen Sie eine ``Schleife``, um die Eingaben zu prüfen, bis die Zahl erraten wurde oder die Leben aufgebraucht sind. Welche ``Schleife`` verwenden wir, wenn *die Anzahl der Wiederholungen unbekannt ist*?
* Verwenden Sie ``geheime_zahl = randint(0, 100)``
  **Achtung!** inklusive 0 und inklusive 100! Hier weicht Python von z.B. JAVA ab. Dort wäre exklusive 100 bei der Angabe der Zahl 100.
* ``leben = 5`` (Zählt, wie viele Leben ein:e Benutzer:in hat).
* Nutzen Sie ``input()`` um Eingaben aus dem Terminal einzulesen.

#### Testfälle:
```
Willkommen beim Zahlen-Ratespiel!
Ich habe eine geheime Zahl zwischen 0 und 100 ausgewählt.
Sie haben 5 Leben. Viel Glück!
 
Geben Sie Ihre Schätzung ein: 
> 50
Die Zahl ist zu hoch! Sie haben noch 4 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 25
Die Zahl ist zu klein! Sie haben noch 3 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 37
Die Zahl ist zu hoch! Sie haben noch 2 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 30
Die Zahl ist zu klein! Sie haben noch 1 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 35
Game Over! Die geheime Zahl war: 33
```

### Primzahl prüfen
Schreiben Sie ein Programm, das alle Primzahlen bis zu einer vom Benutzer eingegebenen Zahl ausgibt.  
Verwenden Sie eine Schleife zur Überprüfung, ob eine Zahl durch irgendeine Zahl zwischen 2 und (Zahl - 1) teilbar ist.

### Palindrom
Schreiben Sie ein Programm, das eine Zeichenkette vom Benutzer einliest und überprüft, ob sie ein Palindrom ist.  
Verwenden Sie dazu eine While-Schleife.

### Rechnen mit Menü
Erstellen Sie ein Programm mit folgendem Menü:
```
Bitte wählen Sie eine Option:
1 Addieren
2 Subtrahieren
3 Dividieren
4 Multiplizieren
-1 Programm beenden
```
Das Programm fragt zwei Zahlen ab und gibt das Ergebnis der gewählten Rechenart aus.  
Solange nicht -1 eingegeben wird, soll das Menü erneut erscheinen.  
Bei Abbruch wird die Anzahl der durchgeführten Rechnungen ausgegeben.

### Zeichenketten
Schreiben Sie ein Programm, das ein Wort vom Benutzer einliest und:
- Die Anzahl der Zeichen ausgibt
- Die Anzahl der Buchstaben ausgibt
- Nach Eingabe eines Zeichens: Anzahl dieses Zeichens im Wort ausgibt

Beispiel:  
```
Wort: `Abbcc123`, Zeichen: `b`  
Ausgabe:
- Zeichenanzahl: 8
- Buchstabenanzahl: 5
- Anzahl b: 2
```

### Schachtelung von Schleifen
Schreiben Sie ein Programm, das folgendes Muster mit for-Schleifen erzeugt:
```
*
**
***
****
*****
****
***
**
*
```

### Matrix
Schreiben Sie ein Programm, das die Zahlen 0 bis 99 in einer 10x10 Matrix ausgibt.  
Beispiel:
```
 0  1    2   3   4   5   6   7   8   9 
10  11  12  13  14  15  16  17  18  19
20  21  22  23  24  25  26  27  28  29
30  31  32  33  34  35  36  37  38  39
40  41  42  43  44  45  46  47  48  49
50  51  52  53  54  55  56  57  58  59
60  61  62  63  64  65  66  67  68  69
70  71  72  73  74  75  76  77  78  79
80  81  82  83  84  85  86  87  88  89
90  91  92  93  94  95  96  97  98  99
```
Verwenden Sie `%2d` zur Formatierung der Zahlen.

### Auffüllen zur Matrix
Erstellen Sie ein Programm mit folgendem Output durch verschachtelte Schleifen:
```
....1
...22
..333
.4444
55555
```

### Summe bilden
Schreiben Sie eine do-while-Schleife, die Zahlen summiert, bis "exit" eingegeben wird.  
Geben Sie am Ende auch den Durchschnitt aus.

### Würfeln
- Anzahl der Würfel vom Benutzer abfragen
- do-while-Schleife zum Würfeln und Raten der Augensumme erstellen
- Hinweise geben: höher / niedriger

### Tic Tac Toe
Implementieren Sie ein Tic Tac Toe-Spiel mit do-while:
- X und O abwechselnd setzen
- Spielbrett nach jedem Zug ausgeben
- Spielende bei Sieg oder Unentschieden

Beispiel:
```
-------------
| X | X | X |
-------------
|   | O |   |
-------------
|   |   | O |
-------------
```

