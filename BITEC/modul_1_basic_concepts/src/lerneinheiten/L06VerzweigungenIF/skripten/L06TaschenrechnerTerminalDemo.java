package lerneinheiten.L06VerzweigungenIF.skripten;

import java.util.Scanner;

public class L06TaschenrechnerTerminalDemo {
    public static void main(String[] args) {
        // Wir wollen hier mit einer Kommandozeilenapplikation eine Rechnung einlesen und diese in der gleichen Zeile wieder ausgeben.
        // Also, wenn wir "2 + 5" in eine Zeile schreiben, soll " = 7" an diese Eingabe angehängt werden.
        // Wenn wir aber folgendes Programm in Intellij ausführen, haben wir immer noch 2 Zeilen.
        // Leider hat der Terminal/die Console von Intellij nicht immer das gleiche Verhalten, wie z.B. jene in Windows.
        // Wir können also folgendes Programm nicht in der Intellij Konsole umsetzen!
        // Wir müssen dazu unser JAVA Programm im Terminal des jeweiligen Betriebssystems direkt aufrufen.
        // Wir tun dies folgendermaßen (Windows 11):
        // - starte in Intellij und navigiere in die Projektstruktur (meistens auf der Linken Seite).
        // - Drücke auf TaschenrechnerTerminalDemo rechts und gehe zu "open in" und danach "Explorer".
        // - Drücke rechts unter TaschenrechnerTerminalDemo auf einen freien Platz (nicht auf ein anderes File!) und danach "Open in Terminal"
        // Dort tippe:
        // - "javac TaschenrechnerTerminalDemo.java". Das c steht für "compile". Wir erstellen hier den JAVA Bytecode, welcher der JAVA Virtual Machine gegeben wird um es auszuführen.
        // - wenn ein TaschenrechnerTerminalDemo.class filer im gleichen Ordner erstellt wurde, tippe "java TaschenrechnerTerminalDemo".
        //   Wir führen damit das Java Programm aus. Diese beiden Befehle werden geschrieben, wenn wir in Intellij auf "run" (grünes Dreieck) drücken.
        // ACHTUNG! Die Endung ".java" muss bei "javac" geschrieben werden, ansonsten kommt ein Fehler.
        // ACHTUNG! Die Endung ".class" darf bei "java" NICHT geschrieben werden, ansonsten kommt ein Fehler.

        // Gib nun 2.0 + 5.0 ein und schau was passiert.
        // Führe das gleiche Programm in Intellij aus und schau was passiert.

        Scanner scanner = new Scanner(System.in);

        System.out.print("Rechnung: ");
        Double ersteZahl = scanner.nextDouble();
        String operator = scanner.next();
        Double zweiteZahl = scanner.nextDouble();

        Double ergebnis;

        if (operator.equals("+")) {
            ergebnis = ersteZahl + zweiteZahl;

        } else if (operator.equals("-")) {
            ergebnis = ersteZahl - zweiteZahl;

        } else if (operator.equals("*")) {
            ergebnis = ersteZahl * zweiteZahl;

        } else if (operator.equals("/")) {
            ergebnis = ersteZahl / zweiteZahl;

        } else {
            System.out.println("\nError! Ungültiger Operator.");
            return;
        }

        // ANSICODE: dieser Code stellt einen Speziellen String dar, welcher uns erlaubt die Console zu manipulieren.
        // Ähnlich der Übung00 mit den Farben. Wir manipulieren damit den Ort des Cursors.
        // Wir springen eine zeile hoch und ganz nach links.
        // - "\033" ist ein Code für "escape the next characters" - das Bedeutet diese werden nicht ausgegeben,
        //   sondern als "spezieller" Befehl interpretiert.
        // - "[" ist ein Symbol für den Start einer "Control sequence" - es wird also etwas manipuliert.
        // - "F" bedeutet springe eine Zeile hoch und ganz nach links.
        System.out.print("\033[F");

        // Wir simulieren den User input und schreiben das Ergebnis inklusive " = " hinzu.
        String result = "Rechnung: " + ersteZahl + " " + operator + " " + zweiteZahl + " = " + ergebnis;

        // TODO: Welches Problem haben wir dadurch? Gib dazu "2 + 5" ein.
        System.out.print(result);
    }
}