package lerneinheiten.L05VariablenUmwandeln.live;

import java.util.Scanner;

public class SchachbrettKoordinaten {
    public static void main(String[] args) {
        // 1. nextLine
        Scanner scanner = new Scanner(System.in);

        System.out.print("Wähle die Spielfigur - x y: ");
        String input = scanner.nextLine();

        //----

        System.out.print("Wähle das Ziel - x y: ");
        input = scanner.nextLine();

        //----
    }
}
