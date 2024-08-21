import java.util.Scanner;

public class WhileUebung2 {
    public static void main(String[] args) {
//        // 1.) Schreibe ein While Schleife, welche von 1 bis 10 zaehl
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

        Scanner scanner = new Scanner(System.in);

        System.out.print("BIS wann soll gezählt werden? ");
        Integer obereGrenze = Integer.parseInt(scanner.nextLine());

        System.out.print("AB wann soll gezählt werden? ");
        Integer untereGrenze = Integer.parseInt(scanner.nextLine());
        Integer zaehler = untereGrenze;

        while ( zaehler  <= obereGrenze) {

            // wenn zahl gerade dann gib "gerade" aus.
            if (zaehler % 2 == 0) {
                System.out.println(zaehler + " ist eine gerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");

                // wenn zahl ungerade dann gib "ungerade" aus.
            } else {
                System.out.println( zaehler + " ist eine ungerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");
            }

            zaehler++;
        }

//        while (true) {
//            System.out.println(zaehler);
//
//            if (zaehler == 10) {
//                break;
//            }
//
//            zaehler++;
//        }

    }
}
