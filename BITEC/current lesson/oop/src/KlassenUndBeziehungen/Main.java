package KlassenUndBeziehungen;
public class Main {
    public static void main(String[] args) {
        Hund hundo = new Hund();
        SchaeferHund frodo = new SchaeferHund();

        frodo.hueten();
        frodo.bellen();
        hundo.spielen();
    }
}