import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    public static void main(String[] args) {
        // 1 Zahl zu Zahl
        Double myDouble = 1.5;
        Integer myInteger;

        double myPrimitiveDouble = myDouble;
        int myPrimitiveInt;

        myInteger = myDouble.intValue();
        myPrimitiveInt = (int) myPrimitiveDouble;

        System.out.println(myInteger + " " + myPrimitiveInt );

        // int vs Integer
        myInteger = ((Integer) myPrimitiveInt).intValue();

        myInteger = ((Integer) (myPrimitiveInt + myInteger)).intValue();
//        myInteger = ((Integer) myPrimitiveInt + myInteger).intValue(); geht nicht!? -> weil Reihenfolge der Auswertung zu einem primitiven (int) Typ zuerkommt.

        // 2. Zahl zu String
        String myString = Integer.toString(myPrimitiveInt);
        myString = Integer.toString(myInteger);

        myString = myInteger.toString();

        // 3. String zu Zahl
        myInteger = Integer.parseInt("1");
        myDouble = Double.parseDouble("1.0");
        myDouble = Double.parseDouble("1");


    }
}