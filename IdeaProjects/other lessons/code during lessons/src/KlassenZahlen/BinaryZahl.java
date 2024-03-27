package KlassenZahlen;

public class BinaryZahl extends Zahl {

    public BinaryZahl() {

    }

    public BinaryZahl(String wert) {
        super.setWert(wert);
    }

    public Summierbar sum(Summierbar x) {
        return null;
    }

    /*
    Wir verwenden hier einen neuen Vergleichsoperator. Dieser ist instanceof und vergleicht ein Objekt mit einer Klasse.
    Dieser gibt true zurück, wenn das Objekt der angegebenen Klasse entspricht. Ansonsten False.
    Wir können leider in JAVA nicht ein switch statement verwenden, um Klassen mit instance of aufzuteilen (C# schon).

    SUPER
     */
    public Transformierbar transformieren(Transformierbar x) {
        System.out.println("Das ist eine Binary Zahl mit dem Wert " + super.getWert());

        if (x instanceof BinaryZahl) {

            return x;

        } else if (x instanceof DecimalZahl) { // DecimalZahl y) {
//            y.asdf();

            DecimalZahl decimalZahl = (DecimalZahl) x;
            String binaryWert = this.getWert();
            Integer decimalWert = 0;

            for (int i=0; i<binaryWert.length(); i++) {
                Character characterDigit = binaryWert.charAt(binaryWert.length() - i - 1);
                Integer digit = Character.getNumericValue(characterDigit);
                decimalWert += digit * (int) Math.pow(2, i);
//                decimalWert += digit * Double.valueOf(Math.pow(2, i)).intValue();
            }

            decimalZahl.setWert(decimalWert.toString());

            return decimalZahl;

        } else {
            return null;
        }
    }
}
