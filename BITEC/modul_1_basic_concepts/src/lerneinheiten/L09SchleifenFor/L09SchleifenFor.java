package lerneinheiten.L09SchleifenFor;

import java.util.Scanner;

public class L09SchleifenFor {
    public static void main(String[] args) {

//        For-Schleife - Erste Kontakte:
//        Eine Schleife hat den Sinn Programmcode wiederholt auszugeben, und zwar, solange bis eine Bedingung erfüllt ist (Siehe While-Loop).
//        Die For-Schleife ist speziell in dem Sinn, dass diese folgende While-Schleife kompakt zusammenfasst.

//        Die folgende For-Schleife
        for (int zaehlvariableDerForLoop = 1; zaehlvariableDerForLoop <= 10; zaehlvariableDerForLoop++) {
            System.out.println("FOR: wir haben " + zaehlvariableDerForLoop + " mal den Code in der Schleife ausgeführt.");
        }

//        hat die gleiche Bedeutung wie
        int zaehlvariableDerWhileLoop = 0;
        while (zaehlvariableDerWhileLoop < 10) {
            System.out.println("WHILE: wir haben " + zaehlvariableDerWhileLoop + " mal den Code in der Schleife ausgeführt.");
            zaehlvariableDerWhileLoop++; // bedeutet i+=1 und das bedeutet i = i + 1;
        }

        // Abgekürzt schreiben wir meist die Zählvariable mit dem Namen "i,j,k,l,m,..." usw. (i für "es ist ein Integer")

//        Was bedeutet nun die Syntax ("wie schreibe ich etwas in meiner Sprache") der For-Schleife:
//        Wir haben 3 Blöcke welche mit ";" getrennt sind. for(Block1; Block2; Block3) { ... }
//            Block1:
//                Hier kann eine Variable definiert werden. Diese ist meist die Zählvariable, welche zählt wie oft wir die Schleife schon ausgeführt haben.
//                (ANMERKUNG) Dieser Block kann (sehr selten) auch leer sein, falls wir die benötigte Variable schon vorher definiert haben!
//            Block2:
//                Hier muss ein boolescher Wert zurückgegeben, welche die Abbruchbedingung der Schleife darstellt.
//                Dies beinhaltet meistens die in Block 1 definierte Zählvariable (z.B. i < 5).
//                Solange diese Bedingung "true" zurückgibt, wird die Schleife wiederholt.
//                (ANMERKUNG) Diese Bedingung kann direkt hingeschrieben werden (z.B. i < 5), kann aber im Prinzip auch eine Methode (was das ist sehen wir später) sein, welche einen booleschen Wert zurückgibt.
//            Block3:
//                Hier kann eine Variable manipuliert werden. Diese ist meist die Zählvariable aus Block1 (i++).
//                (ANMERKUNG) Dieser Block kann (sehr selten) auch leer sein, falls wir die benötigte Variable an einer anderen Stelle verändert haben.

//         (Merke) Die Variable i in der For-Schleife gilt nur in der Zeile 12. Die Variable i in Zeile 15 für die While-Schleife gilt hier in der Gesamten Main Methode.
//         (Merke) Folgende Daumenregel hilft fuer die Entscheidung welche Schleife zu verwenden ist:
//         - verwende eine For-Schleife, wenn du weißt wie oft etwas wiederholt werden muss.
//            - Beispiel: Wir fragen den User wie groß der Weihnachtsbaum sein soll und bauen diesen danach. (Aufgabe 6)
//         - verwende eine While-Schleife, wenn du NICHT weißt wie oft etwas wiederholt werden muss.
//            - Beispiel: Wir dividieren eine vom User eingegebene Zahl und schauen, ob diese durch 2 teilbar ist. Wenn ja, mach weiter, wenn nein, stop.
//         - verwende eine Do-While-Schleife, wenn du NICHT weißt wie oft etwas wiederholt werden muss, ABER
//              die Schleife zumindest EIN mal ausgeführt werden soll, bevor die Bedingung überprüft werden soll.
//            - Beispiel: Wir fragen den User nach seinem Alter. Diese Eingabe wird nur akzeptiert, wenn diese uns "sinnvoll" erscheint. Ansonsten fragen wir immer wieder erneut nach dem Alter.

//        (Merke) Wie die Zählvariablen definiert werden ist im prinzip euch überlassen! Wir können z.B. mit 10 Beginnen und dann bis 15 Zählen.
        for (int i = 10; i < 15; i++) {
            System.out.println("wir sind... " + i + " mal durch die Schleife gegangen? Nein... eher " + (i - 9));
        }
//        Das scheint aber nicht sehr sinnvoll zu sein. Denke an Arrays!
//        Auf das erste Element des Arrays können wir mit dem Index 0 zugreifen. Also meinArray[0] gibt dir das Erste Element zurück.
//        Hier macht es also Sinn i bei 0 beginnen zu lassen.

//        (Merke) Je nachdem ob wir bei 0 Zählen beginnen oder bei 1 ändert das die Logik der Abbruchbedingung!
//        Wir haben hier leider oft das Problem eines "off by one" Gedankenfehlers.
//        Also "wir sind eins entfernt" obwohl wir das gar nicht wollen.
//        Wir wollen z.B. alle Elemente des Arrays mit Größe 10 durchlaufen. Beginnen also bei i = 0 und müssen bei i = 9 stoppen!
//        Wir haben aber fälschlicherweise, da das Array 10 Groß ist, die Abbruchbedingung auf i <= 10 gesetzt, nicht i < 10 oder i <= 9.
//        Dadruch gehen wir die Schleife 11 mal durch!
        for (int i = 0; i <= 10; i++) {
            System.out.println("FOR LOGIK \"i <= 10\": UPS! Wir haben " + (i + 1) + " mal den Code in der Schleife ausgeführt."); // \" bedeutet hier dass "in der Ausgabe steht, nicht dass der Sting endet!
        }

//        Hier i < 10 bedeutet die Bedingung ist false, wenn i = 9, also das was wir wollen.
        for (int i = 0; i < 10; i++) {
            System.out.println("FOR LOGIK \"i < 10\": :) Wir haben " + (i + 1) + " mal den Code in der Schleife ausgeführt."); // \" bedeutet hier dass "in der Ausgabe steht, nicht dass der Sting endet!
        }

//        Ebenso funktioniert i <= 9;
        for (int i = 0; i <= 9; i++) {
            System.out.println("FOR LOGIK \"i <= 9\": :) Wir haben " + (i + 1) + " mal den Code in der Schleife ausgeführt."); // \" bedeutet hier dass "in der Ausgabe steht, nicht dass der Sting endet!
        }

//        Machen wir das nun wirklich mit einem Array
        String[] myStringArray = {"Hallo", "ich", "bin", "genau", "zehn", "Elemente", "groß", "oder", "lang", "!"};
        System.out.println("Das array hat " + myStringArray.length + " Elemente!");

//        (MERKE) Hier verwenden wir i < 10 als Abbruchbedingung.
//        Lege dir EINE Logik fest, mit der du die Beispiele unten lösen möchtest. Danach versuche zwischen diesen zu wechseln.
        for (int i = 0; i < myStringArray.length; i++) {
            System.out.println("FOR mit Array und LOGIK \"i < 10\": wir haben \"" + myStringArray[i] + "\" an der Stelle " + i + " des Arrays."); // \" bedeutet hier dass "in der Ausgabe steht, nicht dass der Sting endet!
        }
//        (ANMERKUNG) Das funktioniert auch, wenn die Abbruchbedingung "i <= myStringArray.length-1" ist. also i <= 9.
        for (int i = 0; i <= myStringArray.length - 1; i++) {
            System.out.println("FOR mit Array und LOGIK \"i < 10\": wir haben \"" + myStringArray[i] + "\" an der Stelle " + i + " des Arrays."); // \" bedeutet hier dass "in der Ausgabe steht, nicht dass der Sting endet!
        }

//        (ANMERKUNG) Wenn wir nicht bei 0 Anfangen wollen zu zählen, dann müssen wir hier im Code und in der Abbruchbedingung korrigieren... das kann aber zu sehr versteckten Fehlern führen!
//        Also die Abbruchbedingung "um eins nach rechs" schieben, also erhöhen. Das geht mit "i <= myStringArray.length" oder "i < myStringArray.length+1"
//        Wir müssen im Code dann myStringArray[i-1] verwenden, um den Start von i=1 zu korrigieren!
        for (int i = 1; i <= myStringArray.length; i++) {
            System.out.println("FOR mit Array und LOGIK \"i <= 10\": wir haben \"" + myStringArray[i - 1] + "\" an der Stelle " + (i - 1) + " des Arrays, bei dem Wert von i gleich " + i); // \" bedeutet hier dass "in der Ausgabe steht, nicht dass der Sting endet!
        }
        for (int i = 1; i < myStringArray.length + 1; i++) {
            System.out.println("FOR mit Array und LOGIK \"i < 10+1\": wir haben \"" + myStringArray[i - 1] + "\" an der Stelle " + (i - 1) + " des Arrays, bei dem Wert von i gleich " + i); // \" bedeutet hier dass "in der Ausgabe steht, nicht dass der Sting endet!
        }

//        Hier nun ein paar For-Schleifen-Beispiele wo wir auf die Konsole zeichnen.

        Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

//        Aufgabe 1:
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ##
//        ###
//        ####
//        #####
//        ######

        System.out.println();
        System.out.println("------Aufgabe 1------");
        System.out.println("Lösung mit zwei verschachtelten Schleifen - ohne die repeat methode");

        for (int zeilen = 1; zeilen <= oberesLimit; zeilen++) {
            for (int spalten = 1; spalten <= zeilen; spalten++) {
                System.out.print("#");
                //  + zeilen + " " + spalten
            }
            System.out.println();
        }

        System.out.println("Lösung mit einer Schleife - mit der repeat methode");
        // Die repeat Methode ist hier eine "kürzere" Variante.
        // Wir wollen mit der zweite verschachtelten Schleife im obigen Beispiel, zeichen wiederholt, nebeneinander ausgeben.
        // Das ist der gleiche Anwendungsfall wie die "repeat" Methode.
        // Hier ist quasi eine Schleife in der repeat Methode versteckt.
        // Wir haben also immer noch den Fall, dass wir "alle Symbole in der Richtung der Zeilen (y-Achse) und
        // Richtung der Spalten (x-Achse) abgehen.
        for (int i = 1; i <= oberesLimit; i++ ) {
            System.out.println("#".repeat(i));
        }


//        Aufgabe 2
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ##
//        ###
//        ####
//        #####
//        ######
//        #####
//        ####
//        ###
//        ##
//        #
        System.out.println();
        System.out.println("------Aufgabe 2------");
        System.out.println("Lösung mit zwei verschachtelten Schleifen zwei mal hintereinander - ohne die repeat methode");
        for (int zeilen = 1; zeilen <= oberesLimit; zeilen++) {
            for (int spalten = 1; spalten <= zeilen; spalten++) {
                System.out.print("#");
            }

            System.out.println();
        }

        for (int zeilen = oberesLimit-1; zeilen >= 1; zeilen--) {
            for (int spalten = 1; spalten <= zeilen; spalten++) {
                System.out.print("#");
            }

            System.out.println();
        }


        System.out.println("Lösung mit zwei Schleifen - mit der repeat methode");

        for (int i = 1; i <= oberesLimit; i++) {
            System.out.println("#".repeat(i));
        }

        for (int i = oberesLimit - 1; i > 0; i--) {
            System.out.println("#".repeat(i));
        }

        System.out.println("Lösung mit einer Schleife");
        int j = 6;

        for (int i = 1; i <= 2*oberesLimit-1; i++ ) {

            if (i > oberesLimit) {
                j = j - 1;
                System.out.println("#".repeat(j));

            } else {
                System.out.println("#".repeat(i));
            }

        }


//        Aufgabe 3
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        ~
//        ##
//        ~~~
//        ####
//        ~~~~~
//        ######
//        ~~~~~
//        ####
//        ~~~
//        ##
//        ~

        System.out.println();
        System.out.println("------Aufgabe 3------");

        for (int i = 1; i <= oberesLimit; i++) {

            if (i % 2 == 0) {
                System.out.println("#".repeat(i));
            } else {
                System.out.println("~".repeat(i));
            }

        }

        for (int i = oberesLimit - 1; i > 0; i--) { // i -= 1 ODER i-- ODER --i

            if (i % 2 == 0) {
                System.out.println("#".repeat(i));
            } else {
                System.out.println("~".repeat(i));
            }

        }

//        Aufgabe 4
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ###
//        ##
//        ####
//        ###
//        #####
//        ####
//        ######
//        #####
//        #######
//        ######
//        ########
        System.out.println();
        System.out.println("------Aufgabe 4------");
        j = 1;

        for (int i = j; i <= oberesLimit * 2; i++) {

            System.out.println("#".repeat(j));

            if (i % 2 == 1) {
                j += 2; // bedeutet j = j + 2;
            } else {
                j -= 1; // bedeutet j = j - 1;
            }

        }


//        Aufgabe 5
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        Dieses Muster ist während des Wachstums und Zerfalls doppelt so lange wie jene bisher
//        #
//        ###
//        ##
//        ####
//        ###
//        #####
//        ####
//        ######
//        #####
//        #######
//        ######
//        ########
//        ++++++
//        +++++++
//        +++++
//        ++++++
//        ++++
//        +++++
//        +++
//        ++++
//        ++
//        +++
//        +
        System.out.println();
        System.out.println("------Aufgabe 5------");
        int distance = 1;
        int i = 1;
        j = i + distance;
        int up = distance + 1;
        int down = distance;

        for (; i <= oberesLimit * 2; i++) {

            if (i % 2 == 0) {
                j += up;
            } else {
                j -= down;
            }

            System.out.println("#".repeat(j));
        }

        for (i = oberesLimit * 2 - 1; i > 0; i--) {

            if (i % 2 == 0) {
                j += down;
            } else {
                j -= up;
            }

            System.out.println("+".repeat(j));

        }

//        Aufgabe 6
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        Dieses Muster ist während des Wachstums und Zerfalls doppelt so lange wie jene bisher UND
//        hat bei der halben und ganzen Länge während des Wachstums und Zerfalls spezielle Symbole ":)" und ":(".
//        ~
//        #####
//        ~~
//        ######
//        ~~~
//        :):):):):):):)
//        ~~~~
//        ########
//        ~~~~~
//        #########
//        ~~~~~~
//        :):):):):):):):):):)
//        ~~~~~~
//        +++++++++
//        ~~~~~
//        ++++++++
//        ~~~~
//        :(:(:(:(:(:(:(
//        ~~~
//        ++++++
//        ~~
//        +++++
//        ~

        System.out.println();
        System.out.println("------Aufgabe 6------");
        distance = 3;
        i = 1;
        j = i + distance;
        up = distance + 1;
        down = distance;

        String raute = "#";
        String tilde = "~";
        String plus = "+";
        String sad = ":(";
        String happy = ":)";
        String symbolInUse;

        for (; i <= oberesLimit * 2; i++) {

            if (i % 2 == 0) {
                j += up;

                if (i % oberesLimit == 0)
                    symbolInUse = happy;
                else
                    symbolInUse = raute;

            } else {

                j -= down;
                symbolInUse = tilde;

            }

            System.out.println(symbolInUse.repeat(j));

        }

        for (i = oberesLimit * 2 - 1; i > 0; i--) {

            if (i % 2 == 1) {

                j -= up;
                symbolInUse = tilde;

            } else {

                j += down;
                if (i % oberesLimit == 0)
                    symbolInUse = sad;
                else
                    symbolInUse = plus;

            }

            System.out.println(symbolInUse.repeat(j));

        }

//        (Anmerkung) Aufgabe 6.1
//        Gib das Muster aus Aufgabe 6... aber anders... und zwar ohne verschachtelte if mit guard clause logik! Siehe De-morgansche Gesetze! (Tafelbild 21.12.2023)
        System.out.println();
        System.out.println("------Aufgabe 6.1------");
        i = 1;
        j = i + distance;

        for (; i <= oberesLimit * 2; i++) {

            if (i % 2 != 0) {
                j -= down;
                System.out.println(tilde.repeat(j));
                continue;
            }

            if (i % oberesLimit != 0) {
                j += up;
                System.out.println(raute.repeat(j));
                continue;
            } // ein else würde hier auch gehn aber bleiben wir bei der guard clause logik.

            j += up;
            System.out.println(happy.repeat(j));

        }

        for (i = oberesLimit * 2 - 1; i > 0; i--) {

            if (i % 2 != 0) {
                j -= up;
                System.out.println(tilde.repeat(j));
                continue;
            }

            if (i % oberesLimit != 0) {
                j += down;
                System.out.println(plus.repeat(j));
                continue;
            } // ein else würde hier auch gehn aber bleiben wir bei der guard clause logik.

            j += down;
            System.out.println(sad.repeat(j));

        }

//        Aufgabe 6.2
//        Gib das Muster aus Aufgabe 6, mit beliebiger Länge welche vom User bestimmt wird, aus.
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("------Aufgabe 6.2------");
        System.out.print("Wie lange soll das Muster sein? ");
        oberesLimit = Integer.parseInt(scanner.nextLine());

        i = 1;
        j = i + distance;

        for (; i <= oberesLimit * 2; i++) {

            if (i % 2 == 0) {
                j += up;

                if (i % oberesLimit == 0)
                    symbolInUse = happy;
                else
                    symbolInUse = raute;

            } else {

                j -= down;
                symbolInUse = tilde;

            }

            System.out.println(symbolInUse.repeat(j));

        }

        for (i = oberesLimit * 2 - 1; i > 0; i--) {

            if (i % 2 == 1) {

                j -= up;
                symbolInUse = tilde;

            } else {

                j += down;
                if (i % oberesLimit == 0)
                    symbolInUse = sad;
                else
                    symbolInUse = plus;

            }

            System.out.println(symbolInUse.repeat(j));

        }

//        Aufgabe 7
//        Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
//        speichere dieses in ein 2 dimensionales array.
        System.out.println();
        System.out.println("------Aufgabe 7------");

        System.out.print("Wie groß soll das Schachbrett sein? ");
        Integer dimension = Integer.parseInt(scanner.nextLine());

        String[][] brett = new String[dimension][dimension];
        char whiteSquare = 0x2588;
        char blackSquare = 0x2591;

        String farbe;

        for (i = 0; i < dimension; i++) {
            for (j = 0; j < dimension; j++) {

                if (j % 2 == 0) {
                    if (i % 2 == 0) {
                        farbe = new String(Character.toChars(whiteSquare));
                    } else {
                        farbe = new String(Character.toChars(blackSquare));
                    }
                } else {
                    if (i % 2 == 0) {
                        farbe = new String(Character.toChars(blackSquare));
                    } else {
                        farbe = new String(Character.toChars(whiteSquare));
                    }
                }

                brett[i][j] = farbe;
                System.out.print(farbe);
            }

            System.out.println();
        }


//        Aufgabe 8 Christmas Tree
        System.out.println();
        System.out.println("------Aufgabe 9------");
        Scanner sc = new Scanner(System.in);
        System.out.print("Höhe des Baumes (ohne Stamm): ");
        int h = sc.nextInt();

//    beginning of upper part
        for (i = 1; i <= h; i++) {
            for (j = h - i; j > 0; j--) {
                System.out.print(" ");
            }

            for (int k = 1; k <= i; k++) {
                System.out.print("* ");
            }

            System.out.println();
        }
//        end of upper part
//        beginning of lower part
        for (i = 1; i <= h - 1; i++) {

            System.out.print(" ");

            for (j = h - 3; j > 0; j--) {
                System.out.print(" ");
            }

            for (int k = 2; k > 0; k--) {
                System.out.print("| ");
            }

            System.out.println();
        }// end of lower part

        // Aufgabe 9
        // Müssen wir immer alles in "einem Block" die komplette Aufgabe lösen? Natürlich nicht. Wenn wir es können
        // ist es gut, es kann aber auch sein, dass es Sinn macht die Aufgabe zu unterteilen egal ob wir sofort diese Lösen könnnen
        // oder nicht.

        // Versuchen wir folgendes Problem zu unterteilen.
        // generiere folgendes Muster:
        //  x---x
        //  -x-x-
        //  --x--
        //  -x-x-
        //  x---x

        // Variante 1 - mit Unterteilung in Schritten
        // beachte die Nummerierung Schritt 1-5!
        System.out.println("~~~~~~~~~ Variante 1 ~~~~~~~~~");
        System.out.println();


        // Schritt 1 - Feld erstellen
        int n = 5;
        String[][] feld = new String[n][n];

        // Schritt 2 - Feld mit "~" befüllen
        for (i = 0; i < n; i++) {
            for (j = 0; j < n; j++) {
                feld[i][j] = "-";
            }
        }

        // Schritt 4 - Feld mit der 1. Diagonale befüllen (links nach rechts)
        // Hier soll erkannt werden, dass wenn wir uns die indices der 1. Diagonale anschauen -> (0,0) (1,1) (2,2) (3,3) (4,4)
        // der Index immer der gleiche für die X und Y-Achse ist. Wir brauchen also nur eine Schleife!
        for (i = 0; i < n; i++) {
            feld[i][i] = "x";
        }


        // Schritt 5 - Feld mit der 2. Diagonale befüllen (rechts nach links)
        // Hier soll erkannt werden, dass wenn wir uns die indices der 2. Diagonale anschauen -> (0,4) (1,3) (2,2) (3,1) (4,0)
        // der Index von der x achse (j) verkehrt zum Schritt 4 ist. Wir schaffen das wenn "4 minus index" gemacht wird. Oder allgemein n-1-i.
        for (i = 0; i < n; i++) {
            feld[i][n-1-i] = "x";
        }

        // alternativer Lösung für 5 - hier gibt es mehrere Möglichkeiten (Siehe Tafelbild vom 11.01.2024)
//        for (int i = 0; i < n; i++) {
//            for (int j = n-1; j >= 0; j--) {
//                if (i + j == n-1) {
//                    feld[i][j] = "x";
//                }
//            }
//        }



        // Schritt 3 - Ausgabe
        for (i = 0; i < n; i++) {
            for (j = 0; j < n; j++) {
                System.out.print(feld[i][j]);
            }
            System.out.println();
        }

        // Nun können wir Schritte kombinieren, wenn diese sich anbieten!
        // Z.B das Zeichnen der Diagonale kann in einer gemeinsamen For Schleife gemacht werden (Schritt 4 und 5).

        //        for (int i = 0; i < n; i++) {
        //            feld[i][i] = "x";
        //            feld[i][n-1-i] = "x";
        //        }


        // variante 2
        System.out.println("~~~~~~~~~ Variante 2 ~~~~~~~~~");
        System.out.println();

        for (i = 0; i < n; i++) {
            for (j = 0; j < n; j++) {

                if(i == j || i == n-1-j) {
                    System.out.print("x");
                } else {
                    System.out.print("-");
                }

            }
            System.out.println();
        }
    }
}
