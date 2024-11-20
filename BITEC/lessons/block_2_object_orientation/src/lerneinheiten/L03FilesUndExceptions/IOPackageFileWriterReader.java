package lerneinheiten.L03FilesUndExceptions;

import java.io.*;
import java.net.Socket;
import java.util.Scanner;

public class IOPackageFileWriterReader {
    public static void main(String[] args) {
        // Wir versuchen hier einen Text in eine Datei z.B. am Betriebssystem zu schreiben und danach diese wieder auszulesen.
        String filePath = "example.txt";
        String content = "yes. no. maybe. I don't know.";
        // Davor schauen wir uns aber Exceptions an, welche wir nun zwingend behandeln müssen.
        // Bis jetzt waren Exceptions wie "NullPointer" und "ArrayOutOfBounds" Exceptions nicht zwingen abzufangen,
        // wenn diese möglicherweise auftreten. Ansonsten müssten wir bei jedem erstellen bzw. manipulieren eines
        // Arrays oder Objektes diese Fehlerbehandlung durchführen. Das ist nicht zielführend.
        // Diese Exceptions werden RuntimeExceptions (unchecked) genannt.
        // Wir werden uns aber hier mit den CompiletimeExceptions (checked) beschäftigen, welche zwingend abgefragt werden.

        // Wir verwenden Exceptions um Ausnahmezustände ("Fehler") abzufangen, damit unser Programm im schlimmsten Fall
        // nicht abstürzt und im besten Fall der Fehler behoben werden kann.
        // Um Exception verwenden zu können, brauchen wir einen Punkt an dem Sie Auftreten. Dieser ist eine Methode.
        // Wir benötigen nun 4 Konzepte:
        // - (throw) erzeuge eine Exception innerhalb einer Methode, falls ein Fehler entstehen soll.
        // - (throws) delegiere eine Exception weiter, ich als Aufrufer einer Methode die Fehlerbehandlung nicht durchführen will.
        // - (catch) Behandle einen Fehler, welcher durch ein Aufrufen einer Methode (try) und auftritt.

        // Ein Beispiel für den ersten Fall ist folgender Code unter Verwendung der FileWriter und FileReader.
        // Wir erinnern uns, dass ein Konstruktor eine Methode ist. Es kann deshalb bei dem Erzeugen einer Methode,
        // bereits das Behandeln einer Exception vorkommen.

        // Aus Sicht eines Aufrufers einer Methode (hier Erzeugung eines Objektes, also Konstruktor) ist der 1. Schritt
        // die Verwendung des Keywords "try". Dieses signalisiert nur, dass innerhalb dieses Blockes "{...}" Exceptions im
        // darauffolgenden "catch" behandelt werden. Beide Blöcke werden meist try/catch Block genannt.
        // Achtung! Es sind aber immer noch getrennte Blocke! Bedeutet Variablen welche im "try" block
        // definiert/deklariert werden, können nicht im "catch" block verwendet werden.
        // Hier legen z.B. einen FileWriter an.

        try {

            // #################################### Schreiben ####################################
            // Anzumerken ist, dass beim Filewriter ein Argument dem Konstruktor übergeben wird, welche das Verhalten
            // steuert, beim Öffnen des Files. Wenn "append" auf "true" gesetzt, wird ein File gelesen und der Text
            // immer wieder am Ende angehängt, falls eine "write" operation mit diesem Objekt fileWriter durchgeführt wird.
            // Ansonsten, wird beim ersten Aufruf eines "write"-Befehls der Inhalt der angegebenen Datei verworfen!
            BufferedWriter fileWriter = new BufferedWriter(new FileWriter(filePath, false));
            // TODO: wechsle hier zwischen dem FileWriter und dem BufferedFileWriter
//            FileWriter fileWriter = new FileWriter(filePath, false);

            // Wir sehen hier, dass der FileWriter in den Konstruktor der Klasse BufferedWriter übergeben wird.
            // BufferedWriter fügt dem FileWriter eine zusätzliche Pufferungsschicht hinzu (von uns manipulierbar),
            // die größere Blöcke von Daten auf einmal schreibt. Das reduziert möglicherweise die Anzahl der Interaktionen mit dem
            // Betriebssystem und verbessert somit die Effizienz.
            // Der FileWriter verwendet die Puffer welche vom Betriebsystem zur Verfügung gestellt werden.

            // Ein BufferedWriter oder BufferedReader kommuniziert nur mit dem Betriebssystem, wenn genügend Daten im Puffer gesammelt wurden.
            // Beim Schreiben landen die Daten zuerst im Puffer (standardmäßig z.B. 8 kB groß) und werden erst in die Datei geschrieben, wenn der Puffer voll ist.
            // Beim Lesen werden direkt größere Blöcke (z.B. 8 kB) geladen, aus denen dann gelesen wird, bis neue Daten benötigt werden.
            // Der Vorteil liegt darin, dass "teure" Interaktionen mit dem Betriebssystem so gebündelt werden, wie wir es für richtig halten.

            // Wir folgern daraus:
            /*
                +----------------------------+-------------------------------+------------------------------------------+
                | Merkmal                   | FileReader/FileWriter         | BufferedReader/BufferedWriter           |
                +----------------------------+-------------------------------+------------------------------------------+
                | **Pufferung**             | Nutzt Betriebssystempuffer.   | Fügt eigenen benutzerdefinierten Puffer |
                |                            |                               | hinzu (z.B. 8 kB).                      |
                +----------------------------+-------------------------------+------------------------------------------+
                | **Leistung**              | Weniger effizient bei         | Effizienter durch gebündelte            |
                |                            | vielen kleinen I/O-Operationen. | Lese-/Schreiboperationen.               |
                +----------------------------+-------------------------------+------------------------------------------+
                | **Anwendungsfall**        | Für kleine oder seltene       | Für große oder häufige                  |
                |                            | Lese-/Schreiboperationen.     | Lese-/Schreiboperationen.               |
                +----------------------------+-------------------------------+------------------------------------------+
                | **Flush-Verhalten**       | Flushed OS-Puffer (falls      | Flushed benutzerdefinierten Puffer      |
                |                            | vorhanden).                  | und OS-Puffer.                          |
                +----------------------------+-------------------------------+------------------------------------------+
                | **Anpassbarkeit**         | Keine Anpassung der Puffergröße.| Benutzerdefinierte Puffergröße möglich |
                |                            |                               | (Standard: 8 kB).                       |
                +----------------------------+-------------------------------+------------------------------------------+
            */

            // Wir können mit dem Befehl write Daten in eine Datei schreiben. Wenn wir das Schreiben explizit erzwingen wollen, rufen wir die Methode "flush" auf.
            // Diese Methode leert den Puffer des BufferedWriter und sorgt dafür, dass alle Daten sofort in die Datei geschrieben werden.
            // Auch FileWriter hat eine flush-Methode. Sie interagiert mit dem OS-Puffer und stellt sicher, dass alle gepufferten Daten direkt in die Datei geschrieben werden.

            fileWriter.write(content);
            fileWriter.flush();

            // Es gibt eine spezielle "append" Methode, welche die Flag "append" im Konstruktor ignoriert und immer "append" macht.
            // Das Verhalten der "write" Methode bezieht sich auf den Zustand der Flag.
            fileWriter.append(content);
            fileWriter.flush();

            // Eine allgemeine Anmerkung zum BufferedReader:
            // Der Buffered Reader ist ein Wrapper (wie z.B. Integer für int) für verschiedenste "Datenströme"
            // Das wären alle Objekte, welche von der Reader Klasse abgeleitet sind - als Supertype hat.
            // Diese können beispielsweise:
            // - InputStreams aus dem Web sein.
            Socket socket = new Socket("www.google.com", 80);
            // brauchen internet. Wenn keine Internetverbindung vorhanden ist, verwende
//            Socket socket = new Socket("localhost", 8080);

            BufferedReader reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));

