package KlassenUndBeziehungen;
public class Main {
    public static void main(String[] args) {
        Hund gilbert = new Hund("Gilbert", 5, "m", true, 10);
        Hund frido = new Hund("Frido", 5, "m", true, 10);
        gilbert.spielFreund = frido;
        frido.spielFreund = gilbert;

//        SchaeferHund frodo = new SchaeferHund();

//        frodo.hueten();
//        frodo.bellen();
        gilbert.spielen();
        frido.spielen();
    }
}