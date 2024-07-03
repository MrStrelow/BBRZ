package block1;

public class L01ErsteSchritte {
    // Java ist eine objektorientierte Sprache, welche dadurch am Anfang Dinge verwendet, welche wir noch nicht erklärt haben.
    // Das bedeutet wir müssen für unsere ersten Programme folgendes berücksichtigen.
    // 1) Wir müssen unser File, welches den Programmcode enthält, in einem Projekt anlegen.
    //    Dort wird der Ordner "src", was "source", also "Quelle" bedeutet von IntelliJ angelegt.
    //    Nur innerhalb dieses "src" Ordners können wir Files erstellen in denen wir programmieren können.
    // 2) Wir haben ein File angelegt. Dieses ist eine Klasse mit dem Namen "block1.ErstesProgramm".
    //    Das wird oben mit "public class block1.ErstesProgramm" gemacht. Was die orange gefärbten "public" und "class" machen ist vorerst nicht wichtig.
    //    Eine Klasse ist für uns erstmal nur eine Umgebung in die wir den Namen des Programms festhalten.
    //    In den geschwungenen Klammern wird eine neue Umgebung geschaffen in der wir weiter arbeiten können. Das gilt auch für zukünftige Programmkonstrukte.
    // 3) Wir erstellen innerhalb der neuen Umgebung, in der Klasse, eine neue Umgebung in der wir nun programmieren können.
    //    Das ist die Methode mit namen "main". Wieder was die orange gefärbten "public static void" machen wird in ein paar Monaten besprochen.
    //    Das String[] args ist so weit auch nicht essenziell. Für uns ist es ein mit dem wir weiter unten in diesem File von "der Außenwelt" Information bekommen können.
    //    Wir brauchen um programmieren anfangen zu können, eine Klasse welche beliebigen Namen hat und eine Methode welche main heißt.
    //    Diese muss GENAU so aussehen wie jene unten. Also "public static void main(String[] args)". Wird z.B. das "String[] args" gelöscht bekommen wir Fehler.

    public static void main(String[] args) {

        // Hier ist nun der Punkt, an dem wir was machen können.
        // Ein häufiges erstes Programm in einer Programmiersprache ist, "Hello World" auszugeben.
        // Das soll sicherstellen, dass die Sprache bzw. das Setup der Umgebung funktioniert.
        // Falls hier Fehler auftreten ist wahrscheinlich bei der Installation, dem Erstellen der Files
        // (z.B. nicht im "src" Ordner), etwas schiefgelaufen.

        // Programme werden von oben nach unten gelesen und führen die weiter unten geschriebenen "Befehle" vor jenen aus, welche davor stehen.

        // Hier geben wir nun etwas auf die Console aus. Das wird mit dem Befehl System.out.println(); gemacht.
        // Wieder was genau der Punkt macht, wird viel später erst erklärt. Für uns ist es einfach ein Befehl, der uns
        // erlaubt etwas auszugeben.
        // Wenn wir "Befehle" verwenden, ist immer in den runden Klammern () das reinzuschreiben, was wir dem Befehl geben wollen.
        //         In unserem Fall ist es das Wort "Hello World".
        // Tippe "sout" ein um System.out.println(); zu erhalten. Das erspart dir die vielen Worte jedes mal zu tippen.

        System.out.println("Hello World");

        // Wir wollen aber mehr als nur das machen. In Programmiersprachen gibt es, unter anderem, folgende wichtige Konstrukte
        // Variablen, Verzweigungen, block1.Operatoren und Schleifen sind hier die wichtigsten.
        // Wir gehen hier auf Variablen ein. Diese sind der Baustein von allen weiteren Konstrukten, welche wir verwenden.
        // Eine Variable ist ein Platzhalter für Werte. Anstatt also zu sagen "Hello World" können wir dieses Wort in eine Variable speichern.
        // Es ist nun zu beachten was für einen Typ die Variable hat.
        // Beispielsweise sind Typen von Variablen folgendes.
        //        - String: das sind Wörter (z.B. "Hello World").
        //        - Integer: das sind ganze Zahlen (z.B. -5 und 568)
        //        - Float: das sind Kommazahlen (z.B. -9.6 und 7.0)
        //        - Boolean: das kann den Wert wahr oder falsch annehmen.

        // Wir müssen also dem Programm irgendwie sagen können "Ich will eine Variable anlegen und diese hat den Typ String".
        // Wir machen das so.
        String meinNeuDeklarierterString;

        // Hier haben wir zuerst den Typ hingeschrieben und danach den Namen welchen wir frei festlegen können.
        // In JAVA wird ein "Befehl" mit einem Strichpunkt abgeschlossen.
        // Wir nennen die obige Eingabe "eine Variable deklarieren". Also diese anlegen, ohne einen Wert dafür festzulegen.
        // Wenn wir nun diese Variable befüllen wollen, machen wir das so.
        meinNeuDeklarierterString = "Hello";

        // Hie sprechen wir die Variable mit ihren Namen an und weisen ihr einen Wert zu.
        // Strings werden innerhalb von Anführungszeichen "" geschrieben. Wenn diese vergessen werden gibt es einen Fehler.

        // Wenn wir nun direkt eine Variable mit Wert anlegen wollen, geht das natürlich auch.
        // Wir nennen das "eine Variable definieren" und geht folgendermaßen.
        // Wir haben also das Muster zuerst Typ, dann Name und dann Wert.

        String meinNeuDefinierterString = "World";

        // Das = hier wird Zuweisungsoperator genannt. block1.Operatoren sind Befehle welche es erlauben Werte oder Variablen zu kombinieren.
        // Wir kombinieren also die leere Variable mit Namen meinNeuDefinierterString mit dem Wert "Hello World".
        // Weitere block1.Operatoren sind + - * / ++ -- && || . Wir werden diese uns aber zu einem späteren Zeitpunkt anschauen.
        // Hier ist nur wichtig, dass es nicht von Anfang an klar ist, was ein Operator macht. Das + kann zwei Zahlen addieren
        // oder auch zwei Strings miteinander kombinieren.
        // Es kommt also auf den Typ der Variable an, welche Bedeutung der Operator hat.
        // Zwei Stings kombinieren wird "concatenate" oder "konkatenieren" genannt.

        // Hier verbinden wir die Variablen miteinander und fügen dazwischen noch ein Leerzeichen ein.
        String meinKombinierterString = meinNeuDefinierterString + " " + meinNeuDeklarierterString;

        // Diese können wir nun ausgeben.
        // überall wo eine Variable akzeptiert wird, wird auch ein Wert vom gleichen Typ akzeptiert.
        System.out.println(meinKombinierterString);
    }

}
