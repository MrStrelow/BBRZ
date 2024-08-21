package uebungen.loesungen;

import java.util.Scanner;

public class FLugpreise {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Bitte geben Sie die Flugstrecke in[Km] an :");
        Double strecke = Double.parseDouble(scanner.nextLine());

        System.out.println("Geben sie den Flugmonat ein :");
        Integer monat = Integer.parseInt(scanner.nextLine());

        System.out.println("Wählen sie die Buchungsklasse,geben sie für Economy EC ein für Premium PC und für die erste Klasse FC ein");

        String klasse = scanner.nextLine().trim().toUpperCase();

        Double basisPreis = strecke*0.02;

        if (monat >= 7 && monat <= 9) {
            basisPreis += 20.00;
        } else if (monat == 12) {

            basisPreis += 15.00;
        }


        switch (klasse) {
            case "FC":
                basisPreis += 400.00;
                break;
            case "PC":
                basisPreis += 200.00;
                break;
            case "EC":

                break;
            default:
                System.out.println("Unbekannte Buchungsklasse.");
                scanner.close();
                return;
        }

        System.out.printf("Der Preis für Ihr Ticket beträgt: %.2f€%n", basisPreis);

    }
}
