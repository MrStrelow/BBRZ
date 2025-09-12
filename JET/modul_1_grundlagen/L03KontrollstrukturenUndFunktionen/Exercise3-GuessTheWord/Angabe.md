## Guess the Word
Entwickeln Sie das Spiel "Hangman". Das Spiel sollte folgende Funktionen haben:
* Fragen Sie den Benutzer nach einem Wort mit 3 Buchstaben. Die Zahl 3 soll in der Konstante Länge gespeichert werden und somit einfach veränderbar sein.
* Ist das Wort zu lang oder leer, soll eine Fehlermeldung ausgegeben werden und erneut angefragt werden.
* Anzeige des Status des Wortes, das der Spieler erraten muss (zum Beispiel als Striche (_), die die Buchstaben repräsentieren).
* Eine Schleife, die dem Spieler erlaubt, Buchstaben zu raten, bis das Wort vollständig erraten oder der Galgenmann "vollständig gehängt" ist. (Groß-/Kleinschreibung soll egal sein)
* Begrenzung der Anzahl der Fehlversuche des Spielers (zum Beispiel sechs Fehlversuche, bevor das
Spiel endet).
* Überprüfung der Eingaben des Spielers und Aktualisierung des Spielstands entsprechend der
geratenen Buchstaben.
* Anzeige des Gewinns oder Verlusts des Spiels nach dem Ende der Spielrunde.

Beispielwörter mit 3 Buchstaben: Bau, Hut, Arm, Tag, Eis, Zoo, See
Beispielwörter mit 4 Buchstaben: Haus, Bahn, Tier, Buch, Fest

Optional: Führe das Programm im Terminal/Console aus und implementiere, dass das eingegebene Wort "verschwindet". Wir überschreiben die Zeile wo es ausgegeben wird. Verwende dazu die Konsolenbefehle

*Hinweis: Verwende folgenden Ort für die Darstellung des Problems (siehe Lösung):*
```
void ZeichneHangman(int fehler) {
    // switch ausdruck mit fehlerfällen oder 
    // kompakter if ausdrücke (siehe Lösung) 
}

static void ZeichneSharkFin(int fehlversuche) {
    // switch ausdruck mit den fehlerfällen
}

static void ZeichneEisbecher(int fehlversuche) {
    // switch ausdruck mit den fehlerfällen
}  
```

#### Darstellung - Hangman
Beispiel:
```
Wähle das Wort ohne dass deine Mitspieler es sehen: Hut
Wort: _ _ _
    ____ 
   |    | 
   |     
   |     
   |    
  _|___  

Rate einen Buchstaben: a
Wort: _ _ _

    ____ 
   |    | 
   |    O 
   |     
   |    
  _|___  
 
Rate einen Buchstaben: b
Wort: _ _ _

    ____ 
   |    | 
   |    O 
   |    |  
   |    
  _|___  

Rate einen Buchstaben: k
Wort: _ _ _

    ____ 
   |    | 
   |    O 
   |   /|  
   |    
  _|___   
 
Rate einen Buchstaben: h
Wort: H _ _

    ____ 
   |    | 
   |    O 
   |   /|  
   |    
  _|___ 
 
Rate einen Buchstaben: e
Wort: H _ _

    ____ 
   |    | 
   |    O 
   |   /|\ 
   |     
  _|___  

Rate einen Buchstaben: u
Wort: H u _
    ____ 
   |    | 
   |    O 
   |   /|\ 
   |     
  _|___
 
Rate einen Buchstaben: p
Wort: H u _
   ____ 
   |    | 
   |    O 
   |   /|\  
   |   /  
  _|___  

Rate einen Buchstaben: g
Wort: H u _
    ____ 
   |    | 
   |    O 
   |   /|\  
   |   / \ 
  _|___  
 
Verloren. Das Wort war: Hut.
```

#### Darstellung - Shark Fin

- Grafik zeigt eine Hai-Flosse, die bei jedem Fehler näher kommt
Beispiel:
```
Wähle das Wort ohne dass deine Mitspieler es sehen: Hut
Wort: _ _ _
🦈🌊🌊🌊🌊🌊🏄🏻

Rate einen Buchstaben: a
Wort: _ _ _
🌊🦈🌊🌊🌊🌊🏄🏻 
 
Rate einen Buchstaben: b
Wort: _ _ _
🌊🌊🦈🌊🌊🌊🏄🏻  
 
Rate einen Buchstaben: h
Wort: H _ _
🌊🌊🦈🌊🌊🌊🏄🏻
 
Rate einen Buchstaben: e
Wort: H _ _
🌊🌊🌊🦈🌊🌊🏄🏻 

Rate einen Buchstaben: u
Wort: H u _
🌊🌊🌊🦈🌊🌊🏄🏻
 
Rate einen Buchstaben: p
Wort: H u _
🌊🌊🌊🌊🦈🌊🏄🏻 

Rate einen Buchstaben: g
Wort: H u _
🌊🌊🌊🌊🌊🦈🏄🏻 

Rate einen Buchstaben: k
Wort: H u _
🌊🌊🌊🌊🌊🌊🤕
 
Verloren. Das Wort war: Hut.
```

#### Darstellung - Verschwindender Eisbecher
Beispiel:
```
Wähle das Wort ohne dass deine Mitspieler es sehen: Hut
Wort: _ _ _
  🔴
 🟢🟤
🟢🟠🐻‍❄️
\ /\ /
 \. /
  \/

Rate einen Buchstaben: a
Wort: _ _ _
  
 🟢🟤
🟢🟠🐻‍❄️
\ /\ /
 \. /
  \/
 
Rate einen Buchstaben: b
Wort: _ _ _
  
 🟢
🟢🟠🐻‍❄️
\ /\ /
 \. /
  \/ 
 
Rate einen Buchstaben: h
Wort: H _ _
  
 🟢
🟢🟠🐻‍❄️
\ /\ /
 \. /
  \/
 
Rate einen Buchstaben: e
Wort: H _ _
 
 
🟢🟠🐻‍❄️
\ /\ /
 \. /
  \/

Rate einen Buchstaben: u
Wort: H u _


🟢🟠🐻‍❄️
\ /\ /
 \. /
  \/
 
Rate einen Buchstaben: p
Wort: H u _


  🟠🐻‍❄️
\ /\ /
 \. /
  \/

Rate einen Buchstaben: g
Wort: H u _


    🐻‍❄️
\ /\ /
 \. /
  \/ 

Rate einen Buchstaben: k
Wort: H u _



\ /\ /
 \. /
  \/
 
Verloren. Das Wort war: Hut.
```