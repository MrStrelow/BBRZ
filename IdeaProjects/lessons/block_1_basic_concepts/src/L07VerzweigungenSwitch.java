import java.util.Random;
import java.util.Scanner;

public class L07VerzweigungenSwitch {
    public static void main(String[] args) {
        // ############################## SWITCH ##############################

        // Wir haben nur mit der IF-Verzweigung begonnen. Jedoch ist es manchmal syntaktisch angenehmer ein anderes Sprachkonstrukt
        // zu verwenden. Die SWITCH-Verzweigung. Diese eignet sich, wenn wir mit dem Vergleichsoperator "==" bzw. ".equals();" verwenden.
        // Die Variablen, welche wir mit dem genannten Vergleichsoperator in dem SWITCH vergleichen können, sind Strings und Zahlen (leider keine eigenen Objekte).
        // Wir geben dazu die Variable innerhalb der runden Klammern "switch(<hier>)".
        // Danach geben wir die Fälle an, welche wir mit dem Vergleichsoperator vergleichen wollen.
        // z.B. wenn die Variable "input" den Typ Integer hat, kann diese gleich "1" sein. Also input == 1.
        // Das schreiben wir im Switch mit "case 1:".
        // Weiters folgt dann der Code welcher ausgeführt werden soll, wenn diese Bedingung eintritt.
        // ACHTUNG: wir müssen am Ende des Codeblockes ein "break;" schreiben um nicht alle cases durchzugehen.
        // OPTIONAL: Wir können zudem einen Fall festlegen, wenn keines des cases als korrekt ausgewertet wird.
        // Das wird mit dem keyword "optional" angegeben. Wir schreiben dies anstatt des wortes "case".

        // Schauen wir uns dazu die Übungen aus der IF Verzweigung an.
        // 1 )
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.

        Scanner scanner = new Scanner(System.in);

        System.out.print("Geben Sie eine Zahl zwischen 1 und 7 ein um einen Wochentag zu erhalten: ");
        Integer input = Integer.parseInt(scanner.nextLine());

        switch (input) {
            case 1: System.out.println("Montag :("); break;
            case 2: System.out.println("Dienstag"); break;
            case 3: System.out.println("Mittwoch"); break;
            case 4: System.out.println("Donnerstag"); break;
            case 5: System.out.println("Freitag :)"); break;
            case 6: System.out.println("Samstag"); break;
            case 7: System.out.println("Sonntag"); break;
            default: System.out.println("Kein Wochentag.");
        }

        // Wir Können das SWITCH statement auch in einer anderen Variante schreiben welche es erlaubt eine Rückgabe zu erzeugen,
        // welche wir in eine Variable speichern.
        // Damit meinen wir Folgendes.
        // Hier wird der String "Montag :(" welcher in case 1 zurückgegeben wird, der Variable "output" zugewiesen.
        // Das passiert nur, wenn die Variable "input" den Wert "1" hat.
        // Wir sehen hier auch keine Anwendung des keywords "break".

        String output = switch (input) {
            case 1 -> "Montag :(";
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        System.out.println(output);

        // Hier eine kleine Modifikation um "mehr Code" zu ermöglichen. Also mehrere Zeilen code pro case ausführen zu können.
        // Wir können mit dieser Schreibweise auch komplizierteren Code schreiben, wenn der Fall "input == 1", also case 1, eintritt.
        // Dazu geben wir geschwungene Klammern nach dem "->" hinzu und gehen diesen Block von oben nach unten ab.
        // Am Ende müssen wir ein Ergebnis zurückgeben, welches der Variable "output" zugewiesen wird.
        // Das machen wir mit dem Befehl "yield".

        // 2 )
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.
        //  - Zusätzlich hat der Montag eine chance von 80% 5 mal ":(", also ":(:(:(:(:(" zum String "Montag :(" hinzuzufügen.
        //  - Zusätzlich hat der Freitag eine chance von 30% 7 mal ":(", also ":):):):):):):)" zum String "Freitag :)" hinzuzufügen.
        //  - Zusätzlich hat jeder Tag eine Chance von 1%, dass dieser einen zusätzlichen Smiley ":)" hat.

//        Double zufallszahl = Math.random(); // das ist eine andere Variante.
        Random random = new Random();
        Double zufallszahlMontag = random.nextDouble();
        Double zufallszahlFreitag = random.nextDouble();
        Double zufallszahlJederTag = random.nextDouble();

        output = switch (input) {
            case 1 -> {
                String res = "Montag :)";

                if (zufallszahlMontag < 0.8) {
                    res = res + ":(".repeat(5);
                }

                yield(res);
            }
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> {
                String res = "Freitag :)";

                if (zufallszahlFreitag < 0.3) {
                    res = res + ":)".repeat(7);
                }

                yield(res);
            }
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        if (zufallszahlJederTag < 0.01) {
            System.out.print(output + ":)");
        } else {
            System.out.println(output);
        }

        // Wir können zusätzlich zu ganzen Zahlen auch Strings mit dem switch in cases aufspalten.
        // Wir sehen zudem, dass auch in der Basisvariante mehrere Zeilen Code in einem case hintereinander ausgeführt werden können.
        // Hier ein Beispiel:
        String wochentag = "Montag";
        Integer res;

        switch (wochentag) {
            case "Montag":
                res = 1;
                System.out.println("Heute ist Montag");
                break;

            case "Dienstag":
                res = 2;
                System.out.println("Heute ist Dienstag");
                break;

            default:
                res = -1;
                System.out.println("Heute ist irgend ein anderer Tag");
        }
    }
}