import java.util.Scanner;

public class L06VerzweigungenIf {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer first = 5;
        Integer second = 37;
        Integer third = 58;

        Integer x = Integer.parseInt(scanner.nextLine());
        System.out.print("Gib eine ganze Zahl (Integer) ein: ");

        // Wir betrachten nun das 3. große Konzept, die Verzweigungen (Variablen, Operatoren, Verzweigungen, Schleifen).
        // Wir werden dazu 2 verschiedene Arten betrachten eine Verzweigung zu schreiben.
        // Diese sind die:
        // - if/if-else/else-if (und wir erwähnen den ternärer Operator)
        // - switch

        // Kurz ein paar Worte zur Theorie. Das Konzept "Verzweigung" ist semantisches Konzept. Ein solches spiegelt
        // die Bedeutung unseres Vorhabens wider. Dieses Vorhaben ist eben dem Programm zu sagen
        // "führe einen Teil des Programmes aus, aber nur wenn ein gewisser Zustand bereits eingetreten ist".
        // Wir müssen nun die Bedeutung (die Semantik), die wir im Kopf haben, in unserer Programmiersprache formulieren.
        // Diese Formulierung ist dann nicht mehr ein semantisches Konzept, sondern ein syntaktisches.
        // Wir schreiben dann

        if (x == 5) {
            System.out.println("mal schauen ob es ausgeführt wird.");
        }

        // Semantik ist also die Bedeutung unseres Vorhabens und die Syntax die Art wie wir es in unserer
        // Programmiersprache formulieren. Wenn wir es in einer anderen Sprache formulieren wollen, ist die Syntax eine andere.
        // Die Bedeutung des Programmes ist aber die gleiche und unabhängig von der Sprache.
        // Wir können nun mit Logik unser Programm mathematisch analysieren, ob es das tut, was es soll.
        // Diese Analyse ist dann auf der semantischen Ebene.
        // Dies wird benötigt um Autopiloten von Flugzeugen, Software für Atomkraftwerke, NASA, usw. zu schreiben.
        // Theorie ende.

        // Wir betrachten nun wie wir in JAVA Verzweigungen formulieren können.
        // Wir haben dazu die genannten 2 Möglichkeiten.
        // - if/if-else/else-if und switch.

        // ############################## IF/IF-ELSE/ELSE-IF ##############################
        // ##### IF #####
        // Wir brauchen für die if-Verzweigung folgendes.
        // 1) Eine boolesche Aussage, welche steuert, ob wir in die Verzweigung "reingehen" oder nicht.
        // 2) Den Befehl (die Syntax) welche notwendig ist um "if" in JAVA schreiben zu können.
        // 3) Den Teil des Programmes, welcher innerhalb der Verzweigung formuliert wird.

        // Ein Beispiel ist der bereits oben geschriebene Programmcode.

        // 1) ist hier x == 5. Das Ergebnis des Vergleichsoperators ist immer ein boolesche Variable. Wir fragen hier ab,
        // ob die Zahl x den Wert 5 hat. Diese wurde vom User zuerst eingegeben.
        // 2) ist hier "if () { }". Wir beginnen mit if, gefolgt von einer runden Klammer welche die boolesche Variable, oder
        // ein sonstiger Ausdruck (Methode, Wert, mit Operatoren verknüpfte Werte) welche einen booleschen Wert ergibt.
        // 3) ist eine Ausgabe des Textes, welche nur ausgeführt wird, wenn die boolesche Variable (auch Bedingung genannt)
        // wahr ist. Wenn der User also 5 eingibt, wird "mal schauen ob es ausgeführt wird." ausgegeben.
        // Wenn nicht, dann wird der Block an Code welcher in den geschwungenen Klammern steht, nicht ausgeführt.
        if (x == 5) {
            System.out.println("mal schauen ob es ausgeführt wird.");
        }

        // Wir modellieren also "WENN X, DANN Y" Aussagen.
        // "WENN die Zahl die er User eingibt gleich 5 ist, DANN gib 'mal schauen ob es ausgeführt wird. aus."

        // Zum Vergleich, wenn wir unterhalb oder über der IF-Verzweigung code schreiben wird dieser immer ausgeführt.

        // ##### IF-ELSE #####
        // Wenn wir aber nicht nur "WENN X, DANN Y" Aussagen tätigen wollen, sondern "WENN X, DANN Y, ANSONSTEN Z"
        // dann brauchen wir ein zusätzliches Sprachkonstrukt.
        // Dieses nennen wir "else" und ist Teil der IF-Verzweigung.
        // Wir formulieren also:
        // "WENN die Zahl die er User eingibt gleich 5 ist,
        //  DANN gib 'mal schauen ob es ausgeführt wird. aus.
        //  ANSONSTEN gib ':(' aus und verdopple x"
        if (x == 5) {

            System.out.println("mal schauen ob es ausgeführt wird.");

        } else {

            System.out.println(":(");
            x *= 2;

        }

