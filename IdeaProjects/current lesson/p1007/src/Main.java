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

    }
}