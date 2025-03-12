package lerneinheiten.L04UserInput.live;

import java.util.Scanner;

public class UserInput {
    public static void main(String[] args) {
        // <Typ> <name> <Zuweisungsoperator> <Wert>
        Scanner myScanner = new Scanner(System.in);

        // Problem! wenn wir eine next methode vor einer nextline methode verwenden, verschwindet eine zeile des inputs.

        // haben 2 Arten "der Scannung"
        // next (haben die Auswahl von Methoden welche Werte in andere Typen umwandeln)
        System.out.println("Gib einen Integer ein: ");
        Integer inputZahl = myScanner.nextInt(); // 5 einlesen
        myScanner.nextLine(); // \n einlesen und verwerfen - aber hässlich
        System.out.println(inputZahl);

        // nextLine
        System.out.println("gib einen String ein: ");
        String input = myScanner.nextLine(); // die neue zeile einlesen (inklusive \n)

        // schließe ressourcen - wenn diese nicht mehr benötigt werden
        // Achtung! hier ist es nicht mehr möglich später einen neuen scanner mit system.in anzulegen.
        myScanner.close();
    }
}