        // Wir sehen nun, warum dieses Konstrukt "Abzweigung" genannt wird.
        // Wir zweigen ab, ob wir den Programmcode unter dem IF oder unter dem ELSE ausführen wollen.
        // Eine Verzweigung kann als "Baum" dargestellt werden. Jede Verzweigung ist eine Gabelung eines Astes. Der erste Ast
        // ist der Stamm und wir können nur den Baum hinaufgehen bis wir am Ende sind. Nur entlang dieses Astes wird unser
        // Code ausgeführt. Der Code auf andern Ästen wird nicht ausgeführt.
        // Der Baum den obigen Code sieht so aus:
        // || ist der Rumpf und der start des Programmes.
        // Die Bedingungen werden neben der Gabelung geschrieben, welche zuvor in den runden Klammern des IF's gestanden sind.
        // Wenn keine Verzweigungen mehr vorhanden sind schließen wir den Baum mit einem Blatt () ab.
        // Code kann nun entlang der Äste \/ und in den Blättern ausgeführt werden.

        /*        ()  ()
                   \  /
           x == 5   \/   ELSE
                    ||
         */
        // Hier ist x != 5 der ELSE Zweig. denn x != 5 ist das "Gegenteil" von x == 5. Diese schließen sich also aus.
        // wir können auch x != 5 anstatt ELSE in unserem Baum schreiben.

        // Der Baum eines einzelnen If statements sieht so aus:
        /*
                   ()
                    \
           x == 5    \
                     ||
         */

        // ##### ELSE-IF #####
        // Was aber, wenn wir nicht nur 2 Abzweigungen wollen, sondern 3, oder 4?
        // Die Idee hier ist eine
        // WENN DANN ANSONSTEN WENN DANN ANSONSTEN WENN DANN ...
        // Konkreter:
        // "WENN die Zahl die er User eingibt gleich 5 ist,
        //  DANN gib 'mal schauen ob es ausgeführt wird. aus.
        //  ANSONSTEN
        //      WENN die Zahl die er User eingibt kleiner 5 ist
        //      DANN gib ':)' aus und halbiere x"
        //      ANSONSTEN gib ':(' aus und verdopple x".

        // Dies führt zu einer Verschachtelung der IF-ELSE Anweisungen.
        // Also eine IF Anweisung innerhalb der ELSE (oder auch IF) Anweisung.
        // Wir können dies folgendermaßen schreiben.
        if (x == 5) {

            System.out.println("mal schauen ob es ausgeführt wird.");

        } else {
            if (x < 5) {

                System.out.println(":)");
                x /= 2;

            } else {

                System.out.println(":(");
                x *= 2;

            }
        }
        // Unser Baum sieht nun so aus:
        /*
                      ()  ()
                       \  /
                ()  x<5 \/ ELSE
                 \      /
                  \    / *
                   \  /
             x==5   \/   ELSE
                    ||
         */

        // Wenn wir uns nun vorstellen, dass es 5 Abzweigungen eben soll, dann sehen wir, dass diese Schreibweise uns
        // immer weiter nach rechts abdriften lässt, wenn wir uns an die Standardregeln der Einrückung halten.
        // Das führt uns zur else-if Anweisung. Dies ist auch Teil der IF/IF-ELSE Anweisung und erlaubt uns den obigen
        // Ausdruck einfacher schreiben zu können. Dieser wird jetzt folgendermaßen geschrieben. In anderen Sprachen,
        // wie z.B. Python schreiben wir statt "else if", "elif".
        if (x == 5) {

            System.out.println("mal schauen ob es ausgeführt wird.");

        } else if (x < 5) {

            System.out.println(":)");
            x /= 2;

        } else {

            System.out.println(":(");
            x *= 2;

        }

        // Unser Baum sieht nun so aus:
        /*
              ()    ()      ()
         x==5  \ x<5 | ELSE/
                \    |    /
                 \   |   /
                  \  |  /
                   \ | /
                    \|/
                    | |
         */

