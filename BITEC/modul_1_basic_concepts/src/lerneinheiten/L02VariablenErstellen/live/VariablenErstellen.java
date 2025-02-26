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

        // <Typ> <Namen> <Zuweisungsoperator> <Wert>
        Integer wrapper = primitiv;

        String initialisertUndDefiniert = wrapper.toString();

        System.out.println(definiert);
    }
}
