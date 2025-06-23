Kopiere folgende Angabe nach [Aufgabe_3/01_Programmverständnis.md](../Aufgabe_3/01_Programmverstaendnis.md) und beantworte dort die folgenden Fragen.

Folgender *Code-Ausschnitt* funktionier nicht. Suche dort Fehler im Code, markiere diese Durch den Text ``//Fehler in dieser Zeile! Begründung: TODO`` und erkläre warum es ein Fehler ist.

```java
public static void main(String[] args) {
    String[][] muster = new String[5][5];
    
    // Hier wird das Muster erzeugt, es steht also im Muster was sinnvolles, nicht nur 5x5 null.
    ...
    
    String[][] gedrehtesMuster = drehen(spieglenX(transponieren(muster))); // Fehler in dieser Zeile! Begründung:
    // * Es gibt die Fukntion drehen nicht. 
    // * Dazu kommt, dass die Typen der Rückgabeparameter und Eingangsparameter nicht zusammenpassen. 
        // * Die Funktion transponieren(muster) erwartet als Eingangsparameter den Typ String[], jedoch geben wir String[][] an. 
        // * Die Funktion transponieren(muster) gibt als Rückgabeparameter den Typ Character[][][] zurück, jedoch spiegelnX erwartet sich ein en Eingangsparameter mit Typ String[][].
}

// Ein String ist ein Array von Characters - deshalb gibt es hier ein Character[][][] anstatt String[][].
// Fehler in dieser Zeile! Begründung: Der Parameter array sollte 2-Dimensionen haben. Der Typ wäre String[][].
static Character[][][] transponieren(String[] array) {
    Character[][][] result = new Character[array.length][array[0].length][array[0].length()];

    // Hier wird das Muster erzeugt, es steht also im Muster was sinnvolles, nicht nur 5x5 null.
    ...
    
    return result;
}

// Fehler in dieser Zeile! Begründung: Der Parameter array sollte 2-Dimensionen haben. Der Typ wäre String[][].
static string[][] spiegelnX(String[][] array) {
     String[][] result = new String[array.length][array[0].length];

    // Hier wird das Muster erzeugt, es steht also im Muster was sinnvolles, nicht nur 5x5 null.
    ...

    return result;
}