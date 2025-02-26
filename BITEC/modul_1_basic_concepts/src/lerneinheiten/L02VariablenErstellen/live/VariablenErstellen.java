package lerneinheiten.L02VariablenErstellen.live;

import java.util.Random;

public class VariablenErstellen {
    // Startpunkt
    public static void main(String[] args) {
        // definierte Variable
        // <Typ> <Name>
        String definiert;

        // initialisierte Variable
        // <Name> <Zuweisungsoperator> <Wert>
        definiert = "hallo";

        // initialisiert und definiert
        // <Typ> <Name> <Zuweisungsoperator> <Wert>
        int primitiv = 3;

        // <Typ> <Namen> <Zuweisungsoperator> <Variable mit passendem Typ>
        Integer wrapper = primitiv;

        // <Typ> <Namen> <Zuweisungsoperator> <irgendwas was mit den passenden Typ erzeugt>
        String initialisertUndDefiniert = wrapper.toString();

        System.out.println(initialisertUndDefiniert);
        // Allgemein:
        // <Typ> <Namen> <Zuweisungsoperator> <Wert oder eine Variable mit dem passendem Typ oder irgendwas was den passenden Typ erzeugt>

        // warum geht das nicht? - Variable ist schon definiert -> brauchen den Typ nicht mehr.
        initialisertUndDefiniert = String.valueOf(primitiv);
        System.out.println(initialisertUndDefiniert);

        // Zeichenketten:
        // Zeichen (Character)
        Character userInputCharacter = 'l';
        userInputCharacter = 97; // ASCI -> Decimal
        userInputCharacter = 0x0061; // Univode -> Hexadezimal
        userInputCharacter = '\u0061';
        String userInputString = "🥹";

        System.out.println(userInputCharacter);

        userInputString = "a" + "b"; // concatenation - zusammenfügen
        System.out.println(userInputString);
        userInputCharacter = (char) (97 + 98); // 195 = Ã

        System.out.println(userInputCharacter);

        // casting - nur bei primitiven!
        userInputCharacter = (char) (primitiv + 98); // 101 = e
        Integer alter = 32;
        double doubleZahl = 10.8;
        Float floatZahl = 10.8f;

        alter = (int) doubleZahl;
        doubleZahl = (double) alter; // geht auch ohne weil, keine Information verloren wird.
        floatZahl = (float) alter;
        userInputCharacter = (char) doubleZahl;
        System.out.println("asdfsad");
        System.out.println(userInputCharacter); // warum leer? nicht darstellbar.
    }
}
