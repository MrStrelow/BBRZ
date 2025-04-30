package lerneinheiten.L09SchleifenFor.uebung;

import java.util.Random;
import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
        String RESET = "\u001B[0m";
        String WHITE = "\u001B[37m";
        String RED = "\u001B[31m";
        String GREEN = "\u001B[32m";
        String BLUE = "\u001B[34m";

        Scanner scanner = new Scanner(System.in);

        // 1. Zahlen von 1 bis n
        // For-Schleife, welche die Zahlen von 1 bis 10 ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 10 beliebig anpassen kann.
        System.out.print("Grenze für Zahlen 1 bis n: ");
        int grenze = scanner.nextInt();

        for (int i = 1; i <= grenze; i++) {
            System.out.print(i + " ");
        }

        System.out.println();
        System.out.println();

        // 2. Gerade Zahlen von 2 bis n
        // For-Schleife, welche die gerade Zahlen von 2 bis 20 ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 20 beliebig anpassen kann.
        System.out.print("Grenze für gerade Zahlen: ");
        grenze = scanner.nextInt();

        for (int i = 2; i <= grenze; i += 2) {
            System.out.print(i + " ");
        }

        System.out.println();
        System.out.println();

        // 3. Ungerade Zahlen rückwärts von n bis m
        // For-Schleife, welche die ungeraden Zahlen von **15 bis 5** ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 15 beliebig anpassen kann.
        System.out.print("obere und untere Grenze für ungerade Zahlen rückwärts [untere obere]: ");
        int grenzeUnten = scanner.nextInt();
        int grenzeOben = scanner.nextInt();

        for (int i = grenzeOben; i >= grenzeUnten; i--) {
            if (i % 2 != 0) {
                System.out.print(i + " ");
            }
        }

        System.out.println();
        System.out.println();

        // 4. Alphabet
        // For-Schleife, welche die Buchstaben von A bis Z ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von Z beliebig anpassen kann.
        System.out.print("Letzter Buchstabe (z.B. Z): ");
        char buchstaben = scanner.next().toUpperCase().charAt(0);

        for (char c = 'A'; c <= buchstaben; c++) {
            System.out.print(c + " ");
        }

        System.out.println();
        System.out.println();

        // 5. Quadratzahlen
        // For-Schleife, welche die Quadratzahlen von 20 bis 100 ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 100 beliebig anpassen kann.
        // Beispiel:
        // Quadratzahlen: 5*5=25, 6*6=36, 7*7=49, 8*8=64, 9*9=81, 10*10=100
        System.out.print("Grenze für Quadratzahlen: ");
        grenze = scanner.nextInt();

        for (int i = 1; i <= grenze; i++) {
            if (i * i <= grenze) {
                System.out.println(i + "*" + i + " = " + (i * i));
            }
        }

        System.out.println();

        // alternativ: Die Bedingung der If-Bedingung direkt in die Bedingung der For-Schleife geben
        System.out.println("alternativ: Die Bedingung der If-Bedingung direkt in die Bedingung der For-Schleife geben");

        for (int i = 1; i * i <= grenze; i++) {
            System.out.println(i + "*" + i + " = " + (i * i));
        }

        System.out.println();

        // 6. Summe der Zahlen
        // For-Schleife, welche bis 10 die Summe von 1 + 2 + 3 + ... + 10 ausrechnet. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 10 beliebig anpassen kann.
        // Optional: Wieso funktioniert hier 10 * (10 + 1) / 2 als Lösungsformel? Siehe hier [Bild]().
        System.out.print("Grenze für Summe 1 + 2 + ... + n: ");
        grenze = scanner.nextInt();
        int summe = 0;

        for (int i = 1; i <= grenze; i++) {
            summe += i;
        }

        System.out.println("Summe = " + summe);
        System.out.println("Formel: n*(n+1)/2 = " + (grenze * (grenze + 1) / 2));
        System.out.println();

        // 7. Harmonische Reihe
        // For-Schleife, welche bis 10 die Harmonische Reihe ausrechnen. Diese ist (1 + 1/2 + 1/3 + ... + 1/10). Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 100 beliebig anpassen kann.
        System.out.print("Grenze für harmonische Reihe: ");
        grenze = scanner.nextInt();
        double harmonisch = 0;

        for (int i = 1; i <= grenze; i++) {
            harmonisch += 1.0 / i;
        }

        System.out.println("Harmonische Summe = " + harmonisch);
        System.out.println();

        // 8. Fakultät
        // For-Schleife, welche die Fakultät der Zahl 5 berechnet. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        // Beispiel:
        // Berechne die Fakultät von [gerade zahl]: 5
        // 5! = 1*2*3*4*5 = 120
        System.out.print("Berechne Fakultät von: ");
        grenze = scanner.nextInt();
        long fakultaet = 1;
        String rechnung = "";

        for (int i = 1; i <= grenze; i++) {
            fakultaet *= i;
            rechnung += (i != grenze) ? i+"*" : i;
        }

        System.out.println(grenze + "! = " + rechnung + " = "+ fakultaet);
        System.out.println();

        // 9. Multiplikationstabelle
        // Erstelle eine Multiplikationstabelle von 1 bis 5. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        // Beispiel:
        // Berechne die Multiplikationstabelle von 1 bis [gerade zahl]: 5
        //     1   2   3   4   5
        //     ------------------
        // 1 | 1   2   3   4   5
        // 2 | 2   4   6   8   10
        // 3 | 3   6   9   12  15
        // 4 | 4   8   12  16  20
        // 5 | 5   10  15  20  25
        System.out.print("Grenze für Multiplikationstabelle: ");
        grenze = scanner.nextInt();
        System.out.print("\t");

        for (int i = 1; i <= grenze; i++) {
            System.out.print(i + "\t");
        }

        System.out.println();
        System.out.println("  \t\t" + "----".repeat(grenze));

        for (int i = 1; i <= grenze; i++) {
            System.out.print(i + "\t|\t");

            for (int j = 1; j <= grenze; j++) {
                System.out.print(i * j + "\t");
            }

            System.out.println();
        }

        System.out.println();

        // 10. Fibonacci-Zahlen
        // For-Schleife, welche die ersten 10 Fibonacci-Zahlen ausgibt.
        // Die ersten beiden Fibonacci-Zahlen sind 0 und 1, und jede weitere Zahl ist die Summe der beiden vorherigen.
        // Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 10 beliebig anpassen kann.
        // Genauer:
        // * Die **0.** Fibonacci-Zahl ist... **``0``**, also **``fib(0) = 0``**..
        // * Die **1.** Fibonacci-Zahl ist... **``1``**, also **``fib(1) = 1``**..
        // * Die **2.** Fibonacci-Zahl ist... die Summe aus der **0.** Fibonacci-Zahl, welche ``0`` ist und der **1.** Fibonacci-Zahl, welche ``1`` ist, also **``fib(2) = 1``**.
        // * Die **3.** Fibonacci-Zahl ist... die Summe aus der **1.** Fibonacci-Zahl, welche ``1`` ist und der **2.** Fibonacci-Zahl, welche ``1`` ist, also **``fib(2) = 2``**.
        // * Die **4.** Fibonacci-Zahl ist... die Summe aus der **2.** Fibonacci-Zahl, welche ``1`` ist und der **3.** Fibonacci-Zahl, welche ``2`` ist, also **``fib(2) = 3``**.
        // * Die **5.** Fibonacci-Zahl ist... die Summe aus der **3.** Fibonacci-Zahl, welche ``2`` ist und der **4.** Fibonacci-Zahl, welche ``3`` ist, also **``fib(2) = 5``**.
        // * Die **6.** Fibonacci-Zahl ist... die Summe aus der **4.** Fibonacci-Zahl, welche ``3`` ist und der **5.** Fibonacci-Zahl, welche ``5`` ist, also **``fib(2) = 8``**.
        // * Die **7.** Fibonacci-Zahl ist... die Summe aus der **5.** Fibonacci-Zahl, welche ``5`` ist und der **6.** Fibonacci-Zahl, welche ``8`` ist, also **``fib(2) = 13``**.
        // * ...
        // * Die **n.** Fibonacci-Zahl ist... die Summe aus der **n-2.** Fibonacci-Zahl, welche ``fib(n-2)`` ist und der **n-1.**, welche ``fib(n-1)`` ist, also **``fib(n)``**.

        // Beispiel:
        // Berechne die Fibonacci-Zahlen von 1 bis [gerade zahl]: 7
        // fib(7) = 0 + 1 + 1 + 2 + 3 + 5 + 8 = 13

        // Berechne die Fibonacci-Zahlen von 1 bis [gerade zahl]: 10
        // fib(10) = 0 + 1 + 1 + 2 + 3 + 5 + 8 + 13 + 21 + 34 = 55

        // Berechne die Fibonacci-Zahlen von 1 bis [gerade zahl]: 15
        // fib(15) = 0 + 1 + 1 + 2 + 3 + 5 + 8 + 13 + 21 + 34 + 55 + 89 + 144 + 233 + 377 = 610
        System.out.print("Wie viele Fibonacci-Zahlen berechnen? ");
        grenze = scanner.nextInt();
        int fibCurrent = 0, fibNext = 1;
        System.out.print(fibCurrent + "+" + fibNext);

        for (int i = 0; i < grenze - 1; i++) {
            int temp = fibCurrent + fibNext;
            fibCurrent = fibNext;
            fibNext = temp;

            System.out.print(i == grenze-2 ? " = " + fibNext : "+" + fibNext);
        }

        System.out.println();
        System.out.println();

        // **Optional und für sehr fortgeschrittene:**
        // Lese im Internet über Rekursion nach und versuche dieses Problem damit zu lösen. Rekursion ist seltenst relevant für moderne Programmierstile, aber als **Denkansatz** interessant und zeigt was **Methoden** und **Funktionen** können.
        // Schlagwörter: Funktion/Methode, Recursion, Tail/Head - Recursion

        // 11. Teiler einer Zahl ausgeben
        // For-Schleife, welche alle Teiler der Zahl ``z = 40`` ausgibt. Eien Zahl ``t`` teilt eine andere Zahl ``z``, wenn ``z/t keinen Rest ergibt``. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 40 beliebig anpassen kann.
        // Optional: färbe die Ausgabe rot, wenn der User eine Primzahl eingibt. Eine Primzahl ``p`` ist eine Zahl welche nur ``1`` und ``p`` als Teiler hat.
        // Beispiel:
        // Berechne die Teiler der Zahl [ganze Zahl]: 40
        // teiler(40) = 1, 2, 4, 5, 8, 10, 20, 40

        // Berechne die Teiler der Zahl [ganze Zahl]: 7
        // teiler(7) = 1, 7

        System.out.print("Gib eine Zahl ein um Teiler zu berechnen: ");
        grenze = scanner.nextInt();
        String ergebnis = "teiler(" + grenze + ") = ";
        boolean hatZweiAlsTeiler = false;
        boolean hatZahlSelbstAlsTeiler = false;
        boolean keinePrimzahl = false;

        for (int teiler = 1; teiler <= grenze; teiler++) {
            if (grenze % teiler == 0) {
                ergebnis += teiler + " ";

                if (teiler == 1) {
                    hatZweiAlsTeiler = true;
                } else if (teiler == grenze) {
                    hatZahlSelbstAlsTeiler = true;
                } else {
                    keinePrimzahl = true;
                }
            }
        }

        if (hatZweiAlsTeiler && hatZahlSelbstAlsTeiler && !keinePrimzahl) {
            System.out.println(RED + ergebnis + RESET);
        } else {
            System.out.println(ergebnis);
        }

        System.out.println();

        // 12. Potenzen
        // For-Schleife, welche die ersten 10 Potenzen von 2 ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 10 sowie 2 beliebig anpassen kann.
        // *Hinweis: Mit ``Math.Pow(x,y)``* kann x<sup>y</sup> dargestellt werden (*x* wird die *Basis* genannt und *y* der *Exponent*).
        // Beispiel:
        // Ich wähle die Basis [ganze Zahl]: 2
        // ... und den Exponenten [ganze Zahl]: 10
        // pow(2,1)    = 2
        // pow(2,2)    = 4
        // pow(2,3)    = 8
        // pow(2,4)    = 16
        // pow(2,5)    = 32
        // pow(2,6)    = 64
        // pow(2,7)    = 128
        // pow(2,8)    = 256
        // pow(2,9)    = 512
        // pow(2,10)   = 1024

        // Ich wähle die Basis [ganze Zahl]: 3
        // ... und den Exponenten [ganze Zahl]: 4
        // pow(3,1) = 3
        // pow(3,2) = 9
        // pow(3,3) = 27
        // pow(3,4) = 81

        // Optional: Füge einen Tabulator ``\t`` ein, falls nicht alle Zahlen in der Ausgabe untereinander stehen können.
        // Hinweis: Verwende "\t".repeat(2) um z.B. 2 Tabulatoren einzufügen. Berechne die Anzahl der Tabulatoren mit String.valueOf(exponentGrenze).length() - 1;
        System.out.print("Basis für Potenzen: ");
        int basis = scanner.nextInt();
        System.out.print("Exponenten-Grenze: ");
        int exponentGrenze = scanner.nextInt();
        int anzahlTabulatoren = String.valueOf(exponentGrenze).length() - 1;

        for (int i = 1; i <= exponentGrenze; i++) {
            System.out.println("pow(" + basis + "," + i + ")" + "\t".repeat(anzahlTabulatoren) + " = " + (int) Math.pow(basis, i));
        }

        System.out.println();

        // Formen ausgeben - Dreieck:
        // Erstelle die folgenden Formen mit der größe 5. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        // 0. 🙂 "Canvas ausmahlen"
        // 🔹🔹🔹🔹🔹
        // 🔹🔹🔹🔹🔹
        // 🔹🔹🔹🔹🔹
        // 🔹🔹🔹🔹🔹
        // 🔹🔹🔹🔹🔹
        // *Hinweis: Versuche die erste Zeile der Form mit System.out.**print**() auszugeben. Wir **wiederholen** also den Befehl System.out.**print**() 5 mal und schreiben am Ende **\n**. Wiederhole nun den vorherigen Code 5 mal um 5 Zeilen der Form zu erstellen.*

        System.out.print("Gib die größe des Musters ein [zahl]: ");
        int groesseSpielfeld = scanner.nextInt();

        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                System.out.print("🔹");
            }
            System.out.println();
        }

        System.out.println();

        // 1. 🤔 Dreieck
        // ❎0️⃣1️⃣2️⃣3️⃣4️⃣
        // 0️⃣⬜🔹🔹🔹🔹
        // 1️⃣⬜⬜🔹🔹🔹
        // 2️⃣⬜⬜⬜🔹🔹
        // 3️⃣⬜⬜⬜⬜🔹
        // 4️⃣⬜⬜⬜⬜⬜
        // *Hinweis: Schreibe dir Zahlen in die Zeilen und Spalten. Was ist die **Bedingung** für die "Trennlinie" der weißen und blauen blöcke?*
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();

        // 2. 🤔 Dreieck über X-Achse "spiegeln"
        // ⬜⬜⬜⬜⬜
        // ⬜⬜⬜⬜🔹
        // ⬜⬜⬜🔹🔹
        // ⬜⬜🔹🔹🔹
        // ⬜🔹🔹🔹🔹
        // *Hinweis: Die **erste** Zeile dieses Dreieck ist die **letzte** Zeile des vorherigen Dreiecks. Denke an "zähle mit For von **0 bis 4** vs. von **4 bis 0**".*
        for (int zeilen = groesseSpielfeld - 1; zeilen >= 0; zeilen--) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();

        // 3. 😢 Dreieck über y-Achse "spiegeln"
        // ⬜⬜⬜⬜⬜
        // 🔹⬜⬜⬜⬜
        // 🔹🔹⬜⬜⬜
        // 🔹🔹🔹⬜⬜
        // 🔹🔹🔹🔹⬜
        // *Hinweis: **Tausche** die blauen und weißen gedanklich aus. Haben wir dieses Muster bereits erstellt?*
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                // Negation/Gegenteil von zeilen >= spalten ist zeilen < spalten.
                // Wir brauchen aber noch die Diagonale also zeilen <= spalten.
                if (zeilen <= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();


        // 4. 😢 Dreieck wieder über X-Achse "spiegeln"
        // 🔹🔹🔹🔹⬜
        // 🔹🔹🔹⬜⬜
        // 🔹🔹⬜⬜⬜
        // 🔹⬜⬜⬜⬜
        // ⬜⬜⬜⬜⬜
        // *Hinweis: Die **erste** Zeile dieses Dreieck ist die **letzte** Zeile des vorherigen Dreiecks. Denke an "zähle mit For von **0 bis 4** vs. von **4 bis 0**".*
        for (int zeilen = groesseSpielfeld - 1; zeilen >= 0; zeilen--) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen <= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();

        // 5. 🙂 Langes Dreieck zusammenbauen
        // ⬜🔹🔹🔹🔹
        // ⬜⬜🔹🔹🔹
        // ⬜⬜⬜🔹🔹
        // ⬜⬜⬜⬜🔹
        // ⬜⬜⬜⬜⬜
        // ⬜⬜⬜⬜⬜
        // ⬜⬜⬜⬜🔹
        // ⬜⬜⬜🔹🔹
        // ⬜⬜🔹🔹🔹
        // ⬜🔹🔹🔹🔹
        // *Hinweis: Wir haben den Code für die beiden Einzelteile. Wie muss ich die For schleifen schreiben damit diese untereinander ausgegeben werden?*
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        for (int zeilen = groesseSpielfeld - 1; zeilen >= 0; zeilen--) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();

        // 6. 🤔 Langes Dreieck spitz zusammenbauen
        // ⬜🔹🔹🔹🔹
        // ⬜⬜🔹🔹🔹
        // ⬜⬜⬜🔹🔹
        // ⬜⬜⬜⬜🔹
        // ⬜⬜⬜⬜⬜
        // ⬜⬜⬜⬜🔹
        // ⬜⬜⬜🔹🔹
        // ⬜⬜🔹🔹🔹
        // ⬜🔹🔹🔹🔹
        // *Hinweis: Wie steuern wir die Anzahl der Zeilen des unteren Dreiecks?*
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        for (int zeilen = groesseSpielfeld - 2; zeilen >= 0; zeilen--) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();

        // 7. 💀 Diamant aus Dreiecken bauen
        // 🔹🔹🔹🔹⬜⬜🔹🔹🔹🔹
        // 🔹🔹🔹⬜⬜⬜⬜🔹🔹🔹
        // 🔹🔹⬜⬜⬜⬜⬜⬜🔹🔹
        // 🔹⬜⬜⬜⬜⬜⬜⬜⬜🔹
        // ⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
        // ⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
        // 🔹⬜⬜⬜⬜⬜⬜⬜⬜🔹
        // 🔹🔹⬜⬜⬜⬜⬜⬜🔹🔹
        // 🔹🔹🔹⬜⬜⬜⬜🔹🔹🔹
        // 🔹🔹🔹🔹⬜⬜🔹🔹🔹🔹
        // *Hinweis: Wie schaffe ich es in der ersten Zeile einmal den Code für das linke Dreick und danach in der gleichen Zeile den Code für das andere Dreieck aufzurufen?*
        for (int zeilen = groesseSpielfeld - 1; zeilen >= 0; zeilen--) {
            // links oben
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (spalten >= zeilen) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            // rechts oben
            int verkehrzeZeilen = groesseSpielfeld - 1 - zeilen;
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (verkehrzeZeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            System.out.println();
        }

        // mustergenerierung
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            // links unten
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (spalten >= zeilen) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            // rechts unten
            int verkehrzeZeilen = groesseSpielfeld - 1 - zeilen;
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (verkehrzeZeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            System.out.println();
        }

        System.out.println();

        // kompakte Variante: Lösungsansatz siehe - 9. 💀☠️💀 Diamant spitz aus Dreiecken bauen - ohne vorherigen Code zu kopieren
        int breite = 2 * groesseSpielfeld;

        for (int zeile = 0; zeile < breite; zeile++) {
            for (int spalte = 0; spalte < breite; spalte++) {

                // abstand zur mitte berechnen
                // Ist hier schwerer wie bei de mSpitz, da wir hier uns auf +2 und -2 ist das Gleiche verlassen.
                // Durch Math.abs() wird beides 2.
                // Was passiert aber bei 0? Wir haben nur eine 0.
                // Deshalb ist hier ein If-Ausdruck, welcher ab der Mitte so tut als wir noch einmal in der Mitte wären.
                // Wir ziehen deshalb -1 noch zusätzlich ab.
                int abstandZurMitteZeile =
                        zeile >= groesseSpielfeld ?
                                Math.abs(groesseSpielfeld - 1 - zeile) - 1 :
                                Math.abs(groesseSpielfeld - 1 - zeile);

                int abstandZurMitteSpalte =
                        spalte >= groesseSpielfeld ?
                                Math.abs(groesseSpielfeld - 1 - spalte) - 1 :
                                Math.abs(groesseSpielfeld - 1 - spalte);

                // sind innerhalb der Raute sind
                if (abstandZurMitteSpalte <= groesseSpielfeld - 1 - abstandZurMitteZeile) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();

        // 8. 💀 Diamant spitz aus Dreiecken bauen
        // 🔹🔹🔹🔹⬜🔹🔹🔹🔹
        // 🔹🔹🔹⬜⬜⬜🔹🔹🔹
        // 🔹🔹⬜⬜⬜⬜⬜🔹🔹
        // 🔹⬜⬜⬜⬜⬜⬜⬜🔹
        // ⬜⬜⬜⬜⬜⬜⬜⬜⬜
        // 🔹⬜⬜⬜⬜⬜⬜⬜🔹
        // 🔹🔹⬜⬜⬜⬜⬜🔹🔹
        // 🔹🔹🔹⬜⬜⬜🔹🔹🔹
        // 🔹🔹🔹🔹⬜🔹🔹🔹🔹
        for (int zeilen = groesseSpielfeld - 1; zeilen >= 0; zeilen--) {
            // links oben
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (spalten >= zeilen) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            // rechts oben
            int verkehrzeZeilen = groesseSpielfeld - 1 - zeilen;
            for (int spalten = 1; spalten < groesseSpielfeld; spalten++) {
                if (verkehrzeZeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            System.out.println();
        }

        for (int zeilen = 1; zeilen < groesseSpielfeld; zeilen++) {
            // links unten
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (spalten >= zeilen) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            // rechts unten
            int verkehrzeZeilen = groesseSpielfeld - 1 - zeilen;
            for (int spalten = 1; spalten < groesseSpielfeld; spalten++) {
                if (verkehrzeZeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }

            System.out.println();
        }

        System.out.println();

        // 9. 💀☠️💀 Diamant spitz aus Dreiecken bauen - ohne vorherigen Code zu kopieren
        // Wir können den Code stark verkürzen wenn wir uns den **Abstand** der aktuellen Spalte ``int abstandZurMitteSpalte = Math.abs(groesseSpielfeld - 1 - spalte);`` und Zeile den Diagonalen ausrechnen ``int abstandZurMitteZeile = Math.abs(groesseSpielfeld - 1 - zeile);``. Hier ist ``zeile`` der Zählindex der äußeren Schleife, ``spalte`` der Zählindex der inneren Schleife und ``Math.abs()`` der absolute Wert einer Zahl (heißt Vorzeichen weg). Siehe Bild unten. Dieser **Abstand** von z.B. dem **<span style="color:green">grünen</span>** Viereck zu den **<span style="color:red">roten</span>** Diagonalen ist jeweils 2. Es ist auch der **Abstand** des **<span style="color:violet">violetten</span>** Vierecks 2. Wenn wir diese Abstände ausrechnen können, schaffen wir eine ähnliche **Bedingung** wie ``zeile >= spalte`` für die "Trennlinie" der Dreiecke zu finden?
        // * Überlege nun für die **<span style="color:orange">orangen</span>** Vierecke was ist der summierte Abstand von ``abstandZurMitteSpalte + abstandZurMitteZeile`` zu der **<span style="color:red">roten</span>** Diagonale?* Dieser ist hier immer 4.
        // * Wie rechne ich jedoch aus dass **4** so eine spezielle zahl hier ist? Es scheint die ``groesseSpielfeld - 1`` zu sein.
        // * Was ist nun die Bedingung dass wir **auf** dieser **<span style="color:orange">orangen</span>** linie sind?
        // * Was ist nun die Bedingung dass wir **innerhalb** dieser **<span style="color:orange">orangen</span>** linie sind?
        // * Was ist nun die Bedingung dass wir **innerhalb** udn **auf** dieser **<span style="color:orange">orangen</span>** linie sind?
        // 🔹🔹🔹🔹🟥🔹🔹🔹🔹
        // 🔹🔹🔹🟨🟥🟨🔹🔹🔹
        // 🔹🔹🟨⬜🟥⬜🟩🔹🔹
        // 🔹🟨⬜⬜🟥⬜⬜🟨🔹
        // 🟥🟥🟥🟥🟥🟥🟥🟥🟥
        // 🔹🟨⬜⬜🟥⬜⬜🟨🔹
        // 🔹🔹🟪⬜🟥⬜🟨🔹🔹
        // 🔹🔹🔹🟨🟥🟨🔹🔹🔹
        // 🔹🔹🔹🔹🟥🔹🔹🔹🔹

        // **Anmerkung:** Wir werden in L12 nochmals diese Form uns anschauen, denn wir können allgmein durch Spiegeln und zusammenfügen von Dreiecken diese Formen erzeugen. Warum schreiben wir nicht einen allgemeinen Code der uns einfach spiegeln lässt und einen der uns zusammenfügen lässt? Wir brauchen dazu noch ``Arrays`` und ``Funktionen`` als Werkzeug.
        breite = 2 * groesseSpielfeld - 1;

        for (int zeile = 0; zeile < breite; zeile++) {
            for (int spalte = 0; spalte < breite; spalte++) {

                // abstand zur mitte berechnen
                int abstandZurMitteZeile = Math.abs(groesseSpielfeld - 1 - zeile);
                int abstandZurMitteSpalte = Math.abs(groesseSpielfeld - 1 - spalte);

                // sind innerhalb der Raute sind
                if (abstandZurMitteSpalte + abstandZurMitteZeile <= groesseSpielfeld - 1) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        System.out.println();

        // ---

        // Formen mit Zahlen - ausgefüllt:
        // 1
        // 12
        // 123
        // 1234
        // 12345
        // Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        for (int i = 1; i <= groesseSpielfeld; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.print(j);
            }
            System.out.println();
        }

        System.out.println();

        // Formen mit Zahlen - nur am Rand:
        // 5
        // -4
        // --3
        // ---2
        // ----1
        // Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        for (int i = groesseSpielfeld; i >= 1; i--) {
            for (int j = 1; j <= groesseSpielfeld - i; j++) {
                System.out.print("-");
            }
            System.out.println(i);
        }

        System.out.println();

        // Formen mit Zahlen - Diagonale bis zur mitte Zählen
        // 5----
        // -4---
        // --3--
        // ---4-
        // ----5

        // 6-----
        // -5----
        // --4---
        // ---4--
        // ----5-
        // -----6
        // Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        for (int i = 0; i < groesseSpielfeld; i++) {
            for (int j = 0; j < groesseSpielfeld; j++) {
                int zeile = i < groesseSpielfeld / 2 ? i : groesseSpielfeld - i - 1;

                if (i == j) {
                    System.out.print((groesseSpielfeld - zeile));
                } else {
                    System.out.print("-");
                }
            }
            System.out.println();
        }

        System.out.println();

        // Formen mit Zahlen - Beide Diagonalen bis zur mitte Zählen
        // 5---1
        // -4-2-
        // --3--
        // -2-4-
        // 1---5

        // 6----1
        // -5--2-
        // --43--
        // --34--
        // -2--5-
        // 1----6
        // Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        for (int i = 0; i < groesseSpielfeld; i++) {
            for (int j = 0; j < groesseSpielfeld; j++) {
                int zeile = i < groesseSpielfeld / 2 ? i : groesseSpielfeld - i - 1;

                if (i == j) {
                    System.out.print(groesseSpielfeld - zeile);
                } else if (i + j == groesseSpielfeld - 1) {
                    System.out.print(zeile + 1);
                } else {
                    System.out.print("-");
                }
            }
            System.out.println();
        }

        System.out.println();

        // Formen mit Zahlen - Kreuz bis zur mitte Zählen
        // --5--
        // --4--
        // 12321
        // --4--
        // --5--

        // ---6--
        // ---5--
        // ---4--
        // 123321
        // ---5--
        // ---6--
        // Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        int mid = groesseSpielfeld / 2;

        for (int i = 0; i < groesseSpielfeld; i++) {
            for (int j = 0; j < groesseSpielfeld; j++) {
                int zeile = i < groesseSpielfeld / 2 ? i : groesseSpielfeld - i - 1;

                if (j == mid && i != mid) {
                    System.out.print(groesseSpielfeld - zeile);
                } else if (i == mid) {
                    int spalte = j < groesseSpielfeld / 2 ? j : groesseSpielfeld - j - 1;
                    System.out.print(spalte + 1);
                } else {
                    System.out.print("-");
                }
            }
            System.out.println();
        }

        System.out.println();

        // Formen mit Zahlen - Ziffernquadrat
        // 0 1 2 3 4 5 6 7 8 9
        // 1                 8
        // 2                 7
        // 3                 6
        // 4                 5
        // 5                 4
        // 6                 3
        // 7                 2
        // 8                 1
        // 9 8 7 6 5 4 3 2 1 0
        // Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 10 beliebig anpassen kann.
        // *Hinmweis:* Die "Leere" inder Mitte sind Leerzeichen.

        // Variante 1 - Siehe Angabe für Farben:
        for (int zeile = 0; zeile < groesseSpielfeld; zeile++) {
            for (int spalte = 0; spalte < groesseSpielfeld; spalte++) {
                if (zeile == 0) {
                    System.out.print(BLUE + (spalte + 1) + RESET + " ");

                } else if (zeile == groesseSpielfeld - 1) {
                    System.out.print(GREEN + (groesseSpielfeld - spalte) + RESET + " ");

                } else if (spalte == groesseSpielfeld - 1 && 1 <= zeile && zeile <= groesseSpielfeld - 2 ) {
                    System.out.print(RED + (groesseSpielfeld - zeile) + RESET + " ");

                } else if (spalte == 0 && 1 <= zeile && zeile <= groesseSpielfeld - 2) {
                    System.out.print(WHITE + (zeile + 1) + RESET + " ");

                } else {
                    System.out.print("  ");
                }
            }

            System.out.println();
        }

        System.out.println();

        // Variante 2 - Siehe Angabe für Farben
        for (int zeile = 0; zeile < groesseSpielfeld; zeile++) {
            for (int spalte = 0; spalte < groesseSpielfeld; spalte++) {
                if (zeile == 0 && 1 <= spalte && spalte <= groesseSpielfeld - 2 ) {
                    System.out.print(BLUE + (spalte + 1) + RESET + " ");

                } else if (zeile == groesseSpielfeld - 1 && 1 <= spalte && spalte <= groesseSpielfeld - 2 ) {
                    System.out.print(GREEN + (groesseSpielfeld - spalte) + RESET + " ");

                } else if (spalte == groesseSpielfeld - 1) {
                    System.out.print(RED + (groesseSpielfeld - zeile) + RESET + " ");

                } else if (spalte == 0) {
                    System.out.print(WHITE + (zeile + 1) + RESET + " ");

                } else {
                    System.out.print("  ");
                }
            }

            System.out.println();
        }

        System.out.println();

        // Matrix
        // Schreiben Sie ein Programm, das die Zahlen 0 bis 99 in einer 10x10 Matrix ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 10 beliebig anpassen kann.
        // Beispiel:
        //  0  1    2   3   4   5   6   7   8   9
        // 10  11  12  13  14  15  16  17  18  19
        // 20  21  22  23  24  25  26  27  28  29
        // 30  31  32  33  34  35  36  37  38  39
        // 40  41  42  43  44  45  46  47  48  49
        // 50  51  52  53  54  55  56  57  58  59
        // 60  61  62  63  64  65  66  67  68  69
        // 70  71  72  73  74  75  76  77  78  79
        // 80  81  82  83  84  85  86  87  88  89
        // 90  91  92  93  94  95  96  97  98  99

        // 0   1   2   3   4   5   6   7   8   9  10
        // 11  12  13  14  15  16  17  18  19  20  21
        // 22  23  24  25  26  27  28  29  30  31  32
        // 33  34  35  36  37  38  39  40  41  42  43
        // 44  45  46  47  48  49  50  51  52  53  54
        // 55  56  57  58  59  60  61  62  63  64  65
        // 66  67  68  69  70  71  72  73  74  75  76
        // 77  78  79  80  81  82  83  84  85  86  87
        // 88  89  90  91  92  93  94  95  96  97  98
        // 99 100 101 102 103 104 105 106 107 108 109
        // 110 111 112 113 114 115 116 117 118 119 120

        // Hinweis: Verwenden Sie `System.out.printf("%3d", i);` zur Formatierung der Zahlen, falls eine zweistellige Zahl angegeben wird.
        // Es werden 3 Stellen erzeugt z.B. "22 ". Falls der User eine dreistellige Zahl eingibt, verwende `System.out.printf("%4d", i);`
        // Berechne die Anzahl der Stellen mit `String.valueOf(anzahlFelder).length() + 1;`

        int anzahlFelder = (int) Math.pow(groesseSpielfeld, 2);
        int anzahlStellen = String.valueOf(anzahlFelder).length() + 1;

        for (int i = 0; i < anzahlFelder; i++) {
            System.out.printf("%"+ anzahlStellen +"d", i);
            if ((i + 1) % groesseSpielfeld == 0) {
                System.out.println();
            }
        }

        System.out.println();

        // Die halbe Matrix
        // Schreiben Sie ein Programm, das die Zahlen 0 bis *15 = (5 * (5 + 1)) / 2* in einer 5x5 Matrix ausgibt. Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
        // Beispiel für input 10 -> (10 * 11)/2 = 55 Symbole:
        // .  .  .  .  .  .  .  .  .  01
        // .  .  .  .  .  .  .  .  02 03
        // .  .  .  .  .  .  .  04 05 06
        // .  .  .  .  .  .  07 08 09 10
        // .  .  .  .  .  11 12 13 14 15
        // .  .  .  .  16 17 18 19 20 21
        // .  .  .  22 23 24 25 26 27 28
        // .  .  29 30 31 32 33 34 35 36
        // .  37 38 39 40 41 42 43 44 45
        // 46 47 48 49 50 51 52 53 54 55

        // Beispiel für input 15 -> (15 * 16)/2 = 120 Symbole:
        // .   .   .   .   .   .   .   .   .   .   .   .   .   .   001
        // .   .   .   .   .   .   .   .   .   .   .   .   .   002 003
        // .   .   .   .   .   .   .   .   .   .   .   .   004 005 006
        // .   .   .   .   .   .   .   .   .   .   .   007 008 009 010
        // .   .   .   .   .   .   .   .   .   .   011 012 013 014 015
        // .   .   .   .   .   .   .   .   .   016 017 018 019 020 021
        // .   .   .   .   .   .   .   .   022 023 024 025 026 027 028
        // .   .   .   .   .   .   .   029 030 031 032 033 034 035 036
        // .   .   .   .   .   .   037 038 039 040 041 042 043 044 045
        // .   .   .   .   .   046 047 048 049 050 051 052 053 054 055
        // .   .   .   .   056 057 058 059 060 061 062 063 064 065 066
        // .   .   .   067 068 069 070 071 072 073 074 075 076 077 078
        // .   .   079 080 081 082 083 084 085 086 087 088 089 090 091
        // .   092 093 094 095 096 097 098 099 100 101 102 103 104 105
        // 106 107 108 109 110 111 112 113 114 115 116 117 118 119 120

        int counter = 1;
        anzahlFelder = (int) Math.pow(groesseSpielfeld, 2) / 2;
        anzahlStellen = String.valueOf(anzahlFelder).length();
        String StellenNebenTrennsymbolLinks = " ".repeat(anzahlStellen/2);
        String StellenNebenTrennsymbolRechts =
            anzahlStellen % 2 == 0 ?
                " ".repeat(anzahlStellen/2) :
                " ".repeat(anzahlStellen/2 + 1);

        for (int i = 0; i < groesseSpielfeld; i++) {
            for (int j = 0; j < groesseSpielfeld; j++) {
                if (j >= groesseSpielfeld - i - 1) {
                    String line = String.format("%0"+ anzahlStellen +"d", counter++);
                    System.out.print(" " + line);
                } else {
                    System.out.print(StellenNebenTrennsymbolLinks + "." + StellenNebenTrennsymbolRechts);
                }
            }
            System.out.println();
        }

        System.out.println();
        scanner.nextLine(); // Achtung, da wir im nächsten Beispiel scanner.nextLine() verwenden, müss der letzte Aufruf von
        // scanner.next(); bzw. scanner.nextInt(); mit scanner.nextLine() korrigiert werden. Wir lassen ansonst ein "\n" übrig welches
        // auf scanner.nextLine(); matcht. Wir verlieren dadurch einen Userinput. Es kann passieren, dass wir, obwohl wir 3 eingeben nur 1 passwort generieren.

        // ---

        // For und While Schleife gemischt

        // Passwort Generator
        // Schreiben Sie ein Programm, dass zufällige Passwörter generiert.
        // Fragen Sie hierzu den Benutzer folgende Fragen:
        // * Soll das Passwort Großbuchstaben beinhalten?
        // * Soll das Passwort Ziffern beinhalten?
        // * Soll das Passwort Sonderzeichen beinhalten?
        // * Wie lang soll das Passwort sein?
        // * Fragen Sie den Benutzer wie viele Passwörter generiert werden sollen
        // Erweitere das Programm so, dass der Benutzer die Erzeugung der Passwörter wiederholen kann.
        // Hinweis: Verwende für die Wahl der Symbole folgende variablen, welche final sind.
        // Bedeutet diese können nicht mehr im Programm verändert werden.
        // final String KLEINBUCHSTABEN = "abcdefghijklmnopqrstuvwxyz";
        // final String GRO?BUCHSTABEN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // final String ZIFFERN = "0123456789";
        // final String SONDERNZEICHEN = "!\"§$%&/()=?{[]}\\@#*+~^.,;:-_<>|";

        // Beispiel:
        // Soll das Passwort Großbuchstaben beinhalten [+/-]? +
        // Soll das Passwort Ziffern beinhalten [+/-]? +
        // Soll das Passwort Sonderzeichen beinhalten [+/-]? +
        // Wie lang soll das Passwort sein [ganze Zahl]? 10
        // Wie viele Passwörter sollen generiert werden? 3
        // Es wurden:
        // 2G4fm"V2g8
        // u710/&8GP!
        // Atn6a47*]e
        // generiert
        // Neue Passwörter generieren [+/-]? +
        // Soll das Passwort Großbuchstaben beinhalten [+/-]? -
        // Soll das Passwort Ziffern beinhalten [+/-]? -
        // Soll das Passwort Sonderzeichen beinhalten [+/-]? -
        // Wie lang soll das Passwort sein [ganze Zahl]? 2
        // Wie viele Passwörter sollen generiert werden? 1
        // Es wurden:
        // ap
        // generiert
        // Neue Passwörter generieren [+/-]? -
        // Programm wurde auf Wunsch des Benutzers beendet.

        Random random = new Random();
        Boolean nochmal = true;

        while (nochmal) {
            final String kleinbuchstaben = "abcdefghijklmnopqrstuvwxyz";
            final String grossbuchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            final String ziffern = "0123456789";
            final String sonderzeichen = "!\"§$%&/()=?{[]}\\@#*+~^.,;:-_<>|";

            String zeichenpool = kleinbuchstaben;

            System.out.print("Soll das Passwort Großbuchstaben beinhalten [+/-]? ");
            String eingabeGross = scanner.nextLine();

            if (eingabeGross.equals("+")) {
                zeichenpool += grossbuchstaben;
            }

            System.out.print("Soll das Passwort Ziffern beinhalten [+/-]? ");
            String eingabeZahl = scanner.nextLine();

            if (eingabeZahl.equals("+")) {
                zeichenpool += ziffern;
            }

            System.out.print("Soll das Passwort Sonderzeichen beinhalten [+/-]? ");
            String eingabeSonder = scanner.nextLine();
            if (eingabeSonder.equals("+")) {
                zeichenpool += sonderzeichen;
            }

            System.out.print("Wie lang soll das Passwort sein [ganze Zahl]? ");
            int passwortLaenge = Integer.parseInt(scanner.nextLine());

            System.out.print("Wie viele Passwörter sollen generiert werden? ");
            int anzahl = Integer.parseInt(scanner.nextLine());

            System.out.println("Es wurden:");
            for (int i = 0; i < anzahl; i++) {
                String passwort = "";
                int zeichenpoolLaenge = zeichenpool.length();

                for (int j = 0; j < passwortLaenge; j++) {
                    int index = random.nextInt(zeichenpoolLaenge);
                    passwort += zeichenpool.charAt(index);
                }

                System.out.println(passwort);
            }
            System.out.println("generiert.");
            System.out.println();

            System.out.print("Neue Passwörter generieren [+/-]? ");
            do {
                nochmal = switch(scanner.nextLine()) {
                    case "+" -> true;
                    case "-" -> {
                        System.out.println("Programm wurde auf Wunsch des Benutzers beendet.");
                        yield false;
                    }
                    default -> {
                        System.out.println("Bitte '+' ein, um neue Passwörter zu generieren oder '-' um das Programm zu beenden.");
                        yield null;
                    }

                };
            } while(nochmal == null);
        }

        System.out.println();

        // Guess the Word
        // Entwickeln Sie das Spiel "Hangman" in Java. Das Spiel sollte folgende Funktionen haben:
        // * Fragen Sie den Benutzer nach einem Wort mit 3 Buchstaben. Die Zahl 3 soll in der Konstante Länge gespeichert werden und somit einfach veränderbar sein.
        // * Ist das Wort zu lang oder leer, soll eine Fehlermeldung ausgegeben werden und erneut angefragt werden.
        // * Anzeige des Status des Wortes, das der Spieler erraten muss (zum Beispiel als Striche (_), die die Buchstaben repräsentieren).
        // * Eine Schleife, die dem Spieler erlaubt, Buchstaben zu raten, bis das Wort vollständig erraten oder der Galgenmann "vollständig gehängt" ist. (Groß-/Kleinschreibung soll egal sein)
        // * Begrenzung der Anzahl der Fehlversuche des Spielers (zum Beispiel sechs Fehlversuche, bevor das
        // Spiel endet).
        // * Überprüfung der Eingaben des Spielers und Aktualisierung des Spielstands entsprechend der
        // geratenen Buchstaben.
        // * Anzeige des Gewinns oder Verlusts des Spiels nach dem Ende der Spielrunde.
        // Beispielwörter mit 3 Buchstaben: Bau, Hut, Arm, Tag, Eis, Zoo, See
        // Beispielwörter mit 4 Buchstaben: Haus, Bahn, Tier, Buch, Fest
        // Optional: Führe das Programm im Terminal/Console aus und implementiere, dass das eingegebene Wort "verschwindet". Wir überschreiben die Zeile wo es ausgegeben wird. Verwende dazu die Konsolenbefehle

        // Hinweis: Verwende folgenden Ort für die Darstellung des Problems (siehe Vorlage):*
        // static void zeichneHangman(int fehler) {
        //     // switch ausdruck mit fehlerfällen oder 
        //     // kompakter if ausdrücke (siehe Lösung) 
        // }
        // public static void zeichneSharkFin(int fehlversuche) {
        //     // switch ausdruck mit den fehlerfällen
        // }
        // public static void zeichneEisbecher(int fehlversuche) {
        //     // switch ausdruck mit den fehlerfällen
        // }  
        // ```

        final int LÄNGE_DES_WORTES = 3;
        final int MAX_FEHLER = 6;
        String zuErratendesWort = "";

        do {
            System.out.print("Wähle das Wort mit " + LÄNGE_DES_WORTES + " Buchstaben (nicht sichtbar machen!): ");
            zuErratendesWort = scanner.nextLine().trim();

            if (zuErratendesWort.length() != LÄNGE_DES_WORTES) {
                System.out.println("Fehler: Das Wort muss genau " + LÄNGE_DES_WORTES + " Buchstaben lang sein.");
            }
        } while (zuErratendesWort.length() != LÄNGE_DES_WORTES);

        // "Verstecktes" Wort als _
        String geratenensWort = "";
        for (int i = 0; i < LÄNGE_DES_WORTES; i++) {
            geratenensWort += "_";
        }

        int fehler = 0;
        String bereitsGeraten = "";

        System.out.println();

        // Gameloop
        while (fehler < MAX_FEHLER && !geratenensWort.equalsIgnoreCase(zuErratendesWort)) {
            System.out.println("Wort: " + geratenensWort);
//            zeichneHangman(fehler);
//            zeichneSharkFin(fehler);
            zeichneEisbecher(fehler);

            System.out.print("Rate einen Buchstaben: ");
            String eingabe = scanner.nextLine().toLowerCase();

            if (eingabe.length() != 1 || !Character.isLetter(eingabe.charAt(0))) {
                System.out.println("Bitte gib genau einen Buchstaben ein.");
                continue;
            }

            String buchstabe = String.valueOf(eingabe.charAt(0));

            if (bereitsGeraten.contains(buchstabe)) {
                System.out.println("Diesen Buchstaben hast du bereits geraten.");
                continue;
            }

            bereitsGeraten += buchstabe;
            boolean treffer = false;

            for (int i = 0; i < LÄNGE_DES_WORTES; i++) {
                if (String.valueOf(zuErratendesWort.charAt(i)).toLowerCase().equals(buchstabe)) {
                    geratenensWort = geratenensWort.substring(0, i) + zuErratendesWort.charAt(i) + geratenensWort.substring(i + 1);
                    treffer = true;
                }
            }

            /*
            oder mit StringBuilder und indexOf
            StringBuilder angezeigtesWort = new StringBuilder(filler.repeat(LÄNGE_DES_WORTES));
            ...
            ...
            ...
            do {
                index = wortZuErraten.indexOf(korrekteEingabe, index+1);

                if (index != -1) {
                    anzeigeWort.replace(index, index+1, korrekteEingabe.toString());
                }

            } while (index >= 0);
             */

            if (!treffer) {
                fehler++;
            }
        }

        // Ausgabe am Spielende
        if (geratenensWort.equalsIgnoreCase(zuErratendesWort)) {
            System.out.println();
            System.out.println("Gewonnen! Das Wort war: " + zuErratendesWort);
        } else {
            System.out.println();
            System.out.println(geratenensWort);
            //            zeichneHangman(fehler);
//            zeichneSharkFin(fehler);
            zeichneEisbecher(fehler);
            System.out.println("Verloren. Das Wort war: " + zuErratendesWort);
        }

        scanner.close();
    }

    // Darstellung - Hangman
    // Beispiel:
    // Wähle das Wort ohne dass deine Mitspieler es sehen: Hut
    // Wort: _ _ _
    //     ____
    //    |    |
    //    |
    //    |
    //    |
    //   _|___
    // Rate einen Buchstaben: a
    // Wort: _ _ _
    //     ____
    //    |    |
    //    |    O
    //    |
    //    |
    //   _|___
    // Rate einen Buchstaben: b
    // Wort: _ _ _
    //     ____
    //    |    |
    //    |    O
    //    |    |
    //    |
    //   _|___
    // Rate einen Buchstaben: k
    // Wort: _ _ _
    //     ____
    //    |    |
    //    |    O
    //    |   /|
    //    |
    //   _|___
    // Rate einen Buchstaben: h
    // Wort: H _ _
    //     ____
    //    |    |
    //    |    O
    //    |   /|
    //    |
    //   _|___
    // Rate einen Buchstaben: e
    // Wort: H _ _
    //     ____
    //    |    |
    //    |    O
    //    |   /|\
    //    |
    //   _|___
    // Rate einen Buchstaben: u
    // Wort: H u _
    //     ____
    //    |    |
    //    |    O
    //    |   /|\
    //    |
    //   _|___
    // Rate einen Buchstaben: p
    // Wort: H u _
    //    ____
    //    |    |
    //    |    O
    //    |   /|\
    //    |   /
    //   _|___
    // Rate einen Buchstaben: g
    // Wort: H u _
    //     ____
    //    |    |
    //    |    O
    //    |   /|\
    //    |   / \
    //   _|___
    // Verloren. Das Wort war: Hut.
    static void zeichneHangman(int fehler) {
        System.out.println("  ____ ");
        System.out.println(" |    |");
        System.out.println(" |    " + (fehler >= 1 ? "O" : ""));
        System.out.print(" |   ");

        if (fehler == 2)
            System.out.print("|");
        else if (fehler == 3)
            System.out.print("/|");
        else if (fehler >= 4)
            System.out.print("/|\\");

        System.out.println();
        System.out.print(" |    ");

        if (fehler == 5)
            System.out.print("/");
        else if (fehler >= 6)
            System.out.print("/ \\");

        System.out.println();
        System.out.println("_|___ ");
    }

    // Hangman-Darstellung

    // Darstellung - Shark Fin
    // - Grafik zeigt eine Hai-Flosse, die bei jedem Fehler näher kommt
    // Beispiel:
    // Wähle das Wort ohne dass deine Mitspieler es sehen: Hut
    // Wort: _ _ _
    // 🦈🌊🌊🌊🌊🌊🏄🏻
    // Rate einen Buchstaben: a
    // Wort: _ _ _
    // 🌊🦈🌊🌊🌊🌊🏄🏻
    // Rate einen Buchstaben: b
    // Wort: _ _ _
    // 🌊🌊🦈🌊🌊🌊🏄🏻
    // Rate einen Buchstaben: h
    // Wort: H _ _
    // 🌊🌊🦈🌊🌊🌊🏄🏻
    // Rate einen Buchstaben: e
    // Wort: H _ _
    // 🌊🌊🌊🦈🌊🌊🏄🏻
    // Rate einen Buchstaben: u
    // Wort: H u _
    // 🌊🌊🌊🦈🌊🌊🏄🏻
    // Rate einen Buchstaben: p
    // Wort: H u _
    // 🌊🌊🌊🌊🦈🌊🏄🏻
    // Rate einen Buchstaben: g
    // Wort: H u _
    // 🌊🌊🌊🌊🌊🦈🏄🏻
    // Rate einen Buchstaben: k
    // Wort: H u _
    // 🌊🌊🌊🌊🌊🌊🤕
    // Verloren. Das Wort war: Hut.
    public static void zeichneSharkFin(int fehlversuche) {
        String bild = switch (fehlversuche) {
            case 0 ->  "🦈🌊🌊🌊🌊🌊🏄🏻";
            case 1 ->  "🌊🦈🌊🌊🌊🌊🏄🏻";
            case 2 ->  "🌊🌊🦈🌊🌊🌊🏄🏻";
            case 3 ->  "🌊🌊🌊🦈🌊🌊🏄🏻";
            case 4 ->  "🌊🌊🌊🌊🦈🌊🏄🏻";
            case 5 ->  "🌊🌊🌊🌊🌊🦈🏄🏻";
            default -> "🌊🌊🌊🌊🌊🌊🤕"; // 6 oder mehr
        };
        System.out.println(bild);
    }

    // Darstellung - Verschwindender Eisbecher
    // Beispiel:
    // Wähle das Wort ohne dass deine Mitspieler es sehen: Hut
    // Wort: _ _ _
    //   🔴
    //  🟢🟤
    // 🟢🟠🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: a
    // Wort: _ _ _
    //
    //  🟢🟤
    // 🟢🟠🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: b
    // Wort: _ _ _
    //
    //  🟢
    // 🟢🟠🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: h
    // Wort: H _ _
    //
    //  🟢
    // 🟢🟠🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: e
    // Wort: H _ _
    //
    //
    // 🟢🟠🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: u
    // Wort: H u _
    //
    //
    // 🟢🟠🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: p
    // Wort: H u _
    //
    //
    //   🟠🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: g
    // Wort: H u _
    //
    //
    //     🐻‍❄️
    // \ /\ /
    //  \. /
    //   \/
    // Rate einen Buchstaben: k
    // Wort: H u _
    //
    //
    //
    // \ /\ /
    //  \. /
    //   \/
    // Verloren. Das Wort war: Hut.
    public static void zeichneEisbecher(int fehlversuche) {
        String becher = switch (fehlversuche) {
            case 0 -> """
                  🔴
                 🟢🟤
                🟢🟠🐻‍❄️""";
            case 1 -> """
                 
                 🟢🟤
                🟢🟠🐻‍❄️""";
            case 2 -> """
                 
                 🟢
                🟢🟠🐻‍❄️""";
            case 3 -> """
                 
                 
                🟢🟠🐻‍❄️""";
            case 4 -> """
                 
                 
                  🟠🐻‍❄️""";
            case 5 -> """
                 
                 
                    🐻‍❄️""";
            default -> """
                 
                 
                """;
        };

        System.out.println(becher);
        System.out.println("\\ /\\ /");
        System.out.println(" \\. /");
        System.out.println("  \\/");
    }

}
