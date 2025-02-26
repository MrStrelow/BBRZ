package lerneinheiten.L04UserInput.uebung;

import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

//        1. - Abfragen von Strings
//        Fragen Sie den Benutzer nach 3 Strings ab. Geben Sie anschließend alle drei Strings aus.
//                Eingabe von String 1: Hallo
//                Eingabe von String 2: am
//                Eingabe von String 3: Mittwoch
//                Ausgabe: Hallo am Mittwoch

        // BEACHTE System.out.print vs. System.out.println hier! Die Eingabe ist damit nicht in der nächsten Zeile.
        System.out.print("Eingabe von String 1: ");
        String ersterString = scanner.nextLine();

        System.out.print("Eingabe von String 2: ");
        String zweiterString = scanner.nextLine();

        System.out.print("Eingabe von String 3: ");
        String dritterString = scanner.nextLine();

        System.out.println("Ausgabe: " + ersterString + " " + zweiterString + " " + dritterString);

//        wenn wir das Objekt scanner hier mit scanner.close(); schließen, können wir keine weiteren Symbole einlesen! ...
//        auch mit einem neuen Objekt zweiter Scanner!
//        deshalb schließen wir diesen erstenScanner hier nicht! Wir schließen den "Stream" (unser Scanner) erst ...
//        wenn wir diesen nicht wieder benötigen! Ein "reopen" mittels neuem Scanner geht leider nicht.

//        2. - Abfragen von Integer
//        Fragen Sie den Benutzer nach 3 Integer ab. Geben Sie anschließend die Summe aller drei Integer aus.
//                Eingabe von Integer 1: 5
//                Eingabe von Integer 2: 2
//                Eingabe von Integer 3: 10
//                Ausgabe: 5 + 2 + 10 = 17
        System.out.print("Eingabe von Integer 1: ");
        Integer ersterInteger = Integer.parseInt( scanner.nextLine() );

        System.out.print("Eingabe von Integer 2: ");
        Integer zweiterInteger = Integer.parseInt( scanner.nextLine() );

        System.out.print("Eingabe von Integer 3: ");
        Integer driterInteger = Integer.parseInt( scanner.nextLine() );

        Integer summe = ersterInteger + zweiterInteger + driterInteger;
        System.out.println("Ausgabe: " + ersterInteger + " + " + zweiterInteger + " + " + driterInteger + " = " + summe );

//        3. - Einstieg
//        Fragen Sie folgende Datentypen von der Konsole ab. Speichern Sie diese Eingaben in die entsprechenden Variablen.
//                String
//                Integer
//                Double
//                Boolean
//        Geben Sie anschließend alle Eingaben aus:
//                Eingegebener String: BBRZ
//                Eingegebener Integer: 17
//                Eingegebener Double: 11.11111
//                Eingegebener Boolean: true
        System.out.print("Eingegebener String: ");
        String vierterString = scanner.nextLine();

        System.out.print("Eingegebener Integer: ");
        Integer vierterInteger = Integer.parseInt( scanner.nextLine() );

        System.out.print("Eingegebener Double: ");
        Double ersterDouble = Double.parseDouble( scanner.nextLine() );

        System.out.print("Eingegebener Boolean: ");
        Boolean ersterBoolean = Boolean.parseBoolean( scanner.nextLine() );

        System.out.println("Ausgabe: " + vierterString + " " + vierterInteger + " " + ersterDouble + " " + ersterBoolean );

//        4. - Name abfragen
//        Fragen Sie den Benutzer in der Konsole nach seinem Vornamen und Nachnamen (zwei Eingaben).
//        Der eingegebene String soll anschließend folgendermaßen ausgegeben werden:
//                Hallo Max Mustermann! Wenn der Benutzer mehrere Vornamen hat, werden diese alle in der Eingabe Vorname gespeichert.
        System.out.print("Vorname: ");
        String vorname = scanner.nextLine();

        System.out.print("Nachname: ");
        String nachname = scanner.nextLine();

        System.out.println("Hallo " + vorname + " " + nachname + "! Wenn der Benutzer mehrere Vornamen hat, werden diese alle in der Eingabe Vorname gespeichert.");

//        5. - Taschenrechner mit Eingaben
//        Fragen Sie den Benutzer nach zwei Integer-Zahlen a und b.
//        Ausführen folgender Operationen und Ausgabe auf die Konsole (a, b, c durch Werte ersetzen)
//                a + b = c
//                a - b = c
//                a / b = c (double)
//                a % b = c
        System.out.println("Taschenrechner:");
        System.out.print("a: ");
        Integer a = Integer.parseInt( scanner.nextLine() );

        System.out.print("b: ");
        Integer b = Integer.parseInt( scanner.nextLine() );

        System.out.println( a + " + " + b + " = " + (a + b) );
        System.out.println( a + " + " + b + " = " + (a - b) );
        System.out.println( a + " + " + b + " = " + (a / ( b + 0.d )) );
        System.out.println( a + " + " + b + " = " + (a % b) );

//        6. - Berechnung des Quadrats einer Zahl:
//        Fordern Sie den Benutzer auf, eine Zahl einzugeben, und geben Sie anschließend das Quadrat dieser Zahl aus.
        System.out.print("Zahl eingeben um Quadrat dieser zu berechnen: ");
        Integer einIntegerWelcherZumQuadratWird = Integer.parseInt( scanner.nextLine() );

        System.out.println("Ergebnis: " + a*a);
        System.out.println("... und noch einmal as gleiche Ergebnis... was anders ist sieht nur der Programmierer :) : " + Math.pow(a, 2) );