            //- PipedReader/Writer für die Kommunikation zwischen Threads.
            BufferedWriter writer = new BufferedWriter(new PipedWriter());


            // #################################### Lesen ####################################
            // Das Erstellen des BufferedReaders oder FileReaders ist gleich dem eines Writers.
            FileReader fileReader = new FileReader(filePath);

            // Wir verwenden nun die "read" Methode. Diese gibt "characterweise" den Text als Ergebnis zurück.
            // Jedoch lesen wir den Text nicht vollständig ein.
            // TODO: versuche herauszufinden warum.
            while ( fileReader.read() != -1 ) {
                char output = (char) fileReader.read();
                System.out.print(output);
            }

            // Wir verwenden nun den BufferedReader welcher eine "readLine" Methode zur Verfügung stellt.
            // Diese gibt bereits einen String als Rückgabe zurück.
            BufferedReader bufferedFileReader = new BufferedReader(new FileReader(filePath));

            // Wir verwenden nun die "readLine" Methode. Jedoch lesen wir wieder den Text nicht vollständig ein.
            // TODO: versuche herauszufinden warum.
            while( bufferedFileReader.readLine() != null ) {
                System.out.println(bufferedFileReader.readLine());
            }

            // Lösung für beide Probleme:
            // Wir sehen, dass das Ergebnis der Methode "readLine" für 2 Zwecke verwendet werden soll.
            // Einmal um abzufragen, ob es noch neuen Text gibt und einmal um diesen weiter zu verarbeiten (Ausgabe).
            while(true) {
                String line = bufferedFileReader.readLine();
                System.out.println(line);

                if(line == null) {
                   break;
                }
            }

            // bzw. für den FileReader
            while(true) {
                int line = fileReader.read();
                System.out.println(line);

                if(line == -1) {
                    break;
                }
            }

            // Da die bereits verwendete Syntax umständlich ist, gibt es hier eine neue um Folgendes ausdrücken zu können.
            // Wir rufen die Methode auf, verwenden das Ergebnis als Bedingung in der IF-Bedingung,
            // schreiben jedoch zusätzlich das Ergebnis in die Variable "line".
            // Achtung! die Variable "line" muss jedoch zuerst deklariert/definiert sein.
            String line;
            while( (line = bufferedFileReader.readLine()) != null ) {
                System.out.println(line);
            }

