import java.util.Scanner;

public class WhileUebung2 {
    public static void main(String[] args) {
        // 1.) Schreibe ein While Schleife, welche von 1 bis 10 zaehl
        Scanner scanner = new Scanner(System.in);

        Integer zaehler = 1;
        Integer obereGrenze = ;

        while (zaehler <= obereGrenze) {

            // wenn zahl gerade dann gib "gerade" aus.
            if (zaehler % 2 == 0) {
                System.out.println(zaehler + " ist eine gerade Zahl.");

                // wenn zahl ungerade dann gib "ungerade" aus.
            } else {
                System.out.println(zaehler + " ist eine ungerade Zahl.");
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
