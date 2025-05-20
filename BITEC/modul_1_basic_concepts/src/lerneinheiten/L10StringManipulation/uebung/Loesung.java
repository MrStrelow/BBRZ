package lerneinheiten.L10StringManipulation.uebung;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.Scanner;
import java.util.Arrays;
import java.util.Locale; // Für Formatierung von Zahlen (z.B. Dezimaltrennzeichen)

// Für optionale Uhrzeit-Aufgaben:


public class Loesung {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String eingabe;
        String eingabe2; // Für Aufgaben mit zwei Eingaben
        String ergebnis;
        double doubleEingabe;
        int intEingabe;

        System.out.println("--- Java Übungen - Lösungen ---");

        // Erstellen Sie einen Java-Code, der einen String einliest und dann die Anzahl der Zeichen in diesem String ausgibt.
        // (Verwenden Sie für die Ausgabe, sofern möglich String.format(...))
        System.out.println("\n--- Aufgabe: String-Länge ---");
        System.out.print("Geben Sie einen Text ein: ");
        eingabe = scanner.nextLine();
        System.out.println(String.format("Der Text \"%s\" hat %d Zeichen.", eingabe, eingabe.length()));


        // Schreiben Sie ein Programm, das einen Namen als Eingabe erhält und ihn in Großbuchstaben formatiert ausgibt.
        // (Verwenden Sie für die Ausgabe, sofern möglich String.format(...))
        System.out.println("\n--- Aufgabe: Name in Großbuchstaben ---");
        System.out.print("Geben Sie einen Namen ein: ");
        eingabe = scanner.nextLine();
        System.out.println(String.format("Der Name in Großbuchstaben: %S", eingabe)); // %S für toUpperCase


        // Entwickeln Sie eine Anwendung, die einen Preis als `double` einliest, formatiert und mit 2 Dezimalstellen ausgibt.
        // (Verwenden Sie für die Ausgabe, sofern möglich String.format(...))
        System.out.println("\n--- Aufgabe: Preis formatieren ---");
        System.out.print("Geben Sie einen Preis ein (z.B. 12.34 oder 12,34): ");
        eingabe = scanner.nextLine();
        try {
            // Versuche, die Eingabe mit Komma oder Punkt zu parsen
            doubleEingabe = Double.parseDouble(eingabe.replace(',', '.'));
            System.out.println(String.format(Locale.GERMAN, "Formatierter Preis: %.2f €", doubleEingabe));
        } catch (NumberFormatException e) {
            System.out.println("Ungültige Eingabe für Preis.");
        }


        // Erstellen Sie eine Methode, die eine Telefonnummer im Format "1234567890" in das Format "(123) 456-7890" umwandelt.
        System.out.println("\n--- Aufgabe: Telefonnummer formatieren ---");
        eingabe = "1234567890"; // Beispiel-Telefonnummer
        ergebnis = "Nicht gültig";
        if (eingabe != null && eingabe.length() == 10 && eingabe.matches("\\d+")) {
            ergebnis = String.format("(%s) %s-%s",
                    eingabe.substring(0, 3),
                    eingabe.substring(3, 6),
                    eingabe.substring(6, 10));
        }
        System.out.println(String.format("Original: %s, Formatiert: %s", eingabe, ergebnis));
        eingabe = "0987654321"; // Weiteres Beispiel
        if (eingabe != null && eingabe.length() == 10 && eingabe.matches("\\d+")) {
            ergebnis = String.format("(%s) %s-%s",
                    eingabe.substring(0, 3),
                    eingabe.substring(3, 6),
                    eingabe.substring(6, 10));
        }
        System.out.println(String.format("Original: %s, Formatiert: %s", eingabe, ergebnis));


        // Schreiben Sie ein Programm, das einen Text in umgekehrter Reihenfolge ausgibt (z.B. "Hallo" wird zu "ollaH").
        System.out.println("\n--- Aufgabe: Text umkehren ---");
        System.out.print("Geben Sie einen Text zum Umkehren ein: ");
        eingabe = scanner.nextLine();
        StringBuilder umgekehrtBuilder = new StringBuilder();
        for (int i = eingabe.length() - 1; i >= 0; i--) {
            umgekehrtBuilder.append(eingabe.charAt(i));
        }
        ergebnis = umgekehrtBuilder.toString();
        System.out.println(String.format("Original: \"%s\", Umgekehrt: \"%s\"", eingabe, ergebnis));


        // Erstellen Sie ein Programm, das eine Zeichenkette entgegennimmt und alle Leerzeichen am Anfang und Ende entfernt.
        System.out.println("\n--- Aufgabe: Leerzeichen entfernen (Anfang/Ende) ---");
        eingabe = "   Hallo Welt!   "; // Beispiel
        System.out.println(String.format("Original: \"---%s---\"", eingabe));
        ergebnis = eingabe.trim();
        System.out.println(String.format("Getrimmt: \"---%s---\"", ergebnis));


        // Schreiben Sie eine Methode, die einen Text in Worte zerlegt und die Anzahl der Worte zählt.
        System.out.println("\n--- Aufgabe: Worte zählen ---");
        System.out.print("Geben Sie einen Satz ein: ");
        eingabe = scanner.nextLine();
        int anzahlWorte = 0;
        if (eingabe != null && !eingabe.trim().isEmpty()) {
            String[] worte = eingabe.trim().split("\\s+"); // Trennt bei einem oder mehreren Leerzeichen
            anzahlWorte = worte.length;
        }
        System.out.println(String.format("Der Text \"%s\" hat %d Worte.", eingabe, anzahlWorte));


        // Entwickeln Sie eine Anwendung, die eine URL (z.B. "www.bbrz.at") in einen klickbaren HTML-Link umwandelt
        // (z.B. "<a href='http://www.bbrz.at'>www.bbrz.at</a>").
        // Überprüfen Sie dabei, ob die URL mit "http://" beginnt (fügen Sie es ggf. hinzu)
        // und ob sie mit einer gängigen TLD wie ".at", ".com", oder ".de" endet.
        System.out.println("\n--- Aufgabe: URL zu HTML-Link ---");
        System.out.print("Geben Sie eine URL ein (z.B. www.bbrz.at): ");
        eingabe = scanner.nextLine().trim();
        String urlAnzeige = eingabe;
        String hrefUrl = eingabe;

        if (!hrefUrl.toLowerCase().startsWith("http://") && !hrefUrl.toLowerCase().startsWith("https://")) {
            hrefUrl = "http://" + hrefUrl;
        }