            // bzw. für den FileReader
            int charLine;
            while( (charLine = fileReader.read()) != -1 ) {
                System.out.print((char) charLine);
            }

            System.out.println("####################################");

            // Zusätzlich gibt es die Möglichkeit den bereits bekannten Scanner zu verwenden.
            // Wir ersetzen dadurch die zu lesende Quelle vom Terminal (System.IN) zu einem File.
            Scanner scanner = new Scanner(new File(filePath));

            // Wir kommen hier ohne die neue Syntax aus, da hier 2 getrennte Methoden für
            // "gibt es noch Symbole zum Lesen" und "ich lese das Symbol" gibt.
            // Bei dem BufferedReader bzw. FileReader ist beides in einer Methode encoded.
            while(scanner.hasNextLine()) {
                line = scanner.nextLine();
                System.out.println(line);
            }

            // Wir müssen zudem meistens, wenn wir mit Systemen außerhalb von "JAVA" kommunizieren,
            // diese Verbindung wieder schließen. Das kennen wir bereits von der Verwendung Scanner.
            // Alles was den Supertyp "Closable" hat, muss eine Methode "close" zur Verfügung stellen.
            // Jedoch ist die Frage wo? Wenn wir es hier tun, werden diese Verbindungen nur geschlossen,
            // wenn wir einen Erfolgreichen Try Block ausführen.
//            scanner.close();
//            fileWriter.close();
//            bufferedFileReader.close();
//            socket.close();

        } catch (IOException e) {
            e.printStackTrace();
            // Hier würde close nur ausgeführt werden, wenn eine Exception geworfen wird, ansonsten nicht.
//            scanner.close();
//            fileWriter.close();
//            bufferedFileReader.close();
//            socket.close();
        }
        // Direkt danach sollte gehen! Denn wir wissen, wenn wir an eine IF-Verzweigung denken, egal ob if oder else,
        // nach diesen Blöcken geht es mit dem Code immer weiter.
//            scanner.close();
//            fileWriter.close();
//            bufferedFileReader.close();
//            socket.close();

        // Leider vergessen wir hier auf etwas. Exceptions beschäftigen sich mit Ausnahmesituationen,
        // welche auch "early exits - System.exit(0)" und "angefangene Exceptions" beinhalten.
        // In diesen Fällen zerstören wir zwar unser Programm, jedoch kann nicht klar sein, was mit den verwendeten
        // Ressourcen (z.B. Verbindung zu einem File mit dem FileReader) passiert.
        // Schließt das Betriebssystem es? Ist es eine Sicherheitslücke? Was, wenn das Programm abstürzt
        // noch etwas als "letzte Nachricht" in ein Logfile schreiben will?

        // Es gibt dazu einen Ort, welcher egal ob Try oder Catch ausgeführt wird (inklusive der oben genannten Probleme),
        // ausgeführt wird. Dieser ist der finally Block.
        // Wir verwenden diesen Block für spezielle aufräumarbeiten verwenden.
        // Beispiele dafür sind log file writes, aufheben von "locks", etc.
        // Jedoch, müssen dazu alle Ressourcen außerhalb des try-catch Blocks definiert werden, da wir keinen Zugriff zwischen den Blöcken haben.
        finally {
//            scanner.close();
//            fileWriter.close();
//            bufferedFileReader.close();
//            socket.close();
            System.out.println("es");
        }

        // Eine neue Art dies zu tun ist folgende.
        // Wenn wir im try Block bereits eine Ressource speziell festlegen, welche "Closable" als Supertype hat
        // (genau genommen AutoClosable, jedoch Closable erweitert AutoClosable. Das klingt vom Namen jedoch irreführend,
        // denn Closable klingt genereller als AutoClosable, ist es aber nicht.)
        try (Reader autoClosedReader = new FileReader(filePath)) {
            System.out.println(autoClosedReader.ready());

        } catch(Exception e) {
            e.printStackTrace();
        }

        // Mehrere Ressourcen können so definiert werden.
        // TODO: passe den Code in unserem "großen" try-catch so an, dass die Ressourcen immer geschlossen werden!
        try (
                FileReader autoClosedReader = new FileReader(filePath);
                FileWriter autoClosedWriter = new FileWriter(filePath)
        ) {
            System.out.println(autoClosedReader.ready());
            System.out.println(autoClosedWriter.getEncoding());

        } catch(Exception e) {
            e.printStackTrace();
        }

        // Achtung! Die Ressource kann nicht zuerst deklariert werden und dann in der neuen Syntax verwendet werden.
        // Falls wir außerhalb des try-catch Blockes die ressource verwenden wollen, mit einer Methode welche keine Exception auslöst,
        // ist das nicht möglich. Diese wird ja nach dem Try-catch geschlossen und kann somit nicht mehr verwendet werden!
//        Reader fehlerAutoClosedReader;
//        try (fehlerAutoClosedReader = new FileReader(filePath)) {
//            System.out.println(fehlerAutoClosedReader.ready());
//
//        } catch(Exception e) {
//            e.printStackTrace();
//        }

//        fehlerAutoClosedReader.dasWäreImmerEinFehler();
    }
}
