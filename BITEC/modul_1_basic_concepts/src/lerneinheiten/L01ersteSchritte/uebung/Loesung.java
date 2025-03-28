package lerneinheiten.L01ErsteSchritte.uebung;

public class Loesung {

    public static final String ANSI_RESET = "\u001B[0m"; 
    public static final String ANSI_BLACK = "\u001B[30m";
    public static final String ANSI_RED = "\u001B[31m";
    public static final String ANSI_GREEN = "\u001B[32m";
    public static final String ANSI_YELLOW = "\u001B[33m";
    public static final String ANSI_BLUE = "\u001B[34m";
    public static final String ANSI_PURPLE = "\u001B[35m";
    public static final String ANSI_CYAN = "\u001B[36m";
    public static final String ANSI_WHITE = "\u001B[37m";

    public static void main(String[] args) {
//      Test fuer die Farben!
        System.out.println("Hello "+ANSI_RED+"World"+ANSI_RESET+"!");

//      Erste Konsolenausgaben
//      1. Erstellen einer HelloWorld Anwendung, die "Hello World" auf die Konsole ausgibt
        System.out.println("Hello World");

//      2. Adaptieren Sie das Programm durch folgende Schritte:
//      2.1. Geben Sie als erste Zeile Ihren Vornamen mittels System.println aus
        System.out.println("Mathias");

//      2.2. Geben Sie in der zweiten Zeile Ihren Nachnamen mit System.println aus
        System.out.println("Cammerlander");

//      2.3. Geben Sie in einer separaten Zeile folgenden Text aus: Heute ist Mittwoch, der 04. Oktober 2023.
//          Jedes Wort soll hierbei separat ausgegeben werden sein. zB.: print("Heute") Tipp: print und println
        System.out.print("Heute ");
        System.out.print("ist ");
        System.out.print("Mittwoch, ");
        System.out.print("der ");
        System.out.print("04. ");
        System.out.print("Oktober ");
        System.out.print("2023.");
        System.out.println();

//      2.4. Geben Sie denselben Satz jetzt mit Tabulatoren als Abständen aus. Tipp: \t erzeugt einen Tabulator.
        String tab = "\t";

        System.out.print("Heute" + tab);
        // oder einfach System.out.print("Heute\t");
        System.out.print("ist" + tab);
        System.out.print("Mittwoch," + tab);
        System.out.print("der" + tab);
        System.out.print("04." + tab);
        System.out.print("Oktober" + tab);
        System.out.print("2023" + tab);

//      2.5 Geben Sie die einzelnen Strings "3", "+", "7", "=", "10" in einer Zeile auf die Konsole mit einem System.out.println(...) aus.
//          In Java können Strings mit + verkettet werden. Beispiel: System.out.println("Hello"+ " " + "World");
        System.out.println("3" + "+" + "7" + "=" + "10");

//      2.6 Geben Sie die Zahl 3 auf die Konsole aus
        System.out.println(3);

//      2.7. Geben Sie die Zahlen 1 bis 5 mit Tabulatoren getrennt auf die Konsole aus.
//          Jede Zahl soll durch eine andere Farbe dargestellt werden.
        System.out.println(ANSI_BLUE + 1 + tab + ANSI_RED + 2 + tab + ANSI_CYAN + 3 + tab + ANSI_PURPLE + 4 + tab + ANSI_YELLOW + 5 + ANSI_RESET);

//      2.8 Geben Sie das Ergebnis der Berechnung 3+7 auf die Konsole aus. Tipp: System.out.println("10") ist falsch
        System.out.println(3+7);

//      VERGESSEN SIE NICHT HIER DIE ARGUMENTE ZU UEBERGEBEN!
//      3.1 Geben Sie in der HelloWorld-Applikation 3 Leerzeilen und folgende Titelzeile aus: === Arbeiten mit Argumenten ===
        System.out.println();
        System.out.println();
        System.out.println();
        System.out.println("=== Arbeiten mit Argumenten ===");

//      3.2 Geben Sie darunter das erste Argument aus. Tipp: Dieses ist über args[0] zugreifbar.
        System.out.println(args[0]);

//      3.3 Geben Sie folgendes auf die Konsole aus: Das erste Argument ist Wien und das zweite Argument ist BBRZ.
//        Die Werte Wien und BBRZ sollen aus den Argumenten kommen
        System.out.println("Das erste Argument ist " + args[0] + " und das zweite Argument ist " + args[1] + ".");
    }
}