        boolean gueltigeTld = false;
        String[] tlds = {".at", ".com", ".de", ".org", ".net"}; // Beispiel TLDs
        for (String tld : tlds) {
            if (eingabe.toLowerCase().endsWith(tld)) {
                gueltigeTld = true;
                break;
            }
        }

        if (gueltigeTld && !eingabe.isEmpty()) {
            ergebnis = String.format("<a href='%s'>%s</a>", hrefUrl, urlAnzeige);
            System.out.println("HTML Link: " + ergebnis);
        } else {
            System.out.println("Keine gültige URL oder TLD für die Linkerstellung erkannt.");
        }


        // Entwickeln Sie eine Anwendung, die eine Temperatur in Grad Celsius in Grad Fahrenheit umrechnet
        // und das Ergebnis im Format $"25^{\circ}C \text{ entspricht } 77^{\circ}F"$ ausgibt.
        // (Umrechnungsformel: Celsius * 1,8 + 32 = Fahrenheit).
        System.out.println("\n--- Aufgabe: Temperaturumrechnung ---");
        System.out.print("Geben Sie die Temperatur in Grad Celsius ein: ");
        eingabe = scanner.nextLine();
        try {
            double celsius = Double.parseDouble(eingabe.replace(',', '.'));
            double fahrenheit = celsius * 1.8 + 32;
            // Das Grad-Symbol ° ist \u00B0 in Unicode
            System.out.println(String.format(Locale.GERMAN, "%.1f\u00B0C entspricht %.1f\u00B0F", celsius, fahrenheit));
        } catch (NumberFormatException e) {
            System.out.println("Ungültige Eingabe für Temperatur.");
        }


        // Schreiben Sie ein Programm, das eine Zeichenkette in ein festgelegtes Längenformat umwandelt,
        // z.B. auf 10 Zeichen auffüllt (mit Leerzeichen am Ende) oder abschneidet.
        System.out.println("\n--- Aufgabe: String auf feste Länge ---");
        System.out.print("Geben Sie einen Text ein: ");
        eingabe = scanner.nextLine();
        int zielLaenge = 10;
        ergebnis = eingabe;
        if (eingabe.length() > zielLaenge) {
            ergebnis = eingabe.substring(0, zielLaenge);
        } else if (eingabe.length() < zielLaenge) {
            // Mit Leerzeichen rechts auffüllen (linksbündig)
            ergebnis = String.format("%-" + zielLaenge + "s", eingabe);
            // Alternative manuelle Auffüllung:
            // StringBuilder tempBuilder = new StringBuilder(eingabe);
            // while (tempBuilder.length() < zielLaenge) {
            //     tempBuilder.append(" ");
            // }
            // ergebnis = tempBuilder.toString();
        }
        System.out.println(String.format("Original (%d): \"%s\"", eingabe.length(), eingabe));
        System.out.println(String.format("Formatiert (%d): \"%s\"", ergebnis.length(), ergebnis));


        // Erstellen Sie ein Programm, das eine Prozentzahl (z.B. den Wert 0.25) im Format "25%" ausgibt,
        // wobei der Wert mit String.format angepasst wird.
        System.out.println("\n--- Aufgabe: Prozent formatieren ---");
        doubleEingabe = 0.25; // Beispielwert
        System.out.println(String.format("Der Wert %.2f als Prozent: %.0f%%", doubleEingabe, doubleEingabe * 100));
        doubleEingabe = 0.055;
        System.out.println(String.format("Der Wert %.3f als Prozent (auf 1 Dezimalstelle gerundet): %.1f%%", doubleEingabe, doubleEingabe * 100));


        // ### Manipulationen
        //
        // Erstellen Sie ein Programm, das die folgenden Schritte nacheinander ausführt:
        // 1.  Einlesen eines beliebigen Textes von der Konsole.
        // 2.  Ausgabe des Textes in Großbuchstaben.
        // 3.  Ausgabe der Länge des Originaltextes.
        // 4.  Anhängen von ":-)" an den Originaltext und Ausgabe des Ergebnisses.
        // 5.  Ausgabe der ersten 5 Zeichen des Originaltextes (falls vorhanden, sonst so viele wie möglich).
        // 6.  Ausgabe des ersten und letzten Zeichens des Originaltextes.
        // 7.  Ausgabe des 3. Zeichens des Originaltextes (Zeichen an Position 2, falls vorhanden).
        // 8.  Ausgabe des Originaltextes, nachdem alle Leerzeichen entfernt wurden.
        // 9.  Ausgabe des Originaltextes, nachdem alle '!' durch '#' ersetzt wurden.
        System.out.println("\n--- Aufgabe: Manipulationen ---");
        System.out.print("Text eingeben: ");
        String manipulationsText = scanner.nextLine();

        System.out.println("* In Großbuchstaben: " + manipulationsText.toUpperCase());
        System.out.println("* Länge: " + manipulationsText.length());
        System.out.println("* Mit Smiley: " + manipulationsText + ":-)");

        if (manipulationsText.length() >= 5) {
            System.out.println("* Erste 5 Zeichen: " + manipulationsText.substring(0, 5));
        } else {
            System.out.println("* Erste 5 Zeichen: " + manipulationsText);
        }

        if (!manipulationsText.isEmpty()) {
            System.out.println("* Erstes Zeichen: " + manipulationsText.charAt(0) + ", Letztes Zeichen: " + manipulationsText.charAt(manipulationsText.length() - 1));
        } else {
            System.out.println("* Erstes und letztes Zeichen: Text ist leer.");
        }

        if (manipulationsText.length() >= 3) {
            System.out.println("* 3. Zeichen: " + manipulationsText.charAt(2));
        } else {
            System.out.println("* 3. Zeichen: Text ist zu kurz.");
        }
        System.out.println("* Ohne Leerzeichen: " + manipulationsText.replace(" ", ""));
        System.out.println("* Ersetzt ('!' durch '#'): " + manipulationsText.replace("!", "#"));


        // ### US Noten
        //
        // * Schreiben Sie ein Programm, welches US-Noten in österreichische Schulnoten übersetzt.
        // * Hierzu wird als erstes die US-Note abgefragt (A, B, C, D, F).
        // * Danach wird abhängig von der Eingabe die österreichische Note ausgegeben.
        // * Noten-Mapping: A: 1, B: 2, C: 3, D: 4, F: 5.
        System.out.println("\n--- Aufgabe: US Noten ---");
        System.out.print("US-Note eingeben (A, B, C, D, F): ");
        eingabe = scanner.nextLine().toUpperCase(); // Um Kleinschreibung zu erlauben
        String oesterreichischeNote = "Ungültige Eingabe";

