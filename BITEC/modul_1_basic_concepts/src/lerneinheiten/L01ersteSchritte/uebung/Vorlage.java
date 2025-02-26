package lerneinheiten.L01ersteSchritte.uebung;

public class Vorlage {
    public static void main(String[] args) {
        String ANSI_RESET = "\u001B[0m";
        String ANSI_BLACK = "\u001B[30m";
        String ANSI_RED = "\u001B[31m";
        String ANSI_GREEN = "\u001B[32m";
        String ANSI_YELLOW = "\u001B[33m";
        String ANSI_BLUE = "\u001B[34m";
        String ANSI_PURPLE = "\u001B[35m";
        String ANSI_CYAN = "\u001B[36m";
        String ANSI_WHITE = "\u001B[37m";

        //      Test fuer die Farben!
        System.out.println("Hello "+ANSI_RED+"World"+ANSI_RESET+"!");

//      Erste Konsolenausgaben
//      1. Erstellen einer HelloWorld Anwendung, die "Hello World" auf die Konsole ausgibt
//      2. Adaptieren Sie das Programm durch folgende Schritte:
//      2.1. Geben Sie als erste Zeile Ihren Vornamen mittels System.println aus
//      2.2. Geben Sie in der zweiten Zeile Ihren Nachnamen mit System.println aus
//      2.3. Geben Sie ein einer separaten Zeile folgenden Text aus: Heute ist Mittwoch, der 04. Oktober 2023.
//          Jedes Wort soll hierbei separat ausgegeben werden sein. zB.: print("Heute") Tipp: print und println

//      2.4. Geben Sie den selben Satz jetzt mit Tabulatoren als Abständen aus. Tipp: \t erzeugt einen Tabulator.
//      2.5 Geben Sie die einzelnen Strings "3", "+", "7", "=", "10" in einer Zeile auf die Konsole mit einem System.out.println(...) aus.
//          In Java können Strings mit + verkettet werden. Beispiel: System.out.println("Hello"+ " " + "World");
//      2.6 Geben Sie die Zahl 3 auf die Konsole aus
//      2.7. Geben Sie die Zahlen 1 bis 5 mit Tabulatoren getrennt auf die Konsole aus.
//          Jede Zahl soll durch eine andere Farbe dargestellt werden.
//      2.8 Geben Sie das Ergebnis der Berechnung 3+7 auf die Konsole aus. Tipp: System.out.println("10") ist falsch

//      3.1 Geben Sie in der HelloWorld-Applikation 3 Leerzeilen und folgende Titelzeile aus: === Arbeiten mit Argumenten ===
//      3.2 Geben Sie darunter das erste Argument aus. Tipp: Dieses ist über args[0] zugreifbar.
//      3.3 Geben Sie folgendes auf die Konsole aus: Das erste Argument ist Wien und das zweite Argument ist BBRZ.
//        Die Werte Wien und BBRZ sollen aus den Argumenten kommen
    }
}
