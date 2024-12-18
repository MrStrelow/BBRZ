package lerneinheiten.L02KlassenUndMethoden.grundlagen;

public class Hund {
    /*
     Felder:
     Hier definieren wir Variablen, welche den Zustand des Hundes abbilden sollen.
     Beispielsweise wollen wir die happiness eines Hundes in einer Kommazahl abbilden.
     Wir verwenden hier zusätzlich eine Einschränkung welche die SICHTBARKEIT der FELDER definiert.
        Es gibt PUBLIC, PROTECTED und PRIVATE.

        PUBLIC erlaubt einen uneingeschränkten Zugriff von "außen". Wenn wir also ein Objekt gilbert der Klasse Hund anlegen,
        dann können wir auf ein FELD welches als public definiert ist zugreifen, und dieses ohne Einschränkung manipulieren.
        Der Hund könnt also auf ein Alter von -245 gesetzt werden.
        FELDER sind deshalb IMMER PRIVATE! Kein Zugriff ist damit von außen möglich.

        PROTECTED erlaubt Zugriffe, welche innerhalb der IST-Beziehung stattfinden.
        Der Schaefer hat somit einen Zugriff auf protected Felder/Methoden welche im Hund angelegt werden.

        Es ist aber nicht zielführend zwischen zwei Extremen (gar keine, oder nur Zugriffe ohne Einschränkung)
        entscheiden zu müssen. Wir werden weiter unten sehen wie wir es umsetzen werden (get und set methoden).
    */

    private String name;
    private int alter;
    private String geschlecht;
    private boolean chipped;
    private double health;

    // hat - beziehungen:
    /*
    Wir haben in UML eine <hat> Beziehung zwischen Hund und Hundebesitzer angegeben. Bedeutet wir wollen zum Ausdruck bringen,
    dass ein Hundebesitzer einen Hund hat und ein Hund einen Hundebesitzer hat. Diese Beziehung ist qualitativ.
    Bedeutet wir sagen, dass es so ist. Wenn wir diese Beziehung nun quantitativ (mit Zahlen belegen), machen wollen
    können wir das durch die KARDINALITÄT ausdrücken. Wir haben das bereits getan, da wir "ein Hundebesitzer hat EINEN Hund" geschrieben haben.
    Es könnte auch "ein Hundebesitzer hat EINEN ODER MEHRERE Hunde" bzw. "ein Hundebesitzer hat KEINEN ODER MEHRERE Hunde".
    Wir unterscheiden zwischen folgenden Kardinalitäten der <hat> Beziehung:
        - 1 zu 1: ein Hundebesitzer hat einen Hund und ein Hund hat einen Hundebesitzer.
        - 1 zu n: ein Hundebesitzer hat mehrere Hunde ABER ein hund hat einen Hundebesitzer.
            - hier gibt es noch Verfeinerungen, denn wir können zudem sagen:
                1 zu 1-n:
                    dass ZUMINDEST ein Hund einem Hundebesitzer zugewiesen wird.
                    Also "ein Hundebesitzer hat EINEN ODER MEHRERE Hunde".
                1 zu 0-n:
                    dass ZUMINDEST kein Hund einem Hundebesitzer zugewiesen wird.
                    Also "ein Hundebesitzer hat KEINEN ODER MEHRERE Hunde".
        - n zu m: ein Hundebesitzer hat mehrere Hunde und ein Hund hat mehrere Hundebesitzer.

    Diese wird in JAVA wie zuvor bei den Attributen durch Deklaration von Variablen umgesetzt.
    Der Unterschied ist nur konzeptionell und soll zudem im UML-Diagramm durch Pfeile leichter lesbar sein.
    Hier in JAVA ist der Unterschied, dass eigens erstellte Klassen eben als <hat> Relation dargestellt sind, ansonsten
    durch Attribute, wenn diese vordefiniert sind (z.B. Double, InputStream, usw.).
     */
    private HundeBesitzer besitzer;
    private Hund spielFreund;

    // Die wird behuetet Beziehung wird hier nicht angegeben, da wir nur in eine Richtung diese uns merken. Siehe UML-Diagramm.

