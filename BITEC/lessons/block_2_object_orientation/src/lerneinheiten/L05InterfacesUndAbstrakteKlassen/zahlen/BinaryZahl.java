package lerneinheiten.L05InterfacesUndAbstrakteKlassen.zahlen;

public class BinaryZahl extends Zahl {

    public BinaryZahl() {

    }

    public BinaryZahl(String wert) {
        super.setWert(wert);
    }

    public Summierbar sum(Summierbar x) {
        return null;
    }

//    public Zahl sum(Zahl[] zahlen) {
//        Zahl previousZahl = null;
//
//        for (Zahl zahl : zahlen) {
//
//            if (previousZahl != null) {
//                zahl = this.sum(zahl, previousZahl);
//            }
//
//            previousZahl = zahl;
//
//        }
//
//        return this.sum(this, previousZahl);
//    }
//
//    private Zahl sum(Zahl firstZahl, Zahl secondZahl) {
//        String first = "0" + firstZahl.toString();
//        String second = "0" + secondZahl.toString();
//
//        Integer numberOfBits = Math.max(first.length(), second.length());
//        Integer diffOfBits = Math.abs(first.length() - second.length());
//
//        String chosenOne = first.length() < second.length() ? first : second;
//        String otherOne  = first.length() < second.length() ? second : first;
//
//        String padding = "";
//
//        for(int i=0; i<diffOfBits; i++) {
//            chosenOne = "0" + chosenOne;
//        }
//
//        char[] result = new char[numberOfBits];
//
//        Boolean hasCarry = false;
//
//        for(int i=numberOfBits-1; i>=0; i--) {
//            char firstBit  = chosenOne.charAt(i);
//            char secondBit = otherOne.charAt(i);
//
//            if( firstBit == '0' && secondBit == '0') {
//                result[i] = '0';
//
//                if(hasCarry) {
//                    result[i] = '1';
//                }
//
//                hasCarry = false;
//
//            } else if( (firstBit == '1' && secondBit == '0') || (firstBit == '0' && secondBit == '1')) {
//
//                if(hasCarry) {
//                    result[i] = '0';
//                    hasCarry = true;
//                } else {
//                    result[i] = '1';
//                    hasCarry = false;
//                }
//
//            } else {
//                result[i] = '0';
//
//                if(hasCarry) {
//                    result[i] = '1';
//                }
//
//                hasCarry = true;
//            }
//
//        }
//
//        super.value = String.copyValueOf(result);
//
//        return this;
//
//    }


    /*
    Wir verwenden hier einen neuen Vergleichsoperator. Dieser ist instanceof und vergleicht ein Objekt mit einer Klasse.
    Dieser gibt true zurück, wenn das Objekt der angegebenen Klasse entspricht. Ansonsten False.
    Wir können leider in JAVA nicht ein switch statement verwenden, um lerneinheiten.L02KlassenUndMethoden.Klassen mit instance of aufzuteilen (C# schon).

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
