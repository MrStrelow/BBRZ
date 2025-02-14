package lerneinheiten.L02KlassenUndMethoden.grundlagen;

import static lerneinheiten.L02KlassenUndMethoden.grundlagen.Essen.*;
/*
    Hier betrachten wir die <ist> Beziehung. Wir wollen hier zum Ausdruck bringen, dass ein Hundebesitzer ein Mensch ist.
    Wir können also überall wo wir einen Mensch haben, einen Hundebesitzer angeben, aber umgekehrt nicht!
    Damit ist der Ausdruck Mensch hans = new Hundebesitzer(); ein gültiger Ausdruck. Hundebesitzer hans = new Mensch();
    geht aber nicht.
    Also wenn wir einen Mensch haben, hat dieser ein allgemeines Verhalten welches wir in der Klasse Mensch definieren.
    Ein Hundebesitzer ERWEITERT (extends) dieses menschliche Verhalten um hundespezifische Eigenschaften.
    Wir definieren also im Mensch allgemeine Methoden/<hat>Beziehungen/Attribute welche zum Mensch passen, und schreiben
    alles hundespezifische in die Klasse Hundebesitzer.
    Wir müssen also das nicht doppelt dsa Menschliche Verhalten in den Hundebesitzer schreiben, wenn ein Hundebesitzer ein Mensch ist
    und geben das mit EXTENDS bei der Klassendefinition an. Also public class Hundebesitzer extends Mensch {...}.
    Es ist also möglich, wenn bert ein Hundebesitzer ist, Hundebesitzer bert = new Hundebesitzer();, dass wir das in Mensch definierte
    Attribut alter verwenden können, bert.getAlter();.

    ACHTUNG! Wir können nicht mit mehreren Klassen eine <ist> Beziehung in JAVA haben (in C++ schon). In JAVA verwenden wir dafür INTERFACES,
    welche wir ein anderes Mal besprechen.
 */

public class HundeBesitzer extends Mensch {
    // Felder
    private boolean hatHundeFuehrerschein;
    private int capacity;

    // hat-beziehungen
    private Hund[] hunde;

    // Konstruktoren
    public HundeBesitzer(String name, double happiness, int age, boolean hatHundeFuehrerschein, int capacity) {
        // Super ist der Konstruktor der superklasse/obertyp. hier ist das der Mensch.
        super(name, happiness, age);

        this.hunde = new Hund[capacity];
        this.hatHundeFuehrerschein = hatHundeFuehrerschein;
        this.capacity = capacity;
    }

    // Wir können mehrere Konstruktoren bauen, solange die Argumente unterschiedlich sind.
    public HundeBesitzer(Mensch istBaldHundebesitzer, boolean hatHundeFuehrerschein, Hund[] hunde, int capacity) {
        // Das ist der Konstruktor dieser Klasse! Wir können diesen mit this(...) aufrufen.
        // Wir sparen uns damit die Übergabe der Felder eines Menschen als Aufrufer dieses Konstruktors.
        this(
            istBaldHundebesitzer.getName(),
            istBaldHundebesitzer.getHappiness(),
            istBaldHundebesitzer.getAlter(),
            hatHundeFuehrerschein,
            capacity
        );
    }

    // dieser erlaubt uns nur einen Hund zu übergeben.
    public HundeBesitzer(Mensch istBaldHundebesitzer, boolean hatHundeFuehrerschein, int capacity) {
        // Das ist der Konstruktor dieser Klasse! Wir können diesen mit this(...) aufrufen.
        // Wir sparen uns damit die Übergabe der Felder eines Menschen als Aufrufer dieses Konstruktors.
        // Achtung! this() und super() muss immer der erste Aufruf sein.
        // Es muss also Hund in einer Zeile zu einem Hunde Array werden.
        this(
            istBaldHundebesitzer.getName(),
            istBaldHundebesitzer.getHappiness(),
            istBaldHundebesitzer.getAlter(),
            hatHundeFuehrerschein,
            capacity
        );
    }

    // Methoden
    public void gassiGehen() {
        System.out.println("Ich: " + this.getName() + " geh mit...");

        // Wir sehen hier eine neue Art der Schleife. Diese ist die ForEach-Schleife. Diese läuft alle elemente einer
        // Collection ab. Eine Collection ist ein Array, Liste, Map, Heap, Set, etc. Wir kennen bis jetzt das Array.
        // Hier sehen wir, dass rechts vom ":" viele Elemente stehen und links vom ":" eines steht.
        // Wir interpretieren das als:
        // "es wird in jedem Schleifendurchlauf ein element aus hunde genommen. Dieses ist mit hund ansprechbar."
        // Wir sparen uns dadurch die Zählvariablen und haben dadurch einen übersichtlicheren Code.
        // Als Daumenregel merken wir uns, eine ForEach verwenden wir, wenn wir die Elemente alle "auslesen" wollen.
        // Die bereits bekannte for-Loop ist für kompliziertere Operationen und "schreibzugriffe".
        for (Hund hund : hunde) {
            System.out.println(hund.getName());
        }

        System.out.println(" gassi.");
    }

