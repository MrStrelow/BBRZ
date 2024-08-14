import java.util.Scanner;

public class MainIF {
    public static void main(String[] args) {
//        Vokal?
//        Schreiben Sie ein Java-Programm, das den Benutzer nach einem Buchstaben fragt und überprüft, ob es
//        sich um einen Vokal oder einen Konsonanten handelt. Wenn es ein Vokal ist, gibt das Programm "Das ist ein
//        Vokal" aus, ansonsten "Das ist ein Konsonant".

        // usereingabe
        Scanner myScanner = new Scanner(System.in);

        System.out.println("Gib einen Vokal ein: ");
        String usereingabe = myScanner.nextLine().toLowerCase();

        if (usereingabe.length() == 1) {

            if (usereingabe.equals("a") || usereingabe.equals("e") || usereingabe.equals("i") || usereingabe.equals("o") || usereingabe.equals("u")) {
                System.out.println("Das ist ein Vokal.");
            } else {
                System.out.println("Das ist ein Konsonant.");
            }

        } else {
            System.out.println("Falsche Eingabe, da diese nur eine Länge von 1 haben darf.");
        }

//        Rabattberechnung
//        Eine Firma die Tiernahrung verkauft hat Sie gebeten eine Software zu schreiben, welche den passenden
//        Mengenrabatt bei einer Bestellung berechnet. Ab 10kg soll es einen Rabatt von 10% geben und ab 50kg
//        von 20%. Schreiben Sie ein Programm, welches zunächst den Preis pro Kilogramm und danach die
//        Bestellmenge [kg] einließt. Danach soll das Programm den Preis ohne Rabatt, mit Rabatt und die Differenz
//        ausgeben.

        System.out.println("Bitte geben Sie den Preis pro Gewicht des Einkaufs ein [€/kg] ");
        Double preisProGewicht = Double.parseDouble(myScanner.nextLine());

        System.out.println("Bitte geben Sie die Bestellmenge des Einkaufs ein [kg] ");
        Double gewicht = Double.parseDouble(myScanner.nextLine());

        Double gesamtpreis = preisProGewicht * gewicht;
        Double rabatt;

        if (10 < gewicht && gewicht < 50) {
            rabatt = 0.1;

        } else if (gewicht > 50) {
            rabatt = 0.2;

        } else {
            rabatt = 0.0;
        }

        Double rabattInEuro = gesamtpreis * rabatt;
        Double neuePreis = gesamtpreis - gesamtpreis * rabatt;;

        System.out.println("Preis: " + gesamtpreis + ", Rabatt in Prozent: " + rabatt * 100 + "[%], neuer Preis: " + neuePreis);


//        Schaltjahrberechnung
//        Berechnen Sie, ob das eingegebene Jahr ein Schaltjahr ist. Ein Schaltjahr erfüllt folgende Bedingungen
//        Es ist ein Schaltjahr, wenn die Jahreszahl durch 4 teilbar ist
//        Ist es auch ganzzahlig durch 100 teilbar, so ist es kein Schaltjahr, außer ...
//          - ... das Jahr ist ebenfalls ganzzahlig durch 400 teilbar
//        Beispiel für Schaltjahre: 1808, 1904 2000, 2112, 2244, 2332, 2380, 2400
//        Kein Schaltjahr: 2100 (durch 4 teilbar, durch 100, und nicht durch 400)

        System.out.print("Bitte geben Sie ein Jahr ein: ");
        Integer jahr = Integer.parseInt(myScanner.nextLine());

        if (jahr % 4 == 0) {

            if (jahr % 100 == 0) {

                if (jahr % 400 == 0) {
                    System.out.println("Schaltjahr.");

                } else {
                    System.out.println("Kein Schaltjahr.");
                }

            } else {
                System.out.println("Schaltjahr.");
            }

        } else {
            System.out.println("Kein Schaltjahr.");

        }

    }
}
