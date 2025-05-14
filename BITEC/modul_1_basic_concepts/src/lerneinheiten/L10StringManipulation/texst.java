package lerneinheiten.L10StringManipulation;

import java.util.Random;

public class texst {
    public static void main(String[] args) {
        String text = "Dies ist ein Satz welcher ueberprueft wird.🌊";
        String mySubString = text.substring(0, 2); // Ergibt "Di"
        System.out.println(mySubString);
        mySubString = text.substring(0, text.length()); // Ergibt "Di"
        System.out.println(mySubString);
        mySubString = text.substring(5, text.length() - 5); // Ergibt "Di"
        System.out.println(mySubString);

        int userinputVon = -25;
        int userinputBis = 394;

        int mindestensNull = Math.max(0, userinputVon);
        int hoechstensLaenge = Math.min(text.length(), userinputBis);
        mySubString = text.substring(mindestensNull, hoechstensLaenge); // Ergibt "Di"
        System.out.println(mySubString);
    }
}
