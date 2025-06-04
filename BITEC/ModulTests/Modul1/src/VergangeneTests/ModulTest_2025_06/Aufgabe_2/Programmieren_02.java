package VergangeneTests.ModulTest_2025_06.Aufgabe_2;

import java.util.Random;
import java.util.Scanner;

public class Programmieren_02 {
    public static void main(String[] args) {
        // Variablen Anlegen
        Random random = new Random();
        Scanner scanner = new Scanner(System.in);
        boolean playAgain = true;

        // Beginne mit Logik (Kontrollstrukturen)
        // spiele nochmals
        while (playAgain) {
            int zahlZuRaten = random.nextInt(0, 101);
            int leben = 5 - 1;
            int versuche = 0;

            System.out.println("Eine Zahl zwischen 0 und 100 wurde gewählt. Rate die Zahl!");

            // Beginne mit Logik (Kontrollstrukturen)
            // Wiederholung der Spiellogik
            while (true) {
                // Wie darf der User seinen Versuch eingeben?
                boolean erwartetZahl = random.nextBoolean();

                int guess;

                // Userinput

                // NEU:
                // wenn eine Zahl erwartet wird!
                if (erwartetZahl) {

                    //alter Code
                    System.out.print("Gib eine Zahl ein [0-100]: ");

                    // guards für falschen Userinput
                    while (!scanner.hasNextInt()) {
                        System.out.print("Falscher userinput, bitte neu eingeben: ");
                        scanner.next();
                    }

                    guess = scanner.nextInt();

                // NEU:
                // wenn eine Zahl ausgeschrieben erwartet wird!
                } else {
                    System.out.print("Gib eine Zahl als WORT mit Bindestrichen ein [null bis ein-hundert] z.B. ein-und-sechzig: ");

                    String nichtKombinierbar = "null|eins|zehn|elf|zwölf";
                    String ersterTeilDreizehnBisNeunZehn = "drei|vier|fünf|acht|neun";
                    String zweiterTeilDreihzehnBisNeunzehn = "sech|sieb";
                    String dreizehnBisNeunzehn = ersterTeilDreizehnBisNeunZehn + "|" + zweiterTeilDreihzehnBisNeunzehn;
                    String basis = "ein|zwei|" + ersterTeilDreizehnBisNeunZehn + "|sechs|sieben";
                    String dreizehnBisNeunZehn = "(" + dreizehnBisNeunzehn + ")-zehn";
                    String zehnerStellen = "zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig";
                    String kombinierterRest = "(" + basis + ")-und-(" + zehnerStellen + ")";
                    String hundert = "ein-hundert";

                    String pattern = "^" +
                            nichtKombinierbar + "|" +
                            basis +
                            "|(" + dreizehnBisNeunZehn + ")|" +
                            zehnerStellen +
                            "|(" + kombinierterRest + ")|" +
                            hundert + "$";

                    // passen hasNextInt auf hasNext(pattern) an
                    while (!scanner.hasNext(pattern)) {
                        System.out.print("Falscher userinput, bitte neu eingeben: ");
                        scanner.next();
                    }

                    // hier kommt nun ein String zurück.
                    String zahlAlsString = scanner.next();

                    // wir sind pragmatisch. wir lösen es mit einem Switch.
                    guess = switch (zahlAlsString) {
                        case "null" -> 0;
                        case "eins" -> 1;
                        case "zwei" -> 2;
                        case "drei" -> 3;
                        case "vier" -> 4;
                        case "fünf" -> 5;
                        case "sechs" -> 6;
                        case "sieben" -> 7;
                        case "acht" -> 8;
                        case "neun" -> 9;
                        case "zehn" -> 10;
                        case "elf" -> 11;
                        case "zwölf" -> 12;
                        case "drei-zehn" -> 13;
                        case "vier-zehn" -> 14;
                        case "fünf-zehn" -> 15;
                        case "sech-zehn" -> 16;
                        case "sieb-zehn" -> 17;
                        case "acht-zehn" -> 18;
                        case "neun-zehn" -> 19;
                        case "zwanzig" -> 20;
                        case "ein-und-zwanzig" -> 21;
                        case "zwei-und-zwanzig" -> 22;
                        case "drei-und-zwanzig" -> 23;
                        case "vier-und-zwanzig" -> 24;
                        case "fünf-und-zwanzig" -> 25;
                        case "sechs-und-zwanzig" -> 26;
                        case "sieben-und-zwanzig" -> 27;
                        case "acht-und-zwanzig" -> 28;
                        case "neun-und-zwanzig" -> 29;
                        case "dreißig" -> 30;
                        case "ein-und-dreißig" -> 31;
                        case "zwei-und-dreißig" -> 32;
                        case "drei-und-dreißig" -> 33;
                        case "vier-und-dreißig" -> 34;
                        case "fünf-und-dreißig" -> 35;
                        case "sechs-und-dreißig" -> 36;
                        case "sieben-und-dreißig" -> 37;
                        case "acht-und-dreißig" -> 38;
                        case "neun-und-dreißig" -> 39;
                        case "vierzig" -> 40;
                        case "ein-und-vierzig" -> 41;
                        case "zwei-und-vierzig" -> 42;
                        case "drei-und-vierzig" -> 43;
                        case "vier-und-vierzig" -> 44;
                        case "fünf-und-vierzig" -> 45;
                        case "sechs-und-vierzig" -> 46;
                        case "sieben-und-vierzig" -> 47;
                        case "acht-und-vierzig" -> 48;
                        case "neun-und-vierzig" -> 49;
                        case "fünfzig" -> 50;
                        case "ein-und-fünfzig" -> 51;
                        case "zwei-und-fünfzig" -> 52;
                        case "drei-und-fünfzig" -> 53;
                        case "vier-und-fünfzig" -> 54;
                        case "fünf-und-fünfzig" -> 55;
                        case "sechs-und-fünfzig" -> 56;
                        case "sieben-und-fünfzig" -> 57;
                        case "acht-und-fünfzig" -> 58;
                        case "neun-und-fünfzig" -> 59;
                        case "sechzig" -> 60;
                        case "ein-und-sechzig" -> 61;
                        case "zwei-und-sechzig" -> 62;
                        case "drei-und-sechzig" -> 63;
                        case "vier-und-sechzig" -> 64;
                        case "fünf-und-sechzig" -> 65;
                        case "sechs-und-sechzig" -> 66;
                        case "sieben-und-sechzig" -> 67;
                        case "acht-und-sechzig" -> 68;
                        case "neun-und-sechzig" -> 69;
                        case "siebzig" -> 70;
                        case "ein-und-siebzig" -> 71;
                        case "zwei-und-siebzig" -> 72;
                        case "drei-und-siebzig" -> 73;
                        case "vier-und-siebzig" -> 74;
                        case "fünf-und-siebzig" -> 75;
                        case "sechs-und-siebzig" -> 76;
                        case "sieben-und-siebzig" -> 77;
                        case "acht-und-siebzig" -> 78;
                        case "neun-und-siebzig" -> 79;
                        case "achtzig" -> 80;
                        case "ein-und-achtzig" -> 81;
                        case "zwei-und-achtzig" -> 82;
                        case "drei-und-achtzig" -> 83;
                        case "vier-und-achtzig" -> 84;
                        case "fünf-und-achtzig" -> 85;
                        case "sechs-und-achtzig" -> 86;
                        case "sieben-und-achtzig" -> 87;
                        case "acht-und-achtzig" -> 88;
                        case "neun-und-achtzig" -> 89;
                        case "neunzig" -> 90;
                        case "ein-und-neunzig" -> 91;
                        case "zwei-und-neunzig" -> 92;
                        case "drei-und-neunzig" -> 93;
                        case "vier-und-neunzig" -> 94;
                        case "fünf-und-neunzig" -> 95;
                        case "sechs-und-neunzig" -> 96;
                        case "sieben-und-neunzig" -> 97;
                        case "acht-und-neunzig" -> 98;
                        case "neun-und-neunzig" -> 99;
                        case "ein-hundert" -> 100;
                        default -> {
                            System.out.println("darf nicht vorkommen, da RegEx uns schon beschützt.");
                            yield -1;
                        }
                    };
                }

                // Hier ist der Code wieder "normal" wie in der Vorlage.
                // Spiellogik: habe ich genug leben?
                if (leben == 0) {
                    System.out.println("Du hast keine Leben mehr. Die Zahl war " + zahlZuRaten + ".");
                    break;
                }

                leben--;
                versuche++;

                // Spiellogik: wo bin ich mit meinem guess?
                if (guess > zahlZuRaten) {
                    System.out.println("Die Zahl ist kleiner. Du hast noch " + (leben + 1) + " Leben.");

                } else if (guess < zahlZuRaten) {
                    System.out.println("Die Zahl ist größer. Du hast noch " + (leben + 1) + " Leben.");

                } else if (guess == zahlZuRaten) {
                    System.out.println("gewonnen. Die Zahl war " + zahlZuRaten + ". Es wurden " + versuche + " benötigt.");
                    break;
                }
            }

            // Logik um Spiel neu starten zu können
            System.out.print("Möchtest du nochmals spielen? [+/-]: ");
            playAgain = scanner.next().equals("+");
        }

        System.out.println("Spiel beendet. Danke fürs Spielen!");
        scanner.close();
    }
}
