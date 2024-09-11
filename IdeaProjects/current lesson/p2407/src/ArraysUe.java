import java.util.Arrays;

public class ArraysUe {
    public static void main(String[] args) {
        // 1. Art der Definition
        String[] myStringArray = {"null", "qwer"};

        // die Länge des Arrays kann mit .length abgefragt werden.
//        System.out.println(myStringArray.length); // Hier kommt "out of bounds" Fehler!
        System.out.println(myStringArray[myStringArray.length-1]);

        // 2. Art der "leeren" Definition
        String[] myEmptyStringArray = new String[2];
        System.out.println(Arrays.toString(myEmptyStringArray));
        System.out.println(Arrays.toString(myStringArray));
        myEmptyStringArray[0].repeat(2); // Hier kommt ein "null" Fehler!

        // Positionen der Arrays:
        // - 1. Position hat index 0
        // - 2. Position hat index 1
        // - n. Position hat index n-1
        String myString = myStringArray[0];
        String myOtherString = myStringArray[1];

        // Regel:
        // - wenn wir mit arrays arbeiten fängt die Zaehlvariable meistens mit 0 an.
        // - wir vergleichen mit < nicht <=
        for (int i = 0; i < myStringArray.length; i++) {
            System.out.println(myStringArray[i]);
        }


    }
}
