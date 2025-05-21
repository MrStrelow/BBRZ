package lerneinheiten.L12Funktionen.live;

import java.util.Scanner;

public class A02FunktionenSchreiben {
    public static void main(String[] args) {
        // rufe die Funktion auf welche den Userinput aufruft.
        Scanner scanner = new Scanner(System.in);
        String textvomUser = userInput(scanner);

        // rufe die Funktion auf welche Character zählt.
        int anzahlZeichen = zaehleZeichen(textvomUser);

        System.out.printf("Der Satz hat folgende Anzahl an Zeichen: %-5d", anzahlZeichen);
    }

    // schreib eine Funktion welche einen String entgegennimmt und die Character zählt.
    static int zaehleZeichen(String satz) {
        return 0;
    }

    // schreib eine Funktion welche den User auffordert einen Satz,
    // welcher mindestens einem Leerzeichen hat, einzugeben. Falls das nicht der Fall ist,
    // frage nochmal nach.
    static String userInput(Scanner scanner){
        return "das ist ein test des userinputs"; // gibt mock zurück
    }


    // 1. Funktionen definieren (static nicht vergessen)
    // 2. Funktionen in main aufrufen
    // 3. Funktionen implementieren
    // 4. Durch 3. ändert sich 1.
}
