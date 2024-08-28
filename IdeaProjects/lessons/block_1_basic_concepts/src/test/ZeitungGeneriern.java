package test;

import java.util.Random;
import java.util.Scanner;

public class ZeitungGeneriern {

    /*
        Wenn (ANMERKUNG) neben einer Zeile steht, dann ist hier eine Kleinigkeit, welche praktisch sein kann,
        aber fuers prinzipielle Verstaendnis nicht unbedingt notwendig ist, gemeint.

        Wenn (MERKE) neben einer Zeile steht, dann gibt es hier eine Kleinigkeit, welche praktisch ist und sehr wohl zum Verständnis beiträgt.
    */

    public static void main(String[] args) {

        // Pools von Wörtern je Wortgruppe (Nomen und Verben)
        String[] nomen = {"Dog", "Tree", "Cat", "Fish", "Orange", "Gauda Cheese", "Scarf", "Laptop", "JAVA", "Mouse", "BBRZ", "Christmas"};
        String[] verb = {"empowers", "adores", "carries", "heats", "froze", "ate", "blames", "injures"};
        String[] adjektiv = {"yellow", "big", "small", "cheeky", "dark", "bright", "dim", "sad"};
        String[] sensationen = {"unglaubliche", "spektakulaere", "unfassbare", "oage"};

        // Zufall
        Random random = new Random();

        // userinput
        Scanner scanner = new Scanner(System.in);

        Boolean unzufriedenPhrase = true;
        Boolean unzufriedenArtikel = true;

        // zusätzlicher userinput. wie viele woerter moechte ich.
        Integer anzahlWoerter;
        String phrase = "";
        String artikel = "";

        Boolean mainLoop = true;
        Boolean setzePhraseZurueck = false;

        while(mainLoop) {

            // schleife
            while (setzePhraseZurueck || unzufriedenPhrase) {
                setzePhraseZurueck = false;

                Integer indexErstesNomen = random.nextInt(0, nomen.length);
                Integer indexVerb = random.nextInt(0, verb.length);
                Integer indexZweitesNomen = random.nextInt(0, nomen.length);
                Integer indexErstesAdjektiv = random.nextInt(0, adjektiv.length);
                Integer indexZweitesAdjektiv = random.nextInt(0, adjektiv.length);

                System.out.println("Wie lange soll das generierte Wort sein?");
                anzahlWoerter = Integer.parseInt(scanner.nextLine());

                phrase = switch (anzahlWoerter) {
                    case 3 -> nomen[indexErstesNomen] + " " + verb[indexVerb] + " " + nomen[indexZweitesNomen];
                    case 4 -> {
                        String ersteWahl = adjektiv[indexErstesAdjektiv] + " " + nomen[indexErstesNomen] + " " + verb[indexVerb] + " " + nomen[indexZweitesNomen];
                        String zweiteWahl = nomen[indexErstesNomen] + " " + verb[indexVerb] + " " + adjektiv[indexErstesAdjektiv] + " " + nomen[indexZweitesNomen];

                        String[] moeglichkeiten = {ersteWahl, zweiteWahl};

                        // zufällig wählen wo das adjektiv steht
                        yield moeglichkeiten[random.nextInt(0, moeglichkeiten.length)];
                    }
                    case 5 -> {
                        String ersteWahl = adjektiv[indexErstesAdjektiv] + " " + adjektiv[indexZweitesAdjektiv] + " " + nomen[indexErstesNomen] + " " + verb[indexVerb] + " " + nomen[indexErstesNomen];
                        String zweiteWahl = adjektiv[indexErstesAdjektiv] + " " + nomen[indexErstesNomen] + " " + verb[indexVerb] + " " + adjektiv[indexZweitesAdjektiv] + " " + nomen[indexErstesNomen];
                        String dritteWahl = nomen[indexErstesNomen] + " " + verb[indexVerb] + " " + adjektiv[indexErstesAdjektiv] + " " + adjektiv[indexZweitesAdjektiv] + " " + nomen[indexErstesNomen];

                        String[] moeglichkeiten = {ersteWahl, zweiteWahl, dritteWahl};

                        yield moeglichkeiten[random.nextInt(0, moeglichkeiten.length)];
                    }
                    default -> {
                        // brauchen die klammern nicht. default -> ":(" würde auch reichen.
                        yield ":(";
                    }
                };

                System.out.println(phrase);

                // userinput
                System.out.println("mehr?");
                String meinung = scanner.nextLine();

                //entscheidung user
                unzufriedenPhrase = switch (meinung.toLowerCase()) {
                    // wenn user ja sagt dann sollen wir weiter machen
                    case "ja" -> true;
                    // wenn user nein sagt dann sollen wir aufhören
                    case "nein" -> false;
                    default -> true;
                };
            }

            while (!setzePhraseZurueck && unzufriedenArtikel) {
                //neuer input
                System.out.println("Schreiben Sie nun den Artikel selbst :) ");
                artikel = scanner.nextLine();

                setzePhraseZurueck = switch (artikel) {
                    case "!!BEFEHL – neue Überschrift" -> {
                        System.out.println("starte komplett neu!");
                        yield true;
                    }
                    default -> {
                        int erstesLeerzeichen = artikel.indexOf(" ");
                        int indexSensation = random.nextInt(0, sensationen.length - 1);

                        String ersterTeil = artikel.substring(0, erstesLeerzeichen);
                        String sensationenTeil = sensationen[indexSensation];
                        String zweiterTeil = artikel.substring(erstesLeerzeichen + 1);

                        Boolean CAPS = random.nextBoolean();

                        if (CAPS) {
                            sensationenTeil = sensationenTeil.toUpperCase();
                        }

                        artikel = ersterTeil + " " + sensationenTeil + " " + zweiterTeil;

                        System.out.println("################# vorläufige Version ##################");
                        System.out.println("Überschrift: " + phrase);
                        System.out.println("SENSATIOELLER Artikel: " + artikel);
                        System.out.println("#######################################################");

                        // userinput
                        System.out.println("Sind Sie unzufrieden mit dem Artikel?");
                        String meinung = scanner.nextLine();

                        //entscheidung user
                        unzufriedenArtikel = switch (meinung.toLowerCase()) {
                            // wenn user ja sagt dann sollen wir weiter machen
                            case "ja" -> true;
                            // wenn user nein sagt dann sollen wir aufhören
                            case "nein" -> {
                                mainLoop = false;
                                yield false;
                            }
                            default -> true;
                        };

                        yield false;
                    }
                };
            }

        }

        System.out.println("################# finale Version ##################");
        System.out.println("Überschrift: " + phrase);
        System.out.println("Artikel: " + artikel);
        System.out.println("###################################################");
    }
}
