import java.util.Scanner;

public class flugpreise {
    public static void main(String[] args) {
        // Userinteraktion
        Scanner scanner = new Scanner(System.in);

        System.out.print("Entfernung: ");
        Double entfernung = scanner.nextDouble();

        System.out.print("Reisemonat: ");
        Integer reiseDatum = scanner.nextInt();

        System.out.print("Buchungsklasse: ");
        String reiseKlasse = scanner.next().toLowerCase();

        System.out.println(entfernung + " " + reiseDatum + " " + reiseKlasse);

        // Ticketpreise berechnen

        // 1. Info: Entfernung

        Double preis = entfernung * 0.02;

        // wenn user economy eingibt, dann +200, ansonsten, wenn user first eingibt, dann +400 ansonsten +0
//        if (reiseKlasse.equals("first")) {
//            preis += 400;
//        } else if (reiseKlasse.equals("premium")) {
//            preis += 200;
//        }
// //        else {
// //            preis += 0;
// //        }

        switch (reiseKlasse) {
            case "premium" -> preis += 200;
            case "first" -> preis += 400;
//            case "economy" -> preis += 0;
//            default -> preis += 0;
        }

        if (7 <= reiseDatum && reiseDatum <= 9) {
            preis += 20;
        } else if (reiseDatum.equals(12)) {
            preis += 15;
        } else {
            preis += 0;
        }

        System.out.println(preis);
    }
}
