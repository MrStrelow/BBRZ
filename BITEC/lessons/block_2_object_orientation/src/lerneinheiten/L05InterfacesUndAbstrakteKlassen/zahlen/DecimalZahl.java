package lerneinheiten.L05InterfacesUndAbstrakteKlassen.zahlen;

public class DecimalZahl extends Zahl{

    public DecimalZahl(String wert) {
        super.setWert(wert);
    }

    public DecimalZahl() {
        super.setWert(null);
    }

    public Summierbar sum(Summierbar x) {
        return null;
    }

    public Transformierbar transformieren(Transformierbar x) {
        System.out.println("Das ist eine Dezimal Zahl mit dem Wert " + super.getWert());
        if (x instanceof BinaryZahl) {
            BinaryZahl binaryZahl = (BinaryZahl) x;

            // String für Ergebnis.
            String result = "";

            // Integer für Modulo
            Integer binaryDigit;

            // Integer für Division
            Integer dividend = Integer.parseInt(this.getWert());

            Boolean done = true;

            if(dividend == 0) {

                binaryZahl.setWert("0");

            } else {

                while(dividend > 1) {
                    binaryDigit = dividend % 2;
                    result += binaryDigit.toString();

                    dividend /= 2;
                }

                result += "1";

                StringBuilder resultGespiegelt = new StringBuilder(result);
                result = resultGespiegelt.reverse().toString();

                binaryZahl.setWert(result);
            }

            return binaryZahl;

        } else if (x instanceof DecimalZahl) { // DecimalZahl y) {
//
            return x;

        } else {
            return null;
        }
    }
}
