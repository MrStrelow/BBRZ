package FreitagNachmittag;

import java.util.Random;

public class Samen {
    // Felder
    private Tuple<Integer, Integer> position;
    private static String darstellung = "🌱";

    // (hat) Beziehungen
    private Spielfeld spielfeld;

    // Konstruktor
    public Samen(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;

        plazierenUndVerwalteSamen();
    }

    private void plazierenUndVerwalteSamen() {
        Random random = new Random();
        boolean done;
        int x, y;

        do {
            x = random.nextInt(spielfeld.getGroesse());
            y = random.nextInt(spielfeld.getGroesse());

            done = spielfeld.weiseSamenZu(this, new Tuple<>(x,y));
        } while (!done);

        position = new Tuple<>(x,y);
    }

    // Methoden
    // wir überschreiben die toString methode von der Klasse Object.
    // Wir erben von der Klasse Object, deshalb haben wir diese Methode.
    // Überschreiben bedeutet, wenn wir eine Variable vom Typ Samen haben,
    // (ein Objekt von der Klasse samen), dann rufen wir unsere eigene toString()
    // Methode auf.
    // z.B. bei System.out.println(samen); würden wir "🟫" als output bekommen.
    // Wenn wir nicht toString so überschreiben wird "FreitagNachmittag.Samen@5b480cf9" ausgeben.
    @Override
    public String toString() {
        return darstellung;
    }

    // get-set Methoden
    public Tuple<Integer, Integer> getPosition() {
        return position;
    }

    public void setPosition(int x, int y) {
        position.setX(x);
        position.setY(y);
    }

    public void setPosition(Tuple<Integer, Integer> position) {
        this.position = position;
    }

    public int getX() {
        return position.getX();
    }

    public void setX(int x) {
        position.setX(x);
    }

    public int getY() {
        return position.getY();
    }

    public void setY(int y) {
        position.setY(y);
    }

    public static String getDarstellung() {
        return darstellung;
    }

    public Spielfeld getSpielfeld() {
        return spielfeld;
    }

    public void setSpielfeld(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;
    }
}
