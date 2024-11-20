package lerneinheiten.L03FilesUndExceptions;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.nio.ByteBuffer;
import java.nio.channels.*;
import java.nio.file.*;
import java.util.List;

public class ModernNIOPackageForFileWriterReader {

    // Wir schauen uns das nicht an! Falls wer schon das io. Packet kennt, hier einfach reinschauen um
    // non-blocking I/O Operations (asynchronous - gu   t für threads) zu sehen.

    // TODO: das erklären :') noch nicht gemacht.
    public static void main(String[] args) {
        String filePath = "lerneinheiten/L03FilesUndExceptions/example_nio.txt";
        String content = "yes. no. maybe. I don't know.";

//        Conciseness: Writing and reading are reduced to single method calls.
//        Ease of Use: No need to manage streams or buffers explicitly.
//        Auto Resource Management: NIO methods internally handle resource management (e.g., closing file handles).

        try {
            Path path = Path.of(filePath);
            // Write content to the file
            Files.write(path, content.getBytes());
            System.out.println("File written successfully.");

            // Read all lines from the file
            List<String> lines = Files.readAllLines(path);
            System.out.println("File content:");
            lines.forEach(System.out::println);

        } catch (IOException e) {
            // Handle exceptions
            System.err.println("An error occurred while writing/reading the file:");
            e.printStackTrace();
        }

        // Schreiben von Daten in eine Datei mit NIO
        try {
            Path path = Paths.get(filePath);
            ByteBuffer buffer = ByteBuffer.wrap(content.getBytes());

            // Datei öffnen oder erstellen und in sie schreiben
            try (FileChannel fileChannel = FileChannel.open(path, StandardOpenOption.CREATE, StandardOpenOption.WRITE, StandardOpenOption.TRUNCATE_EXISTING)) {
                fileChannel.write(buffer);
            }
        } catch (IOException e) {
            System.err.println("Fehler beim Schreiben der Datei: " + e.getMessage());
        }

        // Lesen von Daten aus einer Datei mit NIO
        try {
            Path path = Paths.get(filePath);

            try (FileChannel fileChannel = FileChannel.open(path, StandardOpenOption.READ)) {
                ByteBuffer buffer = ByteBuffer.allocate(1024); // Puffergröße
                int bytesRead;
                while ((bytesRead = fileChannel.read(buffer)) > 0) {
                    buffer.flip(); // Umschalten in den Lese-Modus
                    while (buffer.hasRemaining()) {
                        System.out.print((char) buffer.get());
                    }
                    buffer.clear(); // Zurücksetzen für den nächsten Lesedurchlauf
                }
            }
        } catch (IOException e) {
            System.err.println("Fehler beim Lesen der Datei: " + e.getMessage());
        }

        // Beispiel für das Arbeiten mit einem Netzwerkkanal (SocketChannel)
        try (SocketChannel socketChannel = SocketChannel.open(new InetSocketAddress("www.google.com", 80))) {
            // HTTP-Anfrage senden
            String request = "GET / HTTP/1.1\r\nHost: www.google.com\r\n\r\n";
            ByteBuffer buffer = ByteBuffer.wrap(request.getBytes());
            socketChannel.write(buffer);

            // Antwort empfangen
            buffer.clear();
            while (socketChannel.read(buffer) > 0) {
                buffer.flip();
                while (buffer.hasRemaining()) {
                    System.out.print((char) buffer.get());
                }
                buffer.clear();
            }
        } catch (IOException e) {
            System.err.println("Fehler beim Arbeiten mit dem Netzwerkkanal: " + e.getMessage());
        }

        // Verwendung eines WatchService für Dateisystemänderungen (zusätzliche NIO-Funktionalität)
        try (WatchService watchService = FileSystems.getDefault().newWatchService()) {
            Path path = Paths.get(".");
            path.register(watchService, StandardWatchEventKinds.ENTRY_CREATE, StandardWatchEventKinds.ENTRY_DELETE, StandardWatchEventKinds.ENTRY_MODIFY);

            System.out.println("Überwache Änderungen im aktuellen Verzeichnis...");
            WatchKey key;
            while ((key = watchService.take()) != null) {
                for (WatchEvent<?> event : key.pollEvents()) {
                    System.out.println("Ereignis: " + event.kind() + ", Datei: " + event.context());
                }
                key.reset();
            }
        } catch (IOException | InterruptedException e) {
            System.err.println("Fehler beim Überwachen des Dateisystems: " + e.getMessage());
        }
    }
}