        // ACHTUNG! die verschachtelte IF-ELSE Anweisung ist streng genommen allgemeiner als die ELSE-IF Anweisung!
        // In unserem Fall sind aber beide Bäume gleich. Warum?
        // Wir haben gesagt entlang der Äste kann Code ausgeführt werden. Wir sehen also, einen Ast mit * gekennzeichnet.
        // Dieser * ist im IF-ELSE beispiel vorhanden. Entlang dieses Asters könnte nun Code ausgeführt werden.
        // Das ist aber bei uns nicht der Fall. Deshalb führt der Baum mit 3 Abzweigungen (else-if) und jener mit dem
        // 2 geschachtelten (geschachteltes if-else) zum gleichen Programmcode.

        // Was bedeutet nun aber im Code der mit * gekennzeichneten Ast?
        if (x == 5) {

            System.out.println("mal schauen ob es ausgeführt wird.");

        } else {

            if (x < 5) {

                System.out.println(":)");
                x /= 2;

            } else {

                System.out.println(":(");
                x *= 2;

            }
        }

        // Wir sehen also zwischen den geschachtelten IF-ELSE ist nun code welcher nicht in der else-if Variante vorhanden ist.
        // ABER... wir können dies wieder zu einem else-if umschreiben, wenn wir folgendes tun.
        if (x == 5) {

            System.out.println("mal schauen ob es ausgeführt wird.");

        } else if (x < 5) {

            System.out.println("DAS IST DER * AST"); // doppelter CODE!
            System.out.println(":)");
            x /= 2;

        } else {

            System.out.println("DAS IST DER * AST"); // doppelter CODE!
            System.out.println(":(");
            x *= 2;

        }

        // Diese Variante erzeugt nun aber doppelt geschriebenen Code, welcher anfällig für Fehler ist!
        // Stellen wir uns vor wir müssen einen solchen Baum umschreiben und vergessen einen Zweig mit doppeltem Code.

        // Betrachten wir nun eine geschachtelte if-else Anweisung welche nicht als else-if darstellbar ist.
        // Konkreter:
        // "WENN die Zahl die er User eingibt gleich 5 ist,
        //  DANN
        //      WENN die Zahl die er User eingibt kleiner 5 ist
        //      DANN gib ':)' aus und halbiere x"
        //      ANSONSTEN gib ':(' aus und verdopple x".
        //  ANSONSTEN
        //  gib 'mal schauen ob es ausgeführt wird. aus.

        // Wir haben hier also vertauscht was im ELSE Zweig dargestellt wird.
        if (x == 5) {

            if (x < 5) {

                System.out.println(":)");
                x /= 2;

            } else {

                System.out.println(":(");
                x *= 2;

            }

        } else {

            System.out.println("mal schauen ob es ausgeführt wird.");

        }

        // Hier noch unabhängig von den Verzweigungen ein Thema, welches jetzt zum Ersten mal relevant wird.
        // ################## Namespaces ##################
        // Namensräume/Namespaces sind bereiche des Codes in welcher Variablen erkannt werden, und somit mit deren Namen
        // angesprochen werden können.
        // Diese Räume sind in JAVA innerhalb von den geschwungenen Klammern gegeben.
        // Das bedeutet, die Ersten geschwungenen Klammern, welche in einem JAVA Programm sehen, sind jene in der
        // allerersten Zeile bei der Klasse. Diese ignorieren wir zuerst. Danach ist die nächste jene der
        // main methode. Innerhalb dieser sind Variablen, welche dort definiert oder deklariert werden ansprechbar.
        // Die nächsten geschwungenen Klammern sehen wir nun bei der IF-Verzweigung.
        // Variablen welche außerhalb definiert/deklariert werden, also innerhalb der main Methode, können auch in
        // geschachtelten Namensräumen verwendet werden. Bedeutet innerhalb der IF Verzweigung kann auf eine Variable
        // von außerhalb zugegriffen werden.
        if (x == 5) {
            System.out.println("Ich greife auf eine die Variable x, welche nicht in dem Namensraum der IF-Verzweigung definiert wird zu: " + x);
        }

        // Wenn jedoch eine Variable in einem Namensraum der IF Verzweigung definiert/deklariert wird, dann kann auf diese
        // nicht außerhalb zugegriffen werden.
        if (x == 5) {
            String verstecktVorDerMainMethode = "ich bin vor der Main versteckt";

            System.out.println("Wir sehen dich! " + verstecktVorDerMainMethode);
        }

        // Jedoch nicht hier.
        // System.out.println("Wer bist du? " + verstecktVorDerMainMethode); // Fehler!

        // Dieses Konzept ist immer anwendbar, wenn eine geschwungene Klammer gesehen wird,
        // unabhängig vom genauen Sprachkonstrukt. Hier ist es das IF/IF-ELSE/ELSE-IF Konstrukt.

