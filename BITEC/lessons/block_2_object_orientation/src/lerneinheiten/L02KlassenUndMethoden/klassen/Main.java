package lerneinheiten.L02KlassenUndMethoden.klassen;

public class Main {
    /*
    Die Überlegungen aus den UML-Klassendiagramm werden wir nun in JAVA Klassen übersetzen.
    Wir haben uns dort folgendes überlegt:
        - Wir wollen Menschen welche Hunde halten modellieren.
            Wir verwenden dazu 3 Konzepte:
                1) Welche "Dinge" gibt es in unserer "Welt"?                        (was gibt es? HAUPTWORT/NOMEN)
                2) Was macht ein "Ding" aus und was ist dessen "Zustand"?           (was hat es? was macht es aus? HAUPTWORT/NOMEN)
                3) Was ein "Ding" mit seiner "Umwelt" tun?                          (was kann es tun? ZEITWORT/VERB)
                4) In welcher Art interagieren diese "Dinge" mit anderen "Dingen"?  (<hat> und <ist>)
            1) bezeichnen wir als KLASSE, 2) als die FELDER einer KLASSE, 3) als METHODEN einer KLASSE und
            4) die BEZIEHUNGEN zwischen KLASSEN.
        Wir versuchen nun unsere Überlegungen in ein Diagramm zu fassen (Siehe Hunde.drawio - aus L01UML).
        Daraus sind folgende Klassen, FELDER, Methoden und Beziehungen entstanden:
            - Klassen:
                Hund:
                    - FELDER: chipped, health, age, geschlecht
                    - Beziehungen:
                        - <hat>: einen Hundebesitzer
                        - <ist>:
                    - Methoden: fressen, bellen, spielen, weglaufen
                Pudel:
                    - FELDER: fluff
                    - Beziehungen:
                        - <hat>: einen Hundebesitzer
                        - <ist>: ein Hund
                    - Methoden: winseln
                 Schäferhund:
                    - FELDER: capacity
                    - Beziehungen:
                        - <hat>: einen Hundebesitzer, welcher einen Hundefuehrerschein hat
                        - <ist>: ein Hund
                    - Methoden: hueten
                Hundebesitzer:
                    - FELDER: hatHundeFuehrerschein
                    - Beziehungen:
                        - <hat>: einen oder mehrere Hunde
                        - <ist>: ein Mensch
                    - Methoden: gassi gehen, Hunde fuettern, Hunde vernachlaessigen
                Mensch:
                - FELDER: age, health, happiness
                    - Beziehungen:
                        - <hat>:
                        - <ist>:
                    - Methoden: hundKaufen

        Wir haben nun unsere "Welt" modelliert, jedoch müssen wir bevor wir uns mit JAVA beschäftigen noch klären, was
        OBJEKTE sind. Ein Objekt (oder INSTANZ) einer Klasse, ist die Instanziierung dieser. Die Klasse ist als Bauplan, was ein Hund ist
        oder als "DNA" zu sehen. Wir definieren dort was ein z.B. Hund überhaupt ausmacht und wie er mit seiner Umwelt interagiert.
        Das Objekt ist nun der "echte" Hund. Dieser hat nun nicht nur ein Alter, sonder wir wissen,  dass das Alter vom Objekt
        Gilbert 5 Jahre ist. Wir können beliebig viele Objekte von Klassen erzeugen. Wir können also Hunde erzeugen welche nun
        der Gilbert, Franz und Susi ist. Alles sind Hunde, jedoch sind sie verschieden alt, haben verschiedene Besitzer usw.
        All das folgt den Spielregeln der definierten Klasse. Also ein Objekt Gilbert von Typ Hund kann nicht aufs Klo gehen,
        wenn das nicht in der Klasse vorgesehen ist.

        Wenn wir nun diese Ideen in JAVA schreiben wollen, brauchen wir noch zusätzliche, für die Sprache selbst wichtige Konzepte.
        Diese Konzepte können von Sprache zu Sprache variieren. In JAVA ist es ein KONSTRUKTOR und GETTER bzw. SETTER METHODEN.
        Diese erlauben uns Verhalten von Klassen zu spezifizieren.
        - Konstruktor: dieser ist wie eine Methode, jedoch wird diese quasi beim Erstellen des Objektes ausgeführt.
        - getter bzw. setter: sind methoden welche für die Datenkapselung zuständig sind (dazu später).

        Aber wie lesen und schreiben wir Klassen, FELDER und Methoden und dessen Relationen?
        Siehe dazu die Erklärungen in der Klasse Hundebesitzer (ist relation) und Hund (alles andere).

        Hier schauen wir uns an wie wir Objekte aus der entsprechenden Klasse erstellen können.
        Wir verwenden dazu die gleiche Struktur wie beim Definieren von Variablen.
        diese war "<Typ> <Name> = <ausdruck>;". Konkret wäre es "int age = 5;".
        Wir fügen dieser Struktur das Wort new hinzu, wenn wir ein Objekt von einer Klasse erstellen wollen.
        Das wird mit Hundebesitzer franz = new Hundebesitzer(.5); gemacht. Der Typ ist nun Hundebesitzer und nicht mehr int
        und wir schreiben nach dem = new und danach wieder die Klasse Hundebesitzer() mit Klammern. Die Klammern bedeuten den
        Aufruf des Konstruktors und hier können dadurch auch Variablen von hier in das Objekt "reingegeben" werden.
    */

    public static void main(String[] args) {
        Hund gilbert = new Hund("Gilbert", 1, "m", 10, false);
        Hund frido = new Hund("Frido", 2, "w", 15, true);
        Hund[] hunde = {frido, gilbert};

        System.out.println(frido.getSpielFreund()); // ist null!

        gilbert.setSpielFreund(frido);
        System.out.println(gilbert.getSpielFreund());
        System.out.println(frido.getSpielFreund()); // ist nicht mehr null!

//        Wir brauchen die nächste Zeile nicht, da wir diese im Hintergrund bei setSpielFreund() bereits ausführen.
//        Wir können also nicht diese zweite Zeile vergessen und dadurch ist ein möglicher Bug weniger vorhanden.
//        frido.setSpielFreund(gilbert);

        HundeBesitzer karo = new HundeBesitzer("Karo", 1.0, 25, false, hunde.length*2);
        karo.kaufeHund(frido);
        karo.kaufeHund(gilbert);

        // wir können auch Methoden in einer Schleife z.B. ForEach aufrufen.
        // der Code und die zwei einzelnen Aufrufe der Methoden machen das gleiche.
//        for (Hund hund : hunde) {
//            karo.kaufeHund(hund);
//        }

        gilbert.spielen();
        frido.spielen();

        Mensch hatBaldHunde = new Mensch("Walo", 0.1, 51);
        System.out.println(hatBaldHunde.getClass());
        System.out.println(hatBaldHunde.hashCode());

        hatBaldHunde = hatBaldHunde.hundKaufen(gilbert, true, hunde.length*2);

        //Ist hatBaldHunde nun ein Mensch oder ein Hundebesitzer?
        System.out.println(hatBaldHunde.getClass());

        //ist es aber noch das selbe Objekt?
        System.out.println(hatBaldHunde.hashCode());
        //nein. Wir haben also das alte Objekt zerstört und ein neues geschaffen!
        // Wir können nicht einfach den Typ eines Objektes ändern und dabei noch dasselbe Objekt haben.
        // Es hat nur die gleichen Werte wie der Mensch zuvor, und nun mehr, da er/sie ein Hundebesitzer/in ist.

        karo.fuettern();
    }
}
