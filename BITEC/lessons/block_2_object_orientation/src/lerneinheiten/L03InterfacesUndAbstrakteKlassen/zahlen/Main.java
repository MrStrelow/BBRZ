package lerneinheiten.L03InterfacesUndAbstrakteKlassen.zahlen;

/*
    Wir betrachten hier abstrakte lerneinheiten.L02KlassenUndMethoden.Klassen und Interfaces und wie wir <ist> Beziehungen mit diesen umsetzen.
    In den lerneinheiten.L02KlassenUndMethoden.Klassen "BinaryZahl", "Zahl" und dem Interface "Summierbar" werden weitere Informationen zu den besprochenen
    Themen angegeben.
*/

public class Main {
    public static void main(String[] args) {
        BinaryZahl ersteZahl       = new BinaryZahl("101");

        Zahl binaryZahl            = new BinaryZahl("101");
        Zahl dezimalZahl           = new DecimalZahl("4095");

        Transformierbar dritteZahl = new BinaryZahl("101");
        Summierbar vierteZahl      = new BinaryZahl("101");

        ersteZahl.transformieren(null);

        Zahl transformedZahl = (Zahl) binaryZahl.transformieren(new DecimalZahl());
        System.out.println(transformedZahl.getWert());

        Zahl transformedBinaryZahl = (Zahl) dezimalZahl.transformieren(new BinaryZahl());
        System.out.println(transformedBinaryZahl.getWert());


//        System.out.println(new BinaryZahl("10"));
//        System.out.println(new DecimalZahl("10"));
//        System.out.println(new Object());

        dezimalZahl.transformieren(null);

        dritteZahl.transformieren(null);
    }
}
