public class ThirdLoops {
    public static void main(String[] args) {

//        System.out.println(1);
//        System.out.println(2);
//        System.out.println(3);
//        System.out.println(4);

        // Beginne mit 0, wenn etwas mit arrays/string zu tun ist. wenn nicht, dann mit 1.
//        for (int i = 0; i <= 4; i++ ) {
//            System.out.println(i);
//        }

        // Gebe jeden BUCHSTABEN eines Strings in einer eigenen Zeile in die Konsole aus.
//            System.out.println( "Der " + (i=i+1) + ". Buchstabe im String: " + myString + " ist " + myString.charAt(i) );
//            System.out.println( "Der " + ++i + ". Buchstabe im String: " + myString + " ist " + myString.charAt(i) );
//            System.out.println( "Der " + i++ + ". Buchstabe im String: " + myString + " ist " + myString.charAt(i) );
//            System.out.println( "Der " + i+1 + ". Buchstabe im String: " + myString + " ist " + myString.charAt(i) );

        String myString = "HeLlo, ThiS IS StrinG";

        int anzahlSonderzeichen = 0;

        // 1. String anlegen für ausgabe.
        // 2. ausgabe kopieren und in string einfügen
        // 3.) leerzeichen hinzufügen zum string wenn i<9+anzahlSonderzeichen (StringBuilder Objekte haben die Methode insert(index, " ")

        for (int i = 0; i < myString.length(); i++) {
            StringBuilder ausgabe =
                    new StringBuilder(
                            "Der " + (i-anzahlSonderzeichen+1) + ". Buchstabe im String: " + myString + " ist " + myString.charAt(i)
                    );

            if (myString.charAt(i) != ' ' && myString.charAt(i) != ',') {
                if (i < 9+anzahlSonderzeichen) {
                    System.out.println(ausgabe.insert(4," "));
                } else {
                    System.out.println(ausgabe);
                }
            } else {
                anzahlSonderzeichen ++;
            }
        }


//        for (int i = 0; i < myString.length(); i++) {
//            if (myString.charAt(i) != ' ') {
//                System.out.println( "Der " + (i+1) + ". Buchstabe im String: " + myString + " ist " + myString.charAt(i) );
//            }
//
//            if (myString.charAt(i) == ' ') {
//                anzahlSonderzeichen ++;
//            }
//        }
    }
}