        // Using if-else if
        if (eingabe.equals("A")) {
            oesterreichischeNote = "1 (Sehr Gut)";
        } else if (eingabe.equals("B")) {
            oesterreichischeNote = "2 (Gut)";
        } else if (eingabe.equals("C")) {
            oesterreichischeNote = "3 (Befriedigend)";
        } else if (eingabe.equals("D")) {
            oesterreichischeNote = "4 (Genügend)";
        } else if (eingabe.equals("F")) {
            oesterreichischeNote = "5 (Nicht Genügend)";
        }
        System.out.println("Österreichische Note: " + oesterreichischeNote);


        // ### Zahlen drehen
        //
        // * Schreibe eine Methode, die die Ziffernreihenfolge einer Ganzzahl umdreht.
        //   Z.B: "Du hast die Zahl 153536758 eingegeben! Die umgedrehte Zahl lautet: 857635351".
        System.out.println("\n--- Aufgabe: Zahlen drehen ---");
        System.out.print("Geben Sie eine Ganzzahl ein: ");
        int zahlOriginal = 0;
        int zahlUmgedreht = 0;
        boolean gueltigeZahlEingabe = false;

        if (scanner.hasNextInt()) {
            zahlOriginal = scanner.nextInt();
            scanner.nextLine(); // Konsumiere das verbleibende Newline
            gueltigeZahlEingabe = true;

            if (zahlOriginal == 0) {
                zahlUmgedreht = 0;
            } else {
                int tempZahl = zahlOriginal;
                if (tempZahl < 0) { // Vorzeichen merken und mit positivem Wert arbeiten
                    tempZahl = -tempZahl;
                }
                while (tempZahl > 0) {
                    int letzteZiffer = tempZahl % 10;
                    zahlUmgedreht = zahlUmgedreht * 10 + letzteZiffer;
                    tempZahl = tempZahl / 10;
                }
                if (zahlOriginal < 0) { // Vorzeichen wieder anfügen
                    zahlUmgedreht = -zahlUmgedreht;
                }
            }
            System.out.println(String.format("Du hast die Zahl %d eingegeben! Die umgedrehte Zahl lautet: %d", zahlOriginal, zahlUmgedreht));
        } else {
            System.out.println("Ungültige Eingabe. Bitte geben Sie eine Ganzzahl ein.");
            scanner.nextLine(); // Konsumiere die ungültige Eingabe
        }


        // ### E-Mail Adresse generieren
        //
        // * Implementieren Sie eine Konsolenabfrage von Vorname und Nachname.
        // * Die E-Mailadresse setzt sich folgendermaßen zusammen:
        //     * 1. Buchstabe des Vornamens (kleingeschrieben)
        //     * "." (Punkt)
        //     * Nachname (kleingeschrieben)
        //     * "@bbrz.at"
        // * Beispiel:
        //     Vorname: Max
        //     Nachname: Mustermann
        //     Die E-Mail Adresse für Max Mustermann ist m.mustermann@bbrz.at
        System.out.println("\n--- Aufgabe: E-Mail Adresse generieren ---");
        System.out.print("Geben Sie den Vornamen ein: ");
        String vornameEmail = scanner.nextLine().trim();
        System.out.print("Geben Sie den Nachnamen ein: ");
        String nachnameEmail = scanner.nextLine().trim();
        String emailAdresse = "Konnte nicht generiert werden.";

        if (!vornameEmail.isEmpty() && !nachnameEmail.isEmpty()) {
            char ersterBuchstabeVorname = vornameEmail.toLowerCase().charAt(0);
            String nachnameKlein = nachnameEmail.toLowerCase();
            // Ersetze Umlaute und ß für E-Mail-Adressen (optional, aber oft sinnvoll)
            nachnameKlein = nachnameKlein.replace("ä", "ae")
                    .replace("ö", "oe")
                    .replace("ü", "ue")
                    .replace("ß", "ss");
            // Entferne andere Sonderzeichen, die nicht in E-Mail-Namen vorkommen sollten (vereinfacht)
            nachnameKlein = nachnameKlein.replaceAll("[^a-z0-9]", "");


            emailAdresse = String.format("%c.%s@bbrz.at", ersterBuchstabeVorname, nachnameKlein);
            System.out.println(String.format("Die E-Mail Adresse für %s %s ist %s", vornameEmail, nachnameEmail, emailAdresse));
        } else {
            System.out.println("Vorname oder Nachname dürfen nicht leer sein.");
        }


        // ### Entscheidungen treffen
        //
        // * Führen Sie eine Konsolenabfrage des ersten Vornamens durch.
        // * Fragen Sie, ob die Person einen zweiten Vornamen hat (Eingabe "ja" oder "nein", Groß-/Kleinschreibung soll ignoriert werden).
        // * Wenn die Eingabe "ja" ist:
        //     * Zweiter Vorname wird abgefragt.
        //     * Danach wird der Nachname abgefragt.
        //     * Ausgabe von Vorname, 2. Vorname und Nachname.
        // * Wenn die Eingabe "nein" ist:
        //     * Der Nachname wird abgefragt.
        //     * Ausgabe von Vorname und Nachname.
        // * Wenn die Eingabe weder "ja" noch "nein" ist:
        //     * Ausgabe von "Unbekannte Eingabe".
        System.out.println("\n--- Aufgabe: Entscheidungen treffen (Namen) ---");
        System.out.print("Geben Sie den ersten Vornamen ein: ");
        String ersterVorname = scanner.nextLine().trim();
        String zweiterVorname = "";
        String nachnameEntscheidung;

        if (!ersterVorname.isEmpty()) {
            System.out.print("Hat die Person einen zweiten Vornamen? (ja/nein): ");
            eingabe = scanner.nextLine().trim().toLowerCase();

            if (eingabe.equals("ja")) {
                System.out.print("Geben Sie den zweiten Vornamen ein: ");
                zweiterVorname = scanner.nextLine().trim();
                System.out.print("Geben Sie den Nachnamen ein: ");
                nachnameEntscheidung = scanner.nextLine().trim();
                if (!nachnameEntscheidung.isEmpty()) {
                    System.out.println(String.format("Gesamter Name: %s %s %s", ersterVorname, zweiterVorname, nachnameEntscheidung));
                } else {
                    System.out.println("Nachname darf nicht leer sein.");
                }
            } else if (eingabe.equals("nein")) {
                System.out.print("Geben Sie den Nachnamen ein: ");
                nachnameEntscheidung = scanner.nextLine().trim();
                if (!nachnameEntscheidung.isEmpty()) {
                    System.out.println(String.format("Gesamter Name: %s %s", ersterVorname, nachnameEntscheidung));
                } else {
                    System.out.println("Nachname darf nicht leer sein.");
                }
            } else {
                System.out.println("Unbekannte Eingabe für zweiten Vornamen-Abfrage.");
            }
        } else {
            System.out.println("Erster Vorname darf nicht leer sein.");
        }


