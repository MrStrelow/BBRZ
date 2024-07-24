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
        //  DANN gib 'mal schauen ob es ausgeführt wird'. aus.
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
        //  DANN gib 'mal schauen ob es ausgeführt wird'. aus.
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
        // "WENN die Zahl die er User eingibt UNgleich 5 ist,
        //  DANN
        //      WENN die Zahl die er User eingibt kleiner 5 ist
        //      DANN gib ':)' aus und halbiere x"
        //      ANSONSTEN gib ':(' aus und verdopple x".
        //  ANSONSTEN
        //  gib 'mal schauen ob es ausgeführt wird'. aus.

        // Wir haben hier also vertauscht was im ELSE Zweig dargestellt wird.
        if (x != 5) {

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

        // Wir sehen, dieses Programm ist syntaktisch unterschiedlich wie das vorherige, jedoch semantisch das Gleiche.
        // In normaler Sprache, "der Code ist anders, aber er macht das gleiche".

        // ########## tenärer Operator ##########
        // Wir schauen uns kurz hier die Logik einer "wenn-dann-ansonsten" Verzweigung mittels dem "ternären" Operators an.
        // Da wir nur einen ternären (3-ternär, 2-binär, 1-unär) Operator haben, hat er keinen spezielleren Namen.
        // In anderen Sprachen (z.B. Python) wird dieser "conditional expressions" genannt.
        // Wir können damit folgendes Modellieren.
        // Umgangssprachlich:
        // "<wenn> es regnet <dann> gehe ich schwimmen <ansonsten> bleibe ich zu Hause.
        // In Python verschieben wir die Reihenfolge der Aussage. Es würde dann so geschrieben werden (ohne <>).
        // "gehe schwimmen <if> es regnet <else> bleibe zu Hause". Hier verschwindet das <dann> vor dem "gehe schwimmen"
        // In JAVA schreiben wir dies kryptischer aber wieder in der ursprünglichen Reihenfolge wie in der umgangssprachlichen Version.
        // es regnet ? gehe schwimmen : bleibe zu Hause.

        // Was tut dieser Ausdruck nun?
        Integer userInput = Integer.parseInt(scanner.nextLine());
        String userStringShort = userInput == 5 ? "user hat größer 5 eingegeben" : "user hat kleiner 5 eingegeben";


        // Wir können diese Verzweigung, wie das IF, auch verschachteln.
        userStringShort =
                userInput != 5 ?
                        (userInput > 5 ?
                                "user hat größer 5 eingegeben" :
                                "user hat kleiner 5 eingegeben"
                        ) :
                        "user hat den 5er eingegeben";

        System.out.println(userStringShort);

        // ########## Zusammenhang mit Logischen Operatoren ##########
        // Wir können Verschachtelungen von Verzweigungen auch durch logische Operatoren vermeiden.
        // Ob ein solches Umschreiben sinnvoll ist, kommt immer auf den speziellen Anwendungsfall an
        // und kann nicht allgemein beantwortet werden.
        // Dazu schauen wir uns folgendes an:

        Boolean esRegnet = true;
        Boolean esIstKalt = true;

        if (esRegnet) {
            if (esIstKalt) {
                System.out.println("wir bleiben zuhause");
            }
        }

        // Hier haben wir eine Verschachtelung, welche zuerst abfragt ob "es regnet" und danach ob "es kalt ist".
        // Wenn beide Variablen "wahr" sind, wird "Es ist kalt und regnet" ausgegeben.
        // Wenn eine der beiden Variablen "falsch" ist, bzw. beide "falsch" sind,
        // dann werden wir nicht "Es ist kalt und regnet" ausgegeben.
        // Dieses Verhalten entspricht jenem eines logischen UND. Deshalb kann dieses auch so dargestellt werden:
        if (esRegnet && esIstKalt) {
            System.out.println("wir bleiben zuhause");
        }

        // Wir können auch ein Verhalten erzeugen welches dem logischen ODER entspricht.
        // Dazu schauen wir uns folgendes an:
        if (esRegnet) {
            System.out.println("wir bleiben zuhause");
        }

        if (esIstKalt) {
            System.out.println("wir bleiben zuhause");
        }

        // Hier ist keine Verschachtelung gegeben, jedoch ist hier ein hintereinanderschalten von IF Verzweigungen gegeben.
        // Wir bleiben hier zu Hause, wenn es regnet. Wir bleiben hier zu Hause, wenn es kalt ist. Wir bleiben (sogar doppelt)
        // zu Hause, wenn beides eintritt. Wir nehmen an, dass die doppelte Ausgabe der IFs das Gleiche ist, wie eine einzige Ausgabe.
        // Dann können wir beobachten, dass dieser Zustand ein logisches ODER ist. Deshalb kann dieses auch so dargestellt werden:
        if (esRegnet || esIstKalt) {
            System.out.println("wir bleiben zuhause");
        }
        // ACHTUNG! Das funktioniert nur, wenn der gleiche Code innerhalb der IF Blöcke steht.

        // Wir werden diese Schreibweisen in Zukunft ausnutzen, um sogenannte "Guard Clauses" zu erstellen.
        // Diese funktionieren immer (... oft), da wir folgenden logischen Zusammenhang haben:
        // !(A && B) ist das gleiche wie !A || !B, deshalb ist A && B ist das gleiche wie !( !A || !B).
        // Verneine dazu beide Aussagen und bemerke, dass sich eine doppelte Negation aufhebt.
        // Deshalb kann ein "verschachteltes IF" zu einem "untereinander geschriebenen IF" umgeschrieben werden!
        // Die untereinander geschriebenen IFs bieten oft eine schönere Darstellung welche "Guard Clauses" genannt werden.
        // Folgendes Programm ist also das gleiche wie...
        Boolean userExistiert = false;
        Boolean userIstAltGenug = false;
        Boolean userIstPremiumAccount = true;
        Boolean userIstUnauffaellig = true;

        Boolean ressourceExistiert = false;
        Boolean ressourceIstAmNeuestenStand = true;
        Boolean ressourceUnauffaellig = true;

        System.out.println("----------Verschachteltes IF----------");

        if (userExistiert) {
            if (userIstAltGenug) {
                if (userIstPremiumAccount) {
                    if (userIstUnauffaellig) {
                        if (ressourceExistiert) {
                            if (ressourceIstAmNeuestenStand) {
                                if (ressourceUnauffaellig) {
                                    System.out.println("Passt! User bekommt was er will.");
                                } else {
                                    System.out.println("Fehler 7!");
                                }
                            } else {
                                System.out.println("Fehler 6!");
                            }
                        } else {
                            System.out.println("Fehler 5!");
                        }
                    } else {
                        System.out.println("Fehler 4!");
                    }
                } else {
                    System.out.println("Fehler 3!");
                }
            } else {
                System.out.println("Fehler 2!");
            }
        } else {
            System.out.println("Fehler 1!");
        }


        // ... dieses Programm hier.
        System.out.println("----------Guard Clauses----------");

        if (!userExistiert) {
            System.out.println("Fehler 1!");
            System.exit(0);
        }

        if (!userIstAltGenug) {
            System.out.println("Fehler 2!");
            System.exit(0);
        }

        if (!userIstPremiumAccount) {
            System.out.println("Fehler 3!");
            System.exit(0);
        }

        if (!ressourceExistiert) {
            System.out.println("Fehler 4!");
            System.exit(0);
        }

        if (!userIstUnauffaellig) {
            System.out.println("Fehler 5!");
            System.exit(0);
        }

        if (!ressourceIstAmNeuestenStand) {
            System.out.println("Fehler 6!");
            System.exit(0);
        }

        if (!ressourceUnauffaellig) {
            System.out.println("Fehler 7!");
            System.exit(0);
        }

        System.out.println("Passt! User bekommt was er will.");

        // Kurz ein paar Worte zur Theorie. Das Konzept "Verzweigung" ist semantisches Konzept. Ein solches spiegelt
        // die Bedeutung unseres Vorhabens wider. Dieses Vorhaben ist eben dem Programm zu sagen
        // "führe einen Teil des Programmes aus, aber nur wenn ein gewisser Zustand bereits eingetreten ist".
        // Wir müssen nun die Bedeutung (die Semantik), die wir im Kopf haben, in unserer Programmiersprache formulieren.
        // Diese Formulierung ist dann nicht mehr ein semantisches Konzept, sondern ein syntaktisches.

        // Semantik ist also die Bedeutung unseres Vorhabens und die Syntax die Art wie wir es in unserer
        // Programmiersprache formulieren. Wenn wir es in einer anderen Sprache formulieren wollen, ist die Syntax eine andere.
        // Die Bedeutung des Programmes ist aber die gleiche und unabhängig von der Sprache.
        // Wir können nun mit Logik unser Programm mathematisch analysieren, ob es das tut, was es soll.
        // Diese Analyse ist dann auf der semantischen Ebene.
        // Dies wird benötigt um Autopiloten von Flugzeugen, Software für Atomkraftwerke, NASA, usw. zu schreiben.
        // Theorie ende.

        // ################## Namespaces ##################
        // Hier noch unabhängig von den Verzweigungen ein Thema, welches jetzt zum Ersten mal relevant wird.
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

        // ########### Hier nun ein paar Beispiele zum Mitlesen zu der IF/IF-ELSE/ELSE-IF Verzweigung ############

        // 1 )
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.

        System.out.print("Geben Sie eine Zahl zwischen 1 und 7 ein um einen Wochentag zu erhalten: ");
        Integer input = Integer.parseInt(scanner.nextLine());

        if (input == 1) {
            System.out.print("Montag :(");

        } else if (input == 2) {
            System.out.print("Dienstag");

        } else if (input == 3) {
            System.out.print("Mittwoch");

        } else if (input == 4) {
            System.out.print("Donnerstag");

        } else if (input == 5) {
            System.out.print("Freitag :)");

        } else if (input == 6) {
            System.out.print("Samstag");

        } else if (input == 7) {
            System.out.print("Sonntag");

        } else {
            System.out.print("Kein Wochentag.");
        }


        // 2 )
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.
        //  - Zusätzlich hat der Montag eine chance von 80% 5 mal ":(", also ":(:(:(:(:(" zum String "Montag :(" hinzuzufügen.
        //  - Zusätzlich hat der Freitag eine chance von 30% 7 mal ":(", also ":):):):):):):)" zum String "Freitag :)" hinzuzufügen.
        //  - Zusätzlich hat jeder Tag eine Chance von 1%, dass dieser einen zusätzlichen Smiley ":)" hat.

        Double zufallszahlMontag = Math.random();
        Double zufallszahlFreitag = Math.random();
        Double zufallszahlJederTag = Math.random();

//        oder verwende die Random Klasse.
//        Random random = new Random();
//        Double zufallszahlMontag = random.nextDouble();
//        Double zufallszahlFreitag = random.nextDouble();
//        Double zufallszahlJederTag = random.nextDouble();

        if (input == 1) {

            String output = "Montag :(";

            if (zufallszahlMontag < 0.8) {
                System.out.println(output + ":(".repeat(5));

            } else if (zufallszahlJederTag < 0.01) {
                System.out.println(output + ":)");

            } else {
                System.out.println(output);
            }

        } else if (input == 2) {
            String output = "Dienstag";

            if (zufallszahlJederTag < 0.01) {
                System.out.print(output + ":)");

            } else {
                System.out.println(output);
            }

        } else if (input == 3) {
            String output = "Mittwoch";

            if (zufallszahlJederTag < 0.01) {
                System.out.print(output + ":)");

            } else {
                System.out.println(output);
            }

        } else if (input == 4) {
            String output = "Donnerstag";

            if (zufallszahlJederTag < 0.01) {
                System.out.println(output + ":)");

            } else {
                System.out.println(output);
            }

        } else if (input == 5) {
            String output = "Freitag :)";

            if (zufallszahlFreitag < 0.3) {
                System.out.print(output + ":)".repeat(7));

            } else if (zufallszahlJederTag < 0.01) {
                System.out.println(output + ":)");

            } else {
                System.out.println(output);
            }

        } else if (input == 6) {
            String output = "Samstag";

            if (zufallszahlJederTag < 0.01) {
                System.out.print(output + ":)");

            } else {
                System.out.println(output);
            }

        } else if (input == 7) {
            String output = "Sonntag";

            if (zufallszahlJederTag < 0.01) {
                System.out.print(output + ":)");

            } else {
                System.out.println(output);
            }

        } else {
            System.out.println("Kein Wochentag.");
        }


        // 3)
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.
        //  - Zusätzlich hat der Montag eine chance von 80% 5 mal ":(", also ":(:(:(:(:(" zum String "Montag :(" hinzuzufügen.
        //  - Zusätzlich hat der Freitag eine chance von 30% 7 mal ":(", also ":):):):):):):)" zum String "Freitag :)" hinzuzufügen.
        //  - Zusätzlich hat jeder Tag eine Chance von 1%, dass dieser einen zusätzlichen Smiley ":)" hat.


        System.out.println("######################### HERE #########################");
        String output;

        if (input == 1) {
            output = "Montag :(";

            if (zufallszahlMontag < 0.8) {
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

            if (zufallszahlFreitag < 0.3) {
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

        if (zufallszahlJederTag < 0.01) {
            System.out.print(output + ":)");
        } else {
            System.out.println(output);
        }
    }
}
