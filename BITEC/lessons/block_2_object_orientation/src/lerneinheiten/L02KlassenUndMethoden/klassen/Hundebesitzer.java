package lerneinheiten.L02KlassenUndMethoden.klassen;

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

public class Hundebesitzer extends Mensch {
    private boolean hatHundeFuehrerschein;
    private Hund[] hunde;

    public Hundebesitzer(String name, double happiness, int age, boolean hatHundeFuehrerschein, int capacity) {
        super(name, happiness, age);
        hunde = new Hund[capacity];
        this.hatHundeFuehrerschein = hatHundeFuehrerschein;
    }

    public void gassiGehen() {
        System.out.println("Ich:" + this.getName() + " geh mi...");

        for (Hund hund : hunde) {
            System.out.println(hund.getName());
        }
        System.out.println(" gassi.");
    }

    public void fuettern() {
        System.out.println("ich fuettere meinen Hund");
    }

    public void vernachlaessigtHund() {
        for(int i = 0; i < hunde.length; i++) {
            hunde[i].weglaufen();
            hunde[i] = null;
        }
        happiness = -6858.;
    }

    public Double getHappiness() {
        return happiness;
    }

    public void setHappiness(Double happiness) {
        this.happiness = happiness;
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