//        7. - Berechnung des Durchschnitts:
//        Fordern Sie den Benutzer auf, drei Zahlen einzugeben, und berechnen Sie den Durchschnitt dieser Zahlen.
//        Geben Sie das Ergebnis aus.
        System.out.println("Drei zahlen eingeben und daraus gibts den Durchschnitt:");
        System.out.println("Variante 1 - eine Zahl pro Zeile:");

        System.out.print("Erste Zahl: ");
        Integer fuenfterInteger = Integer.parseInt( scanner.nextLine() );

        System.out.print("Zweite Zahl: ");
        Integer sechsterInteger = Integer.parseInt( scanner.nextLine() );

        System.out.print("Dritte Zahl: ");
        Integer siebterInteger = Integer.parseInt( scanner.nextLine() );

        System.out.println( "Durchschnitt: " + (fuenfterInteger + sechsterInteger + siebterInteger) / 3 );

        System.out.println("Variante 2 - jetzt in einer Zeile alle Zahlen getrennt mit einem Leerzeichen:");
        System.out.print("Alle Zahlen in einer Zeile: ");
        Integer achterInteger = scanner.nextInt();
        Integer neunterInteger = scanner.nextInt();
        Integer zehnterInteger = scanner.nextInt();
        scanner.nextLine(); // damit das \n der Eingabe nicht zukünftige Eingaben beeinflusst! (hier ist danach gleich scanner.close(), aber falls das nicht wäre)

        System.out.println( "Durchschnitt: " + (achterInteger + neunterInteger + zehnterInteger) / 3 );

//
//        8. - Entfernung
//        Die Variablen für einen Ort1, einen Ort2 und die Entfernung als Text deklarieren.
//        Die Werte vom Benutzer einlesen. Nach den Benutzereingaben sollen sie wie im Beispiel verkettet der Variablen Ausgabe
//        zugewiesen und danach in einer Zeile ausgegeben werden.
//                Ort 1: Wien
//                Ort 2: Bratislava
//                Entfernung in km: 55
//                Die Entfernung zw. Wien und Bratislava beträgt 55 km.
        System.out.print("Die erste Stadt: ");
        String ersteStadt = scanner.nextLine();

        System.out.print("Die zweite Stadt: ");
        String zweiteStadt = scanner.nextLine();

        System.out.print("Distanz: ");
        Double distanz = Double.parseDouble( scanner.nextLine() );

        System.out.println("Die Entfernung zw. " + ersteStadt + " und " + zweiteStadt + " beträgt " + distanz + "km.");

//        9. - Jahre bis 100
//        Das Alter des Benutzers einlesen. Die Differenz auf 100 Jahre ermitteln und wie im Beispiel dem Benutzer
//        mitteilen, wie viel Jahre er noch bis 100 hat.
//                Alter: 80
//                Du hast noch 20 Jahre bis 100.
        System.out.print("Alter: ");
        Integer alterInJahren = Integer.parseInt( scanner.nextLine() );
        Integer hundertJahre = 100;

        System.out.println("Du hast noch " + (hundertJahre - alterInJahren) + " Jahre bis " + hundertJahre);

//        10. - Durchschnitt
//        Vom Benutzer 2 Zahlen einlesen und den Variablen zuweisen. Nach der Berechnung des Durchschnitts soll
//        dieser, wie im Beispiel, ausgegeben werden. (Datentyp für Ergebnis beachten)
//                Zahl 1: 4
//                Zahl 2: 2
//                Der Durchschnitt beträgt 3.
        System.out.print("Erste Zahl: ");
        Double zweiterDouble = Double.parseDouble( scanner.nextLine() );

        System.out.print("Zweite Zahl: ");
        Double dritterDouble = Double.parseDouble( scanner.nextLine() );

        System.out.println("Der Durchschnitt beträgt " + (zweiterDouble+dritterDouble)/3 + ".");

//        11. - Mehrwertsteuerrechner
//        Fragen Sie den Benutzer um einen Produktnamen und einen Nettobetrag ab. Errechnen Sie die Mehrwertsteuer (20%)
//        Geben Sie folgendes auf die Konsole aus:
//              Das Produkt XXXXX kostet XXXXX € netto und XXXXX€ brutto
//        Formatieren Sie die Beträge mit folgendem Befehl: String.format( "%.2f", value ); ODER String.format( "%,2f", value );
//              - Hierfür ersetzen Sie value mit dem entsprechenden Variable
//              - "%.2f" bedeutet 2 Nachkommastellen
        System.out.print("Produktname: ");
        String produktname = scanner.nextLine();

        System.out.print("Nettobetrag: ");
        Double nettoBetrag = Double.parseDouble( scanner.nextLine() );

        Double bruttoBetrag = nettoBetrag * 1.2;
        String bruttoBetragTrimmed = String.format("%.2f", bruttoBetrag);

        System.out.println("Das Produkt " + produktname + " kostet " + nettoBetrag + "€ und " + bruttoBetragTrimmed + "€ brutto.");

        scanner.close();
    }
}