    public void fuettern() {
        for (Hund hund : hunde) {
            // Wenn wir hier nicht die null objekte in hunde ignorieren, werden wir fehler bekommen!
            // Das liegt leider am Aufbau des Arrays. Ein Grund warum wir in Zukunft andere Datenstrukturen verwenden.
            if (hund != null) {
                // Wir können das enum mit wert FLEISCH direkt verwenden, wenn wir oben einen static import machen.
                // ansonsten ist...
//                hund.fressen(Essen.FLEISCH);
                // zu schreiben.
                hund.fressen(FLEISCH);
            }
        }
    }

    public void buersten() {
        for (Hund hund : hunde) {
            // Wir greifen hier ein wenig vor.
            // Jedoch haben wir ein Problem, wenn wir ein Array an Hunden besitzen, aber nicht wissen, ob es
            // ein Pudel, Schaefer oder einfach ein Hund ist. Denn dadurch, dass ein Schaefer ein Hund ist, kann ich
            // diesen überall verwenden, wo ein Hund erwartet wird. Deshalb sind für uns in dem Array von Hunden alles
            // Hunde. Es könnte aber sein, dass im Hintergrund ein Hund zusätzlich ein Pudel ist.
            // Wenn wir nun ein anderes Verhalten für Pudel wollen, müssen wir das irgendwie abfragen können.
            // Dies geschieht hier mit dem "instanceof" operator. Dieser liefert als Rückgabe eine Boolesche Variable

            // Achtung! das hier ist ein Trick damit JAVA weiß, dass es nun einpudel ist.
            // Wir fragen also ab, ist das Objekt hund vom Typ Pudel, wenn ja, dann nennen wir das Objekt pudel.
            // Wir ersparen uns somit Typumwandlungen!
            if (hund instanceof Pudel pudel) {
                pudel.setHealth(hund.getHealth() + 10);
                pudel.setFluff(pudel.getFluff() * 2);

            } else {
                hund.setHealth(hund.getHealth() + 1);
            }
        }
    }

    public void aussetzen(Hund hund) {
        for (int i = 0; i < hunde.length; i++) {
            if (hunde[i].equals(hund)) {
               hunde[i] = null;
            }
        }
    }

    // Wir sehen hier, dass findeHund und kaufeHund das gleiche Verhalten haben.
    // Es kann jedoch in zukunft beim Kauf eine Transaktion mit einem Geschäft dazukommen,
    // welche beim Finden nicht der Fall ist.
    public void finden(Hund neuerHund) {
        neuerHund.setBesitzer(this);
    }

    public void kaufen(Hund neuerHund) {
        // guard clause
        if (neuerHund instanceof SchaeferHund && !hatHundeFuehrerschein) {
            System.out.println("Fehler! es wird für einen " + neuerHund.getClass() + " ein Hundeführerschein benötigt.");
        }

        neuerHund.setBesitzer(this);
    }

    public void verkaufen(Hund hund) {
        //Frage: ist das hier korrekt? der Code macht, was wir wollen, aber denken wir, ob aussetzen bei einem verkauf konzeptionell zusammenpasst?
        //zukünftig kann es sein, dass durch eine solche Verwendung Fehler zur Laufzeit entstehen.
        aussetzen(hund);

        hund.setBesitzer(null);
    }

    // get-und-set Methoden
    public Hund[] getHunde() {
        return hunde;
    }

    public void addHund(Hund hund) {
        // stelle sicher, dass hund nicht bereits besessen wird
        if(hund != null && !besitztHund(hund)) {
            int key = habePlatz();

            if (key >= 0) {
                this.hunde[key] = hund;

            } else {
                System.out.println("Bin voll :(");
            }
        }
    }

    // Hilfsmethoden: Methoden, von "Domänen-Klassen" welche nicht in der Domäne notwendig sind, jedoch uns technisch das Leben einfacher machen.
    // Ein solches Verhalten kann in eigenen Klassen abgespalten werden. Diese heiße dann "Application Klassen".
    public boolean besitztHund(Hund hund) {
        boolean besitztHund = false;

        for (int i = 0; i < hunde.length; i++) {
            // Achtung! Wir fragen hier auf Gleichheit ab. Wir können also nicht 2 Hunde besitzen, die gleich sind (.equals).
            // Wir wollen aber aussschließen, dass diese nicht dieselben sind. Das machen wir mit "==".
//            if (hund.equals(hunde[i])) {
            if (hund == hunde[i]) {
                besitztHund = true;
                break;
            }
        }

        return besitztHund;
    }

    private int habePlatz() {
        int key = -1;

        for (int i = 0; i < hunde.length; i++) {
            if (this.hunde[i] == null) {
                key = i;
                break;
            }
        }

        return key;
    }
}
