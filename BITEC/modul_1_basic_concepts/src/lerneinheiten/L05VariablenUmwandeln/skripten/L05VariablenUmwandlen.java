package lerneinheiten.L05VariablenUmwandeln;

import java.math.RoundingMode;
import java.text.DecimalFormat;

public class L05VariablenUmwandlen {
    public static void main(String[] args) {
        Integer ganzeZahl = 1;
        int ganzePrimitiveZahl = 10;

        Long grosseGanzeZahl = 2L;
        long grosseGanzePrimitiveZahl = 20L;

        Float kleineKommaZahl = 3.0f;
        float kleinePrimitiveKommaZahl = 30.0f;

        Double grosseKommaZahl = 4.0;
        double grossePrimitiveKommaZahl = 4.0d;

        Boolean boolscherWert = false;
        boolean boolscherPrimitiverWert = true;

        String kleineGanzeTextZahl;
        String kleineGanzePrimitiveTextZahl;
        String grosseGanzeTextZahl;
        String grosseGanzePrimitiveTextZahl;
        String kleineKommaTextZahl = "75.2";
        String kleinePrimitiveKommaTextZahl;
        String grosseKommaTextZahl = "101.5";
        String grossePrimitiveKommaTextZahl;
        String boolscherTextWert;
        String boolscherPrimitiverTextWert;

        // ############# 1. Zahl zu Zahl #############
        Double meinDoublerWelcherEinIntegerWar = ganzeZahl.doubleValue();

        String meinNeunerString = "9";
        Integer meinNeuner = Integer.parseInt(meinNeunerString);

        System.out.println(ganzeZahl                       + " <Typ>: " + meinNeuner.getClass().getSimpleName());
        System.out.println(meinDoublerWelcherEinIntegerWar + " <Typ>: " + meinDoublerWelcherEinIntegerWar.getClass().getSimpleName());

        System.out.println(meinNeunerString + " <Typ>: " + meinNeunerString.getClass().getSimpleName());
        System.out.println(meinNeuner       + " <Typ>: " + meinNeuner.getClass().getSimpleName());

        grosseKommaZahl = grosseGanzeZahl.doubleValue();
        ganzeZahl = grosseKommaZahl.intValue();
        grosseGanzeZahl = ganzeZahl.longValue();
        grosseGanzeZahl = kleineKommaZahl.longValue();
        kleineKommaZahl = grosseKommaZahl.floatValue();

        boolscherPrimitiverWert = Double.valueOf(grosseGanzeZahl.doubleValue()).isInfinite();

        System.out.println("Was ist es? - " + kleineKommaZahl.getClass().getSimpleName());
        System.out.println("Was ist es? - " + grosseKommaZahl.getClass().getSimpleName());

        ganzePrimitiveZahl       = (int) grossePrimitiveKommaZahl;

        grossePrimitiveKommaZahl = (double) ganzePrimitiveZahl;

        ganzeZahl = grosseKommaZahl.intValue();

        ganzeZahl = ((Integer) ganzePrimitiveZahl).intValue();

        ganzeZahl = ((Integer) (ganzePrimitiveZahl + ganzeZahl)).intValue();

        // ############# 2. Zahl zu String #############

        kleineGanzeTextZahl = ganzeZahl.toString();
        boolscherTextWert = boolscherWert.toString();

        kleineGanzePrimitiveTextZahl = Integer.toString(ganzePrimitiveZahl);
        kleineGanzeTextZahl = Integer.toString(ganzeZahl);

        System.out.println("Was ist es? - " + ganzeZahl.getClass().getSimpleName());
        System.out.println("Was ist es? - " + kleineGanzeTextZahl.getClass().getSimpleName());

        Double anotherDouble = 3.1488582546225456464;

        String roundedDouble = String.format("%.2f", anotherDouble);
        System.out.println("Die Zahl auf zwei kommastellen gerunden lautet - " + roundedDouble);

        DecimalFormat df = new DecimalFormat("#.##");

        df.applyLocalizedPattern("#.##");
        df.setRoundingMode(RoundingMode.FLOOR);

        String StringButItsADouble = df.format(anotherDouble);

        System.out.println(StringButItsADouble);

        // ############# 3. String zu Zahl: #############

        ganzeZahl = Integer.parseInt(kleineGanzeTextZahl);
        grosseGanzeZahl = Long.parseLong(kleineGanzeTextZahl);
        boolscherWert = Boolean.parseBoolean(boolscherTextWert);

        grosseKommaZahl = Double.parseDouble(kleineKommaTextZahl);
        kleineKommaZahl = Float.parseFloat(grosseKommaTextZahl);

        grosseKommaZahl = Double.parseDouble(kleineKommaTextZahl + "f");
        grosseKommaZahl = Double.parseDouble(kleineKommaTextZahl + "F");
        kleineKommaZahl = Float.parseFloat(grosseKommaTextZahl + "d");
        kleineKommaZahl = Float.parseFloat(grosseKommaTextZahl + "D");

/*      - 3.1) Boolescher Wert zu Zahl: */
        boolscherWert = false;
        ganzeZahl = boolscherWert.compareTo(false);

        System.out.println("Geht das wirklich?... " + ganzeZahl + " und ist vom Typ: " + ganzeZahl.getClass().getSimpleName());

        boolscherWert = true;
        ganzeZahl = boolscherWert.compareTo(false);

        System.out.println("Geht das wirklich?... " + ganzeZahl + " und ist vom Typ: " + ganzeZahl.getClass().getSimpleName());

        ganzeZahl = boolscherWert ? 1 : 0;

        double myDoubleWhoIsNotAnObject = 5.0;
        Integer warEinmalEinDoubleUndIstJetztEinInteger2 = Long.valueOf(Math.round(myDoubleWhoIsNotAnObject)).intValue();
        Integer warEinmalEinDoubleUndIstJetztEinInteger3 = (int) Math.round(myDoubleWhoIsNotAnObject);
        Integer warEinmalEinDoubleUndIstJetztEinInteger4 = Double.valueOf(myDoubleWhoIsNotAnObject).intValue();
    }
}