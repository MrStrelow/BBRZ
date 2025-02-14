package lerneinheiten.L03FilesUndExceptions.kommunikation_mit_files.optional;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.concurrent.TimeUnit;

public class BehebeProblemInCatchSaveInCloud {

    private static final Path LOCAL_BACKUP_PATH = Paths.get("local_backup.txt");
    private static final int RETRY_INTERVAL_SECONDS = 10;
    private static final int MAX_RETRY_DURATION_SECONDS = 300; // 5 Minuten

    // Denken wir an ein Excel welches ein File in der Cloud speichern will. Falls wir keine Internetverbindung haben,
    // wird eine Exception "geworfen" und wir können zumindest die Daten des Users lokal zwischen speichern.
    // Wenn wir wollen, können wir versuchen danach alle 10 Sekunden für maximal 5 Minuten das file wieder zu speichern.
    // Das passiert in einem Thread damit nicht das gesamte Programm hängt während wir warten.
    // Wir starten quasi ein kleines Programm was "neben" dem aktuellen Programm läuft und versucht unser File zu speichern.

    public static void main(String[] args) {
        String fileContent = "Hier sind die Daten aus dem Excel.";

        try {
            saveFileToCloud(fileContent);
            System.out.println("Datei erfolgreich in der Cloud gespeichert.");

        } catch (IOException e) {
            System.out.println("Speichern in der Cloud fehlgeschlagen. Lokale Sicherung wird erstellt.");
            saveFileLocally(fileContent);

            // Starte einen neuen Thread, um das Speichern in der Cloud erneut zu versuchen.
            // Wir erstellen dazu ein neues Objekt der Klasse Thread. Dieses Kann mit einem Objekt, welches von Runnable
            // ableitet (ist Beziehung), bestückt werden. In einem solchen Objekt muss es die Methode run geben.
            // Das schaffen wir mit einem Interface. Das zwingt die abgeleitete Klasse, eine vorgegebene Methode zu implementieren.
            // Mehr dazu aber in einer späteren Einheit. Da wir nicht ein eigenes File machen wollen, mit einer neuen Klasse,
            // welche die Methode run implementiert, können wir dies auch "alles in einem" Schreiben.
            // Wir sagen new Runnable() und implementieren gleich dahinter die methode "run". Ein solches Konstrukt wird eine
            // anonyme Klasse genannt (da sie keine eigene Klasse als Typ hat).
            new Thread(
                new Runnable() {
                    public void run() {
                        retryCloudSave(fileContent);
                    }
                }
            ).start();

            // Da diese Schreibweise aber sehr umständlich ist ("Boilerplate-Code"), gibt es eine kürzere Schreibweise.
            // Das folgende ist ein Lambda ausdruck. Dieser ist eine Kurzform von dem oben geschriebenen.
            // Der Pfeil "->" symbolisiert die methode "run" und die runden Klammern "()" dass diese methode keine Parameter hat.
            // Da wir nur eine Methode haben welche auf das Muster "kein Parameter" zutrifft, müssen wir hier den namen nicht verwenden.
            // Der Compiler weiß damit wir meinen die Methode "run", und in dieser wollen wir den folgenden code
            // "retryCloudSave(fileContent)" ausführen. Danach haben wir ein neues Objekt, welches wir nicht in eine Variable speichern.
            // Dort rufen wir sofort start auf, welches uns quasi ein kleines neues Programm startet und alle
            // x sekunden versucht das Backup in die Cloud zu speichern.
//            new Thread(() -> retryCloudSave(fileContent)).start();
        }
    }

    /**
     * Simuliert das Speichern einer Datei in der Cloud.
     * Es wird eine IOException geworfen, wenn die "Internetverbindung" nicht verfügbar ist.
     */
    private static void saveFileToCloud(String content) throws IOException {
        if (!hasInternetConnection()) {
            throw new IOException("Keine Internetverbindung.");
        }

        // Simuliertes Speichern in der Cloud (hier einfach auf der Konsole ausgeben)
        System.out.println("Speichere Datei in der Cloud: " + content);
    }

    /**
     * Speichert die Datei lokal.
     */
    private static void saveFileLocally(String content) {
        try {
            Files.writeString(LOCAL_BACKUP_PATH, content);
            System.out.println("Datei lokal unter " + LOCAL_BACKUP_PATH + " gespeichert.");
        } catch (IOException e) {
            System.out.println("Lokales Speichern fehlgeschlagen: " + e.getMessage());
        }
    }

    /**
     * Wiederholt das Speichern in der Cloud alle 10 Sekunden bis maximal 5 Minuten.
     */
    private static void retryCloudSave(String content) {
        int elapsedTime = 0;
        while (elapsedTime < MAX_RETRY_DURATION_SECONDS) {
            try {
                TimeUnit.SECONDS.sleep(RETRY_INTERVAL_SECONDS);
                saveFileToCloud(content);
                System.out.println("Datei erfolgreich nach erneutem Versuch in der Cloud gespeichert.");
                break; // Beende den Versuch, sobald das Speichern erfolgreich war
            } catch (IOException | InterruptedException e) {
                elapsedTime += RETRY_INTERVAL_SECONDS;
                System.out.println("Erneuter Versuch fehlgeschlagen. Warte " + RETRY_INTERVAL_SECONDS + " Sekunden.");
            }
        }
        if (elapsedTime >= MAX_RETRY_DURATION_SECONDS) {
            System.out.println("Maximale Wiederholungsdauer erreicht. Datei konnte nicht in der Cloud gespeichert werden.");
        }
    }

    /**
     * Simuliert die Überprüfung einer Internetverbindung.
     */
    private static boolean hasInternetConnection() {
        // Zufällig für die Demonstration, in einem echten Programm könnte dies eine tatsächliche Überprüfung sein
        return Math.random() < 0.3; // 30% Chance, dass die Verbindung verfügbar ist
    }
}