        // ### Uhrzeiten (Optionale Übungen)
        //
        // Lesen Sie sich zuerst in die Formatierung und Verarbeitung von Uhrzeiten in Java ein
        // (z.B. mit `java.time.LocalTime`, `java.time.LocalDate`, `java.time.LocalDateTime`
        // und `java.time.format.DateTimeFormatter`).
        //
        // 1.  Schreiben Sie ein Java-Programm, das die aktuelle Uhrzeit im 24-Stunden-Format (hh:mm:ss) ausgibt.
        System.out.println("\n--- Aufgabe: Uhrzeiten 1 (Aktuell 24h) ---");
        LocalTime aktuelleZeit = LocalTime.now();
        DateTimeFormatter formatter24h = DateTimeFormatter.ofPattern("HH:mm:ss");
        System.out.println("Aktuelle Uhrzeit (24h): " + aktuelleZeit.format(formatter24h));


        // 2.  Schreiben Sie ein Programm, das eine Zeichenkette mit einer Uhrzeit im Format "13:45" einliest
        //     und sie dann im 12-Stunden-Format (z.B. "01:45 PM") formatiert ausgibt.
        System.out.println("\n--- Aufgabe: Uhrzeiten 2 (12h Format) ---");
        System.out.print("Geben Sie eine Uhrzeit im Format HH:mm ein (z.B. 13:45): ");
        eingabe = scanner.nextLine();
        LocalTime geleseneZeit = LocalTime.parse(eingabe, DateTimeFormatter.ofPattern("HH:mm"));
        DateTimeFormatter formatter12h = DateTimeFormatter.ofPattern("hh:mm a", Locale.ENGLISH); // a für AM/PM
        System.out.println("Uhrzeit im 12-Stunden-Format: " + geleseneZeit.format(formatter12h));


        // 3.  Erstellen Sie ein Programm, das eine `LocalTime`-Instanz erhält und die verbleibende Zeit bis Mitternacht (00:00:00)
        //     in Stunden, Minuten und Sekunden ausgibt.
        System.out.println("\n--- Aufgabe: Uhrzeiten 3 (Zeit bis Mitternacht) ---");
        LocalTime jetztFuerMitternacht = LocalTime.now();
        LocalTime mitternacht = LocalTime.MAX; // ist 23:59:59.999...
        // Besser: LocalTime.MIDNIGHT ist 00:00, aber für Duration.between ist es einfacher, wenn der zweite Wert größer ist
        // oder wir addieren einen Tag, wenn 'jetzt' nach 'mitternacht' (00:00) ist.
        // Einfacher: Sekunden bis zum Ende des Tages
        long sekundenBisMitternacht = ChronoUnit.SECONDS.between(jetztFuerMitternacht, LocalTime.of(23, 59, 59).plusSeconds(1));
        // Alternative mit Duration, wenn man Mitternacht als den Beginn des nächsten Tages betrachtet:
        // Duration dauerBisMitternacht;
        // if (jetztFuerMitternacht.equals(LocalTime.MIDNIGHT)) {
        //    dauerBisMitternacht = Duration.ofDays(1);
        // } else {
        //    dauerBisMitternacht = Duration.between(jetztFuerMitternacht, LocalTime.MIDNIGHT.plusDays(1));
        //    // Falls LocalTime.MIDNIGHT als 00:00 des aktuellen Tages interpretiert wird und 'jetzt' später ist:
        //    if(jetztFuerMitternacht.isAfter(LocalTime.MIDNIGHT) && !jetztFuerMitternacht.equals(LocalTime.MAX.withNano(0))) {
        //        // Dies ist der Fall, wenn es nicht genau 00:00 ist.
        //        // Wir wollen die Dauer bis zum nächsten 00:00
        //        LocalDateTime heuteJetzt = LocalDateTime.of(LocalDate.now(), jetztFuerMitternacht);
        //        LocalDateTime morgenMitternacht = LocalDateTime.of(LocalDate.now().plusDays(1), LocalTime.MIDNIGHT);
        //        dauerBisMitternacht = Duration.between(heuteJetzt, morgenMitternacht);
        //    } else { // Es ist genau 00:00 oder ein anderer seltener Fall
        //         dauerBisMitternacht = Duration.between(jetztFuerMitternacht, LocalTime.MAX.withNano(0).plusNanos(1)); // Bis Ende des Tages
        //    }
        // }

        long stunden = sekundenBisMitternacht / 3600;
        long minuten = (sekundenBisMitternacht % 3600) / 60;
        long sekunden = sekundenBisMitternacht % 60;
        System.out.println(String.format("Zeit bis Mitternacht (ca.): %02d Stunden, %02d Minuten, %02d Sekunden", stunden, minuten, sekunden));


        // 4.  Schreiben Sie ein Programm, das die aktuelle Uhrzeit mit Millisekunden formatiert (hh:mm:ss.SSS) und ausgibt.
        System.out.println("\n--- Aufgabe: Uhrzeiten 4 (Aktuell mit Millis) ---");
        DateTimeFormatter formatterMillis = DateTimeFormatter.ofPattern("HH:mm:ss.SSS");
        System.out.println("Aktuelle Uhrzeit (mit Millis): " + LocalTime.now().format(formatterMillis));


        // 5.  Erstellen Sie ein Programm, das eine Uhrzeit im 24-Stunden-Format via Programmargumente als Zeichenkette (z.B. "18:30")
        //     akzeptiert und diese in eine `LocalTime`-Instanz konvertiert.
        //     HINWEIS: Diese Aufgabe ist schwer direkt in diesem interaktiven Format zu testen, da Programmargumente
        //     normalerweise beim Start des Programms übergeben werden (z.B. java MeinProgramm 18:30).
        //     Wir simulieren es hier mit einer direkten String-Zuweisung.
        System.out.println("\n--- Aufgabe: Uhrzeiten 5 (Uhrzeit von Argument/String) ---");
        String zeitArgument = "18:30"; // Simuliertes Programmargument
        if (args.length > 0) { // Prüfen, ob echte Argumente übergeben wurden (für den Fall der Fälle)
            zeitArgument = args[0];
        }

        LocalTime zeitVonArgument = LocalTime.parse(zeitArgument, DateTimeFormatter.ofPattern("HH:mm"));
        System.out.println("Konvertierte Zeit vom Argument \"" + zeitArgument + "\": " + zeitVonArgument.format(formatter24h));

