package lerneinheiten.L02KlassenUndMethoden.live;

public class Main {
    public static void main(String[] args) {
        Hund frido = new Hund("wüf~", false, 2, "schäfer");
        Hund frodo = new Hund("grub~", true, 1, "mops");

        System.out.println(frido.geräusch);
        System.out.println(frodo.geräusch);

        Besitzer hans = new Besitzer();
        hans.hunde = new Hund[5];
        hans.hunde[0] = frido;
        hans.hunde[1] = frido;

    }
}
