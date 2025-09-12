package lerneinheiten.L07VerzweigungenSwitch.uebung;

import java.util.Random;
import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Monate
        // Einlesen von Monatsnummer (1=Jänner, 2=Februar, ...) und in Variable speichern
        // Fallunterscheidung und Ausgabe des gewählten Monats mittels switch.
        // **Beispiel:**
        // ```
        // Monatsnummer eingeben:  2
        // Das 2.  Monat hat den Namen Februar
        // ```

        System.out.print("Monatsnummer eingeben: ");
        int monat = scanner.nextInt();

        String ausgabe = switch (monat) {
            case 1 -> "Das 1. Monat hat den Namen Jänner";
            case 2 -> "Das 2. Monat hat den Namen Februar";
            case 3 -> "Das 3. Monat hat den Namen März";
            case 4 -> "Das 4. Monat hat den Namen April";
            case 5 -> "Das 5. Monat hat den Namen Mai";
            case 6 -> "Das 6. Monat hat den Namen Juni";
            case 7 -> "Das 7. Monat hat den Namen Juli";
            case 8 -> "Das 8. Monat hat den Namen August";
            case 9 -> "Das 9. Monat hat den Namen September";
            case 10 -> "Das 10. Monat hat den Namen Oktober";
            case 11 -> "Das 11. Monat hat den Namen November";
            case 12 -> "Das 12. Monat hat den Namen Dezember";
            default -> "Ungültige Monatsnummer.";
        };

        System.out.println(ausgabe);

        // Anzahl der Tage/Monat ermitteln
        // Die Monate 1, 3, 5, 7, 8, 10, 12 haben 31 Tage
        // Die Monate 4, 6, 9, 11 haben 30 Tage
        // Das Monat Februar (2) hat 28 Tage (Schaltjahre ignorieren)
        // 1. Schreiben Sie ein Programm, welches die Monatsnummer einliest und die Anzahl der Tage ausgibt.
        // 2. Kombinieren Sie diese Übung mit der Ermittlung des Monatsnamen um auch diesen Auszugeben.
        // **Beispiel:**
        // ```
        // Monatsnummer eingeben:  4
        // Das 4.  Monat ist April und hat 30 Tage.
        // ```


        // Variante 1
        System.out.print("Monatsnummer eingeben: ");
        monat = scanner.nextInt();

        String name = "";
        int tage = 0;

        switch (monat) {
            case 1: name = "Jänner"; tage = 31; break;
            case 2: name = "Februar"; tage = 28; break;
            case 3: name = "März"; tage = 31; break;
            case 4: name = "April"; tage = 30; break;
            case 5: name = "Mai"; tage = 31; break;
            case 6: name = "Juni"; tage = 30; break;
            case 7: name = "Juli"; tage = 31; break;
            case 8: name = "August"; tage = 31; break;
            case 9: name = "September"; tage = 30; break;
            case 10: name = "Oktober"; tage = 31; break;
            case 11: name = "November"; tage = 30; break;
            case 12: name = "Dezember"; tage = 31; break;
        }

        System.out.println("Das " + monat + ". Monat ist " + name + " und hat " + tage + " Tage.");

        // Variante 2
        name = switch (monat) {
            case 1 -> "Jänner";
            case 2 -> "Februar";
            case 3 -> "März";
            case 4 -> "April";
            case 5 -> "Mai";
            case 6 -> "Juni";
            case 7 -> "Juli";
            case 8 -> "August";
            case 9 -> "September";
            case 10 -> "Oktober";
            case 11 -> "November";
            case 12 -> "Dezember";
            default -> "unbekannt";
        };

        tage = switch (monat) {
            case 1, 3, 5, 7, 8, 10, 12 -> 31;
            case 4, 6, 9, 11 -> 30;
            case 2 -> 28;
            default -> 0;
        };
        
        System.out.println("Das " + monat + ". Monat ist " + name + " und hat " + tage + " Tage.");
        
        // Preisberechnung
        // Die Eintrittspreise für ein Schwimmbad sind gestaffelt nach dem Wochentag:
        // - Am Tag 1: 4,5 Euro.
        // - Am Tag 2: 6 Euro.
        // - Am Tag 3: 7 Euro
        // - Tag 4 bis 7 kosten die Tageskarten 8 Euro.
        
        // Einlesen von Wochentag. Ausgabe von Tagname und Preis
        // **Beispiel:**
        // ```
        // Wochentag eingeben:  2
        // Am Dienstag kostet die Tageskarte 6 Euro.
        // ```

        // Variante 1
        System.out.print("Wochentag eingeben (1=Mo, ..., 7=So): ");
        int tag = scanner.nextInt();
        double preis;
        String tagName;

        ausgabe = switch (tag) {
            case 1 -> "Am Montag kostet die Tageskarte 4.5 Euro.";
            case 2 -> "Am Dienstag kostet die Tageskarte 6 Euro.";
            case 3 -> "Am Mittwoch kostet die Tageskarte 7 Euro.";
            case 4 -> "Am Donnerstag kostet die Tageskarte 8 Euro.";
            case 5 -> "Am Freitag kostet die Tageskarte 8 Euro.";
            case 6 -> "Am Samstag kostet die Tageskarte 8 Euro.";
            case 7 -> "Am Sonntag kostet die Tageskarte 8 Euro.";
            default -> "Ungültiger Wochentag";
        };

        System.out.println(ausgabe);

        // Variante 2
        System.out.print("Wochentag eingeben (1=Mo, ..., 7=So): ");
        tag = scanner.nextInt();

        tagName = "";
        preis = 0;

        switch (tag) {
            case 1: tagName = "Montag"; preis = 4.5; break;
            case 2: tagName = "Dienstag"; preis = 6; break;
            case 3: tagName = "Mittwoch"; preis = 7; break;
            case 4: tagName = "Donnerstag"; preis = 8; break;
            case 5: tagName = "Freitag"; preis = 8; break;
            case 6: tagName = "Samstag"; preis = 8; break;
            case 7: tagName = "Sonntag"; preis = 8; break;
            default:
                System.out.println("Ungültiger Wochentag");
                // was apssiert hier mit den Variablen tagNAme und preis?
        }

        System.out.println("Am " + tagName + " kostet die Tageskarte " + preis + " Euro.");


        // Klassifizierung von Schrauben
        // Ein Hersteller klassifiziert Schrauben nach folgendem Schema:
        // - Schrauben mit einem Durchmesser bis zu 3 mm und einer Länge bis zu 20 mm sind vom Typ1.
        // - Schrauben mit einem Durchmesser von 4 bis 6 mm und einer Länge von 21 bis 30 mm sind vom Typ2
        // - Schrauben mit einem Durchmesser von 7 bis 20 mm und einer Länge von 31 bis 50 mm sind vom Typ3
        // Schreiben Sie ein Programm die den richtigen Schraubentyp ermittelt, wenn Durchmesser und Länge als ganze Zahlen eingegeben werden. Sollte eine Schraube keiner der oben beschriebenen Kategorien angehören, soll die Meldung „Unbekannter Schraubentyp“  ausgegeben werden. Testen Sie Ihr Programm für verschiedene Eingaben.

        System.out.print("Durchmesser (mm): ");
        int d = scanner.nextInt();
        System.out.print("Länge (mm): ");
        int l = scanner.nextInt();

        String typ = (d <= 3 && l <= 20) ? "Typ1" :
                     (d >= 4 && d <= 6 && l >= 21 && l <= 30) ? "Typ2" :
                     (d >= 7 && d <= 20 && l >= 31 && l <= 50) ? "Typ3" :
                     "Unbekannter Schraubentyp";

        System.out.println("Schraubentyp: " + typ);

        // Zielpreisberechnung
        // Sie sind Programmierer in einem Online-Shop und möchten den Versandpreis basierend auf dem Land des Kunden berechnen. Bitten Sie den Benutzer, das Zielland für den Versand einzugeben (z.B., "DE" für Deutschland, "US" für die USA, "FR" für Frankreich usw.). Verwenden Sie eine switch-Anweisung, um den Versandpreis zu berechnen, basierend auf dem Zielland. Geben Sie dann den Versandpreis aus. Wenn das Zielland nicht erkannt wird, geben Sie eine Fehlermeldung aus.
        // **Preise:**
        // ```
        // Land Preis
        // AT 0,00€
        // DE 4,00€
        // FR 8,00€
        // IT 8,00€
        // SZ 8,00€
        // US 10,00€
        // CZ 10,00€
        // Rest 17,00€
        // ```

        System.out.print("Zielland (z.B. DE, AT, US): ");
        String land = scanner.nextLine().toUpperCase();

        preis = switch (land) {
            case "AT" -> 0.00;
            case "DE" -> 4.00;
            case "FR", "IT", "SZ" -> 8.00;
            case "US", "CZ" -> 10.00;
            default -> 17.00;
        };

        System.out.println("Versandpreis: " + preis + " €");

        // Flugpreise
        // Sie entwickeln eine Anwendung für eine Fluggesellschaft, die den Ticketpreis basierend auf verschiedenen Kriterien berechnet. Bitten Sie den Benutzer um folgende Informationen:
        // - Die Entfernung in Kilometern für die Flugstrecke.
        // - Das Reisedatum (Monat) als Ganzzahlwert (z.B., 1 für Januar, 2 für Februar usw.).
        // - Die Buchungsklasse (Erste Klasse, Premium Economy oder Economy). Verwenden Sie eine Kombination von switch und if-Anweisungen, um den Ticketpreis basierend auf diesen Informationen zu berechnen. Zum Beispiel können Sie verschiedene Preise für verschiedene Entfernungen und Monate festlegen, und je nach Buchungsklasse den Preis entsprechend anpassen.
        // **Preise:**
        // ```
        // Strecke je km 0,02€
        // Economy Aufschlag 0,00€
        // Premium Economy Aufschlag 200,00€
        // Erste Klasse Aufschlag 400,00€
        // Aufschlag Juli-September 20,00€
        // Aufschlag Dezember 15,00€
        // ```

        System.out.print("Entfernung in km: ");
        int km = scanner.nextInt();
        System.out.print("Reisemonat (1–12): ");
        monat = scanner.nextInt();
        scanner.nextLine();
        System.out.print("Buchungsklasse (economy, premium, first): ");
        String klasse = scanner.nextLine().toLowerCase();

        double basisPreis = km * 0.02;
        double aufschlag = switch (klasse) {
            case "economy" -> 0;
            case "premium" -> 200;
            case "first" -> 400;
            default -> 0;
        };

        if (monat >= 7 && monat <= 9) aufschlag += 20;
        else if (monat == 12) aufschlag += 15;

        double gesamt = basisPreis + aufschlag;
        System.out.println("Gesamtpreis: " + gesamt + " €");


        // Tage bis Wochenende
        // Schreiben Sie ein Programm, das den Namen eines Wochentags als Eingabe erhält und die Anzahl der verbleibenden Tage bis zum Wochenende ausgibt. Verwenden Sie Switch-Case, um den entsprechenden Wochentag zu bestimmen.
        // **Beispiel:**
        // ```
        // Montag: 5 Tage
        // Dienstag: 4 Tage
        // Mittwoch: 3 Tage
        // Donnerstag: 2 Tage
        // Freitag: 1 Tage
        // Samstag: Es ist Wochenende
        // Sonntag: Es ist Wochenende
        // ```

        System.out.print("Wochentag eingeben: ");
        String tagAlsString = scanner.nextLine().toLowerCase();

        ausgabe = switch (tagAlsString) {
            case "montag" -> "5 Tage";
            case "dienstag" -> "4 Tage";
            case "mittwoch" -> "3 Tage";
            case "donnerstag" -> "2 Tage";
            case "freitag" -> "1 Tage";
            case "samstag", "sonntag" -> "Es ist Wochenende";
            default -> "Ungültiger Wochentag";
        };

        System.out.println(ausgabe);

        // Altersgruppe
        // Schreibe ein Programm, das den Nutzer nach seinem Alter fragt und basierend darauf eine entsprechende Meldung ausgibt, z.B. ob der Nutzer ein Kind(0-13), Jugendlicher(14-17), Erwachsener(18-65) oder Pensionist(ab 65) ist. Entscheiden Sie selbst, ob if oder switch besser passt.
        // **Beispiel:**
        // ```
        // Wie alt bist du? 25
        // Du bist ein Erwachsener.
        // ```
        System.out.print("Wie alt bist du? ");
        int alter = scanner.nextInt();

        String gruppe = (alter >= 0 && alter <= 13) ? "Kind" :
                        (alter >= 14 && alter <= 17) ? "Jugendlicher" :
                        (alter >= 18 && alter <= 65) ? "Erwachsener" :
                        (alter > 65) ? "Pensionist" :
                        "Ungültiges Alter";

        System.out.println("Du bist ein " + gruppe + ".");


        // Rabattrechner
        // Schreiben Sie ein Programm, das den Nutzer nach dem Kaufpreis eines Produkts fragt und basierend darauf einen Rabatt berechnet. Wenn der Kaufpreis über 100 Euro beträgt, soll ein Rabatt von 10% gewährt werden, ansonsten kein Rabatt.
        System.out.print("Kaufpreis in Euro: ");
        preis = scanner.nextDouble();

        double rabatt = preis > 100 ? preis * 0.1 : 0;
        double endpreis = preis - rabatt;

        System.out.println("Endpreis: " + endpreis + " €");


        // Zahl erraten
        // Schreibe ein Programm, das eine zufällige Zahl zwischen 1 und 100 generiert und den Benutzer auffordert, diese Zahl zu erraten. Das Programm soll dann eine Nachricht ausgeben, ob die geratene Zahl zu hoch, zu niedrig oder korrekt ist. Der Benutzer hat insgesamt drei Versuche, um die Zahl zu erraten. Verwende dazu die java.util.Random-Klasse.
        // Erinnerung: Zahl zwischen 1 und 10 generieren:
        // ```java
        // import java.util.Random; 
        // .... 
        // Random random = new Random(); 
        // int randomNumber = random.nextInt(0, 11); 
        // ```
        // **Beispiel:**
        // ```
        // Ich denke an eine Zahl zwischen 1 und 100.  Du hast 3 Versuche,  um sie zu erraten.
        // Was ist deine erste Vermutung? 50
        // Zu niedrig.  Du hast noch 2 Versuche.
        // Was ist deine nächste Vermutung? 75
        // Zu hoch.  Du hast noch 1 Versuch.
        // Was ist deine letzte Vermutung? 62
        // Richtig! Du hast gewonnen.
        // ```

        int versuch = 0;
        Random random = new Random();
        int ziel = random.nextInt(1, 101);

        System.out.println("Ich denke an eine Zahl zwischen 1 und 100. Du hast 3 Versuche, um sie zu erraten.");
        System.out.print("Was ist deine Vermutung? ");
        int tipp = scanner.nextInt();
        boolean gewonnen = false;

        if (tipp == ziel) {
            System.out.println("Richtig! Du hast gewonnen.");
            gewonnen = true;
        } else if (tipp < ziel) {
            System.out.println("Zu niedrig. Du hast noch " + (3 - versuch) + " Versuche.");
        } else {
            System.out.println("Zu hoch. Du hast noch " + (3 - versuch) + " Versuche.");
        }

        System.out.print("Was ist deine Vermutung? ");
        tipp = scanner.nextInt();

        if (!gewonnen) {
            if (tipp == ziel) {
                System.out.println("Richtig! Du hast gewonnen.");
                gewonnen = true;
            } else if (tipp < ziel) {
                System.out.println("Zu niedrig. Du hast noch " + (3 - versuch) + " Versuche.");
            } else {
                System.out.println("Zu hoch. Du hast noch " + (3 - versuch) + " Versuche.");
            }
            
            if (!gewonnen) {
                System.out.print("Was ist deine Vermutung? ");
                tipp = scanner.nextInt();
                
                if (tipp == ziel) {
                    System.out.println("Richtig! Du hast gewonnen.");
                    gewonnen = true;
                } else {
                    System.out.println("Leider verloren. Die Zahl war: " + ziel);
                }
            }
            
        }

        // Switch zu ...
        // Wandle folgenden Code in eine Mehrfachverzweigung mittels...
        // ```java
        // String toPrint = switch(genre.toLowerCase()) {
        //     case "action"            -> "Schauen wir einen Actionfilm!";
        //     case "komödie", "lustig" -> "Lass uns eine Komödie sehen!";
        //     case "horror"            -> "Du magst es grueselig";
        //     case "thriller"          -> "Spannend!";
        //     case "romantik", "liebesfilm" -> "Wie wäre es mit einer Romanze?";
        //     default                  -> "Ich kenne dieses Genre nicht.";
        // }
        // System.out.println(toPrint)
        // ```
        // * ... IF-Anweisung um
        System.out.print("Gib ein Genre ein.");
        String genre = scanner.nextLine();

        if (genre.equalsIgnoreCase("action")) {
            ausgabe = "Schauen wir einen Actionfilm!";

        } else if (genre.equalsIgnoreCase("komödie") || genre.equalsIgnoreCase("lustig")) {
            ausgabe = "Lass uns eine Komödie sehen!";

        } else if (genre.equalsIgnoreCase("horror")) {
            ausgabe = "Du magst es grueselig";

        } else if (genre.equalsIgnoreCase("thriller")) {
            ausgabe = "Spannend!";

        } else if (genre.equalsIgnoreCase("romantik") || genre.equalsIgnoreCase("liebesfilm")) {
            ausgabe = "Wie wäre es mit einer Romanze?";

        } else {
            ausgabe = "Ich kenne dieses Genre nicht.";
        }

        System.out.println(ausgabe);

        // * ... IF-Ausdruck um
        ausgabe = genre.equalsIgnoreCase("action") ? "Schauen wir einen Actionfilm!" :
                  genre.equalsIgnoreCase("komödie") || genre.equalsIgnoreCase("lustig") ? "Lass uns eine Komödie sehen!" :
                  genre.equalsIgnoreCase("horror") ? "Du magst es grueselig" :
                  genre.equalsIgnoreCase("thriller") ? "Spannend!" :
                  genre.equalsIgnoreCase("romantik") || genre.equalsIgnoreCase("liebesfilm") ? "Wie wäre es mit einer Romanze?" :
                "Ich kenne dieses Genre nicht.";


        // * ... klasische Switch-Anweisung mit case: und break; um
        switch (genre.toLowerCase()) {
            case "action":
                ausgabe = "Schauen wir einen Actionfilm!";
                break;
            case "lustig", "komödie":
                ausgabe = "Lass uns eine Komödie sehen!";
                break;
            case "horror":
                ausgabe = "Du magst es grueselig";
                break;
            case "thriller":
                ausgabe = "Spannend!";
                break;
            case "liebesfilm", "romantik":
                ausgabe = "Wie wäre es mit einer Romanze?";
                break;
            default:
                ausgabe = "Ich kenne dieses Genre nicht.";
        }

        System.out.println(ausgabe);

        // * ... klassische Switch-Anweisung mit case: und break; ohne Beistrich wie case "komödie", "lustig":
        switch (genre.toLowerCase()) {
            case "action":
                ausgabe = "Schauen wir einen Actionfilm!";
                break;
            case "komödie": // Achtung! Was passiert hier?
            case "lustig":
                ausgabe = "Lass uns eine Komödie sehen!";
                break;
            case "horror":
                ausgabe = "Du magst es grueselig";
                break;
            case "thriller":
                ausgabe = "Spannend!";
                break;
            case "romantik":
            case "liebesfilm":
                ausgabe = "Wie wäre es mit einer Romanze?";
                break;
            default:
                ausgabe = "Ich kenne dieses Genre nicht.";
        }

        System.out.println(ausgabe);
    }
}
