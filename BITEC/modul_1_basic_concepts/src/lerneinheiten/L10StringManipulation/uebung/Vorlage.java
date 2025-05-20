public class Vorlage {

    public static void main(String[] args) {
        // Erstellen Sie einen Java-Code, der einen String einliest und dann die Anzahl der Zeichen in diesem String ausgibt.
        // (Verwenden Sie für die Ausgabe, sofern möglich String.format(...))


        // Schreiben Sie ein Programm, das einen Namen als Eingabe erhält und ihn in Großbuchstaben formatiert ausgibt.
        // (Verwenden Sie für die Ausgabe, sofern möglich String.format(...))


        // Entwickeln Sie eine Anwendung, die einen Preis als `double` einliest, formatiert und mit 2 Dezimalstellen ausgibt.
        // (Verwenden Sie für die Ausgabe, sofern möglich String.format(...))


        // Erstellen Sie eine Methode, die eine Telefonnummer im Format "1234567890" in das Format "(123) 456-7890" umwandelt.
       


        // Schreiben Sie ein Programm, das einen Text in umgekehrter Reihenfolge ausgibt (z.B. "Hallo" wird zu "ollaH").


        // Erstellen Sie ein Programm, das eine Zeichenkette entgegennimmt und alle Leerzeichen am Anfang und Ende entfernt.


        // Schreiben Sie eine Methode, die einen Text in Worte zerlegt und die Anzahl der Worte zählt.


        // Entwickeln Sie eine Anwendung, die eine URL (z.B. "www.bbrz.at") in einen klickbaren HTML-Link umwandelt
        // (z.B. "<a href='http://www.bbrz.at'>www.bbrz.at</a>").
        // Überprüfen Sie dabei, ob die URL mit "http://" beginnt (fügen Sie es ggf. hinzu)
        // und ob sie mit einer gängigen TLD wie ".at", ".com", oder ".de" endet.


        // Entwickeln Sie eine Anwendung, die eine Temperatur in Grad Celsius in Grad Fahrenheit umrechnet
        // und das Ergebnis im Format $"25^{\circ}C \text{ entspricht } 77^{\circ}F"$ ausgibt.
        // (Umrechnungsformel: Celsius * 1,8 + 32 = Fahrenheit).


        // Schreiben Sie ein Programm, das eine Zeichenkette in ein festgelegtes Längenformat umwandelt,
        // z.B. auf 10 Zeichen auffüllt (mit Leerzeichen am Ende) oder abschneidet.


        // Erstellen Sie ein Programm, das eine Prozentzahl (z.B. den Wert 0.25) im Format "25%" ausgibt,
        // wobei der Wert mit String.format angepasst wird.


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
        //
        // Beispielinteraktion:
        // ```
        // Text eingeben: Hallo Welt!
        // In Großbuchstaben: HALLO WELT!
        // Länge: 11
        // Mit Smiley: Hallo Welt!:-)
        // Erste 5 Zeichen: Hallo
        // Erstes Zeichen: H, Letztes Zeichen: !
        // 3. Zeichen: l
        // Ohne Leerzeichen: HalloWelt!
        // Ersetzt: Hallo Welt#
        // ```


        // ### US Noten
        //
        // * Schreiben Sie ein Programm, welches US-Noten in österreichische Schulnoten übersetzt.
        // * Hierzu wird als erstes die US-Note abgefragt (A, B, C, D, F).
        // * Danach wird abhängig von der Eingabe die österreichische Note ausgegeben.
        // * Noten-Mapping: A: 1, B: 2, C: 3, D: 4, F: 5.
        //
        // Beispiel:
        // ```
        // US-Note eingeben: C
        // Österreichische Note: 3
        // ```


        // ### Zahlen drehen
        //
        // * Schreibe eine Methode, die die Ziffernreihenfolge einer Ganzzahl umdreht.
        //   Z.B: "Du hast die Zahl 153536758 eingegeben! Die umgedrehte Zahl lautet: 857635351".



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


        // ### Uhrzeiten (Optionale Übungen)
        //
        // Lesen Sie sich zuerst in die Formatierung und Verarbeitung von Uhrzeiten in Java ein
        // (z.B. mit `java.time.LocalTime`, `java.time.LocalDate`, `java.time.LocalDateTime`
        // und `java.time.format.DateTimeFormatter`).
        //
        // 1.  Schreiben Sie ein Java-Programm, das die aktuelle Uhrzeit im 24-Stunden-Format (hh:mm:ss) ausgibt.


        // 2.  Schreiben Sie ein Programm, das eine Zeichenkette mit einer Uhrzeit im Format "13:45" einliest
        //     und sie dann im 12-Stunden-Format (z.B. "01:45 PM") formatiert ausgibt.


        // 3.  Erstellen Sie ein Programm, das eine `LocalTime`-Instanz erhält und die verbleibende Zeit bis Mitternacht (00:00:00)
        //     in Stunden, Minuten und Sekunden ausgibt.


        // 4.  Schreiben Sie ein Programm, das die aktuelle Uhrzeit mit Millisekunden formatiert (hh:mm:ss.SSS) und ausgibt.


        // 5.  Erstellen Sie ein Programm, das eine Uhrzeit im 24-Stunden-Format via Programmargumente als Zeichenkette (z.B. "18:30")
        //     akzeptiert und diese in eine `LocalTime`-Instanz konvertiert.


        // 6.  Schreiben Sie ein Java-Programm, das die aktuelle Uhrzeit in einer Zeile und das aktuelle Datum
        //     in einer anderen Zeile ausgibt.


        // 7.  Schreiben Sie ein Programm, das die aktuelle Uhrzeit und das aktuelle Datum in einem benutzerdefinierten Format
        //     (z. B. "Mittwoch, 27. Oktober 2023, 15:30 Uhr") ausgibt.


        // ### String-Grundlagen 기초

        // Schreibe ein Java-Programm, das den Benutzer zur Eingabe eines Text-Strings auffordert. Führe dann die folgenden Operationen durch und zeige die Ergebnisse an:
        
        // * **a) Umwandlung in Großbuchstaben**: Wandle den gesamten eingegebenen String in Großbuchstaben um.
        // * **b) Umdrehen mit StringBuilder**: Drehe den String mithilfe der eingebauten Methode der `StringBuilder`-Klasse um.
        // * **c) Manuelles Umdrehen**: Drehe den String *manuell* mithilfe einer Schleife (z.B. `for` oder `while`) und dem Zugriff auf einzelne Zeichen (`charAt()`) um. Verwende für diesen Teil **nicht** die `StringBuilder.reverse()`-Methode.
        // * **d) Palindrom-Prüfung**:
        //     * Bereinige zuerst den eingegebenen String, indem du alle Leerzeichen entfernst und ihn in Kleinbuchstaben umwandelst.
        //     * Überprüfe dann, ob der bereinigte String ein Palindrom ist (d.h. vorwärts und rückwärts gelesen gleich ist).
        //     * Gib aus, ob die ursprüngliche Eingabe (nach der Bereinigung) ein Palindrom ist oder nicht.
        
        
        // ### Zeichenanalyse 📊
        
        // Schreibe ein Java-Programm, das den Benutzer nach einem String fragt und dann eine Zeichenanalyse durchführt:
        
        // * **a) Zählung eines bestimmten Zeichens**:
        //     * Fordere den Benutzer auf, ein einzelnes Zeichen einzugeben, das gezählt werden soll.
        //     * Fordere den Benutzer auf, einen Text-String einzugeben.
        //     * Zähle und zeige an, wie oft das angegebene Zeichen im Text-String vorkommt.
        // * **b) Häufigkeit aller Zeichen (eindeutig)**:
        //     * Fordere den Benutzer auf, einen Text-String einzugeben.
        //     * Iteriere durch den String und zähle für jedes Zeichen dessen Gesamtvorkommen im String.
        //     * Zeige die Anzahl für jedes Zeichen an, stelle dabei aber sicher, dass du die Häufigkeit für jedes eindeutige Zeichen nur *einmal* ausgibst. Wenn der String beispielsweise "banane" ist, sollte die Ausgabe 'b': 1, 'a': 3, 'n': 2 zeigen und 'a' nicht dreimal auflisten.
        //         * **Hinweis**: Du kannst einen Hilfs-String verwenden, um dir zu merken, für welche Zeichen die Häufigkeit bereits ausgegeben wurde.
        
        // ---
        
        // ### Wortzauberei 🧙‍♂️
        
        // Erstelle ein Java-Programm, das die Anzahl der Wörter in einem gegebenen String zählt. Implementiere eine robuste Benutzerführung für die Eingabe:
        
        // * Fordere den Benutzer so lange zur Eingabe eines Text-Strings auf, bis eine gültige Eingabe erfolgt.
        // * Der eingegebene String darf **nicht** leer sein.
        // * Der eingegebene String **muss** mindestens ein Leerzeichen enthalten (als einfache Methode, um sicherzustellen, dass potenziell mehrere Wörter vorhanden sind).
        // * Sobald eine gültige Eingabe empfangen wurde, teile den String in Wörter auf und zeige die Gesamtzahl der Wörter an.
        //     * **Hinweis**: Die `split()`-Methode der `String`-Klasse wird hier sehr nützlich sein.
        
        // ---
        
        // ### Abwechselnde Groß-/Kleinschreibung 🔄
        
        // Schreibe ein Java-Programm, das die Groß-/Kleinschreibung von Zeichen in einem vom Benutzer bereitgestellten String manipuliert.
        
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
        
        // ---
        
        // ### Grundlegende Datenkompression (Konzeptionell) 🤏
        
        // Bei dieser Übung geht es mehr darum, einen Prozess zu durchdenken. Stelle dir vor, du müsstest eine einfache Form der Datenkompression implementieren, die als Lauflängenkodierung (Run-Length Encoding, RLE) bezeichnet wird.
        
        // **Was ist Lauflängenkodierung (RLE)?**
        // Die Lauflängenkodierung ist eine einfache Form der Datenkompression, bei der Sequenzen von gleichen Datenwerten (sogenannte "Runs" oder "Läufe") als ein einzelner Datenwert und dessen Anzahl gespeichert werden. Sie ist besonders effektiv bei Daten mit vielen Wiederholungen.
        
        // * **Beispiel für Kodierung mit Binärcode (einzelne Bits)**: Ein Binärstring wie `0000011100000000` (16 Bit) besteht aus:
        //     * Fünf `0`en
        //     * Drei `1`en
        //     * Acht `0`en
        //     Die RLE-Version könnte dann als Sequenz von (Anzahl, Wert) Paaren dargestellt werden, z.B. `(5,0)(3,1)(8,0)` oder in einer kompakteren Form wie `503180`.
        
        // * **Beispiel für Dekodierung mit Binärcode (einzelne Bits)**: Aus der RLE-Darstellung `503180` würde man wieder den ursprünglichen Binärstring `0000011100000000` erhalten.
        
        // * **Anwendungsbeispiel: Bilddaten (Pixelwerte)** 🖼️
        //     Stell dir eine Bilddatei vor. Jedes Pixel wird oft durch drei Farbwerte dargestellt: Rot, Grün und Blau (RGB). Jeder dieser Werte kann z.B. 1 Byte (8 Bit) beanspruchen, also insgesamt 3 Bytes pro Pixel. Ein Pixel mit der Farbe Weiß könnte z.B. als (255, 255, 255) gespeichert werden, was binär `11111111 11111111 11111111` (3 Bytes) entspricht.
        //     Wenn nun mehrere aufeinanderfolgende Pixel exakt denselben Farbwert haben (also dieselben 3 Bytes), kann RLE angewendet werden:
        //     * **Originale Pixeldaten (Sequenz von 3-Byte-Farbwerten):**
        //         `Pixel1_RGB_Daten` `Pixel1_RGB_Daten` `Pixel1_RGB_Daten` `Pixel2_RGB_Daten` `Pixel2_RGB_Daten`
        //         (Wobei `Pixel1_RGB_Daten` z.B. die 3 Bytes für Weiß sind, und `Pixel2_RGB_Daten` die 3 Bytes für eine andere Farbe.)
        //     * **RLE-kodiert:** `(3, Pixel1_RGB_Daten) (2, Pixel2_RGB_Daten)`
        //     Dies speichert, dass der 3-Byte-Block `Pixel1_RGB_Daten` dreimal vorkommt, gefolgt von zweimal dem 3-Byte-Block `Pixel2_RGB_Daten`. Dies ist besonders bei großen, einfarbigen Flächen in Bildern effizient.
        
        // **Aufgabe**:
        
        // 1.  Beschreibe in Worten (Pseudocode oder eine schrittweise Beschreibung) die Logik, die du verwenden würdest, um eine Java-Methode `String komprimiere(String eingabe)` zu schreiben, die eine RLE-Kodierung für einen String durchführt, der nur aus den Zeichen '0' und '1' besteht (ähnlich dem ersten Binärcode-Beispiel, das einzelne Bits/Zeichen komprimiert).
        // 2.  Beschreibe in Worten die Logik für eine Methode `String dekomprimiere(String komprimierteEingabe)`, die die entsprechende Dekodierung für den RLE-kodierten '0'/'1'-String durchführt.
        
        // *Du musst für diese Übung nicht den vollständigen Java-Code schreiben, sondern dich auf die algorithmischen Schritte konzentrieren.*
        
        // ---

        // ### Ist es ein Palindrom?
        // Das bedeutet, dass das Wort von vorne und von hinten gelesen den gleichen Text ergibt.
        // Wir müssen also:
        // - (um ganz genau zu sein, alle Leerzeichen entfernen und alles in Kleinbuchstaben umwandeln)
        // - das Wort umdrehen
        // - vergleichen, ob es mit dem nicht umgedrehten übereinstimmt.
        // Wenn ja, dann ist es ein Palindrom, ansonsten nicht.
        
        // ### Anagramm-Ermittler 🕵️‍♀️
        
        // Zwei Strings sind Anagramme, wenn sie dieselben Zeichen in derselben Anzahl enthalten, aber möglicherweise in einer anderen Reihenfolge (z.B. "listen" und "silent", oder "Tom Marvolo Riddle" und "Ich bin Lord Voldemort" nach der Normalisierung).
        
        // Schreibe ein Java-Programm, das:
        
        // 1.  Den Benutzer zur Eingabe von zwei Strings auffordert.
        // 2.  Beide Strings vorverarbeitet:
        //     * Alle Leerzeichen entfernt.
        //     * Alle Zeichen in eine einheitliche Schreibweise umwandelt (z.B. Kleinbuchstaben).
        // 3.  Ermittelt, ob die beiden vorverarbeiteten Strings Anagramme voneinander sind.
        //     * **Hinweis**: Überlege, wie du den Zeicheninhalt zweier Strings unabhängig von ihrer Reihenfolge vergleichen kannst. Das Sortieren der Zeichen jedes Strings könnte ein hilfreicher Ansatz sein.
        // 4.  Ausgibt, ob die beiden ursprünglichen Strings (nach der Normalisierung) Anagramme sind.
        


    }
}