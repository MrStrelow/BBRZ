import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    public static void main(String[] args) {
        //hier gehts los
        // <Typ> <Name> <Zuweisungsoperator> <alles was einen Wert erzeugt der den gleichen Typ hat wie ganz links steht>;

//        String meinText = "System.out.println();";
//        Integer a = 5;
//        Double b = .5;
//        Boolean myBoolean = true; //false;
//
//        String deinText = meinText;
//        String nochEinText = a.toString();
//
//        Scanner myScanner = new Scanner(System.in);

        System.out.println("####### Operatoren #######");
        System.out.println("#### Addieren? ####");

        System.out.println( 35 + 17 );
        System.out.println( "35" + "17" );
        System.out.println( "hallo" + " du" );


        System.out.println("### HIER ###");
//        System.out.println( "35" + "17" + 12 ); // 3529 // 351712
//        System.out.println( "3517" + 12 ); // 3529 // 351712
//        System.out.println( "3517" + "12" ); // 3529 // 351712
//        System.out.println( "351712" ); // 3529 // 351712
//
//        System.out.println( (15 + 18) + "25"); // 3325
//
//        System.out.println( 15 + (18 + "25")); // 151825

        System.out.println("#### dividieren? ####");

        Double meineVariable = 5.;
//        Integer meineVariable = 5;

        // ganzzahlige Division mit Rest
        System.out.println( 11 / 3 ); // 3
        System.out.println( 11 % 3 ); // 2 Rest

        // "normale" Division
        System.out.println( 11. / 3. ); // beide Inputs sind vom Typ Double
        System.out.println( 11  / 3. ); // 1. Input ist vom Typ Double
        System.out.println( 11. / 3 );  // 2. Input ist vom Typ Double

        System.out.println( 11 / (3 + meineVariable * 7 / 2) );


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




    }
}