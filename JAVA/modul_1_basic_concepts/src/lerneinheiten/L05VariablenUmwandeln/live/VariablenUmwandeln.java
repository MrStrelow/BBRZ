package lerneinheiten.L05VariablenUmwandeln.live;

import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class VariablenUmwandeln {
    public static void main(String[] args) {
        // 3 Arten der Umwandlung
//        1. Von einer Zahl zu einer anderen Zahl (verwende z.B. `<variable>.intValue()`)
//        2. Von einer Zahl zu einem String (verwende `<variable>.toString()`, siehe Beispiel unten)
//        3. Von einem String zu einer Zahl (verwende `Integer.parseInt()`)

        // zahl zu zahl
        int myPrimitveInteger = 5;
        Integer myInteger = 5;
        Double myDouble = myInteger.doubleValue();

        // zahl zu string
        String myStringNumber = myDouble.toString();

        // DecimalFormat df = new DecimalFormat("#.##");
        DecimalFormat df = (DecimalFormat) DecimalFormat.getInstance(Locale.GERMANY);
        df.setRoundingMode(RoundingMode.HALF_EVEN);
        df.applyPattern("#.##"); // wird nur gebraucht wenn wir nicht new DecimalFormat("#.##"); schreiben.

        String myFormattedNumber = df.format(5.5548);
        System.out.println(myFormattedNumber);

        System.out.printf("hello this is 2 decimals %.2f", 5.5548);

        // string zu zahl
        Integer number = Integer.parseInt("5");
        Double doubleNumber = Double.parseDouble("5");

        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        Double userInput = Double.parseDouble(line);
        // Double userInput = Double.parseDouble(scanner.nextLine());

        System.out.print("bitte gib ein datum ein: ");
        String[] result = scanner.nextLine().split("-");
        String tag = result[0];
        String monat = result[1];
        String jahr = result[2];

        System.out.println(tag);
        System.out.println(monat);
        System.out.println(jahr);

    }
}
