import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class MainSwitch {
    public static void main(String[] args) {
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

        switch (input) {
            case 1 -> System.out.println("Montag :(");
            case 2 -> System.out.println("Dienstag");
            case 3 -> System.out.println("Mittwoch");
            case 4 -> System.out.println("Donnerstag");
            case 5 -> System.out.println("Freitag :)");
            case 6 -> System.out.println("Samstag");
            case 7 -> System.out.println("Sonntag");
            default -> System.out.println("Kein Wochentag.");
        }

        String zuweisung = switch (input) {
            case 1 -> "Montag :(";
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "Kein Wochentag.";
        };

        System.out.println(zuweisung);

        zuweisung = switch (input) {
            case 1 -> {
                System.out.println("Montag!");
                yield("Montag :(");
            }
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "Kein Wochentag.";
        };

        System.out.println(zuweisung);

        Integer zuweisungInt = switch (zuweisung) {
            case "Montag :(" -> 1;
            case "Dienstag" -> 2;
            case "Mittwoch" -> 3;
            case "Donnerstag" -> 4;
            case "Freitag :)" -> 5;
            case "Samstag" -> 6;
            case "Sonntag" -> 7;
            default -> -1;
        };

        zuweisungInt = switch (zuweisung) {
            case "Montag :(", "QWER" -> 1;
            case "Dienstag" -> 2;
            case "Mittwoch" -> 3;
            case "Donnerstag" -> 4;
            case "Freitag :)" -> 5;
            case "Samstag" -> 6;
            case "Sonntag" -> 7;
            default -> -1;
        };
    }
}