package lerneinheiten.L03Operatoren;

public class L03Operatoren {
    public static void main(String[] args) {
        System.out.println( 35 + 17 );

        System.out.println( "35" + "17" );

        // Das gleiche Verhalten gilt für Variablen.
        Integer firstInt = 35;
        Integer secondInt = 17;
        System.out.println(firstInt + secondInt);

        String firstString = "35";
        String secondString = "17";
        System.out.println(firstString + secondString);

        System.out.println(firstInt + secondInt + firstInt + secondInt);

        System.out.println( ( (firstInt + secondInt) + firstInt ) +  secondInt );

        System.out.println( (firstInt + secondInt) + (firstInt  +  secondInt) );

        // Für die andren arithmetischen Operatoren der Zahlen, "-", "*", "/" der Zahlen gelten die Regeln aus der Mathematik.

        //#################################### Arten von Operatoren ####################################
        // Unterschiedliche Bedeutungen von Operatoren, haben zur Folge, dass verschiedene Namen für diese existieren.
        // Diese unterschiedlichen Bedeutungen sind meistens aufgrund der Typen der Werte welche in eine Variable "reinfließen" bzw. "rausfließen"
        // Wir unterscheiden in folgende Operatoren:
        // - Operatoren welche den Typ erhalten:
        //      - string operatoren:
        //          - "+": concatenate bedeutet, füge Zeichen bzw. Zeichenketten zusammen.
        //      - arithmetische Operatoren:
        //          - "+", "-", "*", "/", bei Variablen welche Zahlen darstellen
        //      - logische (oder auch boolesche) Operatoren:
        //          - "!", "||", "&&", "^": das sind beispielsweise das logische nicht, logische und, logische oder, und exclusive oder.
        //      - bitweise Operatoren:
        //          - "|", "&", "^", "~", "<<", ">>", ">>>": bitweise operatoren nehmen die binäre Darstellung eine Zahl und verknüft diese bit pro bit. also 5 & 6 = 101 & 110 = [1&1 = 1, 0&1 = 0, 1&0=0] = 100 = 4
        // - Operatoren welche den Typ nicht erhalten:
        //      - Vergleichsoperatoren:
        //          - "==", "<", ">", "<=", ">=", "instanceof": hier ist "==" eine Frage.
        //              Ist der linke und der rechte Input in einer Beziehung? Wenn ja, dann gib "Wahr" zurück, wenn nein "Falsch".
        // - Zuweisungsoperatoren:
        //      - wir haben in JAVA nur einen und dieser ist das "=". Dieser weist den rechts stehenden Ausdruck der links
        //      stehenden Variable zu.
     // - gemischte Operatoren:
        //      - "+=", "-=", "*=", "/=": diese sind eine Kombination aus zuweisung und arithmetischen Oparatoren.
        //      - "++", "--": diese werden inkrement und dekrement Operatoren genannt und sind eine Kombination aus "x=x+1".
        // - selbst definierte Operatoren
        //      - das ist in JAVA nicht möglich (C++). Wir können aber Methoden erstellen, welche ein solches Verhalten abbilden.

        // Wir unterscheiden zudem in unäre, binäre und tertiäre Operatoren. Diese Kategorisierung gibt an, wie viele Inputs diese annehmen.
        // Achtung, damit ist nicht deren Verkettung gemeint, sondern wirklich ein Operator nimmt 1, 2 oder 3 Inputs an.
        // Beispiel für einen unären Operator ist:

        System.out.println(!true);

        System.out.println(firstInt *= 10);
        firstInt = firstInt * 10;

        Boolean firstBoolean = false;
        Boolean ergebnis = !( firstBoolean && firstBoolean);


        // #################################### Zeichen(ketten) Operatoren ####################################
        System.out.println( "hallo" + " " + "wir " + "verknüpfen" + " Strings");

        System.out.println("Zeichenkette" + ' ' + "getrennt mit einem Character");

        System.out.println("'" + " das geht in dem wir die Symbole verdrehen " + '"');

        // #################################### arithmetische Operatoren ####################################
        Double meinErsterDouble = 2.0;
        Integer meinErsteInteger = 2;
        Integer meinZweiterInteger = 5;

        System.out.println( meinZweiterInteger / meinErsteInteger);

        System.out.println( meinZweiterInteger / meinErsterDouble );

        System.out.println( 5 / 2 );

        System.out.println( 5 % 2 );

        System.out.println( 5 / 2.);  // double
        System.out.println( 5 / 2.0); // double
        System.out.println( 5 / 2D);  // double
        System.out.println( 5 / 2d);  // double
        System.out.println( 5 / 2F);  // float
        System.out.println( 5 / 2f);  // float

        System.out.println( Math.divideExact(5, 2) );

        // #################################### logische Operatoren ####################################
        Boolean isOldEnough = true;
        Boolean isCitizen = true;

        Boolean eligibility = isOldEnough && isCitizen;
        System.out.println(eligibility);

        // Hier ein Beispiel mit einem ||
        Boolean bedingung = true;
        Boolean nochEineBedingung = false;
        Boolean undNochEineBedingung = true;

        Boolean result = bedingung || nochEineBedingung || undNochEineBedingung;
        result = bedingung || (nochEineBedingung || undNochEineBedingung);
        result = (bedingung || nochEineBedingung) || undNochEineBedingung;

        System.out.println(result);

        // #################################### bitweise Operatoren ####################################
        Integer bitwise = 6 & 5;

        System.out.println("Bitwise: " + bitwise);

        // #################################### Vergleichsoperatoren ####################################
        Integer a = 10;
        Integer b = 10;
        Integer c = 20;

        System.out.println("a == b: " + (a == b) );
        System.out.println("a == c: " + (a == c) );
        System.out.println("a != c: " + !(a == c) );
        System.out.println("a != c: " + (a != c) );

        String str1 = "hello";
        String str2 = "hello";
        // hier greifen wir ein wenig vor... aber damit wir uns hier was komischen anschauen können
        String str3 = new String("hello");

        System.out.println("str1 == str2: " + (str1 == str2));
        System.out.println("str1 das SELBE wie str3: " + (str1 == str3)); // ?

        System.out.println("str1 das GLEICHE wie str3: " + str1.equals(str3));

        String correctUsername = "admin";
        String correctPassword = "password123";
        Boolean active = true;
        Integer userMessage = 248;
        Integer saltForHash = 145;
        Boolean ausweisHinterlegt = true;
        Integer alter = 19;

        String username = correctUsername; // Ändere diesen Text auf "TODO CHANGE THIS";
        String password = correctPassword; // Ändere diesen Text auf "TODO CHANGE THIS";

        result =
                false;

        result =
                username.equals(correctUsername + "das ist ein gehackter teil des textes") &&
                password.equals(correctPassword) &&
                active &&
                (userMessage & saltForHash) % 2 == 0 &&
                ausweisHinterlegt &&
                alter > 18;

        System.out.println(result);

        // #################################### gemischte Operatoren ####################################
        alter = alter + 25;
        System.out.println(alter);

        alter += 25;
        System.out.println(alter);

        System.out.println( alter /= 2);

        alter = alter + 1;
        System.out.println(alter);

        alter++;
        System.out.println(alter);

        alter--;
        System.out.println(alter);

        System.out.println("start here:");
        alter = 25;
        alter++;
        System.out.println(alter);

        ++alter;
        alter = alter + 1;
        System.out.println(alter);

        System.out.println("Das momentane Alter ist: " + alter);
        System.out.println("und jetzt erhöhen wir es auf: " + alter++);
        System.out.println("wieso erst jetzt? " + alter);

        System.out.println("Zuweisung und Erhöhung seperat: " + (alter = alter + 1) );
        System.out.println("Das momentane Alter ist: " + alter);

        System.out.println("Inkrement mit ++alter: " + ++alter );
        System.out.println("Das momentane Alter ist: " + alter);

        Integer index = 0;
        System.out.println( ((index+1)+1)+1 );
        System.out.println(index);

        index = 0;
        System.out.println( index=((index+1)+1)+1 );
        System.out.println(index);

        // // #################################### OPERATOREN VS. METHODEN ####################################
        Integer zahl = (((97 + 98) + 82) + 16);
        Integer andereZahl = Math.addExact(97, 98);
        Integer neueZahl1 = Math.addExact(andereZahl, 82);
        Integer neueZahl2 = Math.addExact(neueZahl1, 16);
        Integer andereZahl2 = Math.addExact( Math.addExact(97, 98), 82 );

        Double kommazahl = zahl.doubleValue();
    }
}
