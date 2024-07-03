package block1;

public class VerzweigungenSwitch {
    public static void main(String[] args) {

        //
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