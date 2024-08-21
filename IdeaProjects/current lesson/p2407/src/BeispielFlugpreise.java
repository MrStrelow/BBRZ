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
        Double basispreis = entfernung * 0.02;
    }
}
