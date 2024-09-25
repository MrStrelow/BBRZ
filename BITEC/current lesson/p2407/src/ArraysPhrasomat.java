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
        String phrase; //nur zum testen, String phrase = ""; damit wir nicht alle 7 fälle des switches und
        // default ausprogrammieren müssen bevor wir das programm ausführen könne

        // 2)
        System.out.print("Wie lange soll die Phrase werden? [3-7]: ");
        Integer anzahlWoerter = Integer.parseInt(scanner.nextLine());

        while (unzufriedenPhrase) {
            // 1 a)
            Integer randomIndexFirstNomen      = random.nextInt(0, nomen.length);
            Integer randomIndexSecondNomen     = random.nextInt(0, nomen.length);
            Integer randomIndexVerb            = random.nextInt(0, verb.length);
            Integer randomIndexFirstAdjective  = random.nextInt(0, adjektiv.length);
            Integer randomIndexSecondAdjective = random.nextInt(0, adjektiv.length);
            Integer randomIndexThirdAdjective  = random.nextInt(0, adjektiv.length);
            Integer randomIndexFourthAdjective = random.nextInt(0, adjektiv.length);

            Double randomNumber = random.nextDouble();


            switch (anzahlWoerter) {
                case 3 -> {
                    phrase =
                             ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                             ANSI_RED  + verb[randomIndexVerb]        + " " +
                             ANSI_BLUE + nomen[randomIndexSecondNomen];
                }
                case 4 -> {
                    String phraseEins =
                             ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                             ANSI_BLUE  + nomen[randomIndexFirstNomen]        + " " +
                             ANSI_RED   + verb[randomIndexVerb]               + " " +
                             ANSI_BLUE  + nomen[randomIndexSecondNomen];

                    String phraseZwei =
                            ANSI_BLUE  + nomen[randomIndexFirstNomen]        + " " +
                            ANSI_RED   + verb[randomIndexVerb]               + " " +
                            ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                            ANSI_BLUE  + nomen[randomIndexSecondNomen];

                    String[] moeglichkeiten = {phraseEins, phraseZwei};
                    phrase = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];

                }
                case 5 -> {
                    String phraseEins =
                            ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                            ANSI_RED + verb[randomIndexVerb] + " " +
                            ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                            ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                            ANSI_BLUE + nomen[randomIndexSecondNomen];

                    String phraseZwei =
                            ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                            ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                            ANSI_RED + verb[randomIndexVerb] + " " +
                            ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                            ANSI_BLUE + nomen[randomIndexSecondNomen];

                    String phraseDrei =
                            ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                            ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                            ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                            ANSI_RED + verb[randomIndexVerb] + " " +
                            ANSI_BLUE + nomen[randomIndexSecondNomen];

                    String[] moeglichkeiten = {phraseEins, phraseZwei, phraseDrei};
                    phrase = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];
                }
                case 6 -> {
                        String phraseEins =
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                        String phraseZwei =
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                        String phraseDrei =
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                        String phraseVier =
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                    String[] moeglichkeiten = {phraseEins, phraseZwei, phraseDrei, phraseVier};
                    phrase = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];
                }
                case 7 -> {
                        String phraseEins =
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexFourthAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                        String phraseZwei =
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexFourthAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                        String phraseDrei =
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexFourthAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                        String phraseVier =
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_GREEN + adjektiv[randomIndexFourthAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                        String phraseFuenf =
                                ANSI_GREEN + adjektiv[randomIndexFirstAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexSecondAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexThirdAdjective] + " " +
                                ANSI_GREEN + adjektiv[randomIndexFourthAdjective] + " " +
                                ANSI_BLUE + nomen[randomIndexFirstNomen] + " " +
                                ANSI_RED + verb[randomIndexVerb] + " " +
                                ANSI_BLUE + nomen[randomIndexSecondNomen];

                    String[] moeglichkeiten = {phraseEins, phraseZwei, phraseDrei, phraseVier, phraseFuenf};
                    phrase = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];
                }
                default -> {
                    System.out.println("Die Zahl ist nicht zwischen 3 und 7. Bitte erneut eingeben");
                    phrase = "";
                }
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
