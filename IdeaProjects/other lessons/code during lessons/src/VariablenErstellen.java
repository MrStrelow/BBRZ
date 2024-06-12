public class VariablenErstellen {
    public static void main(String[] args) {

        // Variable deklarieren (keinen Wert zuweisen)
        String firstString;

        // Variable definieren (einen Wert zuweisen)
        // Wert ist fix also "Hallo".
        String myString = "Hallo";

        // Wert ist abhängig von der Variable myString (was auch immer in myString steht, steht auch in otherString)
        String otherString = myString;

        Integer myInteger = 8;

        // Wert ist abhängig von der methode .toString();
        String yetOtherString = myInteger.toString();

        // ABER ALLES sind Strings und stimmen mit dem was links vom = steht überein.


        // Typen von Variablen:
        // kleine geschrieben -> primitive Datentypen (keine Objekte), Groß geschrieben (sind Objekte).
        // - Zeichen(ketten):
        // String (StringBuilder)
        // char oder Character (ist im Hintergrund eine Zahl)
        // - Ganze Zahlen:
        // - long oder Long     (ganze Zahl -> [-2^32, +2^32],  keine Kommazahlen)
        // - int oder Integer   (ganze Zahl -> [-2^16, +2^16],  keine Kommazahlen)
        // - short oder Short   (ganze Zahl -> [-2^8,   +2^8],  keine Kommazahlen)
        // - byte oder Byte     (ganze Zahl -> [-2^4,   +2^4],  keine Kommazahlen)
        // - Kommazahlen:
        // - float oder Float   (Kommazahl, weniger genau wie Double)
        // - double oder Double (Kommazahl)
        // - logische Werte:
        // - boolean oder Boolean (hat 0 oder 1 als Wert)


        // - Zeichenketten:
        // - char und Character
        Integer userinput = 97;
//        Character output = userinput.charValue(); // gibts leider nicht.
//        Character output = new Character(userinput);
        Character output = Character.toChars(userinput)[0];

//        int userinput = 97;
//        char output = (char) userinput;

        System.out.println(output);

        Character a = 97 + 98;
        a = 'a' + 'b';
//        System.out.println(a);
//        String aa = 97;

        // - String:
        // kann man viel machen :) und ist zu viel für diesen Abschnitt hier :)
        // aber eine Sache ist wichtig!
        String string = "hallo " + "du"; // dieses + bedeutet aneinanderhängen (concatenate)
//        StringBuilder.concatenate("hallo ", "du"); // das gibts leider nicht.
        System.out.println(string);

        // - Zahlen:
        // OPERATOREN VS. METHODEN:
        // in der Praxis werden Operatoren meist bei Zahlen verwendet und methodne für alles andere.
        // In C++ oder C# können auch Operatoren "überladen" werden. Also das z.B. "+" Symbol kann für das Kombinieren von eigenen Klassen verwendet werden.
        // ASCII - Table -> gibt Nummer rein, hier 195 und gibt das Symbol an dieser Stelle aus.
        // a -> 97, b -> 98, usw.

        Integer zahl = (((97 + 98) + 82) + 16);
        Integer andereZahl = Math.addExact(97, 98);
        Integer neueZahl1 = Math.addExact(andereZahl, 82);
        Integer neueZahl2 = Math.addExact(neueZahl1, 16);

        Integer andereZahl2 = Math.addExact( Math.addExact(97, 98), 82 );

        // ein paar "Tricks"
        Integer asdf = 11;
//        Integer qwer = 3;
        Float qwer = 3.f;
        System.out.println(11./3);


        // verwende Integer und nicht int weil...
        Double kommazahl = zahl.doubleValue();

//        System.out.println(zahl);
//        System.out.println(neueZahl2);


        // logische Werte:
        Boolean wahrerWert = true;
        Boolean falscherWert = false;

        // Operatoren:
        // Zahlen: +, -, *, /, %
        // Zeichen(ketten): +
        // logische Werte: ||, &&, !, ^

        // Vergleichsoperatoren (geben immer wahr/falsch zurück):
        // >= oder <= was kommt rein:
        // int, int     -> boolean
        // int, double  -> boolean

        // != oder == was kommt rein:
        // int, int         -> boolean
        // boolean, boolean -> boolean
        // double, double   -> boolean

        // kann alles vergleichen: ==, !=

        boolean wahrheitswert1 = true;
        boolean wahrheitswert2 = false;

//        System.out.println(wahrheitswert1 || wahrheitswert2);
//        System.out.println(wahrheitswert1 && wahrheitswert2);
//        System.out.println(wahrheitswert1 == wahrheitswert2);
        System.out.println(wahrheitswert1 != wahrheitswert2);
//        System.out.println(zahl >= andereZahl);
//        System.out.println(kommazahl >= andereZahl);

        System.out.println(!wahrheitswert1);
    }
}