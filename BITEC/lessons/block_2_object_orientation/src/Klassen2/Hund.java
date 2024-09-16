package Klassen2;

public class Hund {
    /*
     attribute:
     Hier definieren wir Variablen. z.B wollen wir die happiness eines Hundes in einer Kommazahl abbilden.
     Wir verwenden hier zusätzlich eine Einschränkung welche die SICHBARKEIT der Attribute definiert.
        Es gibt PUBLIC, PROTECTED und PRIVATE.
        Public erlaubt einen uneingeschränkten Zugriff von "außen". Wenn wir also ein Objekt gilbert der Klasse Hund anlegen,
        dann können wir auf ein Attribut welches als public definiert ist zugreifen, und dieses ohne Einschränkung manipulieren.
        Attribute sind deshalb IMMER private! Das bedeutet, dass eben kein Zugriff von außen möglich ist. (protected behandeln wir hier nicht)
    */

    private Double happiness;
    private Double health;
    private Integer age;

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
    private Hundebesitzer besitzer;


    /*
    konstruktor:
        Wie erwähnt ist dieser eine Methode (Erklärung siehe weiter unten), welche beim Erstellen der Klasse ausgeführt wird. Dieser "haucht" quasi das
        erste leben in ein Objekt ein. Ansonsten ist dieses "leer" und wird nur als "es existiert" angelegt.
        Wir können hier also von außen einen ersten Wert des Alters, Gesundheit, wer der Hundebesitzer ist usw. geben.

        Hier sehen wir auch ein weiteres Konzept, welches zuerst komisch erscheint. Mit THIS wird auf das eigene Objekt
        verwiesen. Bedeutet, wenn wir ein Objekt der Klasse Hund haben welche wir "gilbert" nennen,
        dann ist dieser mit gilbert ansprechbar. Bedeutet, wenn wir gilbert schreiben dann, können wir mit "." auf dessen
        methoden zugreifen und ausführen. Also gilbert.essen(); lässt "gilbert essen". Wenn wir nun in der Klasse Hund selbst sind,
        können wir auf das entsprechende Objekt mit this zugreifen. Also ein "Zugriff auf sich selbst".
        Dies ist nur notwendig, wenn ein Argument der Methode und ein Attribut der Klasse, den selben Namen haben (z.B. health).
        Ansonsten ist ein Zugriff ohne this auch möglich.
    */
    public Hund(Double happiness, Double health, Integer age, Hundebesitzer besitzer) {
        this.happiness = happiness;
        this.health = health;
        this.age = age;
        this.besitzer = besitzer;
        this.besitzer.addHund(this,0);
    }

    // methoden:
       /*
       Diese beschreiben was ein Objekt tun kann. Hier ist es fressen, bellen, usw.
       Wir können auch hier die Sichtbarkeit durch public und private steuern. Wie schreiben wir aber nun die Methoden in JAVA?
       Nach der Sichtbarkeit, ist der RÜCKGABETYP der Methode zu schreiben (int, Integer, Hund, Hund[], jeder bekannte Datentyp und eigens erstellte Klassen).
       Dieser gibt an, was nach dem Ausführen der Methode dem Aufrufer zurückgegeben wird. Wenn also z.B. in der Main-Methode
       frido.bellen() aufgerufen wird, könnten wir die Rückgabe der Methode in einer Variable mit entsprechendem Typ speichern.
       Hier wäre es Double. Also wäre es möglich Double fridosLautstaerke = frido.bellen(); zu schreiben. In der Methode selbst,
       ist mit return die Variable oder Ausdruck anzugeben welcher dann einen Double zurückgibt. Hier ist es der Ausdruck 5.8.
       Wenn keine Rückgabe erwünscht ist, ist void als Rückgabetyp anzugeben. Damit ist auch kein return notwendig.
       Ein Beispiel dafür ist die Methode fressen.
       Ein ARGUMENT einer METHODE sind Variablen/Objekte welche die Methode als "input" von außen benötigt. Von außen bedeutet,
       dass beim Aufruf der Methode, diese Variablen/Objekte anzugeben sind. Ist das nicht möglich, kann die Methode nicht verwendet werden.
       Ein Beispiel dafür ist die Methode setAge. Der Aufrufer muss also in Klammern die benötigte Variable angeben,
       z.B frido.setAge(15). Es kann auch firdo.setAge(myVariable) wobei Integer myVariable = 15; verwendet werden,
       und auch andere Methoden welche den Rückgabetyp Integer haben. Ein Beispiel dafür wäre frido.setAge(hans.getAge());
       wobei die Methode getAge() einen Rückgabetyp von Integer benötigt.
       Beim Schreiben der Methode selbst, muss wenn ein Argument anzugeben ist, dieses folgendermaßen deklariert werden.
       Wir schreiben in Klammern eine Variable/Objekt mit Typ und Namen. Ein Beispiel dafür wäre public Integer setAge(Integer age) {...}.
       Wenn wir mehrere Argumente benötigen, ist dies zu wiederholen und mit Beistrich zu trennen. z.B.
       Integer test(Integer first, Hund second) {...}. Hier ist zu beachten, dass ATTRIBUTE nicht als ARGUMENT angegeben werden müssen.
       Wir können hier innerhalb der Klasse direkt innerhalb der Methode auf diese zugreifen. Ein Beispiel dafür ist
       public Integer getAge() welche auf das Attribut age zugreift.
       */
    public void fressen() {
        System.out.println("ich fresse.");
    }

    public Double bellen() {
        System.out.println("ich belle");
        return 5.8;
    }

    public void weglaufen() {
        System.out.println(":(((((((((");
    }

    public Double getHappiness() {
        return happiness;
    }

    public void setHappiness(Double happiness) {
        this.happiness = happiness;
    }

    public Double getHealth() {
        return health;
    }

    public void setHealth(Double health) {
        this.health = health;
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }

    public Hundebesitzer getBesitzer() {
        return besitzer;
    }

    public void setBesitzer(Hundebesitzer besitzer) {
        this.besitzer = besitzer;
    }
}
