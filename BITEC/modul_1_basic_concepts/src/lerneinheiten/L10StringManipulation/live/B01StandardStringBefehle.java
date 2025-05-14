package lerneinheiten.L10StringManipulation.live;

import java.util.Scanner;

public class B01StandardStringBefehle {
    public static void main(String[] args) {
        // String auf Gleichheit überprüfen
        String text =      "Dies ist ein Satz welcher ueberprueft wird.";
        String vergleich = "Dies ist ein Satz welcher uEberprueft wird.";
        StringBuilder aha = new StringBuilder("Dies ist ein Satz welcher ueberprueft wird.");

////        System.out.println(text == vergleich);
//        System.out.println(text.equals(vergleich));
////        System.out.println(text.toLowerCase().equals(vergleich.toLowerCase()));
//        System.out.println(text.equalsIgnoreCase(vergleich));
//        System.out.println(text.equalsIgnoreCase(vergleich));
//        System.out.println(text.contentEquals(aha));
//
//        // Kommt ein Wort in einem String vor
//        System.out.println(text.contains("ueberprueft"));
//        System.out.println(text.startsWith("Dies i"));
//        System.out.println(text.endsWith("ueberprueft wird."));
//
//        Scanner scanner = new Scanner(System.in);
//        String lowerCaseVergleich = vergleich.toLowerCase();
//        System.out.println("Eingabe: ");
//        String userInput = scanner.nextLine().toLowerCase();
//        boolean userInputKommtVor = lowerCaseVergleich.contains(userInput);
//        System.out.println(userInputKommtVor);
//
//        // Wie extrahiere ich einen Teil eines Strings?
//        // ... mit substring
//        int berechneterStart = 50;
//        int berechnetesEnde = 50;
//
//        if (berechneterStart < text.length() && berechnetesEnde < text.length()) {
//            System.out.println(text.substring(berechneterStart, berechnetesEnde));
//        } else {
//            System.out.println("geht nicht");
//        }

//        // ... mit substring
//        System.out.println("zahlen angeben: ");
//        int start = scanner.nextInt();
//        int ende = scanner.nextInt();
//
//        berechneterStart = Math.max(Math.min(start, text.length()), 0);
//        berechnetesEnde = Math.min(Math.max(ende, 0), text.length());
//        System.out.println(berechneterStart);
//        System.out.println(berechnetesEnde);
//        System.out.println(text.substring(berechneterStart, berechnetesEnde));

        // ... mit charAt
        text = "Wi🌊rd⬜🟩🟫.🐹";
        for (int i = 0; i < text.length(); i++) {
//            System.out.println("i:" + i + " - " + text.charAt(i));
//            System.out.println("i:" + i + " - " + text.substring(i, i+1));
            int unicode = text.codePointAt(i);
            String result = Character.toString(unicode);
            System.out.println("i:" + i + " - " + result + " - " + Integer.toHexString(unicode));

//            if (Character.isEmoji(unicode)) {
            if (Integer.toHexString(unicode).length() > 4) {
                i++;
            }
        }

        System.out.println(text.indexOf("🐹"));
    }
}