    /*
    Konstruktor:
        Wie erwähnt ist dieser eine Methode (Erklärung siehe weiter unten), welche beim Erstellen der Klasse ausgeführt wird.
        Wenn wir "new Hund();" schreiben führen wir diesen Konstruktor also aus.
        Dieser "haucht" quasi das erste leben in ein Objekt ein.
        Ansonsten sind dessen FELDER "leer" und besitzen den Wert null.
        Wir können hier also von außen einen ersten Wert des Alters, Gesundheit, wer der Hundebesitzer ist usw. geben.
        Wir tun das mit "new Hund(35)"; wenn der Hund nur ein FELD "alter" besitzt.

        Wir sehen, dass wir mehrere Konstruktoren anlegen können. Wie bei Methoden können wir den gleichen Namen verwenden,
        aber andere Parameter bzw. Rückgabetypen. Da es keine Rückgabetypen bei einem Konstruktor gibt, können wir die Parameter ändern
        und damit mehrere Konstruktoren definieren.
        (wir können uns auch vorstellen die Klasse selbst ist der Rückgabetyp des Konstruktors).

        Wir können z.B. einen Konstruktor verwenden um einen besitzerlosen Hund und einen besessenen Hund zu erstellen.
        Auch werden wir später sehen (hemstr Projekt), dass wir ein Objekt übergeben können und dessen Inhalt (FELDER) wir
        in unser zu erstellendes Objekt übernehmen (Copy Konstruktor - besonders für tiefe Kopien!).
    */

    public Hund(String name, int alter, String geschlecht, double health, boolean chipped) {
        this.name = name;
        this.alter = alter;
        this.geschlecht = geschlecht;
        this.health = health;
        this.chipped = chipped;
        // Hier ist spielpartner und Besitzer null! Das ist erlaubt, da wir im UML diagramm die Kardinalität 0-1 haben.
        // Falls hier exakt 1 steht, dürfte ein solcher Konstruktor nicht existieren!
    }

/*
    Hier sehen wir auch ein weiteres Konzept, welches zuerst komisch erscheint. Mit THIS wird auf das eigene Objekt
    verwiesen. Bedeutet, wenn wir außerhalb z.B. in der main Methode, ein Objekt der Klasse Hund erzeugen
    welche wir "gilbert" nennen, dann ist dieses mit gilbert im Programmcode ansprechbar.
    Wenn wir gilbert schreiben dann, können wir mit "." auf dessen methoden zugreifen und ausführen.
    Also gilbert.essen(); lässt "gilbert essen".
    Was aber wenn wir gilbert.essen(); lassen gleichzeitig den Gesundheitszustand von "gilbert" anpassen wollen.
    Wir haben dazu eine Methode, "metabolism();" in der Klasse Hund geschrieben.
    Wenn wir innerhalb von der Methode essen(), die Methode metabolism() aufrufen wollen,
    müssten wir doch das Objekt kennen, für welches wir diese Methode aufrufen.
    Wir haben aber kein Objekt "gilbert" welches uns zur Verfügung steht.
    Wenn wir nun "this.metabolism();" innerhalb der Klasse Hund schreiben, drücken wir damit aus,
        "welches Objekt auch immer aus der Klasse abgeleitet wird, ich spreche dieses an". Also ein "Zugriff auf sich selbst".
    Wir können aber meistens auf das "this" verzichten, und JAVA versteht es trotzdem. Wir können "metabolism()"
    anstatt "this.metabolism();" in der Methode "essen()" schreiben und es funktioniert.

    Wann brauchen wir aber "this" zwingend?
    - Wenn wir uns aber den Konstruktor anschauen ist es notwendig, wenn ein Argument der Methode und ein Feld der Klasse,
    denselben Namen haben (z.B. alter = alter funktioniert nicht. Wir müssen unterscheiden.).
    - Wenn wir das objekt selbst einer anderen Klasse weitergeben wollen. z.B. wir geben den Hund dem Hundebesitzer,
    damit dieser sich diesen merken kann. Das geschieht mit "this.besitzer.addHund(this);".
    Ebenso mit "this.spielFreund.setSpielFreund(this);"
*/
    public Hund(String name, Integer alter, String geschlecht, Double health, boolean chipped, HundeBesitzer besitzer) {
        // wir rufen hier mit this den oben definierten Konstruktor auf! Wir verhindern dadurch unnötigen doppelten Code.
        this(name, alter, geschlecht, health, chipped);
        this.besitzer = besitzer;
        this.besitzer.addHund(this);
    }

