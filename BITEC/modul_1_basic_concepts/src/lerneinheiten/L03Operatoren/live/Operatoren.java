package lerneinheiten.L03Operatoren.live;

public class Operatoren {
    public static void main(String[] args) {
        // Achtung! Typen der Inputs können den Operator ändern!

        // Addition
        System.out.println(35 + 17);

        // Concatenation
        System.out.println("35" + "17");

        Integer first = 35;
        Integer second = 17;

        System.out.println(first + second);

        //Arithmetische Operatoren
        System.out.println(5 / 2); // Integer Division
        System.out.println(5 % 2); // der Rest einer Integer Divitions, auch Modulo genannt
        System.out.println(5 / 2.); // "kommazahl" Division
    }
}
