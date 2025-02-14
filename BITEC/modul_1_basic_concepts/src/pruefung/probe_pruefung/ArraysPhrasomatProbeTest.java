package pruefung.probe_pruefung;

import java.util.Random;
import java.util.Scanner;

public class ArraysPhrasomatProbeTest {

    public static final String ANSI_RESET = "\u001B[0m";
    public static final String ANSI_BLACK = "\u001B[30m";
    public static final String ANSI_RED = "\u001B[31m";
    public static final String ANSI_GREEN = "\u001B[32m";
    public static final String ANSI_YELLOW = "\u001B[33m";
    public static final String ANSI_BLUE = "\u001B[34m";
    public static final String ANSI_PURPLE = "\u001B[35m";
    public static final String ANSI_CYAN = "\u001B[36m";
    public static final String ANSI_WHITE = "\u001B[37m";

    String[] neutralerPostfix = {
            ANSI_YELLOW + "es tut was es soll." + ANSI_RESET,
            ANSI_YELLOW + "meistens gehts gut, aber nicht immer." + ANSI_RESET,
            ANSI_YELLOW + "ich habe meine Erwartungen gesenkt und diese wurden übertroffen, aber um nicht viel." + ANSI_RESET,
            ANSI_YELLOW + "es rattert stark, aber passt scho." + ANSI_RESET,
            ANSI_YELLOW + "es ist laut, aber für den Preis ist es ok." + ANSI_RESET
    };
    String[] positiverPostfix = {
            ANSI_GREEN + "es ist genial, dass es zusätzlich einen Regler hat um das Licht zu dämmen!" + ANSI_RESET,
            ANSI_GREEN + "es wurden meine Erwartungen weit übertroffen!" + ANSI_RESET,
            ANSI_GREEN + "ich kann mir mein Leben nicht ohne dem vorstellen!" + ANSI_RESET,
            ANSI_GREEN + "Shut up, and take my money!" + ANSI_RESET,
            ANSI_GREEN + "es ist der Rasen so dicht wie noch nie!" + ANSI_RESET
    };
    String[] negativerPostfix = {
            ANSI_RED + "es funktioniert dieser @§%&$§!!§$ nicht." + ANSI_RESET,
            ANSI_RED + "es wäre 0/5, aber weniger wie 1/5 geht nicht." + ANSI_RESET,
            ANSI_RED + "es hat mir die Hand fast abgerissen." + ANSI_RESET,
            ANSI_RED + "der Geruch ist unerträglich und es tropft eine flammbare Flüssigkeit daraus." + ANSI_RESET,
            ANSI_RED + "der Ramen ist aus Plastik und sollte aus echtem Gold sein." + ANSI_RESET,
            ANSI_RED + "die Staatsanwaltschaft ermittelt wegen Betrug." + ANSI_RESET
    };

    String[] prefix = {
            "Was aber nicht vergessen werden darf, ",
            "Was noch fehlt ist aber, ",
            "Was ich aber hinzufügen will, ",
            "Zudem, ",
            "ABER, ",
            "Jedoch, "
    };

    public static void main(String[] args) {
        // Pools von Woertern je Wortgruppe (Nomen und Verben)
        String[] nomen = {"Dog", "Tree", "Cat", "Fish", "Orange", "Gauda", "Cheese", "Scarf", "Laptop", "JAVA", "Mouse", "BBRZ", "Christmas"};
        String[] verb = {"empowers", "adores", "carries", "heats", "froze", "ate", "blames", "injures"};
        String[] adjektiv = {"yellow", "big", "small", "cheeky", "dark", "bright", "dim", "sad"};
//        String[] sensationen = {"unglaubliche", "spektakulaere", "unfassbare", "oage"};

        // 1 b)
        // Objekte
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        // SchleifenBedingungen
        Boolean unzufriedenUeberschrift = true;
        Boolean unzufriedenInhalt = true;
        Boolean habeBloedsinnEingegeben = false;

        Boolean mitUeberschriftZufriedenEndeDesProgrammes = true;
        Boolean mitInhaltZufriedenEndeDesProgrammes = true;
        Boolean mitArtikelZufriedenEndeDesProgrammes = false;

        // Variablen
        String ueberschrift = null;
        //String ueberschrift = ""; ist nur zum testen.
        // damit wir nicht alle 7 fälle des switches und default ausprogrammieren muessen bevor wir das programm ausfuehren koennen.
        // Warum können wir ueberschrift nicht nur deklarieren und müssen es definieren? D
        // Denke an die Verwendung der Variable ueberschriftnach dem Switch.
        // Welchen Wert hat diese Variable, wenn wir Wörter der Länge 7 wollen, aber nur case 3 programmiert haben? (und keinen default case).

        String zeitungsInhalt = null;
        String zeitungsArtikel = null;

        // 2)
        System.out.print("Wie lange soll die Phrase werden? [3-7]: ");
        Integer anzahlWoerter = Integer.parseInt(scanner.nextLine());

        while (!mitArtikelZufriedenEndeDesProgrammes) {

            // Ueberschrift eines Zeitungsartikels generieren
            while (unzufriedenUeberschrift || !mitUeberschriftZufriedenEndeDesProgrammes) {
                mitUeberschriftZufriedenEndeDesProgrammes = true;

                Integer randomIndexFirstNomen      = random.nextInt(0, nomen.length);
                Integer randomIndexSecondNomen     = random.nextInt(0, nomen.length);
                Integer randomIndexVerb            = random.nextInt(0, verb.length);
                Integer randomIndexFirstAdjective  = random.nextInt(0, adjektiv.length);
                Integer randomIndexSecondAdjective = random.nextInt(0, adjektiv.length);
                Integer randomIndexThirdAdjective  = random.nextInt(0, adjektiv.length);
                Integer randomIndexFourthAdjective = random.nextInt(0, adjektiv.length);

                Double randomNumber = random.nextDouble();

                if (!habeBloedsinnEingegeben) {
                    switch (anzahlWoerter) {
                        case 3 -> {
                            ueberschrift =
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
                            ueberschrift = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];

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
                            ueberschrift = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];
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
                            ueberschrift = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];
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
                            ueberschrift = moeglichkeiten[random.nextInt(0,moeglichkeiten.length)];
                        }
                        default -> {
                            System.out.println("Die Zahl ist nicht zwischen 3 und 7. Bitte erneut eingeben");
                            ueberschrift = "";
                        }
                    }
                }

