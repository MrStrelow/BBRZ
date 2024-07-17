//UE03Verzweigung00
import java.util.Scanner;

public class Main_2 {
    public static void main(String[] args) {
        //        Alle Eingaben sollen über die Konsole erfolgen

//        1. - Zahlen addieren oder multiplizieren
//        Schreiben Sie ein Programm, das zwei Zahlen entgegennimmt. Wenn die Summe der beiden Zahlen größer
//        als 100 ist, geben Sie die Multiplikation der beiden Zahlen aus, andernfalls geben Sie die Addition aus.
        Scanner in = new Scanner(System.in);

        System.out.println("zahl 1 eingeben");
        double zahl1=Double.parseDouble(in.nextLine().replace(",","."));

        System.out.println("zahl 2 eingeben");
        double zahl2=Double.parseDouble(in.nextLine().replace(",","."));

        if(zahl2+zahl1>100){
            System.out.print("Summe > 100 --> multiplikation");
            System.out.println(zahl1 * zahl2);
        }
        else System.out.println("Summe <=100 --> addition");
        System.out.println(zahl1+zahl2);

        //        2. - Teilbarkeit
//        Schreiben Sie ein Programm, das überprüft, ob eine gegebene Zahl durch 5 teilbar ist, und geben Sie
//        entsprechende Meldungen aus.


        // Scanner in =new Scanner(System.in);
        System.out.println("Geben sie eine ganze zahl ein um zu prüfen ob sie durch 5 teilbar ist");
        String input=in.nextLine();

        if (input.contains(",")||input.contains(".")){
            System.out.println("ungültige Eingabe");
        } else {
            int fuenftel = Integer.parseInt(input);

            System.out.println(fuenftel % 5 == 0);
        }
//        3. - Taschenrechner
//        Erstellen Sie einen einfachen Taschenrechner, der zwei Zahlen und einen Operator (+, -, *, /) akzeptiert und
//        das Ergebnis der Berechnung ausgibt. Verwenden Sie "if"-Anweisungen, um den Operator zu identifizieren
//        und die Berechnung durchzuführen.
        System.out.println("Taschenrechner mit if");
        System.out.println("geben sie eine zahl ein");
        double i = Double.parseDouble(in.next().replace(",","."));
        System.out.println("geben sie eine zahl ein");
        double k = Double.parseDouble(in.next().replace(",","."));

        System.out.println("geben sie einen operator ein");
        String op = in.next();


        if (op.equalsIgnoreCase("+")) {
            System.out.println(i + k);
        } else if (op.equalsIgnoreCase("-")) {
            System.out.println(i - k);

        } else if (op.equalsIgnoreCase("*")) {
            System.out.println(i * k);
        } else if(op.equalsIgnoreCase("/")){
            System.out.println(i / k);}
            else System.out.println("ungültige Eingabe");

            in.close();
        }
    }