        // ########### Hier nun ein paar Beispiele zum mitlesen zu der IF/IF-ELSE/ELSE-IF Verzweigung ############

        // 1 )
        // --------------------------- NUR if - ich möchte im Programm einmal Abzweigen. -------------------------------
        System.out.println("----- if -----");
        System.out.println("Hallo :)");

        // Versuche folgende Verzweigung in JAVA zu schreiben.
        // Lege dazu eine boolesche Variable an welche "sympatisch" darstellt.
        // Wie diese zustande kommt, ist nicht relevant. Setze diese im einfachsten Fall auf true.
        // Aussage:
        // "Wenn mir die person sympathisch ist, dann rede ich noch einen Satz mit Ihr."
        // Rede einen Satz ist als System.out.println(); darzustellen.

        // Als Erinnering: wenn die if Bedingung wahr ist, dann führe den Code in der geschwungenen Klammer aus.
        Boolean sympathisch = (first == second) && (first < third);

        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
        }

        // Der Code welcher unabhängig von der Verzweigung geschrieben ist, wird immer ausgeführt.
        System.out.println("Tschau :(");

        // Bemerkung: Variablen welche in einer geschwungenen Klammer definiert bzw. deklariert werden, sind nach
        // der geschlossenen geschwungenen Klammer weg. (Variable nur im Block/Namespace gültig)
        if (true) {
            // a = 5 aber a gibt es nur bis "}"
            Integer a = 5;
        }
        // den Ausdruck "Integer a = 5" gibt es nicht mehr, also kann ich es neu definieren!
        Integer a = 4;


        // 2 )
        // --------------------------- if mit else - ich möchte im Programm "zwei-mal gleichzeitig" Abzweigen. -------------------------------
        System.out.println("----- if mit else -----");
        System.out.println("Hallo :)");

        // WENN mir die person SYMPATISCH ist,
        // DANN rede ich noch einen Satz mit Ihr,
        // ANDERNFALLS,
        // sage ich "hupf in gatsch, schleich di".

        // wenn nach if die Bedingung wahr ist -> dann führe den Code in der geschwungenen Klammer aus.

        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
        } else {
            System.out.println("hupf in gatsch, schleich di");
        }

        System.out.println("Tschau :(");

        // 3 )
        // --------------------------- else-if - ich möchte im Programm "öfters gleichzeitig" Abzweigen. -------------------------------
        System.out.println("----- else-if -----");
        System.out.println("Hallo :)");

        // nur WENN mir die person SYMPATHISCH ist,
        // DANN rede viel,
        // ANDERNFALLS, WENN sie VERWANDT ist
        // DANN rede ich noch einen Satz mit Ihr,
        // ANDERNFALLS,
        // sage ich "hupf in gatsch, schleich di".
        // wenn nach if die Bedingung wahr ist -> dann führe den Code in der geschwungenen Klammer aus.

        Boolean verwandt = (first != second) && (first < third);

        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
            System.out.println("oag, geht mir auch so!");
        } else if(verwandt) {
            System.out.println("OK. Danke.");
        } else {
            System.out.println("hupf in gatsch, schleich di");
        }

        System.out.println("Tschau :(");


        // 4 )
        // --------------------------- diverse Kombinationen von 1-3 -------------------------------
        System.out.println("----- diverse Kombinationen -----");
        System.out.println("Hallo :)");

        // (nur WENN mir die person SYMPATHISCH ist,
        // DANN rede viel,
        // WENN sie SEHR SYMPATHISCH ist,
        // DANN lache viel)
        // ANDERNFALLS, WENN sie VERWANDT ist
        // DANN rede ich noch einen Satz mit Ihr,
        // ANDERNFALLS,
        // sage ich "hupf in gatsch, schleich di".
        // wenn nach if die Bedingung wahr ist -> dann führe den Code in der geschwungenen Klammer aus.

        Boolean sehrSympathisch = (first != second) || (first < third);

        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
            System.out.println("oag, geht mir auch so!");

            if(sehrSympathisch) {
                System.out.print(" :) :) :)");
            }

        } else if(verwandt) {
            System.out.println("OK. Danke.");
        } else {
            System.out.println("hupf in gatsch, schleich di");
        }

        System.out.println("Tschau :(");

        // 5 )
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.

        Integer input = 1;

        if (input == 1) {
            System.out.println("Montag :(");

        } else if (input == 2) {
            System.out.println("Dienstag");

        } else if (input == 3) {
            System.out.println("Mittwoch");

        } else if (input == 4) {
            System.out.println("Donnerstag");

        } else if (input == 5) {
            System.out.println("Freitag :)");

        } else if (input == 6) {
            System.out.println("Samstag");

        } else if (input == 7) {
            System.out.println("Sonntag");

        } else {
            System.out.println("Kein Wochentag.");
        }


        // 6 )
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.
        // Zusätzlich hat der Montag eine chance von 80% 5 mal ":(", also :(:(:(:(:( zum String "Montag :(" hinzuzufügen.
        // Zusätzlich hat der Freitag eine chance von 30% 7 mal ":(", also :):):):):):):) zum String "Freitag :(" hinzuzufügen.

        Double zufallszahl = Math.random();
