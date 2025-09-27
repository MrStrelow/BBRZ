Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* User-Input
* Operatoren (besonders logische)

Welche ``Denkweisen`` üben wir hier?
* Wie steuere ich eine ``Schleife`` mit ``logischen Bedingungen``?

Bei Unklarheiten hier nachlesen:
* [welche Kontrollstrukturen soll ich verwenden?](../Skripten/L03.1Kontrollstrukturen.md)

## Guess the Word - level: 😵‍💫
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

Optional: Führe das Programm im Terminal/Console aus und implementiere, dass das eingegebene Wort "verschwindet". Wir verwenden dazu ``Console.ReadKey(true)`` um die Eingabe des Users zu verstecken. Danach geben wir z.B. ``"*"`` aus. Das muss pro Tastendruck und damit *char* passieren.

* Verwende folgende Vorlage. Dort ist die Darstellung des Spiels bereits implementiert.*
```
using System.Text;

// =================================================================================
// 1. KONSTANTEN UND VARIABLEN
// =================================================================================

const int LAENGE_DES_WORTES = 3;
const int MAX_FEHLER = 6;
string zuErratendesWort = "";
string bereitsGerateneBuchstaben = "";
int fehler = 0;

// =================================================================================
// 2. HAUPTLOGIK (Top-Level Statements)
// =================================================================================

Console.OutputEncoding = Encoding.UTF8;
// TODO: hier die Logik implementieren.

// =================================================================================
// 2. ZEICHNUNGSMETHODEN
// =================================================================================

static void zeichneHangman(int fehler)
{
    Console.WriteLine("  ____ ");
    Console.WriteLine(" |    |");
    Console.WriteLine(" |    " + (fehler >= 1 ? "O" : ""));
    Console.Write(" |   ");

    if (fehler == 2) Console.Write("|");
    else if (fehler == 3) Console.Write("/|");
    else if (fehler >= 4) Console.Write("/|\\");

    Console.WriteLine();
    Console.Write(" |    ");

    if (fehler == 5) Console.Write("/");
    else if (fehler >= 6) Console.Write("/ \\");

    Console.WriteLine();
    Console.WriteLine("_|___ ");
}

static void zeichneSharkFin(int fehlversuche)
{
    string bild = fehlversuche switch
    {
        0 => "🦈🌊🌊🌊🌊🌊🏄🏻",
        1 => "🌊🦈🌊🌊🌊🌊🏄🏻",
        2 => "🌊🌊🦈🌊🌊🌊🏄🏻",
        3 => "🌊🌊🌊🦈🌊🌊🏄🏻",
        4 => "🌊🌊🌊🌊🦈🌊🏄🏻",
        5 => "🌊🌊🌊🌊🌊🦈🏄🏻",
        _ => "🌊🌊🌊🌊🌊🌊🤕", // 6 oder mehr
    };
    Console.WriteLine(bild);
}

static void zeichneEisbecher(int fehlversuche)
{
    string becher = fehlversuche switch
    {
        0 => """
              🔴
             🟢🟤
            🟢🟠🐻‍❄️
            """,
        1 => """
             
             🟢🟤
            🟢🟠🐻‍❄️
            """,
        2 => """
             
             🟢
            🟢🟠🐻‍❄️
            """,
        3 => """
             
             
            🟢🟠🐻‍❄️
            """,
        4 => """
             
             
              🟠🐻‍❄️
            """,
        5 => """
             
             
                🐻‍❄️
            """,
        _ => """
             
             
            
            """,
    };

    Console.WriteLine(becher);
    Console.WriteLine("\\ /\\ /");
    Console.WriteLine(" \\. /");
    Console.WriteLine("  \\/");
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