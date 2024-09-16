package uebungen.loesungen;

import java.util.Scanner;

public class Ue07Switch_und_If_solution {
    public static void main(String[] args) {

//        Flugpreise
//        Sie entwickeln eine Anwendung für eine Fluggesellschaft, die den Ticketpreis basierend auf verschiedenen
//        Kriterien berechnet. Bitten Sie den Benutzer um folgende Informationen:
//          - Die Entfernung in Kilometern für die Flugstrecke.
//          - Das Reisedatum (Monat) als Ganzzahlwert (z.B., 1 für Januar, 2 für Februar usw.).
//          - Die Buchungsklasse (Erste Klasse, Premium Economy oder Economy).
//          Verwenden Sie eine
//          Kombination von switch und if-Anweisungen, um den Ticketpreis basierend auf diesen Informationen
//          zu berechnen. Zum Beispiel können Sie verschiedene Preise für verschiedene Entfernungen und
//          Monate festlegen, und je nach Buchungsklasse den Preis entsprechend anpassen.
//        Land                      Preis
//        ---------------------------------
//        Strecke je km               0,02€
//        Economy Aufschlag           0,00€
//        Premium Economy Aufschlag 200,00€
//        Erste Klasse Aufschlag    400,00€
//        Aufschlag Juli-September   20,00€
//        Aufschlag Dezember         15,00€

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
        switch (klasse) {
            case "premium" -> basispreis += 200;
            case "erste" -> basispreis += 400;
            default -> System.out.println("Fehler.");
        }

        // 3. Info aus der Tabelle - Monat - Zeile 5 bis 6
        switch (monat) {
            case 7,8,9 -> basispreis += 20;
            case 12 -> basispreis += 15;
        }

//        if (7 <= monat && monat <= 9) {
//            basispreis += 20;
//
//        } else if(monat == 12) {
//            basispreis += 15;
//        }

        // Ausgabe
        System.out.println(basispreis);
    }
}