    public Hund(String name, Integer alter, String geschlecht, Double health, boolean chipped, Hund spielFreund) {
        this(name, alter, geschlecht, health, chipped);
        this.spielFreund = spielFreund;

        this.spielFreund.setSpielFreund(this);
    }

    public Hund(String name, Integer alter, String geschlecht, Double health, boolean chipped, HundeBesitzer besitzer, Hund spielFreund) {
        this(name, alter, geschlecht, health, chipped);
        this.besitzer = besitzer;
        this.spielFreund = spielFreund;

        this.besitzer.addHund(this);
        this.spielFreund.setSpielFreund(this);
    }

    // Methoden:
       /*
       Diese beschreiben was ein Objekt tun kann. Hier ist es fressen, bellen, usw.
       Methoden sind syntaktisch gleich wie die bereits besprochenen Funktionen.
       Wir koppeln Funktionen nun an eine Klasse und nennen diese dann Methoden.
       Wir können dadurch die Sichtbarkeit durch public und private steuern.

       Wie schreiben wir Methoden in JAVA?
       Nach der Sichtbarkeit, ist der RÜCKGABETYP der Methode zu schreiben
       (int, Integer, Hund, Hund[], jeder bekannte Datentyp und eigens erstellte Klassen).
       Dieser gibt an, was nach dem Ausführen der Methode dem Aufrufer zurückgegeben wird. Wenn also z.B. in der Main-Methode
       frido.bellen() aufgerufen wird, könnten wir die Rückgabe der Methode in einer Variable mit entsprechendem Typ speichern.
       Hier wäre es String. Also wäre es möglich "String fridosGeräusch = frido.bellen();" in der Main methode zu schreiben.
       In der Methode selbst, ist mit return die Variable oder Ausdruck anzugeben welcher einen String zurückgibt.
       Wenn keine Rückgabe erwünscht ist, ist void als Rückgabetyp anzugeben. Damit ist auch kein return notwendig.
       Ein Beispiel dafür ist die Methode fressen.

       Ein ARGUMENT/PARAMETER einer METHODE sind Variablen/Objekte welche die Methode als "input" von außen benötigt.
       Von außen bedeutet, dass beim Aufruf der Methode, diese Variablen/Objekte anzugeben sind.
       Ist das nicht möglich, kann die Methode nicht verwendet werden. Ein Beispiel dafür ist die Methode setAge.
       Der Aufrufer muss also in Klammern die benötigte Variable angeben, z.B frido.setAge(15).
       Es kann auch "firdo.setAge(myVariable);" wobei Integer "myVariable = 15;" verwendet werden,
       und auch andere Methoden welche den Rückgabetyp Integer haben.
       Ein Beispiel dafür wäre "frido.setAge(hans.getAge());" wobei die Methode getAge() einen Rückgabetyp von Integer benötigt.

       Beim Schreiben der Methode selbst (erstellen der Methodensignatur) muss, wenn ein Parameter anzugeben ist,
       dieses folgendermaßen deklariert werden. Wir schreiben in Klammern eine Variable/Objekt mit Typ und Namen.
       Ein Beispiel dafür wäre "public Integer setAge(Integer age) {...}."
       Wenn wir mehrere Parameter benötigen, ist dies zu wiederholen und mit Beistrich zu trennen. z.B.
       "Integer test(Integer first, Hund second) {...}".

       Hier ist zu beachten, dass FELDER nicht als PARAMETER angegeben werden müssen.
       Wir können hier innerhalb der Klasse direkt innerhalb der Methode auf diese zugreifen. Ein Beispiel dafür ist
       public Integer getAge() welche auf das FELD age zugreift.
       */

