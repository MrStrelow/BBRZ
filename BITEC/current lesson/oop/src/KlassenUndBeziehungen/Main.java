package KlassenUndBeziehungen;
public class Main {
    public static void main(String[] args) {
        Hund gilbert = new Hund("Gilbert", 5, "m", true, 10);
        Hund frido = new Hund("Frido", 5, "m", true, 10);
        gilbert.spielFreund = frido;
        frido.spielFreund = gilbert;

        gilbert.spielen();
        frido.spielen();

        Hund[] hunde = {frido, gilbert};
        HundeBesitzer karo = new HundeBesitzer("Karo", 1.0, 25, false, hunde);

        karo.fuettern();
    }
}