Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* User-Input
* Operatoren (besonders logische)

Welche ``Denkweisen`` üben wir hier?
* Wie steuere ich eine ``Schleife`` mit ``logischen Bedingungen``?

Bei Unklarheiten hier nachlesen:
* [welche Kontrollstrukturen soll ich verwenden?](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_grundlagen/L02TypenOperatorenKontrollstrukturenUndFunktionen/Skripten/L02.3Kontrollstrukturen.md)

## Zahlen zwischen 0 und 100 raten
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

## Hilfestellung:
* Nutzen Sie eine ``Schleife``, um die Eingaben zu prüfen, bis die Zahl erraten wurde oder die Leben aufgebraucht sind. Welche ``Schleife`` verwenden wir, wenn *die Anzahl der Wiederholungen unbekannt ist*?
* Verwenden Sie ``geheime_zahl = randint(0, 100)``
**Achtung!** inklusive 0 und inklusive 100! Hier weicht Python von z.B. JAVA ab. Dort wäre exklusive 100 bei der Angabe der Zahl 100.
* ``leben = 5`` (Zählt, wie viele Leben ein:e Benutzer:in hat).
* Nutzen Sie ``input()`` um Eingaben aus dem Terminal einzulesen.

### Testfälle:
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