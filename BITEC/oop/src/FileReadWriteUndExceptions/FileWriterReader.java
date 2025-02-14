package FileReadWriteUndExceptions;

import java.io.*;
import java.sql.SQLException;
import java.util.Arrays;
import java.util.Scanner;

public class FileWriterReader {
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
            BufferedWriter fileWriter = new BufferedWriter(new FileWriter(filePath, true));
//            BufferedWriter fileWriter = new BufferedWriter(new FileWriter(filePath, false));

            fileWriter.write(content);
            fileWriter.flush();


            BufferedReader fileReader = new BufferedReader(new FileReader(filePath));

//            while(true) {
//                String line = fileReader.readLine();
//                System.out.println(line);
//
//                if(line == null) {
//                   break;
//                }
//            }

            String line;
            while( (line = fileReader.readLine()) != null ) {
                System.out.println(line);
            }

            System.out.println("####################################");
            Scanner scanner = new Scanner(new File(filePath));

            while(scanner.hasNextLine()) {
                line = scanner.nextLine();
                System.out.println(line);
            }

            scanner.close();
            fileWriter.close();
            fileReader.close();

        } catch (IOException e) {
            e.printStackTrace();
        }


        // Denken wir an ein Excel welches ein File in der Cloud speichern will. Falls wir keine Internetverbindung haben,
        // wird eine Exception "geworfen" und wir können zumindest die Daten des Users lokal zwischen speichern.
        // Wenn wir wollen, können wir versuchen danach alle 10 Sekunden für maximal 5 Minuten das file wieder zu speichern.
        // Das passiert in einem Thread damit nicht das gesamte Programm hängt während wir warten.
        // Wir starten quasi ein kleines Programm was "neben" dem aktuellen Programm läuft und versucht unser File zu speichern.


    }


    //        meineMethode();

//        try {
//            meineMethode();
//
//        } catch (SQLException sqle) { // müssen wir fangen, es steht in der Methodensignatur von meineMethode()
//            System.err.println(sqle.getSQLState());
//
//        } catch (IOException ioe) { // müssen wir fangen, es steht in der Methodensignatur von meineMethode()
//            ioe.printStackTrace();
//
//        }
//        catch (NullPointerException ne) { //können wir fangen, es steht nicht in der Methodensignatur von meineMethode()
//            // Achtung! auch wenn es dort stehne würde, müssten wir es nicht fangen, da es eine Runtime exception ist.
//            System.out.println("wir geben hier den fehler aus");
//            ne.printStackTrace();
//
//        }
//        catch (Exception e) {
//            System.err.println(e.getMessage());
//            e.getStackTrace();
//        }

//        meineMethode();


//    public static void meineMethode() throws IOException {
//
//    }
//     if (filePath.equals("hallo")) {
//        throw new MeineException();
//    }

}
