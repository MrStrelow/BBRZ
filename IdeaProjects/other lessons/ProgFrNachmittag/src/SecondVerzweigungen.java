public class SecondVerzweigungen {
    public static void main(String[] args) {
        Integer first = 5;
        Integer second = 37;
        Integer third = 58;

        // 1 )
        // --------------------------- NUR if - ich möchte im Programm einmal Abzweigen. -------------------------------
        System.out.println("----- if -----");
        System.out.println("Hallo :)");

        // nur wenn mir die person sympathisch ist, dann rede ich noch einen Satz mit Ihr.
        //  wenn nach if die Bedingung wahr ist -> dann führe den Code in der geschwungenen Klammer aus.
        Boolean sympathisch = (first == second) && (first < third);
        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
        }

        System.out.println("Tschau :(");

        // Bemerkung: Variablen welche in einer geschwungenen Klammer definiert bzw. deklariert werden, sind nach
        // der geschlossenen geschwungenen Klammer weg. (Variable nur im Block/Namespace gültig)
        if (true) {
            // a = 5 aber a gibt es nur bis "}"
            Integer a = 5;
        }
        // den Ausdruck "Integer a = 5" gibt es nicht mehr, also kann ich es neu definieren!
        Integer a = 4;


        // 2 )
        // --------------------------- if mit else - ich möchte im Programm "zwei-mal gleichzeitig" Abzweigen. -------------------------------
        System.out.println("----- if mit else -----");
        System.out.println("Hallo :)");

        // nur WENN mir die person SYMPATISCH ist,
        // DANN rede ich noch einen Satz mit Ihr,
        // ANDERNFALLS,
        // DANN sage ich "hupf in gatsch, schleich di".
        // wenn nach if die Bedingung wahr ist -> dann führe den Code in der geschwungenen Klammer aus.

        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
        } else {
            System.out.println("hupf in gatsch, schleich di");
        }

        System.out.println("Tschau :(");

        // 3 )
        // --------------------------- else-if - ich möchte im Programm "öfters gleichzeitig" Abzweigen. -------------------------------
        System.out.println("----- else-if -----");
        System.out.println("Hallo :)");

        // nur WENN mir die person SYMPATHISCH ist,
        // DANN rede viel,
        // ANDERNFALLS, WENN sie VERWANDT ist
        // DANN rede ich noch einen Satz mit Ihr,
        // ANDERNFALLS,
        // sage ich "hupf in gatsch, schleich di".
        // wenn nach if die Bedingung wahr ist -> dann führe den Code in der geschwungenen Klammer aus.

        Boolean verwandt = (first != second) && (first < third);

        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
            System.out.println("oag, geht mir auch so!");
        } else if(verwandt) {
            System.out.println("OK. Danke.");
        } else {
            System.out.println("hupf in gatsch, schleich di");
        }

        System.out.println("Tschau :(");


        // 4 )
        // --------------------------- diverse Kombinationen von 1-3 -------------------------------
        System.out.println("----- diverse Kombinationen -----");
        System.out.println("Hallo :)");

        // (nur WENN mir die person SYMPATHISCH ist,
        // DANN rede viel,
        // WENN sie SEHR SYMPATHISCH ist,
        // DANN lache viel)
        // ANDERNFALLS, WENN sie VERWANDT ist
        // DANN rede ich noch einen Satz mit Ihr,
        // ANDERNFALLS,
        // sage ich "hupf in gatsch, schleich di".
        // wenn nach if die Bedingung wahr ist -> dann führe den Code in der geschwungenen Klammer aus.

        Boolean sehrSympathisch = (first != second) || (first < third);

        if (sympathisch) {
            System.out.println("oag, geht mir auch so!");
            System.out.println("oag, geht mir auch so!");

            if(sehrSympathisch) {
                System.out.print(" :) :) :)");
            }

        } else if(verwandt) {
            System.out.println("OK. Danke.");
        } else {
            System.out.println("hupf in gatsch, schleich di");
        }

        System.out.println("Tschau :(");

        // 5 )
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.

        Integer input = 1;

        if (input == 1) {
            System.out.println("Montag :(");

        } else if (input == 2) {
            System.out.println("Dienstag");

        } else if (input == 3) {
            System.out.println("Mittwoch");

        } else if (input == 4) {
            System.out.println("Donnerstag");

        } else if (input == 5) {
            System.out.println("Freitag :)");

        } else if (input == 6) {
            System.out.println("Samstag");

        } else if (input == 7) {
            System.out.println("Sonntag");

        } else {
            System.out.println("Kein Wochentag.");
        }


        // 6 )
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.
        // Zusätzlich hat der Montag eine chance von 80% 5 mal ":(", also :(:(:(:(:( zum String "Montag :(" hinzuzufügen.
        // Zusätzlich hat der Freitag eine chance von 30% 7 mal ":(", also :):):):):):):) zum String "Freitag :(" hinzuzufügen.

        Double zufallszahl = Math.random();
