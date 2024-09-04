import java.time.chrono.MinguoDate;
import java.util.Scanner;

public class GuessTheWord {
    public static void main(String[] args) {
        // - User interaktion:
        //      - [x] Eingabe des users, welche, falls diese falsch ist, wiederholt werden muss.
        // - [x] Wiederholtes abfragen des Rateversuches des Users.
        // - [x] laufende Ausgabe des Ratewortes

        // Variablen
        Scanner scanner = new Scanner(System.in);
        Integer laengeDesWortes = 5;
        Integer maximaleSpielzüge = 12;

        Integer verwendeteSpielzüge = 0;
        String wortZuErraten;
        Character korrekteEingabe = null;
        String eingabeZumRaten;
        String filler = "_";

        Boolean gewonnen = false;

        StringBuilder anzeigeWort = new StringBuilder(filler.repeat(laengeDesWortes));

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
        while ( verwendeteSpielzüge < maximaleSpielzüge && !gewonnen ) {
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


            Boolean rateVersuchIstTeilDesWortes = wortZuErraten.contains(korrekteEingabe.toString());

            if (rateVersuchIstTeilDesWortes) {
                // schau nach an welcher Stelle der Rateversuch und das zu erratende Wort übereinstimmt und überschreibe den string wortErraten.
                Integer index = -1;

                do {
                    index = wortZuErraten.indexOf(korrekteEingabe, index+1);

                    if (index != -1) {
                        anzeigeWort.replace(index, index+1, korrekteEingabe.toString());
                    }

                } while (index >= 0);
            }

//            if (anzeigeWort.toString().equals(wortZuErraten)) {
            if (!anzeigeWort.toString().contains(filler)) {
                gewonnen = true;
                System.out.println("Gewonnen!");
            }

            System.out.println(anzeigeWort);

            verwendeteSpielzüge++;
        }

    }
}
