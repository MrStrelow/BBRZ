package lerneinheiten.L12Funktionen;

public class L12Funktionen {
    // Bis jetzt haben wir unsere 4 Konzepte (Variablen, Operatoren, Verzweigungen und Schleifen) verwendet,
    // um Probleme beim Programmieren zu lösen.
    // Diese Vorgehensweise hat einen Namen. Iteratives Programmieren.
    // Im prinzip brauchen wir nicht mehr um Probleme lösen zu können, jedoch ist uns es jetzt ein Anliegen
    // Programmcode für uns Menschen besser lesbar zu machen.
    // Wenn wir nun Funktionen als Konzept unsren bestehenden 4 Konzepten hinzufügen,
    // bekommt unser Programmierstil einen neuen Namen.
    // Prozedurales Programmieren.
    // Dabei fokussieren wir uns auf die Zerlegung in eines großen Problems in Teilprobleme.
    // Diese Zerlegung benötigt ein Werkzeug und dieses sind die bereits erwähnten Funktionen.
    // Wir sehen diese Funktionen zuerst als "Blackbox". Hier werden Variablen übergeben welche in dieser Blackbox
    // verarbeitet werden. Das Ergebnis dieser Verarbeitung wird dem aufrufer der Funktion wieder zurückgegeben.
    // Funktionen sind nun folgendermaßen in JAVA aufgebaut:
    // - Parameter kommen rein,
    // - Ergebnisse werden mit return dem Aufrufer der Funktion zurückgegeben.
    // - ein name der Funktion muss vergeben werden. Mit diesem rufen wir diese auf (wie der Name bei Variablen).
    // Das Wort static ignorieren wir hier! Wir schreiben es einfach dazu,
    // ohne nachzudenken, was es bedeutet (siehe Objektorientierung)
    static String nameMeinerFunktion(String ersterParameter, String zweiterParameter, int dritterParameter) {
        int a = dritterParameter + 5;
        String ret = ersterParameter + zweiterParameter + " hier kann ich wie gewohnt Programmieren [" + a + "]";

        return(ret);
    }

    // Wenn wir nun diese Funktion aufrufen wollen, müssen wir folgendes tun:
    public static void main(String[] args) {
        // wir schreiben den Namen der Funktion und geben die zu übergebenen Argumente in die runde Klammer
        // nach dem Namen der Funktion.
        // Was können wir alles der Funktion übergeben? Es wird in der Methodensignatur, welche
        // "String nameMeinerFunktion(String ersterParameter, String zweiterParameter)" ist,
        // der Typ der Parameter vorgegeben. Diese sind hier zwei Variablen vom Typ String.

        // Wir können nun alle was einen String erzeugt hier reinschreiben.
        // Wert:
        //(Hinweis, wenn Werte übergeben werden, schreibt Intellij den Namen der Parameter hin.
        // Das hat aber nichts mit JAVA zu tun, sondern ist von Intellij eine "Nettigkeit").
        nameMeinerFunktion("Das ist ein Wert", "und das auch", 101);

        // Variable:
        String meinErstesArgument = "das ist eine Variable";
        String meinZweitesArument = "und das auch";
        int meinDrittesArgument = 1;
        // Achtung! Ein Detail der Bezeichnung.
        // Wir nennen innerhalb der Methode die übergebenen Variablen, Parameter.
        // Wir nennen außerhalb (beim Aufrufer) der Methode diese jedoch, Argumente.
        // Der Wert der Variable mein meinErstesArgument,
        // wird nun übergeben und in dem Parameter meinErsterParameter gespeichert.
        // Wir sprechen also von Argumenten außerhalb der Methode und sprechen von Parametern innerhalb dieser.
        // Dies ist jedoch ein ähnliches Detail, wie die Bedingte Anweisung, nur IF ist und eine IF-Verzweigung ein IF-Else ist.
        nameMeinerFunktion(meinErstesArgument, meinZweitesArument, meinDrittesArgument);

        // Mischung durch Operatoren:
        // Wenn die Zeile dadurch zu lang wird, können wir den Aufruf auch in mehreren Zeilen aufteilen.
        nameMeinerFunktion(
                meinZweitesArument + " mit einem Wert",
                meinZweitesArument + meinErstesArgument,
                10
        );

        // So übergeben wir Variablen (und Co.) einer Funktion für die Weiterverarbeitung.
        // Wie bekommen wir aber das Ergebnis zurück?
        String ergebnis = nameMeinerFunktion("best", "test", 1337);

        // Wir speichern die Rückgabe der Funktion in die Variable ergebnis.
        // Diese können wir nach Belieben weiterverwenden.

        // Wir haben aber auch einen Sonderfall, falls keine Rückgabe erwartet wird.
        // Dazu schauen wir uns folgende Funktion außerhalb der Main Methode an.
        // Wir sehen auch nun, dass wir innerhalb einer Funktion keine Funktion definieren können.
        // Tipp: Drücke STRG+click_auf_den_namen_der_funktion, dann kommst du zu der Definition der Methode.
        nameMeinerFunktionOhneRueckgabewert(meinErstesArgument);

        // folgendes würde nun nicht funktionieren und einen Fehler erzeugen.
        // String wasSollteHierReinkommen = nameMeinerFunktionOhneRueckgabewert(meinErstesArgument);

        // Auch können wir eine Funktion ohne Parameter/Argumenten schreiben
        nameMeinerFunktionOhneRueckgabewertUndArgumente();

        // Nur erwähnt aber nicht ausprogrammiert! Werden wir in JET machen.
        // Weiterführend ist noch auf folgendes einzugehen. Was passiert beim Übergang von Argument zu Parameter?
        // Wird das Argument in den Parameter kopiert und sind zwei gleiche, aber nicht dieselben Variablen?
        // Das bedeutet, wenn ich die Variable "a" als Argument übergebe und ich in der Funktion den Parameter "par",
        // welcher eine Kopie des Wertes der Variable "a=5" ist, manipuliere, z.B. "par = 10;", was passiert mit a?
        // - Bei Call by Value wird a = 5
        // - Bei Call by Reference wird a = 10

        // In JAVA haben wir Call by value, bedeutet wir kopieren immer die Argumente in die Parameter rein.
        // ABER! Wenn es kompliziertere Variablen sind, wie z.B. ein Array, dann wird eine Kopie der Referenz übergeben.
        // Eine Referenz ist die "Adresse" (wie die eines Menschen/Wohnung), mit der wir die Werte einer Variable
        // im "Speicher" finden. Das bedeutet, wenn wir eine Kopie der Adresse bekommen, haben wir ein (fast) gleiches
        // Verhalten wie bei Call by Reference. Es passiert, dass Änderungen eines Parameters der Methode,
        // Auswirkung auf die übergebenen Argumente haben.
        // Heißt, es wird die übergebene Variable auch außerhalb der Funktion manipuliert.
        // Das kann (und wird) zu Bugs führen und ist deshalb wichtig zu wissen.
        // Wir werden aber nicht näher darauf eingehen, da wir endlich zur Objektorientierung wollen.
        // Dieses Verhalten wird in JET behandelt.
    }

    static void nameMeinerFunktionOhneRueckgabewert(String parameter) {
        System.out.println("keine Rückgabe");
    }

    static void nameMeinerFunktionOhneRueckgabewertUndArgumente() {
        System.out.println("keine Argumente/Parameter und keine Rückgabe");
    }
}
