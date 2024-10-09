package lerneinheiten.L06VerzweigungenIF;

import java.util.Scanner;

public class L06TaschenrechnerTerminalRelease {
    public static void main(String[] args) {
        // Siehe TaschenrechnerTerminalDemo.java für Erklärung!
        // Hier ist nur eine elegantere/andere Variante des Codes, welche das Problem in TaschenrechnerTerminalDemo löst.
        // TODO: Finde heraus wo und wieso.
        Scanner scanner = new Scanner(System.in);

        String instructions = "Rechnung: ";
        System.out.print(instructions);

        String userInput = scanner.nextLine();
        String[] userInputSplit = userInput.split(" ");

        Double firstNumber  = Double.parseDouble(userInputSplit[0]);
        String operator     = userInputSplit[1];
        Double secondNumber = Double.parseDouble(userInputSplit[2]);

        Double result;

        if (operator.equals("+")) {
            result = firstNumber + secondNumber;

        } else if (operator.equals("-")) {
            result = firstNumber - secondNumber;

        } else if (operator.equals("*")) {
            result = firstNumber * secondNumber;

        } else if (operator.equals("/")) {
            result = firstNumber / secondNumber;

        } else {
            System.out.println("\nError! Ungültiger Operator.");
            return;
        }

        Integer positionsToShift = instructions.length() + userInput.length();

        // ANSICODE: dieser Code stellt einen Speziellen String dar, welcher uns erlaubt die Console zu manipulieren.
        // Ähnlich der Übung00 mit den Farben. Wir manipulieren damit den Ort des Cursors.
        // Wir springen eine zeile hoch und ganz nach links.
        // - "\033" ist ein Code für "escape the next characters" - das Bedeutet diese werden nicht ausgegeben,
        //   sondern als "spezieller" Befehl interpretiert.
        // - "[" ist ein Symbol für den Start einer "Control sequence" - es wird also etwas manipuliert.
        // - "F" bedeutet springe eine Zeile hoch und ganz nach links.
        System.out.print("\033[F");

        // Hier ebenso. Hier erlaubt uns "<ganzeZahl>C", uns <ganzeZahl> Symbole nach rechts zu springen.
        System.out.print("\033[" + positionsToShift + "C");

        System.out.print(" = " + result);
    }
}
