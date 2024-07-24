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
        System.out.print("\033[F");
        // nC, wobei n eine ganze Zahl ist, erlaubt uns n Symbole nach rechts zu springen.
        System.out.print("\033[" + positionsToShift + "C");

        System.out.print(" = " + result);
    }
}