        // 6.  Schreiben Sie ein Java-Programm, das die aktuelle Uhrzeit in einer Zeile und das aktuelle Datum
        //     in einer anderen Zeile ausgibt.
        System.out.println("\n--- Aufgabe: Uhrzeiten 6 (Datum und Zeit getrennt) ---");
        System.out.println("Aktuelle Uhrzeit: " + LocalTime.now().format(formatter24h));
        DateTimeFormatter datumsFormatter = DateTimeFormatter.ofPattern("dd.MM.yyyy");
        System.out.println("Aktuelles Datum: " + LocalDate.now().format(datumsFormatter));


        // 7.  Schreiben Sie ein Programm, das die aktuelle Uhrzeit und das aktuelle Datum in einem benutzerdefinierten Format
        //     (z. B. "Mittwoch, 27. Oktober 2023, 15:30 Uhr") ausgibt.
        System.out.println("\n--- Aufgabe: Uhrzeiten 7 (Benutzerdefiniertes Format) ---");
        LocalDateTime jetztKomplett = LocalDateTime.now();
        DateTimeFormatter benutzerdefFormatter = DateTimeFormatter.ofPattern("EEEE, dd. MMMM yyyy, HH:mm 'Uhr'", Locale.GERMAN);
        System.out.println("Aktuell formatiert: " + jetztKomplett.format(benutzerdefFormatter));

        // ### String-Grundlagen 기초
        //
        // Schreibe ein Java-Programm, das den Benutzer zur Eingabe eines Text-Strings auffordert. Führe dann die folgenden Operationen durch und zeige die Ergebnisse an:
        //
        // * **a) Umwandlung in Großbuchstaben**: Wandle den gesamten eingegebenen String in Großbuchstaben um.
        // * **b) Umdrehen mit StringBuilder**: Drehe den String mithilfe der eingebauten Methode der `StringBuilder`-Klasse um.
        // * **c) Manuelles Umdrehen**: Drehe den String *manuell* mithilfe einer Schleife (z.B. `for` oder `while`) und dem Zugriff auf einzelne Zeichen (`charAt()`) um. Verwende für diesen Teil **nicht** die `StringBuilder.reverse()`-Methode.
        // * **d) Palindrom-Prüfung**:
        //     * Bereinige zuerst den eingegebenen String, indem du alle Leerzeichen entfernst und ihn in Kleinbuchstaben umwandelst.
        //     * Überprüfe dann, ob der bereinigte String ein Palindrom ist (d.h. vorwärts und rückwärts gelesen gleich ist).
        //     * Gib aus, ob die ursprüngliche Eingabe (nach der Bereinigung) ein Palindrom ist oder nicht.
        System.out.println("\n--- Aufgabe: String-Grundlagen ---");
        System.out.print("Geben Sie einen Text für die Grundlagen-Übung ein: ");
        eingabe = scanner.nextLine();

        // a) Umwandlung in Großbuchstaben
        String grossbuchstaben = eingabe.toUpperCase();
        System.out.println("a) In Großbuchstaben: " + grossbuchstaben);

        // b) Umdrehen mit StringBuilder
        String umgedrehtMitBuilder = new StringBuilder(eingabe).reverse().toString();
        System.out.println("b) Umgedreht (StringBuilder): " + umgedrehtMitBuilder);

        // c) Manuelles Umdrehen
        String manuellUmgedreht = "";
        if (eingabe != null) {
            for (int i = eingabe.length() - 1; i >= 0; i--) {
                manuellUmgedreht += eingabe.charAt(i);
            }
        }
        System.out.println("c) Manuell umgedreht: " + manuellUmgedreht);

        // d) Palindrom-Prüfung
        String bereinigterString = "";
        if (eingabe != null) {
            bereinigterString = eingabe.replaceAll("\\s+", "").toLowerCase(); // Alle Leerzeichen entfernen und klein
        }
        String bereinigtUmgedreht = new StringBuilder(bereinigterString).reverse().toString();
        boolean istPalindrom = false;
        if (!bereinigterString.isEmpty() && bereinigterString.equals(bereinigtUmgedreht)) {
            istPalindrom = true;
        }
        System.out.println("d) Bereinigter String für Palindrom-Check: \"" + bereinigterString + "\"");
        System.out.println("   Ist es ein Palindrom? " + (istPalindrom ? "Ja" : "Nein"));


        // ### Zeichenanalyse 📊
        //
        // Schreibe ein Java-Programm, das den Benutzer nach einem String fragt und dann eine Zeichenanalyse durchführt:
        //
        // * **a) Zählung eines bestimmten Zeichens**:
        //     * Fordere den Benutzer auf, ein einzelnes Zeichen einzugeben, das gezählt werden soll.
        //     * Fordere den Benutzer auf, einen Text-String einzugeben.
        //     * Zähle und zeige an, wie oft das angegebene Zeichen im Text-String vorkommt.
        // * **b) Häufigkeit aller Zeichen (eindeutig)**:
        //     * Fordere den Benutzer auf, einen Text-String einzugeben.
        //     * Iteriere durch den String und zähle für jedes Zeichen dessen Gesamtvorkommen im String.
        //     * Zeige die Anzahl für jedes Zeichen an, stelle dabei aber sicher, dass du die Häufigkeit für jedes eindeutige Zeichen nur *einmal* ausgibst. Wenn der String beispielsweise "banane" ist, sollte die Ausgabe 'b': 1, 'a': 3, 'n': 2 zeigen und 'a' nicht dreimal auflisten.
        //         * **Hinweis**: Du kannst einen Hilfs-String verwenden, um dir zu merken, für welche Zeichen die Häufigkeit bereits ausgegeben wurde.
        System.out.println("\n--- Aufgabe: Zeichenanalyse ---");
        // a) Zählung eines bestimmten Zeichens
        System.out.print("a) Geben Sie ein Zeichen ein, das gezählt werden soll: ");
        eingabe = scanner.nextLine();
        char zuZaehlendesZeichen = ' ';
        if (eingabe.length() == 1) {
            zuZaehlendesZeichen = eingabe.charAt(0);
            System.out.print("   Geben Sie den Text ein, in dem das Zeichen gezählt werden soll: ");
            String textFuerZeichenZaehlung = scanner.nextLine();
            int anzahlZeichen = 0;
            for (int i = 0; i < textFuerZeichenZaehlung.length(); i++) {
                if (textFuerZeichenZaehlung.charAt(i) == zuZaehlendesZeichen) {
                    anzahlZeichen++;
                }
            }
            System.out.println(String.format("   Das Zeichen '%c' kommt %d Mal im Text vor.", zuZaehlendesZeichen, anzahlZeichen));
        } else {
            System.out.println("   Ungültige Eingabe für das zu zählende Zeichen (nur ein Zeichen erlaubt).");
        }

