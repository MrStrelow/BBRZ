import java.util.Scanner;

public class L10StringManipulation {

    public static void main(String[] args) {

        // Da wir nun alle 4 Grundkonzepte kennengelernt haben, können wir diese auf Probleme anwenden welche sich mit
        // der Manipulation von Strings beschäftigt.
        // Diese umfassen:
        // - TODO:
        // - Erkennen eines Palindrom (hannah, anna, nennen, lagertonnennotregal, ...)
        // - Abwechselnd Buchstaben eines Strings groß und klein machen.
        // - TODO:
        // - Kompression eines Textes:
        //      "Dieser Text wird aber länger :("
        //      ->
        //      "D:[0], i:[1,13], e:[2,4,8,19,26], s:[3], r:[5,14,10,20,27], ' ':[6,11,16,21,28], T:[7], x:[9], t:[10], w:[12], d:[15], a:[17], b:[18], l:[22], ä:[23], n:[24], g:[25]"
        // - Erkennen eines Anagrams ("rätseln" = "lästern"; "Tom Marvolo Riddle" = "Lord Voldemort")
        // - Muster erkennen, wie Mailadressen (mit regular expressions)

        // Beginnen wir jedoch zuerst mit ein paar grundsätzlichen Methoden welche uns die Arbeit mit Strings erleichtern.
        // Diese sind:

        // 1) Einfache Mustervergleiche (z.B: Text "nn" kommt im Text "Anna" vor, aber "ed", nicht:
        // Input: String -> Output: Boolean
        // - <meinText>.startsWith(<diesemText>);
        // - <meinText>.endsWith(<diesemText>);
        // - <meinText>.contains(<diesenText>);
        String input = "Dies ist ein Satz welcher ueberprueft wird.";
        boolean kommtAmAnfangVor = input.startsWith("Dies ist ein Satz"); // true
        boolean kommtAmEndeVor = input.endsWith(" wird."); // true
        boolean kommtIrgendwoVor = input.contains("Satz welcher"); // true

        System.out.println("1: " + kommtAmAnfangVor + " - 2: " + kommtAmEndeVor + " - 3: " + kommtIrgendwoVor);

        // 2) Buchstaben/Teiltexte herauslesen:
        // Input: Int -> Output: String/Char
        // - <meinText>.substring(<von_position>,<bis_position>);
        // - <meinText>.chatAt(<position>);
        String mySubString = input.substring(0,2);
        Character mySubChar = input.charAt(3);

        System.out.println( "substring: " + mySubString + " charAt: " + mySubChar);

        // 3) Position eines Textes bestimmen:
        // Input: String -> Output: Int
        // - <meinText>.indexOf(<diesemText>);
        Integer indexDesErstenBuchstabensW = input.indexOf("Wo");
        Integer indexDesErstenBuchstabensS = input.indexOf("Sa");

        System.out.println("'Wo' beginnt an Position: " + indexDesErstenBuchstabensW);
        System.out.println("'Sa' beginnt an Position: " + indexDesErstenBuchstabensS + " (oh, es kommt nicht vor)");

        // 4) Teile eines Textes mit anderem Text ersetzen/Text in anderem Text einfügen:
        String meinErsetzterText = input.replace("i", "XXXX");
        System.out.println("Der orginale Text: " + input + " wurde mit " + meinErsetzterText + " ersetzt.");

        // Wir haben hier aufgrund von einer Eigenschaft des String ein Problem. Diesen könnne wir nicht verändern.
        // StringBuilder erlaubt es uns aber. Deshalb versuchen wir Folgendes.
        StringBuilder meinEingefügterText = new StringBuilder(input);
        meinEingefügterText.insert(10, "NEU");
        meinEingefügterText.delete(7, 9); // wie replace("") aber wir gebn hier die indices an, nicht ein Textmuster.
        meinEingefügterText.deleteCharAt(0);
        meinEingefügterText.replace(15,18,"BUILD"); // die Buchstaben an Position 15, 16 und 17 werden entfernt und danach mit "BUILD" aufgefüllt.
        meinEingefügterText.setCharAt(1, 'ø');
        System.out.println("Der orginale Text: " + input + " wurde manipuliert: " + meinEingefügterText + "." );

        // Hintergrund: Wenn Variablen "immutable" sind, bedeutet es, dass diese nicht geändert werden können.
        // Wenn eine Änderung vollzogen wird, wird ein neuer String angelegt.
        // Dies kann unter umständen zu Problemen mit der Performance führen.
        // Ein StringBuilder ist ein "Builder Pattern", welches den Text manipuliert und am Schluss (mit .toString()); zu
        // einem String zusammenbaut. Achtung! Es ist aber nicht nützlich immer StringBuilder zu verwenden.
        // Die Lesbarkeit des Codes ist auch wichtig, denn das Verwenden des StringBuilders macht den Code ein wenig schwerer lesbar.
        // Das ist natürlich ein wenig übertrieben, aber das Prinzip ist nützlich! Vorläufiges optimieren, ist zu vermeiden!
        // Zuerst "sauberen" Code schreiben, danach optimieren.

        // ############# Übungen zur String manipulation #############

        // Hier zusammenfassend was diese Methoden tun:
        // Es gibt zahlreiche Manipulationen aber, wichtig hier ein paar wichtige,
        //      - "gib mir die Position/Index eines Sub-Strings"                                -> indexOf
        //      - "beginnt/endet/beinhaltet mein String einen anderen Sub-String?"              -> startsWith, endsWith, contains
        //      - "gib mir einen Sub-String, welcher von Position x bis y geht"                 -> substring
        //      - "ersetze mir auf alle Vorkommnisse von z.B. asdf in meinem String druch qwer. -> replace
        //      - "gib mir den character auf position x"                                        -> charAt


//        Übung 1: Basics
//        Lies einen Text als Userinput ein und.
//         - a) wandle ihn in Großbuchstaben um,
//         - b) dreh die Reihenfolge der Buchstaben um (suche dazu eine Methode der Klasse StringBuilder),
//         - c) dreh die Reihenfolge der Buchstaben um (schreibe es selbst mithilfe von Schleifen und Verzweigungen),
//         - d) und überprüfe, ob es sich um ein Palindrom handelt.

        Scanner scanner = new Scanner(System.in);
        System.out.print("Palindrom - Gib einen Text ein: ");
        input = scanner.nextLine();

        // a) Großbuchstaben
        String upperCaseStr = input.toUpperCase();
        System.out.println("Uppercase: " + upperCaseStr);

        // b) den String umdrehen (Methode suchen)
        String reversedStr = new StringBuilder(input).reverse().toString();
        System.out.println("Umgedreht: " + reversedStr);

        // c) den String umdrehen (selbst)
        reversedStr = "";

        for (int i = input.length()-1; i >= 0; i--) {
            reversedStr += input.charAt(i);
        }

        System.out.println("Umgedreht: " + reversedStr);

        // d) Ist es ein Palindrom?
        // Das bedeutet, dass das Wort von vorne und von hinten gelesen den gleichen Text ergibt.
        // Wir müssen also:
        // - (um ganz genau zu sein, alle Leerzeichen entfernen und alles in Kleinbuchstaben umwandeln)
        // - das Wort umdrehen
        // - vergleichen, ob es mit dem nicht umgedrehten übereinstimmt.
        // Wenn ja, dann ist es ein Palindrom, ansonsten nicht.
        String cleanInput = input.replace(" ", "").toLowerCase();
        String verdrehterInput = new StringBuilder(cleanInput).reverse().toString();

        boolean isPalindrome = verdrehterInput.equals(cleanInput);
        System.out.println("Ist es ein Palindrom? - " + (isPalindrome ? "Ja" : "Nein") + "!");

//        Übung 2: Zeichen zählen
//        a) Bestimme die Anzahl eines bestimmten Zeichens in einem String.
//        b) Bestimme die Anzahl aller Zeichens in einem String.

        // a)
        System.out.println("Zeichenketten zählen:");
        System.out.print("Gib einen Character ein welcher im Text gezählt werden soll: ");
        Character charToCount = scanner.nextLine().charAt(0);

        System.out.print("Gib einen Text ein, welcher als Basis dient: ");
        input = scanner.nextLine();

        Integer count = 0;

        for (int i = 0; i < input.length(); i++) {
            if (input.charAt(i) == charToCount) {
                count++;
            }
        }

        System.out.println("Das Symbol: " + charToCount + " kommt " + count + " mal im Text '" + input + "' vor.");

        // b)
        count = 0;
        System.out.println("Alle Characters werden gezählt: ");
        System.out.println("Im Text: '" + input + "' kommt...");

        for (int i = 0; i < input.length(); i++) {
            count = 0;

            charToCount = input.charAt(i);

            for (int j = 0; j < input.length(); j++) {
                if (input.charAt(j) == charToCount) {
                    count++;
                }
            }

            System.out.println("\tdas Symbol: " + charToCount + " kommt " + count + " vor.");
        }

        // Zusatz! Versuche nur die Character auszugeben, welche nicht schon einmal vorgekommen sind (unique).
        // Wir haben noch keine Arrays durchgemacht, deshalb verwende eine Variable mit Strings welche bereits vorgekommene
        // Characters mitschreibt.
        count = 0;
        String memory = "";
        System.out.println("Im Text: '" + input + "' kommt...");

        for (int i = 0; i < input.length(); i++) {
            count = 0;
            charToCount = input.charAt(i);

            if (!memory.contains(charToCount.toString())) {
                memory += charToCount;

                for (int j = 0; j < input.length(); j++) {
                    if (input.charAt(j) == charToCount) {
                        count++;
                    }
                }

                System.out.println("\tdas Symbol: " + charToCount + " kommt " + count + " vor.");
            }
        }


//        Übung 3: Wörter zählen
//        Schreiben Sie ein Java-Programm, das die Anzahl der Wörter in einer gegebenen Zeichenkette zählt.
//        Versuchen Sie ein sinnvolles User-Input handling zu schreiben, welches:
//         - keinen Leeren String und
//         - keinen String ohne Leerzeichen akzeptiert.
        System.out.print("Gib einen Text ein, von diesem die Wörter gezählt werden sollen: ");
        do {
            input = scanner.nextLine();

            // Das sind Guard Clauses!
            if (input.isEmpty()) {
                System.out.print("Bitte geben Sie einen nicht leeren String ein: ");
                continue;
            }

            if (!input.contains(" ")) {
                System.out.print ("Bitte geben Sie einen String ein, welcher Leerzeichen besitzt: ");
                continue;
            }

            // Wir kommen nur hier her, wenn alle Bedingungen erfüllt sind!
            // Somit können wir hier die Schleife verlassen.
            // hier ist eine Anwendung von "continue" und "break" angenehmer als eine Bedingung in der while loop.
            // Das hat den Grund, da wir ansonsten mehrere Bedingungen in while und if angeben müssen.
            // Solange wir nicht verschachtelte Konstrukte haben ist continue und break anwendbar.
            break;

        } while (true);

        // Wir bemerken, dass unsere "Kernlogik" sehr kurz ist, und die "Guards" davor lange sind.
        // Da dies meist der Fall ist, werden wir in Zukunft Werkzeuge kennenlernen um diese voneinander so gut wie möglich zu trennen.
        Integer anzahlWoerter = input.split(" ").length;

        System.out.println( "Der Text '" + input + "' hat " + anzahlWoerter + " Wörter.");

//        Übung 4: Text abwechselnd groß- und kleinschreiben.
//         a) Beginne die Ausgabe mit Großbuchstaben und lass alle anderen Buchstaben im Text unverändert.
//         b) Beginne die Ausgabe mit Großbuchstaben und schreibe jeden anderen Buchstaben als Kleinbuchstaben
//         c) wie b), nur lösche ALLE Characters (z.B. ø oder ß) welche keine Groß- bzw. Kleinbuchstaben haben zuvor aus dem User-Input.

        // a)
        System.out.print("Text abwechselnd groß schreiben - gib einen Text ein: ");
        input = scanner.nextLine();
        Character charToAdd;
        String result = "";

        for (int i = 0; i < input.length(); i++) {
            charToAdd = input.charAt(i);

            if (i % 2 == 0) {
                // Wenn wir oft hintereinander Methoden aufrufen kann dies schnell unleserlicher Code werden.
                // Daumenregel: Versuche immer logisch zusammenhängende Ketten zu bilden.
                // Das bedeutet Folgendes. Wir wollen wir den char zu einem Großbuchstaben machen.
                // Der Aufruf von toString() und charAt(0) ist für Umwandlungen gedacht.
                // Achtung! Zwischen diesen Aufrufen kann immer ein Fehler auftreten.
                // z.B. ist hier versteckt, dass Buchstaben gar nicht toUpperCase sein können!
                // Die Methode toUpperCase gibt keinen Fehler aus, sondern gibt den entsprechenden Character zurück.
                // Beachte jedenfalls, dass Ausdrücke welche in eine Zeile geschrieben werden max. 80 Characters haben.
                charToAdd = charToAdd.toString().toUpperCase().charAt(0);
            }

            result += charToAdd;

        }

        System.out.println("Jeder 2. Buchstabe ist groß und alle anderen sind unverändert: " + result);

        // b)
        System.out.print("Text abwechselnd groß- und kleinschreiben - gib einen Text ein: ");
        result = "";

        for (int i = 0; i < input.length(); i++) {
            charToAdd = input.charAt(i);

            // TODO: hier scheint der Aufruf .toString() sowie .charAt(0) zu stören. Können wir das ändern?
            //  auch haben wir hier eine Verzweigung mit Zuweisung.
            //  Wenn hier der Code kürzer/übersichtlicher wäre, könnten wir den Ternären Operator verwenden.
            if (i % 2 == 0) {
                charToAdd = charToAdd.toString().toUpperCase().charAt(0);
            } else {
                charToAdd = charToAdd.toString().toLowerCase().charAt(0);
            }

            result += charToAdd;

        }

        System.out.println("Jeder 2. Buchstabe ist groß und jeder 2. klein: " + result);

        // c)
        System.out.print("Text abwechselnd groß- und kleinschreiben mit User-input handling - gib einen Text ein: ");

        result = "";
        String whitelistLetters = "abcdefghijklmopqrstuvwxyz";
        String whitelist = whitelistLetters + whitelistLetters.toUpperCase();

        for (int i = 0; i < input.length(); i++) {
            String stringToAdd = Character.toString(input.charAt(i));

            if (whitelist.contains(stringToAdd)) {
                // Achtung! sobald es komplizierter als das wird, normale IF-ELSE blöcke verwenden.
                // Besonders ist ein Ternärer Operator, wenn er geschachtelt wird, meist "Bad Coding".
                stringToAdd = i % 2 == 0 ? stringToAdd.toUpperCase() : stringToAdd.toLowerCase();
                result += stringToAdd;
            }
        }

        System.out.println(result);

//        Übung 5: Zeichenketten-Komprimierung
//        Schreiben Sie ein Java-Programm, das eine einfache Zeichenketten-Komprimierung implementiert. Verwenden Sie die Run-Length-Encoding-Methode, um die Zeichenkette zu komprimieren und dekomprimieren. Verwenden Sie Methoden, die jeweils eine Zeichenkette als Parameter akzeptieren und die komprimierte oder dekomprimierte Zeichenkette zurückgeben.

//        Übung 6: Anagramm Erkennung.

//        Übung 7: formattierungen
        int anzahlSonderzeichen = 0;

        // 1. String anlegen für ausgabe.
        // 2. ausgabe kopieren und in string einfügen
        // 3.) leerzeichen hinzufügen zum string wenn i<9+anzahlSonderzeichen (StringBuilder Objekte haben die Methode insert(index, " ")

        System.out.println("input stuff: ");
        input = scanner.nextLine();

        for (int i = 0; i < input.length(); i++) {
            StringBuilder ausgabe =
                    new StringBuilder(
                            "Der " + (i-anzahlSonderzeichen+1) + ". Buchstabe im String: " + input + " ist " + input.charAt(i)
                    );

            if (input.charAt(i) != ' ' && input.charAt(i) != ',') {
                if (i < 9+anzahlSonderzeichen) {
                    System.out.println(ausgabe.insert(4," "));
                } else {
                    System.out.println(ausgabe);
                }
            } else {
                anzahlSonderzeichen ++;
            }
        }

        // TODO: printf, format usw.
        // TODO: regex!


        // Sehr von Vorteil ist die Verwendung von sogenannten REGEX! Regular Expressions! Diese scheinen jedoch
        // am Anfang komplex zu sein, aber der Vorteil ist, sie sind unabhängig von JAVA zu verwenden. Also
        // Also sie funktionieren im Prinzip gleich überall anders - ist wie eine eigene Sprache! (Siehe Links im Kurs Block 3)
    }

}
