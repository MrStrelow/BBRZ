import java.util.Scanner;

public class BeispielFlugpreise {
    public static void main(String[] args) {
        // 1. userinput - wir lesen hier die benötigten informationen ein.
        Scanner myScanner = new Scanner(System.in);

        System.out.print("Entfernung: ");
        Double entfernung = Double.parseDouble(myScanner.nextLine());

        System.out.print("Reisemonat: ");
        Integer monat = Integer.parseInt(myScanner.nextLine());

        System.out.print("Buchungsklasse: ");
        String klasse = myScanner.nextLine();

        // 2. Ticketpreis berechnen

        // 1. Info aus der Tabelle - Entfernung - Zeile 1
        Double basispreis = entfernung * 0.02;

        // 2. Info aus der Tabelle - Klasse - Zeile 2 bis 4
        // 3. Info aus der Tabelle - Monat - Zeile 5 bis 6
    }
}
