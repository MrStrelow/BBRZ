public class L10StringManipulation {

    public static void main(String[] args) {

        //
        // Übungen zur String manipulation
        // Strings können mittels befehlen manipuliert werden. (Für bessere handhabung siehe die StringBulider Klasse).
        // Es gibt zahlreiche Manipulationen aber, wichtig hier ein paar wichtige,
        //      - "gib mir die Position/Index eines Sub-Strings"                                -> indexOf
        //      - "beginnt/endet/beinhaltet mein String einen anderen Sub-String?"              -> startsWith, endsWith, contains
        //      - "gib mir einen Sub-String, welcher von Position x bis y geht"                 -> substring
        //      - "ersetze mir auf alle Vorkommnisse von z.B. asdf in meinem String druch qwer. -> replace
        //      - "gib mir den character auf position x"                                        -> charAt

        String myString = "Dies ist ein Satz welcher ueberprueft wird.";
        boolean hatB = myString.startsWith("Dies ist ein Satz"); // true
        boolean hatBB = myString.endsWith(" wird.");
        boolean hatBBB = myString.contains("Satz welcher");
        System.out.println(hatBBB);

        System.out.println( myString.substring(0,2) );
        String myStringMeh = "Hallo World";
        System.out.println( myStringMeh.indexOf("Wo") );

        System.out.println(myString.replace("i", "X"));

        System.out.println(myString.charAt(3));

        // Sehr von Vorteil ist die Verwendung von sogenannten REGEX! Regular Expressions! Diese scheinen jedoch
        // am Anfang komplex zu sein, aber der Vorteil ist, sie sind unabhängig von JAVA zu verwenden. Also
        // Also sie funktionieren im Prinzip gleich überall anders - ist wie eine eigene Sprache! (Siehe Links im Kurs Block 3)
    }

}