    public void fressen(Essen essen) {
        System.out.println(name + " frisst " + essen.name());
    }
    /*
        Hier ist ein Konzept, welches einfach aber dennoch neu ist. Es heißt ENUM.
        Ein solches stellt einen eingeschränkten String dar. Ein String kann viele Werte haben,
        wovon nur ein paar für uns relevant sind, wenn wir z.B. Essen oder ein Geschlecht codieren wollen.
        Ein Enum ist deshalb ein String welcher z.B. nur die Werte FLEISCH, NASSFUTTER, TROCKENFUTTER, BROCCOLI annehmen kann.
    */

    public void spielen() {
        System.out.println("Mein Spielfreund: " + spielFreund.name + " spielt mit mir!: " + this.name + " unter der strengen aufsicht von: " + besitzer.getName());
    }

    public String bellen() {
        System.out.println(this.name + " bellt!");
        return "Geräusch eines Hundes.";
    }

    /*
    Entfernen von Beziehungen:
    Wir können uns Beziehungen als Pfeile vorstellen welche, Hund und Hundebesitzer miteinander verbinden.
    Wir haben dadurch auf der Klassenebene folgende Relation: "Ein Hund hat einen Besitzer".
    Diese Verbindung ist dadurch auch auf der Objektebene gegeben.
    Wir stellen uns vor, das Objekt "gilbert" ist einer Hat-beziehung mit "karo". Kürzer gesagt, "gilbert zeigt auf karo".
    Wir können "gilbert auf null" zeigen lassen, um die Referenz auf der Objektebene zu löschen.
    Das entspricht "besitzer = null".
    Um auch den Besitzer klarzumachen, dass dieser keinen Hund mehr besitzt, müssen wir auch "karo zeigt auf gilbert"
    löschen. Das entspricht "besitzer.entferneHund(this);" Wir müssen nämlich, zuerst die Beziehung zwischen "karo" und
    "gilbert" im Array finden, um diese löschen zu können. Dazu brauchen wir das Objekt des Hundes.
    Dieses ist mit this ansprechbar.
     */

    public void weglaufen() {
        System.out.println(this.name + " ist von " + this.besitzer + " weggelaufen...");
        besitzer.aussetzen(this);
        besitzer = null;
    }

    // get und set Methoden.
    /*
        Hier sind spezielle Methoden, welche die Zugriffe auf FELDER regeln sollen.
        Es gibt also maximal zu jedem FELD eine get und eine set Methode. Falls z.B. die Set-Methode fehlt,
        ist es nicht mehr möglich das Feld nach dem Erstellen (Aufruf des Konstruktors) zu verändern.
        Wir können hier auf name zugreifen, obwohl es privat ist. Denn innerhalb der Klasse ist ein Zugriff erlaubt.
        Mit einer public Methode ist nun der Zugriff nach außen wieder möglich. Der Unterschied ist, dass ich z.B.
        beim Setzen des Feldes "alter" eine in der "setAlter()"-methode Abfragen implementieren kann, bevor diese durchgeführt wird.
        z.B. wenn eine Relation die Kardinalität 1 hat, dann darf ich nicht mit der entsprechenden "set-methode" diese auf null setzen.
        Wir können das verhindern, indem wir "if(argument != null) { feld = argument}" schreiben.
     */
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAlter() {
        return alter;
    }

    public void setAlter(int alter) {
        this.alter = alter;
    }

    public String getGeschlecht() {
        return geschlecht;
    }

    public void setGeschlecht(String geschlecht) {
        this.geschlecht = geschlecht;
    }

    public boolean isChipped() {
        return chipped;
    }

    public void setChipped(boolean chipped) {
        this.chipped = chipped;
    }

    public double getHealth() {
        return health;
    }

    public void setHealth(double health) {
        this.health = health;
    }

    public HundeBesitzer getBesitzer() {
        return besitzer;
    }