//        verwende allgemein besser die Random Klasse.
//        Random random = new Random();
//        Double zufallszahl = random.nextDouble();

        if (input == 1) {

            String output = "Montag :(";

            if (zufallszahl < 0.8) {
                System.out.println(output + ":(".repeat(5));
            } else {
                System.out.println(output);
            }

        } else if (input == 2) {
            String output = "Dienstag";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 3) {
            String output = "Mittwoch";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 4) {
            String output = "Donnerstag";

            if (zufallszahl < 0.01) {
                System.out.println(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 5) {
            String output = "Freitag :)";

            if (zufallszahl < 0.3) {
                System.out.print(output + ":)".repeat(7));
            } else {
                System.out.println(output);
            }

        } else if (input == 6) {
            String output = "Samstag";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 7) {
            String output = "Sonntag";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else {
            System.out.println("Kein Wochentag.");
        }


        // 7)
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.
        // Zusätzlich hat der Montag eine Chance von 80% 5 mal ":(", also :(:(:(:(:( zum String "Montag :(" hinzuzufügen.
        // Zusätzlich hat der Montag eine Chance von 30% 7 mal ":(", also :):):):):):):) zum String "Freitag :(" hinzuzufügen.
        // Zusätzlich hat jeder Tag eine Chance von 1%, einen ":)" hat.


        System.out.println("######################### HERE #########################");
        String output;

        if (input == 1) {
            output = "Montag :(";

            if (zufallszahl < 0.8) {
                output = output + ":(".repeat(5);
            }

        } else if (input == 2) {
            output = "Dienstag";

        } else if (input == 3) {
            output = "Mittwoch";

        } else if (input == 4) {
            output = "Donnerstag";

        } else if (input == 5) {
            output = "Freitag :)";

            if (zufallszahl < 0.3) {
                output = output + ":)".repeat(7);
            }

        } else if (input == 6) {
            output = "Samstag";

        } else if (input == 7) {
            output = "Sonntag";

        } else {
            output = "";
            System.out.println("Kein Wochentag.");
        }

        if (zufallszahl < 0.01) {
            System.out.print(output + ":)");
        } else {
            System.out.println(output);
        }

        // ############################## SWITCH ##############################

        // 8) das gleiche mit Switch.
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.

        input = 1;

        switch (input) {
            case 1: System.out.println("Montag :("); break;
            case 2: System.out.println("Dienstag"); break;
            case 3: System.out.println("Mittwoch"); break;
            case 4: System.out.println("Donnerstag"); break;
            case 5: System.out.println("Freitag :)"); break;
            case 6: System.out.println("Samstag"); break;
            case 7: System.out.println("Sonntag"); break;
            default: System.out.println("Kein Wochentag.");
        }


        input = 4;

        output = switch (input) {
            case 1 -> "Montag :(";
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        System.out.println(output);

        output = switch (input) {
            case 1 -> {

                String res = "Freitag :)";

                if (zufallszahl < 0.3) {
                    res = res + ":)".repeat(7);
                }

                yield(res);

            }
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        System.out.println(output);



















//
//
//
//        if( (first == second) && (first < third) ) {
//            System.out.println("Bedingung ist wahr");
//        }
//
//        if( (first == second) ) {
//            if ( first < third ) {
//                System.out.println("Bedingung ist wahr");
//            }
//        }
//
//        //|| boolean, boolean -> boolean
//
//
//        if ( ( (5+8+7/2) == (9/8-6+2) ) || ( (5+8+7/2) == (9/8-6+2) ) ) {
//            System.out.println("wird nie ausgegeben");
//        } else {
//            System.out.println("wird immer ausgegeben");
//        }
////
//        if (true) {
//            System.out.println("hallo1");
//        }
//        System.out.println("nein1");
//
//        //
//
//        if (false) {
//            System.out.println("hallo2");
//        } else {
//            System.out.println("nein2");
//        }
//
//        //
//        if (true) {
//            System.out.println("variante 1");
//        } else if(true) {
//            System.out.println("variante 2");
//        } else {
//            System.out.println("variante 3");
//        }
    }
}
