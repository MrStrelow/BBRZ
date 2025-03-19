package lerneinheiten.L06VerzweigungenUndBedingungenMitIF.live;

public class VerzweigungenUndBedingungen {
    public static void main(String[] args) {
        Integer alter = 5;
        Boolean hasLicence = true;
        System.out.println("##########################################");
        System.out.println("das ist vor dem if");

        // If-Bedingung (if ohne else)
        if (alter >= 18) {
            System.out.println("ist über 18: " + alter);
        }

        System.out.println("das ist nach dem if");

        // If-Verzweigung (if mit else)
        System.out.println("##########################################");
        System.out.println("das ist vor dem if mit else");

        // If-Bedingung (if ohne else)
        if (alter >= 18) {
            Integer alterEinesAnderenKunden = 20;
            System.out.println("ist über 18: " + (alter > alterEinesAnderenKunden));
        } else {
//            System.out.println("Error: User ist nicht über 18: " + (alter > alterEinesAnderenKunden)); // geht nicht! warum? alterEinesAnderenKunden ist in einen anderen Block (oder Scope).
        }

        System.out.println("das ist nach dem if mit else");

        // Mehrfachverzweigung (if else-if else-if ... else)
        Integer bewertungInProzent = 62;

        if (0 <= bewertungInProzent && bewertungInProzent < 50) {
            System.out.println("Nicht Genügend");

        } else if (50 <= bewertungInProzent && bewertungInProzent < 62) {
            System.out.println("Genügend");

        } else if (62 <= bewertungInProzent && bewertungInProzent < 75) {
            System.out.println("Befriedigend");

        } else if (75 <= bewertungInProzent && bewertungInProzent < 87) {
            System.out.println("Gut");

        } else if (87 <= bewertungInProzent && bewertungInProzent <= 100) {
            System.out.println("Sehr Gut");

        } else {
            System.out.println("außerhalb der grenzen 0 und 100, beides inklusive");
        }

        // If-Ausdruck (Expression)
        String note =   87 <= bewertungInProzent && bewertungInProzent <= 100   ? "Sehr Gut" :
                        75 <= bewertungInProzent && bewertungInProzent < 87     ? "Gut" :
                        62 <= bewertungInProzent && bewertungInProzent < 75     ? "Befriedigend" :
                        50 <= bewertungInProzent && bewertungInProzent < 62     ? "Genügend" :
                        0 <= bewertungInProzent && bewertungInProzent < 50      ? "Nicht Genügend" :
                                                                                  "außerhalb der grenzen 0 und 100, beides inklusive";
        System.out.println(note);

        // sonstiges:
        if (true) {
            Integer menge = 5;
        }

        if (false) {
            Integer menge = 50;
        }

//        System.out.println(menge); // geht nicht. warum?

        // ##########################
        Integer menge;

        if (true) {
            menge = 5;
            System.out.println(menge);
        }

        if (false) {
            menge = 50;
            System.out.println(menge);
        }

        System.out.println(menge); // geht aber welchen Wert hat es? kommt auf die bedingung an. hier ist es 5, weil die bedingung true ist.

    }
}
