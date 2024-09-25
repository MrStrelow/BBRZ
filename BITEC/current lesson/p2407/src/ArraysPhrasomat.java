import java.util.Random;
import java.util.Scanner;

public class ArraysPhrasomat {
    public static void main(String[] args) {
        // Pools von Wörtern je Wortgruppe (Nomen und Verben)
        String[] nomen = {"Dog", "Tree", "Cat", "Fish", "Orange", "Gauda Cheese", "Scarf", "Laptop", "JAVA", "Mouse", "BBRZ", "Christmas"};
        String[] verb = {"empowers", "adores", "carries", "heats", "froze", "ate", "blames", "injures"};
        String[] adjektiv = {"yellow", "big", "small", "cheeky", "dark", "bright", "dim", "sad"};
//        String[] sensationen = {"unglaubliche", "spektakulaere", "unfassbare", "oage"};

        // 1 b)
        // Objekte
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        // SchleifenBedingungen
        Boolean unzufriedenPhrase = true;

        // Variablen
        String phrase = ""; // TODO: nur zum testen, damit wir nicht alle 7 fälle des switches und
        // default ausprogrammieren müssen bevor wir das programm ausführen könne

        // 2)
        System.out.println("Wie lange soll die Phrase werden? [3-7]: ");
        Integer anzahlWoerter = Integer.parseInt(scanner.nextLine());

        while (unzufriedenPhrase) {
            // 1 a)
            Integer randomNumberFirstNomen = random.nextInt(0, nomen.length);
            Integer randomNumberSecondNomen = random.nextInt(0, nomen.length);
            Integer randomNumberVerb = random.nextInt(0, verb.length);
            Integer randomNumberAdjective = random.nextInt(0, adjektiv.length);

            switch (anzahlWoerter) {
                case 3 -> {
                    phrase = nomen[randomNumberFirstNomen] + " " + verb[randomNumberVerb] + " " + nomen[randomNumberSecondNomen];
                }
                case 4 -> {
                    if (random.nextDouble() < 0.5) {
                        phrase = adjektiv[randomNumberAdjective] + " " + nomen[randomNumberFirstNomen] + " " + verb[randomNumberVerb] + " " + nomen[randomNumberSecondNomen];
                    } else {
                        phrase = nomen[randomNumberFirstNomen] + " " + verb[randomNumberVerb] + " " + adjektiv[randomNumberAdjective] + " " + nomen[randomNumberSecondNomen];
                    }
                }
                case 5 -> {

                }
                case 6 -> {}
                case 7 -> {}
                default -> {}
            }
            System.out.println(phrase);

            System.out.print("Sind Sie zufrieden mit der Phrase? [ja/nein]: ");
            String meinung = scanner.nextLine();

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
