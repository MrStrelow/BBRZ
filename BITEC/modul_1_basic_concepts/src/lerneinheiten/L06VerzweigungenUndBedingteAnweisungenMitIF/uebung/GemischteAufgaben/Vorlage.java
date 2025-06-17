package lerneinheiten.L06VerzweigungenUndBedingteAnweisungenMitIF.uebung.GemischteAufgaben;

public class Vorlage {
    public static void main(String[] args) {
//        1. - Wahl des Getränks:
//        Bitten Sie den Benutzer, eine Zahl von 1 bis 3 einzugeben, um ein Getränk auszuwählen
//                (1 = Kaffee, 2 = Tee, 3 = Limonade). Verwenden Sie if-Anweisungen, um das ausgewählte Getränk anzuzeigen.

//        2. - Schulnoten:
//        Fordern Sie den Benutzer auf, eine Schulnote zwischen 1 und 5 einzugeben. Verwenden Sie ifAnweisungen, um eine Nachricht anzuzeigen,
//        die angibt, ob die Note "Sehr gut", "Gut", "Befriedigend", "Genügend", oder "Nicht genügend" ist.

//        3. - Jahreszeiten:
//        Fordern Sie den Benutzer auf, den aktuellen Monat (als Zahl von 1 bis 12) einzugeben, und verwenden Sie
//        if-Anweisungen, um die zugehörige Jahreszeit (Frühling, Sommer, Herbst, Winter) anzuzeigen.

//        4. - Rabattberechnung:
//        Fordern Sie den Benutzer auf, den Gesamtbetrag eines Einkaufs und einen Rabatt (in %) einzugeben.
//        Verwenden Sie if-Anweisungen, um zu überprüfen, ob der Rabatt positiv ist. Berechnen Sie den endgültigen
//        Betrag nach Anwendung des Rabatts, sofern der Rabatt positiv ist. Ist der Rabatt negativ, soll eine
//        Fehlermeldung ausgegeben werden.

//        5. - Klassifizierung Programmiersprache:
//        Abfrage von Programmiersprache in der Konsole (Java/Javascript)
//        Wenn die Eingabe Java ist, soll Kompilierte Sprache
//        Wenn die Eingabe Javascript ist, soll Interpretierte Sprache
//        Andernfalls soll Nicht bekannt ausgegeben werden

//        6. - Teilbar
//        Der Benutzer gibt eine ganze Zahl ein, welche in einer Variable gespeichert wird. (siehe Beispiel)
//        Wenn die Zahl durch 2 Teilbar ist, dann soll Zahl X durch 2 teilbar , andernfalls soll Zahl X nicht
//        durch 2 teilbar ausgegeben werden.
//        Erweiterung, sodass der Teiler ebenso abgefragt wird.
//                Teiler eingeben: 3
//                Zahl eingeben: 7
//                Zahl 7 ist nicht durch 3 teilbar

//        7. - Aktuelle Version von Betriebssystem (if, else if, else)
//        Abfrage von Betriebssystem (iPhone, Android, Windows, MacOS)
//        Ausgabe des Betriebsystems aufgrund vom Betriebssytem-String
//        iPhone: iOS 16
//        Android: Android 13
//        Windows: Windows 11
//        MacOS: macOS Venttura

//        8. - Uhrzeit
//        Abfrage von Uhrzeit Stunden und Minuten in der Konsole
//        Wenn Uhrzweit zwischen 11:30 und 12:30 ist, dann soll Mittagspause auf die Konsole ausgegeben
//        werden. Andernfalls soll Arbeitszeit ausgegeben werden.

//        9. - Vokal?
//        Schreiben Sie ein Java-Programm, das den Benutzer nach einem Buchstaben fragt und überprüft, ob es
//        sich um einen Vokal oder einen Konsonanten handelt. Wenn es ein Vokal ist, gibt das Programm "Das ist ein
//        Vokal" aus, ansonsten "Das ist ein Konsonant".

//        10. - Vergleichen von Strings
//        Speichern Sie die zwei String "abc" und "Hallo" in zwei Variablen str1 und str2
//        Mit str1.length() bzw str2.length() bekommt man die Anzahl der Zeichen
//        Erstellen Sie eine Ausgabe abhängig von den Längen der Variablen:
//        Wenn str1 länger als str2 ist: "str1 ist Länger mit dem Wert ..."
//        Wenn str2 länger als str1 ist: "str2 ist Länger mit dem Wert ..."
//        Sonst sind beide Variablen gleich str1 und str2 sind gleich lang

//        11. - Einlesen
//        Schreiben Sie ein Programm, bei welchem Sie zwei Zahlen einlesen können. Ihr Programm soll anschließend
//        ausgeben, welche der beiden Zahlen die größte und welche die kleinste Zahl ist. Falls gleiche Zahlen
//        eingegeben worden sind, so soll diese Zahl ebenfalls ausgegeben werden.

//        12. - Taschenrechner
//        Das Programm soll zwei Zahlen und einen Operator (+,-,/,*) einlesen und abhängig vom gewählten Operator
//        die gewünschte Rechenoperation ausführen.
//        Beispiel:
//        Geben Sie die erste Zahl ein: 10
//        Geben Sie die zweite Zahl ein: 3
//        Geben Sie die die Rechenoperation ein: -
//        Das Ergebnis von 10 - 3 ergibt 7

//        13. - BMI
//        Für die Berechnung des Body-Mass-Index (BMI) sollen Sie ein Programm schreiben. Der Body-Mass- Index
//        dient als Maß zur generellen Beurteilung des Körpergewichts. Der Index gibt das Verhältnis des
//        Körpergewichts G (kg) zu der Größe h (m) an. Er kann mit der folgenden Formel berechnet werden:
//        BMI = G / h^2
//        Beurteilung:
//        < 20 Untergewicht
//        20 <= BMI < 25 Normalgewicht
//        25 <= BMI < 30 Übergewicht
//        30 <= BMI < 40 starkes Übergewicht
//        BMI >= 40 extremes Übergewicht
//
//        Mögliche Programmausgabe:
//        Weight (kg): 55
//        Height (m): 1.6
//        BMI = 21.48437499999 > Du hast Normalgewicht

//        14. - Rabattberechnung
//        Eine Firma die Tiernahrung verkauft hat Sie gebeten eine Software zu schreiben, welche den passenden
//        Mengenrabatt bei einer Bestellung berechnet. Ab 10kg soll es einen Rabatt von 10% geben und ab 50kg
//        von 20%. Schreiben Sie ein Programm, welches zunächst den Preis pro Kilogramm und danach die
//        Bestellmenge einließt. Danach soll das Programm den Preis ohne Rabatt, mit Rabatt und die Differenz
//        ausgeben.

//        15. - Schaltjahrberechnung
//        Berechnen Sie, ob das eingegebene Jahr ein Schaltjahr ist. Ein Schaltjahr erfüllt folgende Bedingungen
//        Es ist ein Schaltjahr, wenn die Jahreszahl durch 4 teilbar ist
//        Ist es auch ganzzahlig durch 100 teilbar, so ist es kein Schaltjahr, außer ...
//          - ... das Jahr ist ebenfalls ganzzahlig durch 400 teilbar
//        Beispiel für Schaltjahre: 1808, 1904, 2000, 2112, 2244, 2332, 2380, 2400
//          Kein Schaltjahr: 2100 (durch 4 teilbar, durch 100, und nicht durch 400)

//        16. - Altersüberprüfung
//        Schreiben Sie ein Java-Programm, das den Benutzer nach seinem Alter fragt. Wenn das Alter des Benutzers zwischen 18 und 65 Jahren liegt, geben Sie folgende Meldung aus:

//        17. - Zahlenvergleich
//        Bitten Sie den Benutzer um zwei Zahlen. Überprüfen Sie, ob mindestens eine der beiden Zahlen größer als 10 ist. Wenn ja, geben Sie folgende Meldung aus:

//        18. - Gerade oder ungerade Zahlen
//        Lassen Sie den Benutzer zwei Zahlen eingeben. Überprüfen Sie:
//        - ob mindestens eine der Zahlen gerade ist (also durch 2 teilbar) oder
//                - ob beide Zahlen ungerade sind.
//
//        Falls eine der Bedingungen zutrifft, soll die Ausgabe lauten:

//        19. - Zeichenklassifizierung
//        Schreiben Sie ein Programm, welches den Benutzer zur Eingabe eines Zeichens auffordert. Das Programm soll dann ausgeben, ob es sich um einen Vokal (a, e, i, o, u), einen Konsonanten, eine Zahl oder ein unbekanntes Zeichen handelt.
    }
}
