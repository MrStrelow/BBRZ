package lerneinheiten.L02KlassenUndMethoden.grundlagen;

public class SchaeferHund extends Hund {
    // Felder
    public int capacity;

    // Beziehungen
    public Hund[] behueteteHunde;

    // Konstruktoren:
    // Dieser ist ein "zentraler" Konstruktor - dieser wird immer wieder von anderen Konstruktoren unten verwendet.
    // Wir ersparen uns damit immer die gleichen Abfragen, welche wir hier nur ein mal definiert haben.

    // Wir sehen hier ein neues Wort. SUPER. Dieses ist gleich wie THIS, nur spricht es die Klasse, an welche oben
    // bei Klassensignatur neben extends steht. Diese Klasse wird auch der Supertyp, Obertyp, Base-type, Parent-type, ...
    // genannt und stellt die Klasse dar, welche mit unserer erweitert wird. Z.B. Schaefer extends Hund.
    // Wir werden uns in späteren Lektionen mit Ersetzbarkeit und Vererbung beschäftigen. Hier belassen wir es bei
    // "Wir erweitern den Supertyp".
    public SchaeferHund(
            String name, Integer alter, String geschlecht, Double health, boolean chipped,
            int capacity, Hund[] behuetendeHunde
    ) {
        super(name, alter, geschlecht, health, chipped);

        if(capacity < behueteteHunde.length) {
            return;
        }

        this.capacity = capacity;
        this.behueteteHunde = behuetendeHunde;
    }

    public SchaeferHund(String name, Integer alter, String geschlecht, Double health, boolean chipped, int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer, Hund spielFreund) {
        this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde);
        this.setBesitzer(besitzer);
        this.setSpielFreund(spielFreund);
    }

    public SchaeferHund(
            String name, Integer alter, String geschlecht, Double health, boolean chipped,
            int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer
    ) {
        this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde);
        this.setBesitzer(besitzer);
    }

    public SchaeferHund(
            String name, Integer alter, String geschlecht, Double health, boolean chipped,
            int capacity, Hund[] behuetendeHunde, Hund spielFreund
    ) {
        this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde);
        this.setSpielFreund(spielFreund);
    }

    public SchaeferHund(
            String name, Integer alter, String geschlecht, Double health, boolean chipped,
            int capacity, Hund[] behuetendeHunde, Hund spielFreund, HundeBesitzer besitzer
    ) {
        this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde);
        this.setSpielFreund(spielFreund);
        this.setBesitzer(besitzer);

    }

    // Methoden
    public void hueten(){
        for (Hund behueteterHund : behueteteHunde) {
            System.out.println("ich: " + this.getName() + " behuete " + behueteterHund.getName());
        }
    }

    public boolean huetetBereitsHund(Hund hund) {
        boolean behuetetHund = false;

        for (int i = 0; i < behueteteHunde.length; i++) {
            if (behueteteHunde[i].equals(hund)) {
                behuetetHund = true;
                break;
            }
        }

        return behuetetHund;
    }

    // get und set Methoden
    public Hund[] getBehueteteHunde() {
        return behueteteHunde;
    }

    public void addZuBehuetendeHunde(Hund hund) {
        if(hund != null && !huetetBereitsHund(hund)) {
            int key = habePlatz();

            if (key >= 0) {
                this.behueteteHunde[key] = hund;

            } else {
                System.out.println("Bin voll :(");
            }
        }
    }

    public void verstosseHund(Hund hund) {
        for (int i = 0; i < behueteteHunde.length; i++) {
            if (behueteteHunde[i].equals(hund)) {
                behueteteHunde[i] = null;
            }
        }
    }

    public int getCapacity() {
        return capacity;
    }

    public void setCapacity(int capacity) {
        this.capacity = capacity;
    }

    private int habePlatz() {
        int key = -1;

        for (int i = 0; i < behueteteHunde.length; i++) {
            if (this.behueteteHunde[i] == null) {
                key = i;
            }
        }

        return key;
    }
}
