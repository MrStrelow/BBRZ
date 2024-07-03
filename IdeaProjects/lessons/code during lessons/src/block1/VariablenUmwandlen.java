package block1;

import java.math.RoundingMode;
import java.text.DecimalFormat;

public class VariablenUmwandlen {
    public static void main(String[] args) {
        /*
        Wenn (ANMERKUNG) neben einer Zeile steht, dann ist hier eine Kleinigkeit, welche praktisch sein kann,
        aber fuers prinzipielle Verstaendnis nicht unbedingt notwendig ist, gemeint.

        Wenn (MERKE) neben einer Zeile steht, dann gibt es hier eine Kleinigkeit, welche praktisch ist und sehr wohl zum Verständnis beiträgt.

        Wir wollen hier Umwandlungen zwischen verschiedenen Typen (String, Double, Integer, Boolean, Float, Long, ...) kennenlernen.
        Wir behandeln die block2.Klassen "Integer/Double/..." usw. und auch primitive Datentypen "int/double/..." usw.
        Außerdem ist, wenn unten "Zahl" erwähnt wird "Double/Float/Integer/Long" und deren primitiven Varianten gemeint.

        Wir definieren mal alle Varianten was wir uns anschauen wollen.
        Anmerkung! deklarieren also, "Integer x;" vs. definieren "Integer x = 25;".
        Beim Deklarieren weisen wir keinen Wert zu. Die Variable kann also nicht weiter verwendet werden.
        Wir koennen aber der Variable spaeter einen Wert zuweisen. z.B. "x = 25;" wenn wir weiter oben im Code "Integer x" bereits geschrieben haben  */

        // //        Character output = userinput.charValue(); // gibts leider nicht.
        ////        Character output = new Character(userinput);
        ////        Character output = Character.toChars(userinput)[0];
        // Point something number mehtod.

        // definieren
        Integer kleineGanzeZahl = 1;
        int kleineGanzePrimitiveZahl = 10;

        Long grosseGanzeZahl = 2L; // Hier wie bei Float muss bei der Zuweisung gesagt werden, dass es sich rechts vom "=" um einen Long handelt.
        long grosseGanzePrimitiveZahl = 20L;

        Float kleineKommaZahl = 3.0f;
        float kleinePrimitiveKommaZahl = 30.0f;

        Double grosseKommaZahl = 4.0;
        double grossePrimitiveKommaZahl = 4.0d; // (ANMERKUNG) Es kann hier auch speziell mit "d" gesgat werden, dass es sich um einen "Double" rechts vom "=" handelt. Muss aber nicht sein.

        Boolean boolscherWert = false; //false entspricht der Zahl 0 und true der Zahl 1.
        boolean boolscherPrimitiverWert = true;

        // deklariert. Hat noch keinen Wert. Wir koennen z.B. jetzt nicht "String neuerString = genzaTextZahl + "Hallo"; machen.
        String kleineGanzeTextZahl;
        String kleineGanzePrimitiveTextZahl;
        String grosseGanzeTextZahl;
        String grosseGanzePrimitiveTextZahl;
        String kleineKommaTextZahl;
        String kleinePrimitiveKommaTextZahl;
        String grosseKommaTextZahl;
        String grossePrimitiveKommaTextZahl;
        String boolscherTextWert;
        String boolscherPrimitiverTextWert;

/*      Prinzipielle Message:
        Es gibt hier "3 Kategorien" von Umwandlungen:
            - 1. von einer Zahl zu einer anderen Zahl ( (MERKE) verwende z.B. intValue ),
            - 2. von einer Zahl zu einem String, ( (MERKE) verwende toString, aber was wenn wir nur 2 Nachkommastellen eines Doubles darstellen wollen? Siehe "format" Beispiel ganz unten)
            - 3. von einem String zu einer Zahl. ( (MERKE) verwende Integer.parseInt )

        Nun genauer.
        - 1. Zahl zu Zahl: */

        grosseKommaZahl = grosseGanzeZahl.doubleValue();
        kleineGanzeZahl = grosseKommaZahl.intValue();
        grosseGanzeZahl = kleineGanzeZahl.longValue();
        grosseGanzeZahl = kleineKommaZahl.longValue();
        kleineKommaZahl = grosseKommaZahl.floatValue();

        // (ANMERKUNG) Streng genommen gibt uns hier z.B. grosseKommaZahl.intValue(); einen int zurueck, nicht einen Integer!
        // wenn wir wirklich einen Integer wollen, dann muessen wir noch Integer.valueOf( grosseKommaZahl.intValue() ); dranhaengen.
        // das ist aber nur notwendig wenn wir in einer Zeile Double, rechts vom "=" verwenden wollen. z.B.
        boolscherPrimitiverWert = Double.valueOf(grosseGanzeZahl.doubleValue()).isInfinite();

        // (ANMERKUNG) Die Methode isInfinite() gibt es nur bei Double und nicht bei double. Alternativ ohne valueOf in zwei Zeilen.
        grosseKommaZahl = grosseGanzeZahl.doubleValue(); // hier ist "grosseKommaZahl" bereits ein Double. Wenn dieser double ist funktioniert das nicht!
        boolscherPrimitiverWert = grosseKommaZahl.isInfinite();

        System.out.println("Was ist es? - " + kleineKommaZahl.getClass().getSimpleName());
        System.out.println("Was ist es? - " + grosseKommaZahl.getClass().getSimpleName());

/*      - 2. Zahl zu String */

        // geht nur mit Integer
        // (MEKRE) Jedes Objekt hat die Methode ".toString()", auch Boolean und auch selbst erstellte.
        kleineGanzeTextZahl = kleineGanzeZahl.toString();
        boolscherTextWert = boolscherWert.toString();

        // geht mit Integer und int
        kleineGanzePrimitiveTextZahl = Integer.toString(kleineGanzePrimitiveZahl);
        kleineGanzeTextZahl = Integer.toString(kleineGanzeZahl);

        System.out.println("Was ist es? - " + kleineGanzeZahl.getClass().getSimpleName());
        System.out.println("Was ist es? - " + kleineGanzeTextZahl.getClass().getSimpleName());

/*      - 3. String zu Zahl: */

        kleineGanzeZahl = Integer.parseInt(kleineGanzeTextZahl); // (Merke): wenn ich einen Integer will, dann mit Integer.parse starten, wenn Double, dann mit Double.parse, usw.
        grosseGanzeZahl = Long.parseLong(kleineGanzeTextZahl);
        boolscherWert = Boolean.parseBoolean(boolscherTextWert);

/*      - 3.1) Boolscher Wert zu Zahl: */
        // wenn "boolscherWert" gleich true ist, dann gibt compareTo(false) 1 zurueck.
        // wenn "boolscherWert" gleich false ist, dann gibt compareTo(false) 0 zurueck.
        // Achtung! beides keine tolle Loesung. Besser mit if-else oder ternary operator. Aber das machen wir spaeter.
        boolscherWert = false;
        kleineGanzeZahl = boolscherWert.compareTo(false);

        System.out.println("Geht das wirklich?... " + kleineGanzeZahl + " und ist vom Typ: " + kleineGanzeZahl.getClass().getSimpleName());

        boolscherWert = true;
        kleineGanzeZahl = boolscherWert.compareTo(false);

        System.out.println("Geht das wirklich?... " + kleineGanzeZahl + " und ist vom Typ: " + kleineGanzeZahl.getClass().getSimpleName());

// ############################## ein paar Beispiele ########################################

        Boolean a = true;
        int ganzeZahlOhneMethoden = 5;
        Integer i = kleineGanzeZahl + 9;

        // Zahl in einen String umwandlen
        // #################################################################
        // Variante 1 - wenn wir Integer (Objekt) haben
        String integerString1 = Integer.toString(kleineGanzeZahl);
        String integerString2 = kleineGanzeZahl.toString();

        // das geht leider nicht, wenn wir int statt Integer als Typ haben.
        // String integerString3 = ganzeZahlOhneMethoden.toString(); :(
        String integerString3 = Integer.toString(ganzeZahlOhneMethoden);
        System.out.println(integerString1  + " " + integerString2);

        // Jetzt mit Double to String?
        Double myDouble = 3.14;
        // String asdf = "" + myDouble; //Das ist ein Trick...
        String doubleString1 = Double.toString(myDouble);
        String doubleString2 = myDouble.toString();
        System.out.println(doubleString1  + " " + doubleString2);

        // Jetzt mit Double to Integer?
        // mit Double einfach
        Integer warEinmalEinDoubleUndIstJetztEinInteger = myDouble.intValue();

        // mit double nicht ganz so
        double myDoubleWhoIsNotAnObject = 5.0;
        // ist leider kompliziert... und casten "(int)" kennen wir noch nicht.
        Integer warEinmalEinDoubleUndIstJetztEinInteger2 = Long.valueOf(Math.round(myDoubleWhoIsNotAnObject)).intValue();
        Integer warEinmalEinDoubleUndIstJetztEinInteger3 = (int) Math.round(myDoubleWhoIsNotAnObject);
        Integer warEinmalEinDoubleUndIstJetztEinInteger4 = Double.valueOf(myDoubleWhoIsNotAnObject).intValue();

        System.out.println(warEinmalEinDoubleUndIstJetztEinInteger);
        System.out.println(warEinmalEinDoubleUndIstJetztEinInteger4);

        // Jetzt Integer to Double
        Double warEinmalEinIntegerUndIstJetztEinDouble = kleineGanzeZahl.doubleValue();

        System.out.println(warEinmalEinIntegerUndIstJetztEinDouble);

        // Kommastellen eines Doubles gerunden
        Double anotherDouble = 3.1488582546225456464;

        // die Zahl zwischen "%.<Zahl>f" gibt die Anzahl der Kommastellen an.
        String roundedDouble = String.format("%.2f", anotherDouble);
        System.out.println("Die Zahl auf zwei kommastellen gerunden lautet - " + roundedDouble);

        // Kommastellen eines Doubles abgeschnitten
        DecimalFormat df = new DecimalFormat("#.##"); // Achtung! Hier "." auf "," ausbessern fuer Deutsche Computer
        df.setRoundingMode(RoundingMode.FLOOR);
        df.applyLocalizedPattern("#.##"); // ODER Hier "." auf "," ausbessern fuer Deutsche Computer
        // Wenn hier die
        // deutsche Variante von 1.000.000,00 und nicht die
        // englische Variante 1,000,000.00 verwendet wird (Systemsprache Deutsch vs. Englisch).
        String StringButItsADouble = df.format(anotherDouble);
        System.out.println(StringButItsADouble);

        //Von String zu einem Double
        Double convertedDouble = Double.parseDouble(StringButItsADouble);
        System.out.println(convertedDouble.getClass().getName());

    }
}