//        verwende allgemein besser die Random Klasse.
//        Random random = new Random();
//        Double zufallszahl = random.nextDouble();

        if (input == 1) {

            String output = "Montag :(";

            if (zufallszahl < 0.8) {
                System.out.println(output + ":(".repeat(5));
            } else {
                System.out.println(output);
            }

        } else if (input == 2) {
            String output = "Dienstag";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 3) {
            String output = "Mittwoch";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 4) {
            String output = "Donnerstag";

            if (zufallszahl < 0.01) {
                System.out.println(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 5) {
            String output = "Freitag :)";

            if (zufallszahl < 0.3) {
                System.out.print(output + ":)".repeat(7));
            } else {
                System.out.println(output);
            }

        } else if (input == 6) {
            String output = "Samstag";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else if (input == 7) {
            String output = "Sonntag";

            if (zufallszahl < 0.01) {
                System.out.print(output + ":)");
            } else {
                System.out.println(output);
            }

        } else {
            System.out.println("Kein Wochentag.");
        }


        // -----------

        System.out.println("######################### HERE #########################");
        String output;

        if (input == 1) {
            output = "Montag :(";

            if (zufallszahl < 0.8) {
                output = output + ":(".repeat(5);
            }

        } else if (input == 2) {
            output = "Dienstag";

        } else if (input == 3) {
            output = "Mittwoch";

        } else if (input == 4) {
            output = "Donnerstag";

        } else if (input == 5) {
            output = "Freitag :)";

            if (zufallszahl < 0.3) {
                output = output + ":)".repeat(7);
            }

        } else if (input == 6) {
            output = "Samstag";

        } else if (input == 7) {
            output = "Sonntag";

        } else {
            output = "";
            System.out.println("Kein Wochentag.");
        }

        if (zufallszahl < 0.01) {
            System.out.print(output + ":)");
        } else {
            System.out.println(output);
        }


        // Montag ::)):):):):):)
        // Montag :)


        // 7)
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.
        // Zusätzlich hat der Montag eine Chance von 80% 5 mal ":(", also :(:(:(:(:( zum String "Montag :(" hinzuzufügen.
        // Zusätzlich hat der Montag eine Chance von 30% 7 mal ":(", also :):):):):):):) zum String "Freitag :(" hinzuzufügen.
        // Zusätzlich hat jeder Tag eine Chance von 1%, einen ":)" hat.



        // 8) das gleiche mit Switch.
        // --------------------------- ÜBUNG: diverse Kombinationen von 1-3 -------------------------------

        // Wir haben Wochentage: und wenn eine Integer Variable 1 ist, dann gib montag aus, andernfalls 2 dienstag, usw.
        // Wenn wir Freitag ausgeben wollen füge ":)". Wenn wir Montag ausgeben füge einen ":(" hinzu.

        input = 1;

        switch (input) {
            case 1: System.out.println("Montag :("); break;
            case 2: System.out.println("Dienstag"); break;
            case 3: System.out.println("Mittwoch"); break;
            case 4: System.out.println("Donnerstag"); break;
            case 5: System.out.println("Freitag :)"); break;
            case 6: System.out.println("Samstag"); break;
            case 7: System.out.println("Sonntag"); break;
            default: System.out.println("Kein Wochentag.");
        }


        input = 4;

        output = switch (input) {
            case 1 -> "Montag :(";
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        System.out.println(output);

        output = switch (input) {
            case 1 -> {

                String res = "Freitag :)";

                if (zufallszahl < 0.3) {
                    res = res + ":)".repeat(7);
                }

                yield(res);

            }
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        System.out.println(output);



















//
//
//
//        if( (first == second) && (first < third) ) {
//            System.out.println("Bedingung ist wahr");
//        }
//
//        if( (first == second) ) {
//            if ( first < third ) {
//                System.out.println("Bedingung ist wahr");
//            }
//        }
//
//        //|| boolean, boolean -> boolean
//
//
//        if ( ( (5+8+7/2) == (9/8-6+2) ) || ( (5+8+7/2) == (9/8-6+2) ) ) {
//            System.out.println("wird nie ausgegeben");
//        } else {
//            System.out.println("wird immer ausgegeben");
//        }
////
//        if (true) {
//            System.out.println("hallo1");
//        }
//        System.out.println("nein1");
//
//        //
//
//        if (false) {
//            System.out.println("hallo2");
//        } else {
//            System.out.println("nein2");
//        }
//
//        //
//        if (true) {
//            System.out.println("variante 1");
//        } else if(true) {
//            System.out.println("variante 2");
//        } else {
//            System.out.println("variante 3");
//        }
    }
}