    /*
    Sicherstellung der Kardinalitäten bei bidirektionalen Beziehungen
    (Achtung! Das ist mehr eine Denkübung als direkt anwendbar!
    In der Praxis werden oft unidirektionale Beziehungen verwendet. Diese sind leichter handhabbar.):

    Bei bidirektional Beziehungen wir haben prinzipiell zwei Probleme:
    - was meinen wir mit "ein Hund hat einen Besitzer" und "ein Besitzer hat einen Hund"? Meinen wir eine gegenseitige
    (mutual) Beziehung? Bedeutet jener Hund, welcher auf den Besitzer zeigt, zwingt den Besitzer dazu auch
    auf genau diesen Hund zu zeigen. Oder kann ein Hund auf irgendeinen Besitzer zeigen und ein ganz anderer Besitzer auf den Hund?
    Wir meinen hier die 1. Auslegung. In UML kann nicht zwischen diesen Varianten unterschieden werden.
    - Es muss nun sichergestellt werden (durch die bidirektionale 1 zu 1 Beziehung zwischen Hund und Besitzer),
    dass nicht ein neuer Hundebesitzer "fritz" auf "gilbert" zeigen kann, während "karo" noch auf diesen zeigt.
    Wir brauchen dadurch einen kontrollierten Zugriff auf "gilbert" und "karo".
    Am besten tun wir das mit Abfragen in der set-methode "setBesitzer(HundeBesitzer besitzer) {...}".
    Da diese der einzige Punkt ist, wo Änderungen an dem Besitzer vorgenommen werden können, scheint es sinnvoll dort
    die Logic der Zugriffe zu implementieren.
    Weiters kann dann diese set-methode in anderen Methoden ohne zusätzliche Abfragen verwendet werde um zu verhindern,
    dass einfach ein neuer Besitzer dem Hund mit verändert werden kann. Das Gleiche gilt auch für "addHunde(Hund hund) {...}"
    in der Klasse Hundebesitzer.
    Um eine Beziehung auflösen zu können, lassen wir dem Hund und dem Besitzer die Möglichkeit, diese Beziehung mit der Methode
    weglaufen() und verkaufen() zu beenden.

    Folgende Skizze soll eine fehlerhafte Beziehung von einem Hund "gilbert" und zwei Besitzern darstellen:
        + bidirectional (Hund und Besitzer wissen voneinander):
                  /<---wird besessen---\         /---wird besessen--->\
            (karo)                      (gilbert)                      (fritz)
                  \------besitzt------>/         \<------besitzt------/

        Wir müssen daher bevor ein solches Konstrukt entsteht bei der Zuweisung des Hundes im Besitzer folgendes abfragen:
        "if (neuerHund.getBesitzer() == null && !hundBereitsBesessen) {... Zuweisung geht ...}"
        "else {... Warnung! Zuweisung verboten ...}

        Hinweis! Denke an Guard Clauses! Diese können hier auch verwendet werden, falls mehrere Bedingungen verwendet werden.

        + unidirectional (Hund weiß nichts von seinem Besitzer. Kann nicht auf diesen zugreifen.):
            Wir können auch hier nicht zusichern, dass gilbert nicht von mehreren Besitzern besessen wird.
            Es fehlt die Kardinalität der "wird besessen" Beziehung und zu dem Fehlt die Beziehung "wird besessen".
            Deshalb ist
            (karo)------besitzt------>(gilbert)<------besitzt------(fritz)
    */

    public Hund getSpielFreund() {
        return spielFreund;
    }

    public void setBesitzer(HundeBesitzer besitzer) {
        if (this.besitzer == null && !besitzer.besitztHund(this)) {
            this.besitzer = besitzer;
            besitzer.addHund(this);

        } else {
            System.out.println("Zuweisung verboten! " + this.getName() + "ist bereits besessen.");
        }
    }

    //    Die Mutual Bedingung gilt auch für die spielFreund-Beziehung.
    //    Auch hat der Hund die "Kompetenz" diese zu verwalten (im Gegensatz zur Beziehung besitzen)
    //    Wir werden hier jedoch nicht einen neuen Namen für die set-Methode finden.
    //    Wer mag, kann diese Methodeauch "befreundet" nennen.
    public void setSpielFreund(Hund spielFreund) {
        this.spielFreund = spielFreund;

        // Achtung! wenn wir hier nicht diese Abfrage haben, werden wir ewig im Kreis laufen!
        // Diese hilft uns, da wir bei einem wiederholten aufrufen von setSpielFreund innerhalb von setSpielfreund
        // immer wieder das gleiche Objekt als Spielfreund zuweisen. Diesen Punkt können wir abfragen und dadurch abbrechen.
        if (spielFreund.spielFreund != this) {
            spielFreund.setSpielFreund(this);
        }
    }
}
