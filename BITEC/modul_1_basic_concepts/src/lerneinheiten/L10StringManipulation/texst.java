package lerneinheiten.L10StringManipulation;

import java.util.Random;

public class texst {
    public static void main(String[] args) {
        String text = "Dies ist ein Satz welcher ueberprueft wird.🌊";
        String mySubString = text.substring(0, 2);
        System.out.println(mySubString);

        mySubString = text.substring(0, text.length());
        System.out.println(mySubString);

        mySubString = text.substring(5, text.length() - 5);
        System.out.println(mySubString);

        mySubString = text.substring(500, text.length() - 500);
        System.out.println(mySubString);
    }
}
