package lerneinheiten.L02VariablenErstellen.live;

public class VariablenErstellen {
    public static void main(String[] args) {
        // Startpunkt
        // <Typ> <Name>
        // definiert
        String definiert;

        // initialisiert
        // <Name> <Zuweisungsoperator> <Wert>
        definiert = "hallo";

        int primitiv = 3;


        // <Typ> <Namen> <Zuweisungsoperator> <Variable mit passendem Typ>
        Integer wrapper = primitiv;


        // <Typ> <Namen> <Zuweisungsoperator> <irgendwas was mit den passenden Typ erzeugt>
        String initialisertUndDefiniert = wrapper.toString();

        // Allgemein:
        // <Typ> <Namen> <Zuweisungsoperator> <Wert oder eine Variable mit dem passendem Typ oder irgendwas was den passenden Typ erzeugt>

        // warum geht das nicht?
        String initialisertUndDefiniert = String.valueOf(primitiv);
    }
}