        // b) Häufigkeit aller Zeichen (eindeutig)
        System.out.print("b) Geben Sie einen Text für die Häufigkeitsanalyse ein: ");
        String textFuerHaefigkeit = scanner.nextLine();
        System.out.println("   Häufigkeit der Zeichen (eindeutig):");
        String bereitsGezählteZeichen = ""; // Hilfsstring
        if (textFuerHaefigkeit != null && !textFuerHaefigkeit.isEmpty()) {
            for (int i = 0; i < textFuerHaefigkeit.length(); i++) {
                char aktuellesZeichen = textFuerHaefigkeit.charAt(i);
                // Prüfen, ob das Zeichen schon gezählt wurde
                boolean schonGezählt = false;
                for (int k = 0; k < bereitsGezählteZeichen.length(); k++) {
                    if (bereitsGezählteZeichen.charAt(k) == aktuellesZeichen) {
                        schonGezählt = true;
                        break;
                    }
                }

                if (!schonGezählt) {
                    int count = 0;
                    for (int j = 0; j < textFuerHaefigkeit.length(); j++) {
                        if (textFuerHaefigkeit.charAt(j) == aktuellesZeichen) {
                            count++;
                        }
                    }
                    System.out.println(String.format("   '%c': %d", aktuellesZeichen, count));
                    bereitsGezählteZeichen += aktuellesZeichen; // Zeichen zu den bereits gezählten hinzufügen
                }
            }
        } else {
             System.out.println("   Der Text ist leer.");
        }


        // ### Wortzauberei 🧙‍♂️
        //
        // Erstelle ein Java-Programm, das die Anzahl der Wörter in einem gegebenen String zählt. Implementiere eine robuste Benutzerführung für die Eingabe:
        //
        // * Fordere den Benutzer so lange zur Eingabe eines Text-Strings auf, bis eine gültige Eingabe erfolgt.
        // * Der eingegebene String darf **nicht** leer sein.
        // * Der eingegebene String **muss** mindestens ein Leerzeichen enthalten (als einfache Methode, um sicherzustellen, dass potenziell mehrere Wörter vorhanden sind).
        // * Sobald eine gültige Eingabe empfangen wurde, teile den String in Wörter auf und zeige die Gesamtzahl der Wörter an.
        //     * **Hinweis**: Die `split()`-Methode der `String`-Klasse wird hier sehr nützlich sein.
        System.out.println("\n--- Aufgabe: Wortzauberei (Wörter zählen) ---");
        String textFuerWortzaehlung;
        while (true) {
            System.out.print("Geben Sie einen Text mit mindestens einem Leerzeichen ein: ");
            textFuerWortzaehlung = scanner.nextLine();
            if (textFuerWortzaehlung == null || textFuerWortzaehlung.trim().isEmpty()) {
                System.out.println("   Eingabe darf nicht leer sein. Bitte erneut versuchen.");
                continue;
            }
            boolean enthaeltLeerzeichen = false;
            for(int i=0; i < textFuerWortzaehlung.length(); i++){
                if(textFuerWortzaehlung.charAt(i) == ' '){
                    enthaeltLeerzeichen = true;
                    break;
                }
            }
            if (!enthaeltLeerzeichen) {
                 System.out.println("   Eingabe muss mindestens ein Leerzeichen enthalten. Bitte erneut versuchen.");
                 continue;
            }
            break; // Gültige Eingabe
        }
        String[] worte = textFuerWortzaehlung.trim().split("\\s+"); // Trennt bei einem oder mehreren Leerzeichen
        System.out.println(String.format("   Der Text \"%s\" hat %d Wörter.", textFuerWortzaehlung, worte.length));


        // ### Abwechselnde Groß-/Kleinschreibung 🔄
        //
        // Schreibe ein Java-Programm, das die Groß-/Kleinschreibung von Zeichen in einem vom Benutzer bereitgestellten String manipuliert.
        //
        // * **a) Einfache abwechselnde Großschreibung**:
        //     * Fordere den Benutzer zur Eingabe eines Strings auf.
        //     * Erstelle einen neuen String, bei dem Zeichen an geraden Indizes (0, 2, 4, ...) in Großbuchstaben umgewandelt werden und Zeichen an ungeraden Indizes in ihrer ursprünglichen Schreibweise verbleiben.
        //     * Zeige den modifizierten String an.
        // * **b) Strikte abwechselnde Groß-/Kleinschreibung**:
        //     * Fordere den Benutzer zur Eingabe eines Strings auf.
        //     * Erstelle einen neuen String, bei dem Zeichen an geraden Indizes in Großbuchstaben und Zeichen an ungeraden Indizes in Kleinbuchstaben umgewandelt werden.
        //     * Zeige den modifizierten String an.
        // * **c) Gefilterte strikte abwechselnde Groß-/Kleinschreibung**:
        //     * Fordere den Benutzer zur Eingabe eines Strings auf.
        //     * Erstelle zuerst eine "bereinigte" Version des eingegebenen Strings, die *nur* alphabetische Zeichen (a-z, A-Z) enthält. Verwirf alle anderen Zeichen (Zahlen, Symbole, Leerzeichen usw.).
        //         * **Hinweis**: Du kannst einen "Whitelist"-String mit erlaubten Zeichen definieren und für jedes Zeichen der Eingabe prüfen, ob es in dieser Whitelist enthalten ist.
        //     * Wende dann auf diesen bereinigten String die strikte Logik zur abwechselnden Groß-/Kleinschreibung aus Teil (b) an: Zeichen an geraden Indizes werden zu Großbuchstaben, Zeichen an ungeraden Indizes zu Kleinbuchstaben.
        //     * Zeige den endgültig modifizierten String an.
        System.out.println("\n--- Aufgabe: Abwechselnde Groß-/Kleinschreibung ---");
        System.out.print("Geben Sie einen Text für die abwechselnde Schreibweise ein: ");
        eingabe = scanner.nextLine();
        StringBuilder sbAlternierendA = new StringBuilder();
        StringBuilder sbAlternierendB = new StringBuilder();
        StringBuilder sbAlternierendCBasis = new StringBuilder();
        StringBuilder sbAlternierendCResultat = new StringBuilder();

