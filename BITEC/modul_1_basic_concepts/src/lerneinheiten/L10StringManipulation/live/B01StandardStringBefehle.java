package lerneinheiten.L10StringManipulation.live;

import java.time.LocalDateTime;
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

        // Umkehrung. Finde das erste Vorkommen eines Symbols und gib den Index aus?
        System.out.println(text.indexOf("🐹"));

        System.out.println("#######");
        text = "halllo";
        int charKommtSoOftVor = 0;

        for (int i = 0; i < text.length(); i++) {
            if (text.charAt(i) == 'l') {
                charKommtSoOftVor++;
                System.out.println(i);
            }
        }

//        System.out.println(charKommtSoOftVor);

        System.out.println("~~~~~~~~~~~~~~~~~");
        int position = 0;
        StringBuilder textBuilder = new StringBuilder(text);

        while (true) {
            position = textBuilder.indexOf("l");

            if (position <= -1) {
                break;
            }

            textBuilder.replace(position, position+1, "_");
            System.out.println(position);
        }

        // formatierte ausgabe mit system.out.printf
        // Zahlenformat
        System.out.printf("hallo %.3f und danach %d", 13.06796, 20);
        System.out.println();

        // Uhrzeitformat
        LocalDateTime now = LocalDateTime.now();
        System.out.println(now);
        System.out.printf("hallo %tY~%td~%tm und danach %d", now, now, now, 20);
        System.out.printf("hallo %tY~%td~%tB und danach %d", now, now, now, 20);

    }
}
