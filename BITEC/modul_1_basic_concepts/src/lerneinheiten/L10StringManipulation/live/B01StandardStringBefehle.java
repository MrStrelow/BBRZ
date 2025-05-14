package lerneinheiten.L10StringManipulation.live;

import java.util.Scanner;

public class B01StandardStringBefehle {
    public static void main(String[] args) {
        // String auf Gleichheit überprüfen
        String text =      "Dies ist ein Satz welcher ueberprueft wird.";
        String vergleich = "Dies ist ein Satz welcher uEberprueft wird.";
        StringBuilder aha = new StringBuilder("Dies ist ein Satz welcher ueberprueft wird.");

//        System.out.println(text == vergleich);
        System.out.println(text.equals(vergleich));
//        System.out.println(text.toLowerCase().equals(vergleich.toLowerCase()));
        System.out.println(text.equalsIgnoreCase(vergleich));
        System.out.println(text.equalsIgnoreCase(vergleich));
        System.out.println(text.contentEquals(aha));

        // Kommt ein Wort in einem String vor
        System.out.println(text.contains("ueberprueft"));
        System.out.println(text.startsWith("Dies i"));
        System.out.println(text.endsWith("ueberprueft wird."));

        Scanner scanner = new Scanner(System.in);
        String lowerCaseVergleich = vergleich.toLowerCase();
        String userInput = scanner.nextLine().toLowerCase();
        boolean userInputKommtVor = lowerCaseVergleich.contains(userInput);
        System.out.println(userInputKommtVor);

        // Wie extrahiere ich einen Teil eines Strings?

    }
}
