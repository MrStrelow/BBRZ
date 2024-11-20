package lerneinheiten.L03FilesUndExceptions;

import java.io.*;
import java.nio.Buffer;

// adapted from https://stackoverflow.com/questions/3459127/should-i-buffer-the-inputstream-or-the-inputstreamreader
// User: BalusC, answered on Aug 11, 2010 at 14:09
public class BufferedReaderVsFileReader {
    public static void main(String... args) throws Exception {
        // TODO: verändere die Buffer size und schau auf die gemessenen Zeiten.
        //  z.B 1 vs 10 vs 10240
        int bufferSize = 10240; // "10KB" (genauer 10 kibibyte).

        // ~100MB: 1024 = "kilo" (genauer kibi), kilo * kilo = mega, mega * 100 = 100 MB
        // TODO: verändere die fileSize size und schau auf die gemessenen Zeiten.
        //  z.B 100 * 1024 vs 100 * 1024 * 1024;

        // TODO: nicht immer ist der BufferedReader schneller
        //  (aber meistens, wenn der Puffer nicht absichtlich schlecht gestzt wird)!

        int fileSize = 100 * 1024 * 1024;
        File file = new File("temp.txt");

        System.out.print("Creating file .. ");

        // try catch mit automatischen resource closing -> wenn es in den Klammern bei Try steht.
        // wir sparen uns den finally block damit, wo der reader geschlossen wird.
        try (BufferedWriter writer = new BufferedWriter(new FileWriter(file))){

            for (int i = 0; i < fileSize; i++) {
                writer.write("0");
            }

            System.out.printf("finished, file size: %d MB.%n", file.length() / 1024 / 1024);

        }

        System.out.print("Buffered Reader .. ");

        // try catch mit automatischen resource closing -> wenn es in den Klammern bei Try steht.
        // wir sparen uns den finally block damit, wo der reader geschlossen wird.
        try (BufferedReader r1 = new BufferedReader(new FileReader(file), bufferSize)) {

            // Achtung! die Messungen sind nicht immer gleich! Ofter ausprobieren und den Durchschnitt nehmen.
            // Das ist eine einfache Abschätzung. Wir sehen aber, dass die Größen weit genug auseinander sind
            // um eine Aussage treffen zu können.
            long st = System.nanoTime();
            for (int data; (data = r1.read()) > -1; ) {} // geht auch mit ; statt {}

            long et = System.nanoTime();
            // nano: 9 nullen nach dem Komma (10^-9) -> mal mega (10^6), ist milli (10^-3)
            System.out.printf("finished in %d ms.%n", (et - st) / 1000000);
        }

        System.out.print("File Reader .. ");

        try (FileReader r2 = new FileReader(file)) {
            long st = System.nanoTime();
            for (int data; (data = r2.read()) > -1;) {}

            long et = System.nanoTime();
            System.out.printf("finished in %d ms.%n", (et - st) / 1000000);
        }

        // Cleanup: lösche tmp.txt datei.
        // hier nutzen wir Folgendes aus:
        // - file.delete() führt den Löschvorgang durch.
        // - gibt false als Rückgabewert zurück, wenn etwas schiefgeht.
        // - gibt true zurück wenn es passt.

        // Hier wird mit keiner Exception gearbeitet.
        // Es wäre ansonst
//        try {
//            file.delete();
//        } catch (Exception e) {
//            // nur eine Dummy code hier in catch, der die stack-trace ausgibt (wo ist der Fehler aufgetreten)
//            e.printStackTrace();
//        }

        // Warum aber nicht? Es wurde eventuell entschieden aufgrund der Vielzahl von verschiedenen möglichen Fehlermeldungen
        // durch verschiedene Betriebsyssteme, dem Programmierer überlassen wie diese Exceptions gehandelt werden.
        // Warum aber nicht:
//        try {
//            file.delete();
//        } catch (Exception e) {
//            throw new MeineSehrSpezifischeException();
//        }
        // Oft ist es angenehmer und "effizienter" auf eine Erstellung der
        // "Stack-Traces" zu verzichten und einfach true oder false, eine Zahl >0 und -1 zurückzugeben.
        // Die Stack-Trace ist eine Zurückverfolgung des Codes, wo genau dieser fehlgeschlagen ist.
        // Wir sehen dieses Verhalten manchmal, bei Interaktionen mit anderen Systemen, wie z.B. dem Betriebsystem.

        // Nebenbemerkung: In der Webprogrammierung wird of eine eigene "Middleware" eingerichtet welche sich um Exceptions kümmert.
        // Da Exceptions ein außerordentliches Scenario darstellen sollen, und wir mit "Client-side-checking" bereits
        // viele Fehler abfangen können bevor sie zum Server kommen, ist es manchmal nicht notwendig auf "Error Code" umzusteigen.
        // um "throw Exception" zu vermeiden. Falls es jedoch notwendig ist, kann ein "Result pattern" verwendet werden.
        // Dieses ersetzt "throw Exception" mit "return Result.Failure(...)", was quasi für uns ein "Error Code" ist.
        // Siehe auch "sealed Interfaces" in JAVA und die möglichkeit diese in einem switch zu verwenden.
        // Wir werden jedoch nicht auf Alternativen zu Exceptions eingehen.
        // Siehe https://www.youtube.com/watch?v=E3dU9Y1CsnI für eine Diskussion in C#

        if (!file.delete()) {
            System.err.printf("Oops, failed to delete %s. Cleanup yourself.%n", file.getAbsolutePath());
            // ich kann hier immer noch "throw new MeineSehrSpezifischeException();" ausführen.
        }
    }
}
