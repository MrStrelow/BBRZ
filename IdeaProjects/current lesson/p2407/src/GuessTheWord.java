import java.util.Scanner;

public class GuessTheWord {
    public static void main(String[] args) {
        // - User interaktion
        // - Eingabe des users, welche, falls diese falsch ist, wiederholt werden muss.
        // - Wiederholtes abfragen des Rateversuches des Users.
        // - aufende Ausgabe des Ratewortes

        // Variablen
        Scanner scanner = new Scanner(System.in);
        Integer laengeDesWortes = 3;
        Integer maximaleSpielzüge = 6;

        Integer verwendeteSpielzüge = 0;
        String wortZuErraten = "";
        Character eingabeZumRaten;

        // - Eingabe des users, welche, falls diese falsch ist, wiederholt werden muss.
        while (wortZuErraten.length() != laengeDesWortes) {
            System.out.println("Bitte gib ein Wort mit " + laengeDesWortes + " Buchstaben ein, welches erraten werden muss.");
            wortZuErraten = scanner.nextLine();
        }

    }
}
