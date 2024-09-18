public class UePalindrom {
    public static void main(String[] args) {
        String s = "Anna".toLowerCase();

        // Ich weiß, dass ein Palindrom von vorne und hinten gelesen, das gleiche Wort ergibt.

        // Vartiante 1
        System.out.println("########## Variante 1 ##########");
        String reversS = new StringBuilder(s).reverse().toString();
        System.out.println( s.equals(reversS) );

        System.out.println("########## Variante 2 ##########");
        // Variante 2
        Integer links = 0;
        Integer rechts = s.length()-1;

        Boolean istPalindrom = false;

        while (s.charAt(links) == s.charAt(rechts)) {
            links++;
            rechts--;

            if (links > rechts) {
                istPalindrom = true;
                break;
            }
        }

        System.out.println(istPalindrom);

         System.out.println("########## Variante 3 ##########");
        // Variante 3
        // TODO: FIXME
        istPalindrom = true;

        while (true) {
            links++;
            rechts--;

            if (s.charAt(links) != s.charAt(rechts)) {
                istPalindrom = false;
                break;
            } else if (links >= rechts){
                istPalindrom = true;
                break;
            }
        }

        System.out.println("########## Variante 4 ##########");
        // Variante 4
        istPalindrom = false;

        while (s.charAt(links) == s.charAt(rechts)) {
            links++;
            rechts--;

            if (s.length()/2 >= links) {
                istPalindrom = true;
                break;
            }
        }

        System.out.println(istPalindrom);
    }
}
