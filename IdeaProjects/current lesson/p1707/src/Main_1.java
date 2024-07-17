//Ue03Verzweigungen01

import javax.swing.text.NumberFormatter;
import java.text.NumberFormat;
import java.time.LocalDateTime;
import java.util.Scanner;


public class Main_1 {
    public static void main(String[] args) {
//        Die Eingabe ist über die Konsole zu erfassen.

//        1. - Altersüberprüfung:
//        Fordern Sie den Benutzer auf, sein Alter einzugeben. Verwenden Sie eine if-Anweisung, um zu überprüfen,
//        ob die Person volljährig ist (über 18 Jahre). Geben Sie eine Nachricht aus, die besagt, ob die Person volljährig ist oder nicht.
        Scanner in=new Scanner(System.in);
        System.out.println("Geben sie ihr Alter ein");

        int age=Integer.parseInt(in.nextLine());

        if(age<18){
            System.out.println("minderjährig");

        }else{
            System.out.println("volljährig");
        }

//        2. - Größer-Kleiner-Vergleich:
//        Fordern Sie den Benutzer auf, zwei Zahlen einzugeben, und verwenden Sie eine if-Anweisung, um zu
//        überprüfen, ob die erste Zahl größer, kleiner oder gleich der zweiten Zahl ist. Geben Sie das Ergebnis aus.
        System.out.println("gr. kl. Vergleich");
        System.out.println("Geben sie eine zahl ein");
        double x= Double.parseDouble(in.nextLine());
        System.out.println("Geben sie eine weitere zahl ein");
        double y =Double.parseDouble(in.nextLine());

        if(x<y){
            System.out.println( x + " < "+y);
        }
        else if (x==y){
            System.out.println(x+" = "+y);}
            else  {
                System.out.println(x+" > "+y);}


//        3. - Positiv oder negativ:
//        Fordern Sie den Benutzer auf, eine Zahl einzugeben, und verwenden Sie eine if-Anweisung, um zu
//        überprüfen, ob die Zahl positiv, negativ oder null ist. Geben Sie das Ergebnis aus.

        System.out.println("Positiv oder negativ:");
        System.out.println("Geben sie eine ganze Zahl ein.");
        String s= in.nextLine();
        if (s.contains(",")||s.contains(".")){
            System.out.println("keine ganze Zahl");
        } else {
            int positiveOrNegatiive = Integer.parseInt(s);

            if (positiveOrNegatiive < 0) {
                System.out.println("negativ");

            } else if (positiveOrNegatiive > 0) {
                System.out.println("positiv");
            } else System.out.println("x = 0");
        }

//        4. - Zahlengleichheit:
//        Fordern Sie den Benutzer auf, zwei Zahlen einzugeben, und verwenden Sie eine if-Anweisung, um zu
//        überprüfen, ob die beiden Zahlen gleich sind. Geben Sie eine Nachricht aus, die angibt, ob die Zahlen gleich
//        sind oder nicht.
        System.out.println("Zahlengleichheit:");
        System.out.println("geben sie eine Zahl ein");
        double first=Double.parseDouble(in.nextLine());
        System.out.println("geben sie eine weitere Zahl ein");
        double sec=Double.parseDouble(in.nextLine());

        System.out.println("sind die Zahlen gleich? " + (first==sec));

//        5. - Kreditwürdigkeitsprüfung:
//        Fordern Sie den Benutzer auf, sein monatliches Einkommen und seine monatlichen Ausgaben einzugeben.
//        Verwenden Sie eine if-Anweisung, um zu überprüfen, ob die Person aufgrund ihres Einkommens und ihrer
//        Ausgaben kreditwürdig ist. Geben Sie eine Nachricht aus, die angibt, ob die Person als kreditwürdig
//        eingestuft wird.
        System.out.println("Kreditwürdigkeitsprüfung:");
        System.out.println("geben sie ihre monatlichen einnahmen ein");
        double income=Double.parseDouble(in.nextLine());
        System.out.println("geben sie Ihre monatlichen Ausgaben ein");
        double outgoing=Double.parseDouble(in.nextLine());

        if(income/3>=outgoing){
            System.out.println("kreditwürdig");
        } else System.out.println("nicht kreditwürdig");


//        6. - Wahl des Getränks:
//        Bitten Sie den Benutzer, eine Zahl von 1 bis 3 einzugeben, um ein Getränk auszuwählen
//                (1 = Kaffee, 2 = Tee, 3 = Limonade). Verwenden Sie if-Anweisungen, um das ausgewählte Getränk anzuzeigen.
       System.out.println("kaffe =1,Tee=2, limo=3");
        int getraenk=Integer.parseInt(in.nextLine());
        if(getraenk<1||getraenk>3){
            System.out.println("ungültige eingabe");
        }
        else if(getraenk!=2 && getraenk!=3){
            System.out.println("Kaffe");
        }else if(getraenk==2){
            System.out.println("Tee");

        }else System.out.println("Limo");

//        7. - Schulnoten:
//        Fordern Sie den Benutzer auf, eine Schulnote zwischen 1 und 5 einzugeben. Verwenden Sie ifAnweisungen, um eine Nachricht anzuzeigen,
//        die angibt, ob die Note "Sehr gut", "Gut", "Befriedigend", "Genügend", oder "Nicht genügend" ist.

        System.out.println("geben sie ihre schulnote ein");
        String schulnote=in.nextLine();
        String s1="Sehr gut";
        String s2="gut";
        String s3="befriedigend";
        String s4="genügend";
        String s5="nicht genügend";
                if(schulnote.equals("1")){
                    System.out.println(s1);
                }
                else if (schulnote.equals("2")){
                    System.out.println(s2);
                }else if(schulnote.equals("3")){
                    System.out.println(s3);
                }
                else if (schulnote.equals("4")) {
                    System.out.println(s4);
                }
                else if (schulnote.equals("5")){
                    System.out.println(s5);
                }
        else System.out.println("ungültige Eingabe");

//        8. - Jahreszeiten:
//        Fordern Sie den Benutzer auf, den aktuellen Monat (als Zahl von 1 bis 12) einzugeben, und verwenden Sie
//        if-Anweisungen, um die zugehörige Jahreszeit (Frühling, Sommer, Herbst, Winter) anzuzeigen.


        System.out.println("Geben sie den aktuellen Monat ein");
        int month=Integer.parseInt(in.nextLine());
        if(month>12||month<1){
            System.out.println("ungültige Eingabe");
        }
        else if (month ==12||month<=3) {
            System.out.println("winter");
        }
            else if(month<6){
                System.out.println("Frühling");
            }
            else if(month>=6&& month<=8){
                System.out.println("Sommer");
            }

               else {
                System.out.println("Herbst");
            }

//        9. - Rabattberechnung:
//        Fordern Sie den Benutzer auf, den Gesamtbetrag eines Einkaufs und einen Rabatt (in %) einzugeben.
//        Verwenden Sie if-Anweisungen, um zu überprüfen, ob der Rabatt positi ist.Berechnen Sie den endgültigen
//        Betrag nach Anwendung des Rabatts, sofern der Rabatt positiv ist. Ist der Rabatt negativ, soll eine
//        Fehlermeldung ausgegeben werden.
        System.out.println("Geben sie den Gesamtbetrag ihres Einkaufs ein");
        String srabatt=in.nextLine();
        srabatt.replace(',','.');
        double gesBetrg=Double.parseDouble(srabatt);
        System.out.println("Geben sie den Rabatt in % ein");
        double rabatt=Double.parseDouble(in.nextLine());

        if (rabatt<0){
            System.out.println("ungültige Eingabe ");
        }
        else System.out.println("Endbetrag: " + (gesBetrg -(gesBetrg/100*rabatt)));

//        10. - Klassifizierung Programmiersprache:
//        Abfrage von Programmiersprache in der Konsole (Java/Javascript)
//        Wenn die Eingabe Java ist, soll Kompilierte Sprache
//        Wenn die Eingabe Javascript ist, soll Interpretierte Sprache
//        Andernfalls soll Nicht bekannt ausgegeben werden

        System.out.println("geben sie java oder javascript ein");
        String prlanguage=in.nextLine();

        if (prlanguage.toLowerCase().equals("java")) {
            System.out.println("kompilierte Sprache");
        }
            else if(prlanguage.toLowerCase().equals("javascript")){
                System.out.println("interpretierte Sprache");
            }
            else {System.out.println("nicht bekannt");
        }

//        11. - Teilbar
//        Der Benutzer gibt eine ganze Zahl ein, welche in einer Variable gespeichert wird. (siehe Beispiel)
//        Wenn die Zahl durch 2 Teilbar ist, dann soll Zahl X durch 2 teilbar , andernfalls soll Zahl X nicht
//        durch 2 teilbar ausgegeben werden.
//        Erweiterung, sodass der Teiler ebenso abgefragt wird.
//                Teiler eingeben: 3
//                Zahl eingeben: 7
//                Zahl 7 ist nicht durch 3 teilbar
        System.out.println("Teilbar");
       System.out.println("geben sie eine zahl ein");
            int zahl=Integer.parseInt(in.nextLine());
        System.out.println("geben sie den Teiler ein");
        int teiler=Integer.parseInt(in.nextLine());
            if(zahl%teiler==0){
                System.out.println("zahl " + zahl +" ist durch "+ teiler + " teilbar");
            }
            else System.out.println("zahl " + zahl +" ist durch "+ teiler + " nicht teilbar");

//        12. - Aktuelle Version von Betriebssystem (if, else if, else)
//        Abfrage von Betriebssystem (iPhone, Android, Windows, MacOS)
//        Ausgabe der aktuellen Version aufgrund vom Betriebssytem-String
//        iPhone: iOS 16
//        Android: Android 13
//        Windows: Windows 11
//        MacOS: macOS Venttura

        String osName =System.getProperty("os.name");
        //System.out.println("aktuelles betriebssystem: "+osName);
        if (osName.equals("iOS 16")){
            System.out.println("iPhone");
        }
        else if(osName.equals("Android 13")){
            System.out.println("Android");
        }
        else if(osName.equals("Windows 11")){
            System.out.println("Windows");
        } else if(osName.equals("macOS Venttura")){
            System.out.println("MacOS");
        } else System.out.println("unbekanntes Os");




//        13. - Uhrzeit
//        Abfrage von Uhrzeit Stunden und Minuten in der Konsole
//        Wenn Uhrzweit zwischen 1130 und 1230 ist, dann soll Mittagspause auf die Konsole ausgegeben
//        werden. Andernfalls soll Arbeitszeit ausgegeben werden.
        System.out.println("Uhrzeit");
       String  now= String.valueOf(LocalDateTime.now());

       int hour=Integer.parseInt(now.substring(11,13));
       int min=Integer.parseInt(now.substring(14,16));



        System.out.println(hour + ":"+min);
        //System.out.println(now);
        if((hour==11&&min>=30)||(hour==12&&min<=30)) {
            System.out.println("mittagspause");
        }
        else System.out.println("Arbeitszeit");


        System.out.println("geben sie die Uhrzeit ein");
        String [] time = in.nextLine().split(":");
        int stunde=Integer.parseInt(time[0]);
        int mins=Integer.parseInt(time[1]);

        if((stunde==11&&mins>=30)||(stunde==12&&mins<=30)) {
            System.out.println("mittagspause");
        }
        else System.out.println("Arbeitszeit");

        in.close();
    }
}