import java.util.Random;

public class L07VerzweigungenSwitch {
    public static void main(String[] args) {
        // ############################## SWITCH ##############################

        // Wir haben nur mit der IF-Verzweigung begonnen. Jedoch ist es manchmal syntaktisch angenehmer ein anderes Sprachkonstrukt
        // zu verwenden. Die SWITCH-Verzweigung. Diese eignet sich, wenn wir mit dem Vergleichsoperator "==" bzw. ".equals();" verwenden.
        // Die Variablen, welche wir mit dem genannten Vergleichsoperator in dem SWITCH vergleichen können, sind Strings und Zahlen (leider keine eigenen Objekte).
        // Wir geben dazu die Variable innerhalb der runden Klammern "switch(<hier>)".
        // Danach geben wir die Fälle an, welche wir mit dem Vergleichsoperator vergleichen wollen.
        // z.B. wenn die Variable "input" den Typ Integer hat, kann diese gleich "1" sein. Also input == 1.
        // Das schreiben wir im Switch mit "case 1:". Weiters folgt dann der Code welcher ausgeführt werden soll, wenn diese Bedingung eintritt.
        // ACHTUNG: wir müssen am Ende des Code Blockes ein "break;" schreiben um nicht alle cases durchzugehen.


        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.

        Integer input = 1;

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

        input = 4;

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

        // Wir können mit dieser Schreibweise auch komplizierteren Code schreiben, wenn der Fall "input == 1", also case 1, eintritt.
        // Dazu geben wir geschwungene Klammern nach dem "->" hinzu und gehen diesen Block von oben nach unten ab.
        // Am Ende müssen wir ein Ergebnis zurückgeben, welches der Variable "output" zugewiesen wird.
        // Das machen wir mit dem Befehl "yield".

//        Double zufallszahl = Math.random(); // das ist eine Andere Variante.
        Random random = new Random();
        Double zufallszahl = random.nextDouble();

        output = switch (input) {
            case 1 -> {

                String res = "Freitag :)";

                if (zufallszahl < 0.3) {
                    res = res + ":)".repeat(7);
                }

                yield(res);

            }
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        System.out.println(output);


        // Hier noch ein Beispiel in die andere Richtung, ohne dem "->".
        String wochentag="Montag";
        int num;

        switch (wochentag) {
            case "Montag":
                num = 1;
                System.out.println("num");
                break;

            case "Dienstag":
                num = 2;
                System.out.println("helle chello");
                break;

            default:
                num = -1;
        }

        // Die elegantere Variante ist folgende welche einem eine Zuweisung erlaubt.
        // hier wird eine art Rückgabe, das bei "->" steht, dem was am Anfang steht zugewiesen. Hier "num ="

        num = switch (wochentag) {
            case "Montag" -> 1;
            case "Dienstag" -> 2;
            default -> -1;
        };

        System.out.println("das ist nach der switch! :) "+num);

        // Hier eine kleine Modifikation um "mehr Code" zu ermöglichen. Also mehrere Zeilen code pro case ausführen zu können.
        // hier wird eine art Rückgabe, das bei "yield" steht, dem was am Anfang steht zugewiesen. Hier "num ="
        // Das was nach dem "->" steht ist der Block welcher ausgeführt wird.
        num = switch (wochentag) {
            case "Montag" -> {
                System.out.println("this is hello");
                yield 1;
            }
            case "Dienstag" -> 2;
            default -> -1;
        };

        System.out.println("das ist nach der switch! :) "+num);
    }
}