        if (eingabe != null) {
            // a) Einfache abwechselnde Großschreibung
            for (int i = 0; i < eingabe.length(); i++) {
                char c = eingabe.charAt(i);
                if (i % 2 == 0) { // Gerade Indizes
                    sbAlternierendA.append(Character.toUpperCase(c));
                } else {
                    sbAlternierendA.append(c);
                }
            }
            System.out.println("a) Einfach alternierend: " + sbAlternierendA.toString());

            // b) Strikte abwechselnde Groß-/Kleinschreibung
            for (int i = 0; i < eingabe.length(); i++) {
                char c = eingabe.charAt(i);
                if (i % 2 == 0) { // Gerade Indizes
                    sbAlternierendB.append(Character.toUpperCase(c));
                } else { // Ungerade Indizes
                    sbAlternierendB.append(Character.toLowerCase(c));
                }
            }
            System.out.println("b) Strikt alternierend: " + sbAlternierendB.toString());

            // c) Gefilterte strikte abwechselnde Groß-/Kleinschreibung
            String whitelist = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < eingabe.length(); i++) {
                char c = eingabe.charAt(i);
                // Prüfen, ob das Zeichen in der Whitelist ist
                boolean istInWhitelist = false;
                for (int j = 0; j < whitelist.length(); j++) {
                    if (c == whitelist.charAt(j)) {
                        istInWhitelist = true;
                        break;
                    }
                }
                if (istInWhitelist) {
                    sbAlternierendCBasis.append(c);
                }
            }
            System.out.println("c) Bereinigter String (nur Buchstaben): " + sbAlternierendCBasis.toString());

