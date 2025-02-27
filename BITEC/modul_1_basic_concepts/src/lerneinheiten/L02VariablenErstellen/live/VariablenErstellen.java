package lerneinheiten.L02VariablenErstellen.live;

import java.io.Console;
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
        userInputCharacter = (char) (98 + primitiv); //3 + 98 = 101 = e
        Integer alter = 97; // Aber hier
        double hoehe = 97.8; // Warum muss hier `hoehe` double sein und darf nicht Double?
        float breite = 97.8f; // Warum muss hier `breite` double sein und darf nicht Float?

        alter = (int) hoehe;  // wir verlieren Information 97.8 wird zu
        alter = (int) breite;  // wir verlieren Information 97.8 wird zu

        hoehe = (double) alter; // geht auch ohne (double) weil, keine Information verloren wird.
        breite = (float) alter;
        breite = (float) hoehe;

        userInputCharacter = (char) 10.8;

        System.out.println("Hallo" + userInputCharacter + "Welt");
        // warum leer? 10.8 ist kein gültiger ASCII-Code, aber 10 ist einer. Jedoch hat 10 keine Darstellung
        // (interner code für new line also \n) die ersten 32 codes in ASCII usw. sind für Solches reserviert.

        userInputCharacter = (char) 97.8;
        System.out.println(userInputCharacter); // hier sehen wir dass es 'a' ist
    }
}
