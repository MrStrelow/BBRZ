import java.util.Scanner;

public class WhileUebung2 {
    public static void main(String[] args) {
//        // 1.) Schreibe ein While Schleife, welche von 1 bis 10 zaehl

        Scanner scanner = new Scanner(System.in);

        System.out.print("BIS wann soll gezählt werden? ");
        Integer obereGrenze = Integer.parseInt(scanner.nextLine());

        System.out.print("AB wann soll gezählt werden? ");
        Integer untereGrenze = Integer.parseInt(scanner.nextLine());
        Integer zaehler = untereGrenze;

        // Ich verwende eine Bedingung in der While Schleife, mit der ich weiter mache. Diese ist "solange der zaehler kleiner gleich der obereGrenze ist, mache weiter"
        while (zaehler <= obereGrenze) {

            // wenn zahl gerade dann gib "gerade" aus.
            if (zaehler % 2 == 0) {
                System.out.println(zaehler + " ist eine gerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");

                // wenn zahl ungerade dann gib "ungerade" aus.
            } else {
                System.out.println( zaehler + " ist eine ungerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");
            }

            zaehler++;
        }

        // Ich verwende eine Bedingung, ab der ich abbreche. Diese ist "ich höre auf, sobald der zaehler gleich 10 ist"
//        while (true) {
//            System.out.println(zaehler);
//
//            if (zaehler == 10) {
//                break;
//            }
//
//            zaehler++;
//        }

        // Erweitertes Beispiel:
        // zähle auch die Anzahl wie oft eine Schleife ausgeführt wurde. Die Schleife wird 10-mal ausgeführt wenn ich von 1 bis 10 zähle,
        // aber auch wenn ich von 11 bis 20 zähle.

//        Scanner scanner = new Scanner(System.in);
//
//        System.out.print("BIS wann soll gezählt werden? ");
//        Integer obereGrenze = Integer.parseInt(scanner.nextLine());
//
//        System.out.print("AB wann soll gezählt werden? ");
//        Integer untereGrenze = Integer.parseInt(scanner.nextLine());
//        Integer zaehler = 1;
//
//        while ( (zaehler + untereGrenze - 1) <= obereGrenze) {
//
//            // wenn zahl gerade dann gib "gerade" aus.
//            if (zaehler % 2 == 0) {
//                System.out.println((zaehler + untereGrenze - 1) + " ist eine gerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");
//
//                // wenn zahl ungerade dann gib "ungerade" aus.
//            } else {
//                System.out.println( (zaehler + untereGrenze - 1) + " ist eine ungerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");
//            }
//
//            zaehler++;
//        }

    }
}
