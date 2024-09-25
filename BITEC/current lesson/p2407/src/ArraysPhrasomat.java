import java.util.Random;
import java.util.Scanner;

public class ArraysPhrasomat {
    public static void main(String[] args) {
        // Pools von Wörtern je Wortgruppe (Nomen und Verben)
        String[] nomen = {"Dog", "Tree", "Cat", "Fish", "Orange", "Gauda Cheese", "Scarf", "Laptop", "JAVA", "Mouse", "BBRZ", "Christmas"};
        String[] verb = {"empowers", "adores", "carries", "heats", "froze", "ate", "blames", "injures"};
//        String[] adjektiv = {"yellow", "big", "small", "cheeky", "dark", "bright", "dim", "sad"};
//        String[] sensationen = {"unglaubliche", "spektakulaere", "unfassbare", "oage"};

        // 1.
        // b)
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();
        Boolean unzufriedenPhrase = true;

        while (unzufriedenPhrase) {
            // a)
            Integer randomNumberFirstNomen = random.nextInt(0, nomen.length);
            Integer randomNumberVerb = random.nextInt(0, verb.length);
            Integer randomNumberSecondNomen = random.nextInt(0, nomen.length);

            String phrase = nomen[randomNumberFirstNomen] + " " + verb[randomNumberVerb] + " " + nomen[randomNumberSecondNomen];
            System.out.println(phrase);

            System.out.print("Sind Sie zufrieden mit der Phrase? [ja/nein]: ");
            String meinung = scanner.nextLine();

//            if (meinung.equals("ja")) {
//                unzufriedenPhrase = false;
//
//            } else if (meinung.equals("nein")) {
//                unzufriedenPhrase = true;
//
//            } else {
//                System.out.println("Bitte geben Sie ja oder nein ein");
//                unzufriedenPhrase = true;
//            }

            switch (meinung) {
                case "ja" -> unzufriedenPhrase = false;
                case "nein" -> unzufriedenPhrase = true;
                default -> {
                    System.out.println("Bitte geben Sie ja oder nein ein");
                    unzufriedenPhrase = true;
                }
            }

            System.out.println("##########################################");
            System.out.println("Die generierte Phrase ist: " + phrase);
        }


    }
}