                ueberschrift += ANSI_RESET;

                System.out.println("Die generierte Phrase ist: " + ueberschrift);

                System.out.print("Sind Sie zufrieden mit der Phrase? [ja/nein]: ");
                String meinung = scanner.nextLine().toLowerCase();

                switch (meinung) {
                    case "ja" -> {
                        unzufriedenUeberschrift = false;
                        habeBloedsinnEingegeben = false;
                    }
                    case "nein" -> {
                        unzufriedenUeberschrift = true;
                        habeBloedsinnEingegeben = false;
                    }
                    default -> {
                        System.out.println("Bitte geben Sie ja oder nein ein");
                        unzufriedenUeberschrift = true;
                        habeBloedsinnEingegeben = true;
                    }
                }
            }


            // Code des INHALT eines Zeitungsartikels
            habeBloedsinnEingegeben = false;

            while (unzufriedenInhalt || !mitInhaltZufriedenEndeDesProgrammes) {
                mitInhaltZufriedenEndeDesProgrammes = true;
                if (!habeBloedsinnEingegeben) {
                    System.out.println("Geben Sie nun den Text des Zeitungsartikels ein: ");
                    zeitungsInhalt = scanner.nextLine();
                }

                System.out.println("Sind Sie zufrieden mit dem Inhalt? [ja/nein]: ");
                String zufriedenMitInhalt = scanner.nextLine().toLowerCase();

                switch (zufriedenMitInhalt) {
                    case "ja" -> {
                        unzufriedenInhalt = false;
                        habeBloedsinnEingegeben = false;
                    }
                    case "nein" -> {
                        unzufriedenInhalt = true;
                        habeBloedsinnEingegeben = false;
                    }
                    default -> {
                        System.out.println("Bitte geben Sie ja oder nein ein");
                        unzufriedenInhalt = true;
                        habeBloedsinnEingegeben = true;
                    }
                }
            }

            System.out.println("Der ENTWURF ist: ");

            String schoeneUeberschrift = "~~~~~~~~~~~~~~ " + ueberschrift + " ~~~~~~~~~~~~~~";
            String abschluss = "~".repeat(schoeneUeberschrift.length());
            // ADVANCED! wieso sind hier die Linien nicht gleich lang?
            // Wir haben gesagt zähle die Symbole mit ".length();". Wir haben es "händisch" gezählt z.B. 72. Warum zählt JAVA dann z.B. 104?
            zeitungsArtikel = schoeneUeberschrift + "\n" + zeitungsInhalt + "\n" + abschluss;

            System.out.println(zeitungsArtikel);

            habeBloedsinnEingegeben = true;

            // Code um zu Steuern ob wir Ueberschrift, Inhalt oder beides neu haben wollen
            while (habeBloedsinnEingegeben) {
                System.out.println("Gib an ob Sie mit der Ueberschrift, dem Inhalt oder dem gesamten Artikel zufrieden sind [Ueberschrift, Inhalt, Artikel]");
                String ablaufSteuerung = scanner.nextLine().toLowerCase();

                switch (ablaufSteuerung) {
                    case "ueberschrift" -> {
                        mitUeberschriftZufriedenEndeDesProgrammes = true;
                        mitInhaltZufriedenEndeDesProgrammes = false;
                        habeBloedsinnEingegeben = false;
                    }
                    case "inhalt" -> {
                        mitUeberschriftZufriedenEndeDesProgrammes = false;
                        mitInhaltZufriedenEndeDesProgrammes = true;
                        habeBloedsinnEingegeben = false;
                    }
                    case "artikel" -> {
                        mitUeberschriftZufriedenEndeDesProgrammes = true;
                        mitInhaltZufriedenEndeDesProgrammes = true;
                        habeBloedsinnEingegeben = false;
                    }
                    default -> {
                        System.out.println("Bitte geben Sie Ueberschrift, Inhalt oder artikel ein");
                        habeBloedsinnEingegeben = true;
                    }
                }

                mitArtikelZufriedenEndeDesProgrammes = mitInhaltZufriedenEndeDesProgrammes && mitUeberschriftZufriedenEndeDesProgrammes;
            }
        }

        System.out.println("DER ARTIKEL WURDE VERÖFFENTLICHT:");
        System.out.println(zeitungsArtikel);

    }
}
