package lerneinheiten.L04UserInput.skripten;

import java.util.Scanner;

public class L04UserInput {
    public static void main(String[] args) {
        Scanner myScanner = new Scanner(System.in);

        myScanner.nextLine();
        System.out.println("Bitte gib eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
        myScanner.nextLine();

        System.out.println("Bitte gib nocheinmal eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
        String meineEingabe = myScanner.nextLine();

        System.out.println("Deine Eingabe war: " + meineEingabe);

        System.out.println("Bitte gib nocheinmal eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
        meineEingabe = myScanner.next();

        System.out.println("Bitte gib zwei Zahlen getrennt durch die leertaste ein z.B. 'a b', und bestätigen Sie mit <Enter>: ");
        String meineErsteEingabe = myScanner.next();
        String meineZweiteEingabe = myScanner.next();

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        myScanner.useDelimiter("ZZzZZ");

        System.out.println("Bitte gib nochmal zwei Zahlen welches das Haltesymbol ZZzZZ hat ein z.B. 'aZZzZZbZZzZZ', und bestätigen Sie mit <Enter>: ");
        meineErsteEingabe = myScanner.next();
        meineZweiteEingabe = myScanner.next();

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);
        myScanner.nextLine();

        // Hier nochmal das Beispiel:
        myScanner.useDelimiter("ZZzZZ|\n");

        // Wenn wir nun die Eingabe von davor wiederholen sollte folgendes passieren.
        System.out.println("Bitte gib nochmal zwei Zahlen getrennt durch ZZzZZ ein z.B. 'aZZzZZb', und bestätigen Sie mit <Enter>: ");
        meineErsteEingabe = myScanner.next();
        meineZweiteEingabe = myScanner.next();

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        System.out.println("komische eingabe: ");
        meineErsteEingabe = myScanner.next();

        System.out.println("komische zweite eingabe welche aber übersprungen wird!: ");
        meineZweiteEingabe = myScanner.nextLine();

        System.out.println("unkomische eingabe: ");
        meineErsteEingabe = myScanner.next();
        myScanner.nextLine();

        System.out.println("unkomische zweite eingabe welche nicht mehr übersprungen wird: ");
        meineZweiteEingabe = myScanner.nextLine();

        System.out.println("meine ganzahlige Eingabe welche aber als 'String' mit 'nextLine' eingelesen wird.");
        Integer myInteger = Integer.parseInt(myScanner.nextLine());

        // z.B - Achtung hier wird ein neues Konzept verwendet! Ein Array! Dazu aber später mehr.
        System.out.println("meine doppelte Eingabe 'a b' welche ich danach Bearbeite");
        String ganzzeiligeEingabe = myScanner.nextLine();

        String[] mehrereStrings = ganzzeiligeEingabe.split(" ");
        meineErsteEingabe = mehrereStrings[0];
        meineErsteEingabe = mehrereStrings[1];

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        myScanner.close();

        // ACHTUNG! wenn der scanner geschlossen wird, kann die Conole nicht merh verwendet werden!
        // Auch ein neues Anlegen eines scanners mit = new Scanner(System.in) funktioniert dann nicht mehr!
        // Also nur den Scanner schließen wenn wir ihn nicht mehr benötigen!
    }
}
