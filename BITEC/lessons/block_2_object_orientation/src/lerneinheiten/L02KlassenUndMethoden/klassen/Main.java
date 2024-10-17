package lerneinheiten.L02KlassenUndMethoden.klassen;

public class Main {

    /*
    Die Überlegungen aus den UML-Klassendiagramm werden wir nun in JAVA lerneinheiten.L02KlassenUndMethoden.Klassen übersetzen.
    Wir haben uns dort folgendes überlegt:
        - Wir wollen Menschen welche Hunde halten modellieren.
            Wir verwenden dazu 3 Konzepte:
                1) Welche "Dinge" gibt es in unserer "Welt"?                        (was gibt es? HAUPTWORT/NOMEN)
                2) Was macht ein "Ding" aus und was ist dessen "Zustand"?           (was hat es? was macht es aus? HAUPTWORT/NOMEN)
                3) Was ein "Ding" mit seiner "Umwelt" tun?                          (was kann es tun? ZEITWORT/VERB)
                4) In welcher Art interagieren diese "Dinge" mit anderen "Dingen"?  (<hat> und <ist>)
            1) bezeichnen wir als KLASSE, 2) als die ATTRIBUTE einer KLASSE, 3) als METHODEN einer KLASSE und
            4) die BEZIEHUNGEN zwischen KLASSEN.
        Wir versuchen nun unsere Überlegungen in ein Diagramm zu fassen (Siehe UML Tafelbild).
        Daraus sind folgende lerneinheiten.L02KlassenUndMethoden.Klassen, Attribute, Methoden und Beziehungen entstanden:
            - lerneinheiten.L02KlassenUndMethoden.Klassen:
                Hund:
                    - Attribute: happiness, health, age
                    - Beziehungen:
                        - <hat>: einen Hundebesitzer
                        - <ist>:
                    - Methoden: fressen, bellen, weglaufen
                Hundebesitzer:
                    - Attribute: happiness,
                    - Beziehungen:
                        - <hat>: einen oder mehrere Hunde
                        - <ist>: ein Mensch
                    - Methoden: gassi gehen, Hunde fuettern, Hunde vernachlaessigen
                Mensch:
                - Attribute: age, health
                    - Beziehungen:
                        - <hat>:
                        - <ist>:
                    - Methoden:

        Wir haben nun unsere "Welt" modelliert, jedoch müssen wir bevor wir uns mit JAVA beschäftigen noch klären, was
        OBJEKTE sind. Ein Objekt (oder INSTANZ) einer Klasse, ist die Instanziierung dieser. Die Klasse ist als Bauplan, was ein Hund ist
        oder als "DNA" zu sehen. Wir definieren dort was ein z.B. Hund überhaupt ausmacht und wie er mit seiner Umwelt interagiert.
        Das Objekt ist nun der "echte" Hund. Dieser hat nun nicht nur ein Alter, sonder wir wissen,  dass das Alter vom Objekt
        Gilbert 5 Jahre ist. Wir können beliebig viele Objekte von lerneinheiten.L02KlassenUndMethoden.Klassen erzeugen. Wir können also Hunde erzeugen welche nun
        der Gilbert, Franz und Susi ist. Alles sind Hunde, jedoch sind sie verschieden alt, haben verschiedene Besitzer usw.
        All das folgt den Spielregeln der definierten Klasse. Also ein Objekt Gilbert von Typ Hund kann nicht aufs Klo gehen,
        wenn das nicht in der Klasse vorgesehen ist.

        Wenn wir nun diese Ideen in JAVA schreiben wollen, brauchen wir noch zusätzliche, für die Sprache selbst wichtige Konzepte.
        Diese Konzepte können von Sprache zu Sprache variieren. In JAVA ist es ein KONSTRUKTOR und GETTER bzw. SETTER METHODEN.
        Diese erlauben uns Verhalten von lerneinheiten.L02KlassenUndMethoden.Klassen zu spezifizieren.
        - Konstruktor: dieser ist wie eine Methode, jedoch wird diese quasi beim Erstellen des Objektes ausgeführt.
        - getter bzw. setter: sind methoden welche für die Datenkapselung zuständig sind (dazu später).

        Aber wie lesen und schreiben wir lerneinheiten.L02KlassenUndMethoden.Klassen, Attribute und Methoden und dessen Relationen?
        Siehe dazu die Erklärungen in der Klasse Hundebesitzer (ist relation) und Hund (alles andere).

        Hier schauen wir uns an wie wir Objekte aus der entsprechenden Klasse erstellen können.
        Wir verwenden dazu die gleiche Struktur wie beim Definieren von Variablen.
        diese war <Typ> <Name> = <ausdruck>;. Konkret wäre es int age = 5;.
        Wir fügen dieser Struktur das Wort new hinzu, wenn wir ein Objekt von einer Klasse erstellen wollen.
        Das wird mit Hundebesitzer franz = new Hundebesitzer(.5); gemacht. Der Typ ist nun Hundebesitzer und nicht mehr int
        und wir schreiben nach dem = new und danach wieder die Klasse Hundebesitzer() mit Klammern. Die Klammern bedeuten den
        Aufruf des Konstruktors und hier können dadurch auch Variablen von hier in das Objekt "reingegeben" werden.
    */

    public static void main(String[] args) {
        Hundebesitzer franz = new Hundebesitzer(.5);
        Hund frido = new Hund(5.,10., 1, franz);
//        Hund frado = new Hund(5.,10.,2, franz);
//        Hund[] hundeVonFranz = {frido,frado};
//        franz.setHunde(hundeVonFranz);

        System.out.println(frido.getBesitzer());
        System.out.println(franz);
        System.out.println(franz.getHunde()[0]);
//        System.out.println(franz.getHunde()[1]);
        System.out.println(frido);
//        System.out.println(frado);
        Double luatstaerke = frido.bellen();
//        System.out.println(franz.hund);
//        frido.weglaufen();
//        System.out.println(franz.hund);


    }
}

//    Integer summe = franz.addReturnNumbers(6,6);
//
//
//        franz.addNumbers(summe, 8);
