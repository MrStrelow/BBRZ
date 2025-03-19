package lerneinheiten.L05VariablenUmwandeln.live;

import java.util.Scanner;

public class SchachbrettKoordinaten {
    public static void main(String[] args) {
        // 1. nextLine
        Scanner scanner = new Scanner(System.in);

        System.out.print("Wähle die Spielfigur - x y: ");
        String input = scanner.nextLine(); // lies die ganze zeile ein
        String[] teile = input.split("[ \\-,/🧱🔺\n]"); // reiß diesen string an den angegebenen symbolen auseinander
        Integer xStart = Integer.parseInt(teile[0]); // nimm die erste zahl
        Integer yStart = Integer.parseInt(teile[1]); // nimm die 2. zahl

        //----

        System.out.print("Wähle das Ziel - x y: ");
        input = scanner.nextLine();

        //----
    }
}
