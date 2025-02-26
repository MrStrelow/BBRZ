package lerneinheiten.L02VariablenErstellen;

public class L02VariablenErstellen {
    public static void main(String[] args) {
        String firstString;

        String myString = "Hallo";

        String otherString = myString;

        Integer myInteger = 8;
        int myPrimitiveInteger = 8;

        myPrimitiveInteger = myInteger;
        myInteger = myPrimitiveInteger;

        String yetAnotherString = myInteger.toString();

        System.out.println(yetAnotherString);

        System.out.println(yetAnotherString.toUpperCase());

        Character userInputDecimalNumber = 97;
        Character userInputHexNumber = 0x018E;
        Character userInputChar = 'a';

        System.out.println("'" + userInputChar + "' ist das gleiche wie '" + userInputDecimalNumber + "' und auch das gleich wie '" + userInputHexNumber + "'");

        Character million = '҉';

        String tannenbaum = "🌲";
        System.out.println(tannenbaum);

        Character basicSmiley = 0x263A;
        System.out.println(basicSmiley);

        Character aPlusB = 97 + 98;
        Character AMitToupee = 195;

        System.out.println(aPlusB + " ist das gleiche Symbol wie " + AMitToupee);

        Character asdf = 'a' + 'b';
        System.out.println("ich bin hier: " + asdf);

        Integer a = 97;
        Integer b = 98;
        Integer AMitToupeeInteger = a + b;

        Character aPlusBAlsInteger = (char) (a + b);

        Character geht = 65535;
        
        Short AMitToupeeShort =  AMitToupeeInteger.shortValue();
        Character AMitToupeeCharacter = (char) (AMitToupeeShort + 0);
        AMitToupeeCharacter = (char) (AMitToupeeInteger * 1);

        System.out.println(aPlusBAlsInteger + " ist das gleiche Symbol wie " + AMitToupeeCharacter);

        Character aSehrVielAngenehmer = 'a';
        Character bSehrVielAngenehmer = 'b';

        Integer aPlusBSehrVielAngenehmer = aSehrVielAngenehmer + bSehrVielAngenehmer;
        System.out.println("Immer noch " + (char) (aPlusBSehrVielAngenehmer + 0));

        String myNewString = "hallo " + " " + "du";
        System.out.println(myNewString);

        System.out.println(new StringBuilder("hallo").append(" ").append("du").reverse());

        Byte kleinsteGanzeZahlPositive = 127;
        Byte kleinsteGanzeZahlNegative = -128;
        Byte kleinsteGanzeZahlNull = 0;

        kleinsteGanzeZahlPositive = Byte.MAX_VALUE;
        kleinsteGanzeZahlNegative = Byte.MIN_VALUE;
        Integer bitsOfByte = Byte.SIZE;

        System.out.println(kleinsteGanzeZahlPositive + " " + kleinsteGanzeZahlNegative + " " + bitsOfByte);

        Short kleineGanzeZahlPositive = 32767;
        Short kleineGanzeZahlNegative = -32768;
        Short kleineGanzeZahlNull = 0;

        kleineGanzeZahlPositive = Short.MAX_VALUE;
        kleineGanzeZahlNegative = Short.MIN_VALUE;
        Integer bitsOfShort = Short.SIZE;

        System.out.println(kleineGanzeZahlPositive + " " + kleineGanzeZahlNegative + " " + bitsOfShort);

        Integer ganzeZahlPositive = 2147483647;
        Integer ganzeZahlNegative = -2147483648;
        Integer ganzeZahlNull = 0;

        ganzeZahlPositive = Integer.MAX_VALUE;
        ganzeZahlNegative = Integer.MIN_VALUE;
        Integer bitsOfInteger = Integer.SIZE;

        System.out.println(ganzeZahlPositive + " " + ganzeZahlNegative + " " + bitsOfInteger);

        Long grosseGanzeZahlPositive = 9223372036854775807L;
        Long grosseGanzeZahlNegative = -9223372036854775808L;
        Integer grosseGanzeZahlNull = 0;

        grosseGanzeZahlPositive = Long.MAX_VALUE;
        grosseGanzeZahlNegative = Long.MIN_VALUE;
        Integer bitsOflong = Long.SIZE;

        System.out.println(grosseGanzeZahlPositive + " " + grosseGanzeZahlNegative + " " + bitsOflong);

        Float myFirstFloat = 0.25F;
        System.out.println(myFirstFloat);

        Float myStrngeAndBigFloat = 182255459184527355549958849981255210445.0F;
//        Long tooLongforLong = 182255459184527355549958849981255210445L;

        System.out.println(myStrngeAndBigFloat);

        Double myFirstDouble = 0.25;
        System.out.println(myFirstDouble);

        Double myStrngeAndBigDouble = 18225545918452735554995884998125521044555555555555555555544444444444481521515.0;
        System.out.println(myStrngeAndBigDouble);

        Double doubleA = 0.1;     // nicht genau darstellbar   - ?
//        Double doubleA = 0.2;     // nicht genau darstellbar   - ?
//        Double doubleA = 0.5;     // genau darstellbar       - summe genau darstellbar
//        Double doubleA = 0.4;     // nicht genau darstellbar - summe genau darstellbar
//        Double doubleA = 0.0;     // genau darstellbar       - summe genau GENUG darstellbar

        Double doubleB = 0.2;     // nicht genau darstellbar   - ?
//        Double doubleB = 0.2;     // nicht genau darstellbar   - ?
//        Double doubleB = 0.25;    // genau darstellbar       - summe genau darstellbar
//        Double doubleB = 0.35;    // nicht genau darstellbar - summe genau darstellbar
//        Double doubleB = 0.3;     // nicht genau darstellbar - summe genau GENUG darstellbar

        Double sum = doubleA + doubleB;
        System.out.println("a: " + doubleA);
        System.out.println("b: " + doubleB);
        System.out.println("Sum: " + sum);

        Double x = 1e6;
        Double epsilon = 1e-10;

        // Adding epsilon to x in a loop
        for (int i = 0; i < 10; i++) {
            x = x + epsilon;
        }

        System.out.println(x);

        System.out.println(x == 1000000.000000001);

        Boolean myFirstBoolean = true;
        myFirstBoolean = false;
    }
}