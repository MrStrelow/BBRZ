package lerneinheiten.L02KlassenUndMethoden.klassen;

import static lerneinheiten.L02KlassenUndMethoden.klassen.Essen.*;
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
    private boolean hatHundeFuehrerschein;
    private Hund[] hunde;
    private int capacity;

    public HundeBesitzer(String name, double happiness, int age, boolean hatHundeFuehrerschein, Hund[] hunde, int capacity) {
        // Super ist der Konstruktor der superklasse/obertyp. hier ist das der Mensch.
        super(name, happiness, age);

        // TODO:
        if(capacity < hunde.length) {
            return;
        }

        this.hatHundeFuehrerschein = hatHundeFuehrerschein;
        this.hunde = hunde;
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
            hunde,
            capacity
        );
    }

    // dieser erlaubt uns nur einen Hund zu übergeben.
    public HundeBesitzer(Mensch istBaldHundebesitzer, boolean hatHundeFuehrerschein, Hund hund, int capacity) {
        // Das ist der Konstruktor dieser Klasse! Wir können diesen mit this(...) aufrufen.
        // Wir sparen uns damit die Übergabe der Felder eines Menschen als Aufrufer dieses Konstruktors.
        // Achtung! this() und super() muss immer der erste Aufruf sein.
        // Es muss also Hund in einer Zeile zu einem Hunde Array werden.
        this(
            istBaldHundebesitzer.getName(),
            istBaldHundebesitzer.getHappiness(),
            istBaldHundebesitzer.getAlter(),
            hatHundeFuehrerschein,
            new Hund[]{hund},
            capacity
        );
    }

    public void gassiGehen() {
        System.out.println("Ich: " + this.getName() + " geh mit...");

        //TODO: for each loop.
        for (Hund hund : hunde) {
            System.out.println(hund.getName());
        }
        System.out.println(" gassi.");
    }

    public void fuettern() {
        for (Hund hund : hunde) {
            // TODO: enum
            hund.fressen(FLEISCH);
        }
    }

    public void buersten() {
        for (Hund hund : hunde) {
            // TODO: instance of
            if (hund instanceof Pudel) {
                hund.setHealth(hund.getHealth() + 10);

            } else {
                hund.setHealth(hund.getHealth() + 1);
            }
        }
    }

    public Hund[] getHunde() {
        return hunde;
    }

    public void setHunde(Hund[] hunde) {
        if(hunde != null) {
            this.hunde = hunde;
        }
    }
    public void addHund(Hund hund, Integer pos) {
        if(hund != null) {
            this.hunde[pos] = hund;
        }
    }

}
