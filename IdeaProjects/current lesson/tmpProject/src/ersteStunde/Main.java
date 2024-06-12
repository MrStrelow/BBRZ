package ersteStunde;

public class Main {
    public static void main(String[] args) {
        // main oder psvm ist der shortcut
        // System.out.println(); shortcut ist "sout"
        // CTRL + space -> Menü für Vorschläge.

        //          - String: das sind Wörter (z.B. "Hello World").
    //              - Integer: das sind ganze Zahlen (z.B. -5 und 568)
    //              - Double: das sind Kommazahlen (z.B. -9.6 und 7.0)
    //              - Boolean: das kann den Wert wahr oder falsch annehmen.

        // deklariere eine Variable
        String meinErsterString;
        Integer meinErsteInteger;
        Double meinErsterDouble;
        Boolean meinErsterBoolean;

        // initialisiere eine Variable
        meinErsterString = "du";
        meinErsteInteger = 5;

        // definiere eine Variable
        String meinZweiterSting = "hallo";
        Integer meinZweiterInteger = 10;

        // verbinde Variablen mit einem Operator
        String meinDritterString = meinErsterString + meinZweiterSting;
//        System.out.println(meinDritterString);
//
//        System.out.println(meinErsterString + " " + meinZweiterSting);
//        System.out.println(meinErsteInteger + meinZweiterInteger);

        String ausgabe = (meinErsterString + meinZweiterInteger) + meinErsteInteger;
        System.out.println( ausgabe );

        ausgabe = meinZweiterInteger + meinErsterString + (meinZweiterInteger + meinErsteInteger);
        System.out.println( ausgabe );

//        System.out.println( Math.addExact(meinErsteInteger, meinZweiterInteger) );

//        System.out.println(meinZweiterSting);
//        System.out.println(meinErsterString);

        meinErsterDouble = 7.0;

        System.out.println( meinErsteInteger / meinErsterDouble );

        System.out.println( meinZweiterInteger / meinErsteInteger);

        System.out.println( 11 / 5 );

        System.out.println( 11.0 / 5);

        System.out.println( Math.divideExact(11, 5) );

        System.out.println( 11 % 5 );

    }
}