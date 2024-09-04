import java.util.Scanner;

public class GuessTheWord {
    public static void main(String[] args) {
        // - User interaktion
        // - [x] Eingabe des users, welche, falls diese falsch ist, wiederholt werden muss.
        // - [] Wiederholtes abfragen des Rateversuches des Users.
        // - laufende Ausgabe des Ratewortes

        // Variablen
        Scanner scanner = new Scanner(System.in);
        Integer laengeDesWortes = 3;
        Integer maximaleSpielzüge = 6;

        Integer verwendeteSpielzüge = 0;
        String wortZuErraten;
        Character korrekteEingabe;
        String eingabeZumRaten;

        Boolean wortErraten = false;

        String anzeigeWort = "_".repeat(laengeDesWortes);

        // - Eingabe des users, welche, falls diese falsch ist, wiederholt werden muss.
        do {
            System.out.println("Bitte gib ein Wort mit " + laengeDesWortes + " Buchstaben ein, welches erraten werden muss.");
            wortZuErraten = scanner.nextLine();

            if (wortZuErraten.length() != laengeDesWortes) {
                System.out.println("Unpassende Länge! [" + wortZuErraten.length() + "]. Bitte Wort mit " + laengeDesWortes + " Buchstaben eingeben.");
            }
        } while (wortZuErraten.length() != laengeDesWortes);

        // Anzeige vom Ratezustand
        System.out.println("Beginne das Wort zu erraten!");
        System.out.println(anzeigeWort);

        // - Wiederholtes abfragen des Rateversuches des Users.
        while ( verwendeteSpielzüge < maximaleSpielzüge && !wortErraten ) {
//        while ( !(verwendeteSpielzüge >= maximaleSpielzüge || wortErraten) ) {
            // 0 | 0 | 1 | Ergebnis oder: 0 | Ergebnis und: 0 | Ergebnis was wir wollen: 0
            // 0 | 1 | 0 | Ergebnis oder: 1 | Ergebnis und: 0 | Ergebnis was wir wollen: 0
            // 1 | 0 | 1 | Ergebnis oder: 1 | Ergebnis und: 0 | Ergebnis was wir wollen: 1
            // 1 | 1 | 0 | Ergebnis oder: 1 | Ergebnis und: 1 | Ergebnis was wir wollen: 0

            // usereingabe - handling von falschen input
            do {
                eingabeZumRaten = scanner.nextLine();

                if (eingabeZumRaten.length() != 1) {
                    System.out.println("Es darf nicht mehr wie ein Buchstabe eingegeben werden. Bitte wiederholde deinen Rateversuch.");

                } else {
                    korrekteEingabe = eingabeZumRaten.charAt(0);
                }
            } while (eingabeZumRaten.length() != 1);


            Boolean rateVersuchIstTeilDesWortes = wortZuErraten.contains(wortZuErraten);

            if (rateVersuchIstTeilDesWortes) {
                // schau nach wo es übereinstimmt und überschreibe den string wortErraten
                System.out.println("ich schaue nach :)");
            }

            System.out.println(anzeigeWort);

            verwendeteSpielzüge++;
        }

    }
}
