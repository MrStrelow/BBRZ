import java.util.Random;
import java.util.Scanner;

public class ArraysPhrasomat {

    public static final String ANSI_RESET = "\u001B[0m";
    public static final String ANSI_BLACK = "\u001B[30m";
    public static final String ANSI_RED = "\u001B[31m";
    public static final String ANSI_GREEN = "\u001B[32m";
    public static final String ANSI_YELLOW = "\u001B[33m";
    public static final String ANSI_BLUE = "\u001B[34m";
    public static final String ANSI_PURPLE = "\u001B[35m";
    public static final String ANSI_CYAN = "\u001B[36m";
    public static final String ANSI_WHITE = "\u001B[37m";

    public static void main(String[] args) {
        // Pools von Wörtern je Wortgruppe (Nomen und Verben)
        String[] nomen = {"Dog", "Tree", "Cat", "Fish", "Orange", "Gauda", "Cheese", "Scarf", "Laptop", "JAVA", "Mouse", "BBRZ", "Christmas"};
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
        System.out.print("Wie lange soll die Phrase werden? [3-7]: ");
        Integer anzahlWoerter = Integer.parseInt(scanner.nextLine());

        while (unzufriedenPhrase) {
            // 1 a)
            Integer randomNumberFirstNomen = random.nextInt(0, nomen.length);
            Integer randomNumberSecondNomen = random.nextInt(0, nomen.length);
            Integer randomNumberVerb = random.nextInt(0, verb.length);
            Integer randomNumberAdjective = random.nextInt(0, adjektiv.length);

            switch (anzahlWoerter) {
                case 3 -> {
                    phrase =
                             ANSI_BLUE + nomen[randomNumberFirstNomen] + " " +
                             ANSI_RED  + verb[randomNumberVerb]        + " " +
                             ANSI_BLUE + nomen[randomNumberSecondNomen];
                }
                case 4 -> {
                    if (random.nextDouble() < 0.5) {
                        phrase =
                                 ANSI_GREEN + adjektiv[randomNumberAdjective] + " " +
                                 ANSI_BLUE  + nomen[randomNumberFirstNomen]   + " " +
                                 ANSI_RED   + verb[randomNumberVerb]          + " " +
                                 ANSI_BLUE  + nomen[randomNumberSecondNomen];
                    } else {
                        phrase =
                                ANSI_BLUE  + nomen[randomNumberFirstNomen]   + " " +
                                ANSI_RED   + verb[randomNumberVerb]          + " " +
                                ANSI_GREEN + adjektiv[randomNumberAdjective] + " " +
                                ANSI_BLUE  + nomen[randomNumberSecondNomen];
                    }
                }
                case 5 -> {

                }
                case 6 -> {}
                case 7 -> {}
                default -> {}
            }

            System.out.println("Die generierte Phrase ist: " + phrase);

            System.out.print(ANSI_RESET + "Sind Sie zufrieden mit der Phrase? [ja/nein]: ");
            String meinung = scanner.nextLine();

            switch (meinung) {
                case "ja" -> unzufriedenPhrase = false;
                case "nein" -> unzufriedenPhrase = true;
                default -> {
                    System.out.println("Bitte geben Sie ja oder nein ein");
                    unzufriedenPhrase = true;
                }
            }

        }


    }
}
