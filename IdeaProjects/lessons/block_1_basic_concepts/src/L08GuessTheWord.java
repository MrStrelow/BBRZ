import java.util.Scanner;

public class L08GuessTheWord {
    public static void main(String[] args) {
        final int laenge = 3;

        // Frage nach Wort mit 3 Buchstaben.
        Scanner scanner = new Scanner(System.in);
        String wortZuRaten;

        do {
            System.out.println("Eingabe des Ratewortes!");
            wortZuRaten = scanner.nextLine();

            if(wortZuRaten.length() != laenge) {
                System.out.println("Unpassende Laenge! Bitte Wort mit 3 Buchstaben eingeben.");
            }

        } while (wortZuRaten.length() != laenge);

        // anzeige des rate status ___
        StringBuilder rateAusgabe = new StringBuilder("_".repeat(laenge));

        System.out.println("Raten Sie!");
        System.out.println(rateAusgabe);

        //rate solange bis erraten oder abbruch

        int maximaleSpielzuege = 6;
        int verwendeteSpielzuege = 0;
        String rateEingabe;

        while (verwendeteSpielzuege < maximaleSpielzuege) {
            rateEingabe = scanner.nextLine();
            boolean istTeilDesWortes = wortZuRaten.contains(rateEingabe);

            if (istTeilDesWortes) {
                int index = -1;

                do {
                    index = wortZuRaten.indexOf(rateEingabe, index+1);

                    if(index!=-1) {
                        rateAusgabe = rateAusgabe.replace(index, index+1, rateEingabe);
                    }

                } while (index >= 0);

            }

            System.out.println(rateAusgabe);

            if (rateAusgabe.toString().equals(wortZuRaten)) {
                System.out.println("Gratuliere! :) das wort ist " + wortZuRaten);
                System.exit(0);
            }

            //Zeichnen!
//            System.out.println();

            verwendeteSpielzuege++;
        }

        System.out.println("dead :(");

    }
}