            String bereinigterTextFuerC = sbAlternierendCBasis.toString();
            for (int i = 0; i < bereinigterTextFuerC.length(); i++) {
                char c = bereinigterTextFuerC.charAt(i);
                if (i % 2 == 0) { // Gerade Indizes im bereinigten String
                    sbAlternierendCResultat.append(Character.toUpperCase(c));
                } else { // Ungerade Indizes im bereinigten String
                    sbAlternierendCResultat.append(Character.toLowerCase(c));
                }
            }
            System.out.println("c) Gefiltert & strikt alternierend: " + sbAlternierendCResultat.toString());
        } else {
            System.out.println("   Eingabe war null.");
        }


        // ### Grundlegende Datenkompression (Konzeptionell) 🤏
        //
        // Bei dieser Übung geht es mehr darum, einen Prozess zu durchdenken. Stelle dir vor, du müsstest eine einfache Form der Datenkompression implementieren, die als Lauflängenkodierung (Run-Length Encoding, RLE) bezeichnet wird.
        //
        // **Was ist Lauflängenkodierung (RLE)?**
        // Die Lauflängenkodierung ist eine einfache Form der Datenkompression, bei der Sequenzen von gleichen Datenwerten (sogenannte "Runs" oder "Läufe") als ein einzelner Datenwert und dessen Anzahl gespeichert werden. Sie ist besonders effektiv bei Daten mit vielen Wiederholungen.
        //
        // * **Beispiel für Kodierung mit Binärcode (einzelne Bits)**: Ein Binärstring wie `0000011100000000` (16 Bit) besteht aus:
        //     * Fünf `0`en
        //     * Drei `1`en
        //     * Acht `0`en
        //     Die RLE-Version könnte dann als Sequenz von (Anzahl, Wert) Paaren dargestellt werden, z.B. `(5,0)(3,1)(8,0)` oder in einer kompakteren Form wie `503180`.
        //
        // * **Beispiel für Dekodierung mit Binärcode (einzelne Bits)**: Aus der RLE-Darstellung `503180` würde man wieder den ursprünglichen Binärstring `0000011100000000` erhalten.
        //
        // * **Anwendungsbeispiel: Bilddaten (Pixelwerte)** 🖼️
        //     Stell dir eine Bilddatei vor. Jedes Pixel wird oft durch drei Farbwerte dargestellt: Rot, Grün und Blau (RGB). Jeder dieser Werte kann z.B. 1 Byte (8 Bit) beanspruchen, also insgesamt 3 Bytes pro Pixel. Ein Pixel mit der Farbe Weiß könnte z.B. als (255, 255, 255) gespeichert werden, was binär `11111111 11111111 11111111` (3 Bytes) entspricht.
        //     Wenn nun mehrere aufeinanderfolgende Pixel exakt denselben Farbwert haben (also dieselben 3 Bytes), kann RLE angewendet werden:
        //     * **Originale Pixeldaten (Sequenz von 3-Byte-Farbwerten):**
        //         `Pixel1_RGB_Daten` `Pixel1_RGB_Daten` `Pixel1_RGB_Daten` `Pixel2_RGB_Daten` `Pixel2_RGB_Daten`
        //         (Wobei `Pixel1_RGB_Daten` z.B. die 3 Bytes für Weiß sind, und `Pixel2_RGB_Daten` die 3 Bytes für eine andere Farbe.)
        //     * **RLE-kodiert:** `(3, Pixel1_RGB_Daten) (2, Pixel2_RGB_Daten)`
        //     Dies speichert, dass der 3-Byte-Block `Pixel1_RGB_Daten` dreimal vorkommt, gefolgt von zweimal dem 3-Byte-Block `Pixel2_RGB_Daten`. Dies ist besonders bei großen, einfarbigen Flächen in Bildern effizient.
        //
        // **Aufgabe**:
        //
        // 1.  Beschreibe in Worten (Pseudocode oder eine schrittweise Beschreibung) die Logik, die du verwenden würdest, um eine Java-Methode `String komprimiere(String eingabe)` zu schreiben, die eine RLE-Kodierung für einen String durchführt, der nur aus den Zeichen '0' und '1' besteht (ähnlich dem ersten Binärcode-Beispiel, das einzelne Bits/Zeichen komprimiert).
        // 2.  Beschreibe in Worten die Logik für eine Methode `String dekomprimiere(String komprimierteEingabe)`, die die entsprechende Dekodierung für den RLE-kodierten '0'/'1'-String durchführt.
        //
        // *(Für diese RLE-Übung ist nicht zwingend sofort der vollständige Java-Code erforderlich, sondern primär das Verständnis der algorithmischen Schritte. Eine Java-Implementierung darf nur grundlegende Konzepte wie Schleifen, Verzweigungen, Methodenaufrufe, Operatoren, Variablen/Werte und höchstens Arrays verwenden.)*
        System.out.println("\n--- Aufgabe: Grundlegende Datenkompression (RLE für '0'/'1' Strings) ---");
        String rleEingabe = "000001110000000011"; // Beispiel
        // String rleEingabe = "1";
        // String rleEingabe = "";
        // String rleEingabe = "000";

        System.out.println("RLE Eingabe: " + rleEingabe);
        String rleKomprimiert = "";
        if (rleEingabe != null && !rleEingabe.isEmpty()) {
            StringBuilder komprimiertBuilder = new StringBuilder();
            int anzahl = 1;
            char aktuellesZeichenRLE = rleEingabe.charAt(0);
            for (int i = 1; i < rleEingabe.length(); i++) {
                if (rleEingabe.charAt(i) == aktuellesZeichenRLE) {
                    anzahl++;
                } else {
                    komprimiertBuilder.append(anzahl);
                    komprimiertBuilder.append(aktuellesZeichenRLE);
                    aktuellesZeichenRLE = rleEingabe.charAt(i);
                    anzahl = 1;
                }
            }
            // Den letzten Lauf hinzufügen
            komprimiertBuilder.append(anzahl);
            komprimiertBuilder.append(aktuellesZeichenRLE);
            rleKomprimiert = komprimiertBuilder.toString();
        }
        System.out.println("RLE Komprimiert: " + rleKomprimiert);

        // Dekomprimierung (konzeptionell, hier eine einfache Implementierung)
        String rleDekomprimiert = "";
        if (rleKomprimiert != null && !rleKomprimiert.isEmpty() && rleKomprimiert.length() % 2 == 0) { // Einfache Prüfung
            StringBuilder dekomprimiertBuilder = new StringBuilder();
            for (int i = 0; i < rleKomprimiert.length(); i += 2) {
                // Annahme: Anzahl ist immer eine einzelne Ziffer für diese einfache Implementierung.
                // Für größere Anzahlen müsste man die Zahl parsen, bis ein Nicht-Ziffer-Zeichen kommt.
                char anzahlChar = rleKomprimiert.charAt(i);
                char zeichenRLE = rleKomprimiert.charAt(i + 1);
                int wiederholungen = 0;
                // Umwandlung char '0'-'9' zu int 0-9
                if(anzahlChar >= '0' && anzahlChar <= '9'){
                    wiederholungen = anzahlChar - '0';
                } else {
                    System.out.println("Fehler im komprimierten Format (Anzahl ist keine Ziffer).");
                    dekomprimiertBuilder = new StringBuilder("Formatfehler"); // Fehler anzeigen
                    break;
                }

                for (int j = 0; j < wiederholungen; j++) {
                    dekomprimiertBuilder.append(zeichenRLE);
                }
            }
            rleDekomprimiert = dekomprimiertBuilder.toString();
        } else if (rleKomprimiert != null && !rleKomprimiert.isEmpty()) {
            System.out.println("Fehler: Komprimierter String hat eine ungerade Länge oder ist leer.");
            rleDekomprimiert = "Formatfehler";
        }
        System.out.println("RLE Dekomprimiert: " + rleDekomprimiert);
        System.out.println("Stimmt mit Original überein? " + rleEingabe.equals(rleDekomprimiert));


        // ### Ist es ein Palindrom?
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

        // Andere Variante: ohne Umdrehen des strings - wir drehen den Ansatz um! - Schritte von links und rechts gleichzeitig und vergleiche diese
        for (int left = 0; left < input.length(); left++) {
            int right = input.length()-1-left;

            if( input.charAt(left) != input.charAt(right) ) {
                isPalindrome = false;
                break;
            } else {
                isPalindrome = true;
            }
        }
        System.out.println("Ist es ein Palindrom? - " + (isPalindrome ? "Ja" : "Nein") + "!");

        // ### Anagramm-Ermittler 🕵️‍♀️
        //
        // Zwei Strings sind Anagramme, wenn sie dieselben Zeichen in derselben Anzahl enthalten, aber möglicherweise in einer anderen Reihenfolge (z.B. "listen" und "silent", oder "Tom Marvolo Riddle" und "Ich bin Lord Voldemort" nach der Normalisierung).
        //
        // Schreibe ein Java-Programm, das:
        //
        // 1.  Den Benutzer zur Eingabe von zwei Strings auffordert.
        // 2.  Beide Strings vorverarbeitet:
        //     * Alle Leerzeichen entfernt.
        //     * Alle Zeichen in eine einheitliche Schreibweise umwandelt (z.B. Kleinbuchstaben).
        //     * Optional: Andere Satzzeichen entfernen.
        // 3.  Ermittelt, ob die beiden vorverarbeiteten Strings Anagramme voneinander sind.
        //     * **Hinweis**: Überlege, wie du den Zeicheninhalt zweier Strings unabhängig von ihrer Reihenfolge vergleichen kannst. Das Sortieren der Zeichen jedes Strings könnte ein hilfreicher Ansatz sein.
        // 4.  Ausgibt, ob die beiden ursprünglichen Strings (nach der Normalisierung) Anagramme sind.
        System.out.println("\n--- Aufgabe: Anagramm-Ermittler ---");
        System.out.print("Geben Sie den ersten Text für den Anagramm-Check ein: ");
        eingabe = scanner.nextLine();
        System.out.print("Geben Sie den zweiten Text für den Anagramm-Check ein: ");
        eingabe2 = scanner.nextLine();

        String anagrammText1 = "";
        String anagrammText2 = "";

        if (eingabe != null && eingabe2 != null) {
            // Vorverarbeitung: Leerzeichen entfernen, Kleinschreibung, (optional: Satzzeichen entfernen)
            // Hier entfernen wir alles, was kein Buchstabe ist, und machen alles klein.
            anagrammText1 = eingabe.replaceAll("[^a-zA-Z]", "").toLowerCase();
            anagrammText2 = eingabe2.replaceAll("[^a-zA-Z]", "").toLowerCase();

            System.out.println("Bereinigter Text 1: " + anagrammText1);
            System.out.println("Bereinigter Text 2: " + anagrammText2);

            boolean sindAnagramme = false;
            if (anagrammText1.length() != anagrammText2.length()) {
                sindAnagramme = false; // Unterschiedliche Längen können keine Anagramme sein
            } else if (anagrammText1.isEmpty() && anagrammText2.isEmpty()) {
                sindAnagramme = true; // Zwei leere (bereinigte) Strings sind Anagramme
            }
            else {
                // Zeichen-Arrays erstellen und sortieren
                char[] array1 = anagrammText1.toCharArray();
                char[] array2 = anagrammText2.toCharArray();
                Arrays.sort(array1);
                Arrays.sort(array2);
                sindAnagramme = Arrays.equals(array1, array2);
            }

            if (sindAnagramme) {
                System.out.println(String.format("\"%s\" und \"%s\" sind Anagramme.", eingabe, eingabe2));
            } else {
                System.out.println(String.format("\"%s\" und \"%s\" sind KEINE Anagramme.", eingabe, eingabe2));
            }
        } else {
            System.out.println("Eine der Eingaben war null.");
        }

        System.out.println("\n--- Alle Übungen abgeschlossen ---");
        scanner.close(); // Scanner am Ende der main-Methode schließen
    }
}
