package lerneinheiten.L08SchleifenWhile.uebung;

import java.util.Random;
import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
        // Wie schreibe ich die While-Schleife?
        // 1. Schreiben Sie ein Programm, das 100 Mal "Hello World" auf die Konsole ausgibt.
        // Erweitern Sie das Programm, sodass 100 Mal "Hello World" in einer Zeile, mit ", " getrennt, ausgegeben wird.
        Integer zaehlvariable = 0;

        while (zaehlvariable < 10) {
            System.out.println("Hello World");

            zaehlvariable++;
        }

        System.out.println();

        // 2. Schreiben Sie eine While-Schleife, die von 1 bis 10 alle Zahlen ausgibt.
        // Erweitern Sie die Ausgabe um die Info, ob die Zahl gerade oder ungerade ist. (z.B.: 1 (ungerade), 2 (gerade), ...)
        // Erweitern Sie das Programm, indem Sie vom Benutzer die untere und obere Grenze abfragen (z.B. 4 bis 12).
        Scanner scanner = new Scanner(System.in);

        System.out.print("BIS wann soll gezählt werden? ");
        Integer obereGrenze = Integer.parseInt(scanner.nextLine());

        System.out.print("AB wann soll gezählt werden? ");
        Integer untereGrenze = Integer.parseInt(scanner.nextLine());
        Integer zaehler = untereGrenze;

        while (zaehler <= obereGrenze) {

            if (zaehler % 2 == 0) {
                System.out.println(zaehler + " ist eine gerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");
            } else {
                System.out.println(zaehler + " ist eine ungerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");
            }

            zaehler++;
        }

        System.out.println();

        // 3. Schreiben Sie eine While-Schleife, die von 10 bis 1 alle Zahlen im Format "10-9-8-...-1" ausgibt.
        zaehlvariable = 10;
        untereGrenze = 1;

        while (zaehlvariable >= untereGrenze) {

            if (zaehlvariable == untereGrenze) {
                System.out.print(zaehlvariable);

            } else {
                System.out.print(zaehlvariable + "-");
            }

            zaehlvariable--;
        }

        System.out.println();

        // 4. Schreiben Sie ein Programm, das eine Zahl vom Benutzer einliest und die Summe aller Zahlen von 1 bis zur eingegebenen Zahl ausgibt.
        zaehlvariable = 1;
        System.out.print("Gib eine Zahl ein. Bis zu dieser wird die Summe gebildet. z.B. Eingabe: 3 -> 1+2+3=6 ");
        Integer usereingabe = Integer.parseInt(scanner.nextLine());
        Integer summe = 0;

        while (zaehlvariable <= usereingabe) {
            summe += zaehlvariable;

            zaehlvariable++;
        }

        System.out.println("Die Summe von 1 bis " + usereingabe + " ist: " + summe);

        // 5. Schreiben Sie ein Programm, das den Benutzer nach einer Zahl fragt und dann die Fakultät dieser Zahl berechnet.
        // Verwenden Sie dazu eine While-Schleife.
        // ``Hinweis: faculty(3) = 1 * 2 * 3 = 6``
        zaehlvariable = 1;
        System.out.print("Gib eine Zahl ein. Bis zu dieser wird die Fakultät gebildet. z.B. Eingabe: 3 -> 1*2*3=6 ");
        usereingabe = Integer.parseInt(scanner.nextLine());
        Integer fakultaet = 1;

        while (zaehlvariable <= usereingabe) {
            fakultaet *= zaehlvariable;

            zaehlvariable++;
        }

        System.out.println("Die Fakultät von 1 bis " + usereingabe + " ist: " + fakultaet);

        // 6. Erstellen Sie eine While-Schleife, die von 0 bis 26 hochzählt.
        // - Erstellen Sie eine Variable `chVal` mit dem Wert 97
        // - Wandeln Sie `chVal` in eine `char`-Variable um
        // - Geben Sie die `char`-Variable aus und erhöhen Sie `chVal` in jedem Schleifendurchlauf um eins
        // - Beispielausgabe: "a, b, c, d, ..."
        int asciiCode = 97;

        while (asciiCode <= 122) {
            char buchstabe = (char) asciiCode;
            System.out.print(buchstabe);
            if (asciiCode < 122) {
                System.out.print(", ");
            }
            asciiCode++;
        }

        System.out.println();

        // 7. Schreiben Sie ein Programm, das eine Schleife ausführt, die zufällige Zahlen zwischen 1 und 10 generiert, bis eine 7 generiert wird.
        // Zählen Sie die Anzahl der Schleifendurchläufe und geben Sie sie am Ende aus.
        Random random = new Random();
        int versuche = 0;
        int zahl = 0;

        while (zahl != 7) {
            zahl = random.nextInt(10) + 1;
            System.out.println("Zahl: " + zahl);
            versuche++;
        }

        System.out.println("Benötigte Versuche bis zur 7: " + versuche);

        // Wie schreibe ich die do-While-Schleife?
        // 1. Schreiben Sie eine do-while-Schleife, die so lange läuft, bis der Benutzer eine Zahl zwischen 1 und 10 eingibt.
        int eingabe;

        do {
            System.out.print("Gib eine Zahl zwischen 1 und 10 ein: ");
            eingabe = scanner.nextInt();
            scanner.nextLine();
        } while (eingabe < 1 || eingabe > 10);

        System.out.println("Danke! Deine Zahl: " + eingabe);

        // 2. Schreiben Sie eine do-while-Schleife, die so lange läuft, bis das Passwort "geheim" korrekt eingegeben wurde.
        String eingabeZeichenkette;
        do {
            System.out.print("Passwort eingeben [geheim]: ");
            eingabeZeichenkette = scanner.nextLine();
        } while (!eingabeZeichenkette.equals("geheim"));

        System.out.println("Zugriff erlaubt!");

        // 3. Schreiben Sie eine do-while-Schleife, die den Benutzer so lange nach Zahlen fragt, bis er "exit" eingibt.
        do {
            System.out.print("Gib eine Zahl oder \"exit\" ein: ");
            eingabeZeichenkette = scanner.nextLine();
        } while (!eingabeZeichenkette.equalsIgnoreCase("exit"));

        System.out.println("Programm beendet.");

        // While oder Do-While?
        // **Anzahl Ziffern einer Zahl**
        // Einlesen einer Integer-Zahl und Ausgabe der Anzahl ihrer Ziffern.
        // Hinweis: Modulo-Operationen helfen .
        System.out.print("Zahl eingeben: ");
        zahl = scanner.nextInt();
        scanner.nextLine();

        if (zahl == 0) {
            System.out.println("Anzahl Ziffern: 1");
            return;
        }

        int ziffern = 0;
        // negative Zahlen haben die gleiche Anzahl an stellen wie eine positive.
        // Wir haben aber ein Problem mit der Bedingung in der While Schleife zahl > 0, wenn negative Zahlen vorkommen.
        if (zahl < 0)
            zahl = -zahl;

        while (zahl > 0) {
            zahl /= 10;
            ziffern++;
        }

        System.out.println("Anzahl Ziffern: " + ziffern);

        // **Primzahlen berechnen**
        // Einlesen der oberen Grenze `n` und Ausgabe aller Primzahlen bis `n`.
        // Beachten Sie: 1 ist keine Primzahl.
        System.out.print("Obere Grenze n angeben: ");
        int n = scanner.nextInt();
        zahl = 2;

        while (zahl <= n) {
            int teiler = 2;
            boolean istPrim = true;

            while (teiler < zahl) {
                if (zahl % teiler == 0) {
                    istPrim = false;
                    break;
                }
                teiler++;
            }

            if (istPrim) {
                System.out.print(zahl + " ");
            }

            zahl++;
        }

        System.out.println();
        // **Teilbar durch 3**
        // Programmieren Sie eine Schleife, die alle durch 3 teilbaren Ganzzahlen zwischen 10 und 40 ausgibt.
        // Beispiel:
        // 12 15 18 21 24 27 30 33 36 39
        zahl = 10;
        while (zahl <= 40) {
            if (zahl % 3 == 0) {
                System.out.print(zahl + " ");
            }
            zahl++;
        }
        System.out.println();

        // Zahlen raten
        // Der Benutzer muss eine geheime Zahl zwischen 0 und 100 am Terminal erraten. Nach jeder Eingabe gibt das Programm Hinweise, ob die Zahl zu hoch oder zu klein ist. Der Benutzer hat 5 Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit einer Niederlage.
        // Weiters soll folgendes gelten:
        // * Geheime Zahl:
        // Das Programm wählt zu Beginn eine zufällige Zahl zwischen 0 und 100 aus.
        // Verwenden dazu die ``Funktion`` *randint* aus dem ``Modul`` *random*. Um die ``Funktion`` verwenden zu können, schreibe folgendes in die erste Zeile des Programmes ``from random import randint``.
        // * Userinput:
        // Ein:e Benutzer:in wird in jeder Runde aufgefordert, eine Zahl einzugeben. Die Eingabe muss überprüft werden, ob sie der geheimen Zahl entspricht.
        // * Interaktion mit Benutzer:innen:
        // Wenn die Eingabe zu hoch ist, gibt das Programm die Nachricht *"Die Zahl ist zu hoch!"* aus.
        // Wenn die Eingabe zu niedrig ist, gibt das Programm die Nachricht *"Die Zahl ist zu klein!"* aus.
        // Bei korrekter Eingabe zeigt das Programm *"Herzlichen Glückwunsch, Sie haben die Zahl erraten!"* an und beendet das Spiel.
        // * Anzahl der Versuche:
        // Ein:e Benutzer:in hat ``5`` Leben. Bei jeder falschen Eingabe verliert diese:r ein Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit der Nachricht: *"Game Over! Die geheime Zahl war: ``<Geheime Zahl>``".
        // * ``optional``: Gib am Ende die Anzahl der Versuche aus, die ein:e Benutzer:in benötigt um die Zahl zu erraten. Füge eine Möglichkeit hinzu, das Spiel nach einem Durchgang erneut zu starten.
        // Hilfestellung:
        // * Nutzen Sie eine ``Schleife``, um die Eingaben zu prüfen, bis die Zahl erraten wurde oder die Leben aufgebraucht sind. Welche ``Schleife`` verwenden wir, wenn *die Anzahl der Wiederholungen unbekannt ist*?
        // * Verwenden Sie ``geheime_zahl = randint(0, 100)``
        // **Achtung!** inklusive 0 und inklusive 100! Hier weicht Python von z.B. JAVA ab. Dort wäre exklusive 100 bei der Angabe der Zahl 100.
        // * ``leben = 5`` (Zählt, wie viele Leben ein:e Benutzer:in hat).
        // * Nutzen Sie ``input()`` um Eingaben aus dem Terminal einzulesen.
        // Testfälle:
        // Willkommen beim Zahlen-Ratespiel!
        // Ich habe eine geheime Zahl zwischen 0 und 100 ausgewählt.
        // Sie haben 5 Leben. Viel Glück!
        // Geben Sie Ihre Schätzung ein:
        // > 50
        // Die Zahl ist zu hoch! Sie haben noch 4 Leben.
        // Geben Sie Ihre Schätzung ein:
        // > 25
        // Die Zahl ist zu klein! Sie haben noch 3 Leben.
        // Geben Sie Ihre Schätzung ein:
        // > 37
        // Die Zahl ist zu hoch! Sie haben noch 2 Leben.
        // Geben Sie Ihre Schätzung ein:
        // > 30
        // Die Zahl ist zu klein! Sie haben noch 1 Leben.
        // Geben Sie Ihre Schätzung ein:
        // > 35
        // Game Over! Die geheime Zahl war: 33
        // Zusammenfassung der Angabe
        // 1.) benutzereingabe von zahlen 0-100
        // 2.) 5 Leben, bei fehler soll eins abgezogen werden.
        // 3.) info ob größer oder kleiner.
        // 4.) falls gewonnen soll dies ausgegeben werden, falls verloren ebenso.
        // 5.) willst du nochmal spielen? (reset von leben, und neue zahl ziehen)

        /*
        Notizen:
            - while loop
            - scanner
            - verzweigungen für 3 fälle
            - falschen input abfangen
            - zahl erzeugen zufallszahl -> Random
        */

        // Variablen Anlegen
        boolean playAgain = true;

        // Beginne mit Logik (Kontrollstrukturen)
        // spiele nochmals
        while (playAgain) {
            int zahlZuRaten = random.nextInt(0, 101);
            int leben = 5 - 1;
            versuche = 0;

            System.out.println("Eine Zahl zwischen 0 und 100 wurde gewählt. Rate die Zahl!");

            // Beginne mit Logik (Kontrollstrukturen)
            // Wiederholung der Spiellogik
            while (true) {
                // Userinput
                System.out.print("Gib eine Zahl ein [0-100]: ");

                // guards für falschen Userinput
                while (!scanner.hasNextInt()) {
                    System.out.print("Falscher userinput, bitte neu eingeben: ");
                    String inputWelcherKeineZahlIstUndVerworfenWird = scanner.next();
                }

                int guess = scanner.nextInt();

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

        // Primzahl prüfen
        // Schreiben Sie ein Programm, das alle Primzahlen bis zu einer vom Benutzer eingegebenen Zahl ausgibt.
        // Verwenden Sie eine Schleife zur Überprüfung, ob eine Zahl durch irgendeine Zahl zwischen 2 und (Zahl - 1) teilbar ist.
        System.out.print("Gib die Obergrenze ein: ");
        n = scanner.nextInt();
        scanner.nextLine();
        zahl = 2;

        while (zahl <= n) {
            int teiler = 2;
            boolean istPrim = true;

            while (teiler < zahl) {
                if (zahl % teiler == 0) {
                    istPrim = false;
                    break;
                }
                teiler++;
            }

            if (istPrim) {
                System.out.print(zahl + " ");
            }

            zahl++;
        }

        System.out.println();

        // Palindrom
        // Schreiben Sie ein Programm, das eine Zeichenkette vom Benutzer einliest und überprüft, ob sie ein Palindrom ist.
        // Verwenden Sie dazu eine While-Schleife.
        System.out.print("Gib eine Zeichenkette ein: ");
        String text = scanner.nextLine();


        int links = 0;
        int rechts = text.length() - 1;
        boolean istPalindrom = true;

        while (links < rechts) {
            if (text.charAt(links) != text.charAt(rechts)) {
                istPalindrom = false;
                break;
            }
            links++;
            rechts--;
        }

        if (istPalindrom) {
            System.out.println("Das ist ein Palindrom.");
        } else {
            System.out.println("Das ist kein Palindrom.");
        }

        // Rechnen mit Menü
        // Erstellen Sie ein Programm mit folgendem Menü:
        // Bitte wählen Sie eine Option:
        // 1 Addieren
        // 2 Subtrahieren
        // 3 Dividieren
        // 4 Multiplizieren
        // -1 Programm beenden
        // Das Programm fragt zwei Zahlen ab und gibt das Ergebnis der gewählten Rechenart aus.
        // Solange nicht -1 eingegeben wird, soll das Menü erneut erscheinen.
        // Bei Abbruch wird die Anzahl der durchgeführten Rechnungen ausgegeben.
        int auswahl;
        int anzahlRechnungen = 0;

        do {
            System.out.println("\nBitte wählen Sie eine Option:");
            System.out.println("1 Addieren");
            System.out.println("2 Subtrahieren");
            System.out.println("3 Dividieren");
            System.out.println("4 Multiplizieren");
            System.out.println("-1 Programm beenden");
            auswahl = scanner.nextInt();

            System.out.print("Zahl 1: ");
            double a = scanner.nextDouble();
            System.out.print("Zahl 2: ");
            double b = scanner.nextDouble();
            scanner.nextLine();

            System.out.println(
                    switch (auswahl) {
                        case 1 -> "Ergebnis: " + (a + b);
                        case 2 -> "Ergebnis: " + (a - b);
                        case 3 -> {
                            if (b != 0) {
                                yield "Ergebnis: " + (a / b);
                            } else {
                                yield "Division durch 0 nicht erlaubt!";
                            }
                        }
                        case 4 -> "Ergebnis: " + (a * b);
                        default -> "Ungültige Eingabe.";
                    }
            );

            anzahlRechnungen++;

        } while (auswahl != -1);

        System.out.println("Anzahl durchgeführter Rechnungen: " + anzahlRechnungen);

        // Zeichenketten
        // Schreiben Sie ein Programm, das ein Wort vom Benutzer einliest und:
        // - Die Anzahl der Zeichen ausgibt
        // - Die Anzahl der Buchstaben ausgibt
        // - Nach Eingabe eines Zeichens: Anzahl dieses Zeichens im Wort ausgibt
        // Beispiel:
        // Wort: `Abbcc123`, Zeichen: `b`
        // Ausgabe:
        // - Zeichenanzahl: 8
        // - Buchstabenanzahl: 5
        // - Anzahl b: 2
        System.out.print("Gib ein Wort ein: ");
        String wort = scanner.nextLine();

        System.out.print("Gib ein Zeichen zur Suche ein: ");
        char gesucht = scanner.nextLine().charAt(0);

        int i = 0;
        int buchstaben = 0;
        int gesuchtesZeichenAnzahl = 0;

        while (i < wort.length()) {
            char c = wort.charAt(i);

            if (Character.isLetter(c)) {
                buchstaben++;
            }

            if (c == gesucht) {
                gesuchtesZeichenAnzahl++;
            }

            i++;
        }

        System.out.println("Zeichenanzahl: " + wort.length());
        System.out.println("Buchstabenanzahl: " + buchstaben);
        System.out.println("Anzahl '" + gesucht + "': " + gesuchtesZeichenAnzahl);

        // Summe bilden
        // Schreiben Sie eine do-while-Schleife, die Zahlen summiert, bis "exit" eingegeben wird.
        // Geben Sie am Ende auch den Durchschnitt aus.
        summe = 0;
        int anzahl = 0;

        do {
            System.out.print("Zahl eingeben oder \"exit\": ");
            eingabeZeichenkette = scanner.nextLine();

            if (!eingabeZeichenkette.equalsIgnoreCase("exit")) {
                try {
                    zahl = Integer.parseInt(eingabeZeichenkette);
                    summe += zahl;
                    anzahl++;
                } catch (NumberFormatException e) {
                    System.out.println("Ungültige Eingabe.");
                }
            }
        } while (!eingabeZeichenkette.equalsIgnoreCase("exit"));

        if (anzahl > 0) {
            double durchschnitt = (double) summe / anzahl;
            System.out.println("Summe: " + summe);
            System.out.println("Durchschnitt: " + durchschnitt);
        } else {
            System.out.println("Keine Zahlen eingegeben.");
        }

        // Würfeln
        // - Anzahl der Würfel vom Benutzer abfragen
        // - do-while-Schleife zum Würfeln und Raten der Augensumme erstellen
        // - Hinweise geben: höher / niedriger
        System.out.print("Wie viele Würfel? ");
        anzahl = scanner.nextInt();

        int tipp;

        do {
            summe = 0;
            i = 0;
            while (i < anzahl) {
                summe += random.nextInt(6) + 1;
                i++;
            }

            System.out.print("Rate die Augensumme: ");
            tipp = scanner.nextInt();

            if (tipp < summe) {
                System.out.println("Zu niedrig!");

            } else if (tipp > summe) {
                System.out.println("Zu hoch!");

            } else {
                System.out.println("Richtig geraten!");
            }
        } while (tipp != summe);

        // Menü
        // Implementiere ein Menü mit Optionen. Diese werden dann in die Console ausgegeben. Die Optionen werden wiederholt angezeigt, bis der Benutzer 0 eingibt. Bei ungültiger Eingabe soll "Ungültige Auswahl!" ausgegeben werden und es soll solange nachgefragt werden bis diese Eingabe korrekt ist.
        // Optional: Führe eine Wahrscheinlichkeit von 10% ein, dass ein Befehlt nicht funktioniert. Die Anwender werden dann gebeten den Befehl neu einzugeben.
        // Beispiel:
        // Wähle [0-4]
        // 1 - Festplatte formatieren
        // 2 - USB-Stick auswerfen
        // 3 - Bildschirm ausschalten
        // 4 - Task Beenden - es muss eine Id noch angegeben werden.
        // 0 - Programm beenden
        // Beispiel:
        // Es wurde "USB-Stick auswerfen" gewählt.
        // USB-Stick wurde ausgeworfen.
        // Wähle [0-4]
        // 1 - Festplatte formatieren
        // 2 - USB-Stick auswerfen
        // 3 - Bildschirm ausschalten
        // 4 - Task Beenden - es muss eine Id noch angegeben werden.
        // 0 - Programm beenden
        // 4 11671
        // Es wurde "Task Beenden" mit der ID: 11671 gewählt.
        // Task mit ID: 11671 beendet.
        // Wähle [0-4]
        // 1 - Festplatte formatieren
        // 2 - USB-Stick auswerfen
        // 3 - Bildschirm ausschalten
        // 4 - Task Beenden
        // 0 - Programm beenden
        // 0
        // Es wurde "Programm beenden" gewählt.
        boolean falscheUserEingabe = true;

        do {
            System.out.println("Wähle [0-4]");
            System.out.println("1 - Festplatte formatieren");
            System.out.println("2 - USB-Stick auswerfen");
            System.out.println("3 - Bildschirm ausschalten");
            System.out.println("4 - Task Beenden - es muss eine Id noch angegeben werden.");
            System.out.println("0 - Programm beenden");

            // dazu da um bei einer falschen Eingabe "neu" starten zu können.
            if (scanner.hasNextInt()) { // Ist die Eingabe ein int? passt. Ansonsten Schleife neu starten.
                auswahl = scanner.nextInt();

                if (random.nextDouble(10) < 0.1) { // 0 bis 9 → 10% Chance
//                        if (random.nextInt(10) == 0) { // oder mit integer zahlen. 0 ist nicht speziell. Wir wählen einfach eine Zahl aus 0-9.
//                        if (random.nextInt(10) == 6) { // geht genau so.
                    System.out.println("Fehler! Der Befehl hat nicht funktioniert. Bitte erneut versuchen.");
                    continue; // wir "starten" die Schleife neu von ganz oben.
                }

                // Verarbeite Ausgabe:
                String ausgabe = switch (auswahl) {
                    case 0 -> "Es wurde \"Programm beenden\" gewählt.";
                    case 1 -> "Es wurde \"Festplatte formatieren\" gewählt.\n" +
                            "Festplatte wurde formatiert.";
                    case 2 -> "Es wurde \"USB-Stick auswerfen\" gewählt.\n" +
                            "USB-Stick wurde ausgeworfen.";
                    case 3 -> "Es wurde \"Bildschirm ausschalten\" gewählt.\n" +
                            "Bildschirm wurde ausgeschaltet.";
                    case 4 -> {
                        int id = scanner.nextInt();
                        scanner.nextLine();
                        yield ("Es wurde \"Task Beenden\" mit der ID: " + id + " gewählt.\n" +
                                "Task mit ID: " + id + " beendet.");
                    }
                    default -> "Ungültige Auswahl! Nur Zahlen zwischen 0 und 4.";
                };

                if (random.nextDouble(10) < 0.1) {
                    System.out.println("Fehler! Der Befehl hat nicht funktioniert. Bitte erneut versuchen.");
                } else {
                    System.out.println(ausgabe);
                }

                falscheUserEingabe = false; // Wichtig! Wir haben in diesem Block einen erfolgreichen User-Input erhalten.

            } else {
                System.out.println("Ungültige Eingabe! Bitte ID als Zahl angeben.");
                falscheUserEingabe = true; // nicht nötig, jedoch sicher ist sicher.
                // Wir gehen mit Bedingungen welche Schleifen steuern sehr exakt um. Bedeutet wir schreiben
                // explizit die Idee des z.B. else zweiges hin. Das tun wir it falscheUserEingabe = true;, denn das ist dessen Zweck.
            }

        } while (falscheUserEingabe);

        // Einnahmen erfassen
        // Das Programm soll die Kosten für die Bereiche Nahrungsmittel, Getränke erfassen.
        // * Fragen Sie die Benutzer nach deren Namen und begrüßen sie diese.
        // * Fragen Sie die Benutzer in einer Schleife solang um die Eingaben, bis ``abbruch`` eingegeben wird. Anschließend sollen alle Summen angezeigt werden.
        // * Schreiben Sie hierzu ein Menü mit der Abfrage der Aktion mit folgenden Optionen:
        //     * nahrung, getränk, abbruch
        // * Legen Sie zwei double Variablen für Nahrung und Getränke an, in deren die eingegebenen Werte summiert werden.
        // * Fragen Sie den Benutzer um den Betrag
        // * Implementieren Sie folgende Logik
        //     * nahrung: Variable für Nahrung wird um den eingegebenen Betrag erhöht
        //     * getränk: Variable für Getränk wird um den eingegebenen Betrag erhöht
        //     * abbruch: Ausgabe der beiden summen mit zwei Nachkommastellen.
        // Beispiel
        // Willkommen bei der Einnahmenerfassung!
        // Wie ist Ihr Name?
        // Mathias
        // Hallo Mathias!
        // Bitte wählen Sie eine Aktion (`nahrung`, `getränk`, `abbruch`):
        // getränk
        // Geben Sie eine Summe für die Kategorie getränk ein: 12.00
        // Bitte wählen Sie eine Aktion (`nahrung`, `getränk`, `abbruch`):
        // getränk
        // Geben Sie eine Summe für die Kategorie getränk ein: 10.00
        // Bitte wählen Sie eine Aktion (`nahrung`, `getränk`, `abbruch`):
        // nahrung
        // Geben Sie eine Summe für die Kategorie getränk ein: 18.00
        // Bitte wählen Sie eine Aktion (`nahrung`, `getränk`, `abbruch`):
        // abbruch
        // Abrechnung für Mathias: 22,00€ für Getränke und 18,00€ für Nahrungsmittel.
        double summeNahrung = 0.0;
        double summeGetraenk = 0.0;

        System.out.println("Willkommen bei der Einnahmenerfassung!");
        System.out.print("Wie ist Ihr Name? ");
        String name = scanner.nextLine();
        System.out.println("Hallo " + name + "!");

        String aktion;
        boolean done;

        do {
            System.out.print("Bitte wählen Sie eine Aktion [nahrung getränk abbruch]: ");
            aktion = scanner.nextLine().toLowerCase();

            done = switch (aktion) {
                case "nahrung" -> {
                    System.out.print("Geben Sie eine Summe für die Kategorie Nahrung ein [Kommazahl]: ");

                    while (true) {
                        if (scanner.hasNextDouble()) {
                            double betrag = scanner.nextDouble();
                            scanner.nextLine();

                            if (betrag < 0)
                                System.out.print("Bitte geben Sie einen positiven Betrag ein: ");

                            summeNahrung += betrag;
                            break;
                            // warum geht hier nicht folgendes?
                            // yield betrag; // Wir gehen hier doch aus der Schleife "raus".
                            // wäre doch eleganter als break;

                        } else {
                            System.out.print("Ungültiger Betrag! Bitte erneut eingeben: ");
                            scanner.nextLine(); // WICHTIG! das ist die üngültige Eingabe und wenn diese nicht verbraucht wird ist hasNexDouble immer true.
                        }
                    }

                    yield false;
                }
                case "getränk" -> {
                    System.out.print("Geben Sie eine Summe für die Kategorie getränk ein: ");

                    // ... Doppelter Code
                    while (true) {
                        if (scanner.hasNextDouble()) {
                            double betrag = scanner.nextDouble();
                            scanner.nextLine();

                            if (betrag < 0)
                                System.out.print("Bitte geben Sie einen positiven Betrag ein: ");

                            summeGetraenk += betrag;
                            break;

                        } else {
                            System.out.print("Ungültiger Betrag! Bitte erneut eingeben: ");
                            scanner.nextLine(); // WICHTIG! das ist die üngültige Eingabe und wenn diese nicht verbraucht wird ist hasNexDouble immer true.
                        }
                    }

                    yield false;
                }
                case "abbruch" -> {
                    System.out.printf("Abrechnung für %s: %.2f€ für Getränke und %.2f€ für Nahrungsmittel.%n",
                            name, summeGetraenk, summeNahrung);

                    yield true;
                }
                default -> {
                    System.out.println("Ungültige Eingabe! Bitte `nahrung`, `getränk` oder `abbruch` eingeben.");
                    yield false;
                }
            };
        } while (!done);

        scanner.close();
    }
}
