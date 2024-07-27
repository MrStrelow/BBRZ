import java.util.Random;
import java.util.Scanner;

public class L08SchleifenWhile {
    public static void main(String[] args) {

        // ############# WHILE #############
        // Die letzte Zutat fehlt uns um alles berechnen zu können, was wir uns vorstellen können! (zumindest ist noch nichts anders von der Theorie bewiesen worden)
        // Schleifen! (bzw. im Englischen, Loop).
        // Ohne diese müssten wir aussagen hintereinanderschreiben. wie z.B.:
        System.out.println(":)");
        System.out.println(":)");
        System.out.println(":)");
        System.out.println(":)");

        // Wie oft aber soll das geschehen? Wenn wir die Anzahl nicht fixieren, sondern z.B. dem User als eingabe überlassen,
        // dann können wir ein solches Problem nicht lösen.
        // Genauer: "Lass den User eine Zahl eingeben, und gib so oft ':)' aus".
        // Wir müssten dazu eine unendlich lange Verzweigung schreiben.
        // Cheating! ":)".repeat(userInput) darf natürlich nicht verwendet werden! Das ist quasi eine Schleife!

        Scanner scanner = new Scanner(System.in);
        Integer userInput = Integer.parseInt(scanner.nextLine());

        switch (userInput) {
            case 1 -> System.out.print(":)\n");
            case 2 -> System.out.print(":)\n:)\n");
            case 3 -> System.out.print(":)\n:)\n:)\n");
            case 4 -> System.out.print(":)\n:)\n:)\n:)\n");
            default -> System.out.println("Ich kanns nicht ohne Schleife lösen :(");
        }

        // Deshalb hier die allgemeinste Schleife. Die WHILE-Schleife. Allgemein bedeutet hier, dass alle anderen Schleifen, als diese dargestellt werden können.
        // Die Essenz einer While-Schleife ist ein Wiederholen eines Teils des Codes, bis eine Bedingung nicht mehr erfüllt wird.
        // Die Bedingungen können hier beliebig konstruiert werden, jedoch ist wichtig, dass am Schluss ein boolescher Wert rauskommt.
        // Hier ist dies "zaehlvariable < 3". Solange diese Schleifenbedingung erfüllt ist, also auf true auswertet, wird der Code welcher unter der
        // While Schleife steht, ausgeführt. Dies ist hier  System.out.println(" :) "); und zaehlvariable = zaehlvariable + 1;

        Integer zaehlvariable = 0; // zaehlvariable = 1;
        while (zaehlvariable < 3) { // zaehlvariable <= 3;
            System.out.println(" :) ");
            zaehlvariable = zaehlvariable + 1;
        }

        // Hier ist zaehlvariable eine Zählvariable und zählt wie oft die Schleife ausgeführt wurde. Diese wird meist mit "i" geschrieben.
        // Meistens wenn gezählt wird und mit der Zählvariable nicht wilde Dinge passieren
        // (erhöht, und dann verringert in einem nicht vorhersehbaren Ausmaß), dann ist eine For Schleife besser geeignet.
        // Siehe ForSchleife.java. Wenn aber nicht klar ist, wie oft etwas ausgeführt wird,
        // also eben wilde Dinge mit der Zählvariable passieren, oder wir einfach nicht wissen, wann z.B. der User mit einer Ausgabe zufireden ist,
        // dann wird eine While Schleife benötigt.

        // Beachte hier, dass es nur wichtig ist, wie oft etwas ausgeführt wird und nicht was der Wert der Zählvariable ist.
        // Es ist also wichtig, dass 3 Mal die Schleife ausgeführt wird. Der Unterschied zwischen der ersten Zuweisung von i (i=1) und
        // deren Abbruchbedingung mit dem "<" Operator (i <= 3 wird i < 4) ergibt die Anzahl der Schleifendurchläufe. Also 4-1 = 3.
        int i = 1; // i = 101;
        while (i <= 3) { // i <= 103;
            System.out.println(" :) ");
            i = i + 1;
        }

        // Hier wird das Alter vom User eingegeben und erst wenn dieses "plausibel" ist, fahren wir mit dem restlichen Programm fort.
        System.out.print("Bitte Alter eingeben: ");
        Integer alter = Integer.parseInt(scanner.nextLine());

        while ( alter < 18 || alter > 120) {
            System.out.print("Bitte korrektes Alter eingeben: ");
            alter = Integer.parseInt(scanner.nextLine());
        }

        // Beachte hier die Bedingung der Schleife! Sind die beiden Bedingungen die gleichen?
        // Versuche es mit einer Wahrheitstabelle zu überprüfen!
        System.out.print("Bitte Alter eingeben: ");
        alter = Integer.parseInt(scanner.nextLine());

        while ( !(alter >= 5 && alter <= 120) ) {
            System.out.print("Bitte korrektes Alter eingeben: ");
            alter = Integer.parseInt(scanner.nextLine());
        }

        // Achtung! Mit While Schleifen können endlose Programme entstehen!
        // Damit ist gemeint, dass die Schleifenbedingung immer true ist.
//        while (true) {
//            System.out.println("das ist der letzte Durchlauf... oder?");
//        }

        // Wir können aber mit dem Befehlt "break" aus einer Schleife rausspringen, wenn nötig.
        // Bedeutet also, wenn wir in einer Schleife "break" sagen, ist egal, ob die Schleifenbedingung erfüllt ist, diese Beendet.
        while (true) {
            System.out.println("erste ewige Schleife");
            while (true) {
                System.out.println("zweite ewige Schleife");
                if (true) {
                    break;
                }
            }
            break;
        }

        // es gibt auch den Befehlt "condinue", dieser ist ähnlich wie "break", jedoch beenden wir nicht die Schleife, sondern
        // beginnen sie von oben wieder. Hier wird also nie das "ich bin nicht bei Hallo 5 da" print verwendet.
//        i = 0;

//        while (i<10) {
//            System.out.println("Hallo " + i);
//            i++;
//            continue;
//            System.out.println("ich bin nicht bei Hallo 5 da");
//        }

        i = 0;

        // Hier nochmal aber mit einer Bedingung für das continue. break und continue sind immer in einem if vorzufinden.
        // Im allgemeinen, sind, wenn es geht, break und continue zu vermeiden.
        while (i<10) {
            System.out.println("Hallo " + i);
            i++;
            if (i == 6){
                continue;
            }
            System.out.println("ich bin nicht bei Hallo 5 da");
        }

        // ############# Auf der Suche nach der DO-WHILE Schleife #############
        // Schauen wir uns zuerst folgendes Scenario an.
        // wir schreiben eine While Schleife, welche aufgrund eines User-Inputs entscheiden soll, ob die Schleifer weiter
        // fortgeführt werden soll, oder nicht.
        // Sagen wir der user soll so lange eine Zahl raten bis diese erraten wurde. Diese Zahl ist zwischen 1 und 100.

        Random random = new Random();

        Integer draw = random.nextInt(101);
        Integer trials = 0;
        Integer guess;

        System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");
        while (true) {
            guess = Integer.parseInt(scanner.nextLine());
            // Was wäre der Nachteil, wenn wir hier guess definieren würden?
            // Tipp: Wir wollen z.B. die Variable guess, trial und draw nach der Loop ausgeben.
            String hint;
            trials++;

            if (guess > draw) {
                hint = "groß";
                System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

            } else if (guess < draw) {
                hint = "klein";
                System.out.println("Inkorrekt! - Zahl ist zu  " + hint + "!");

            } else {
                System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
                break;
            }
        }

        // Es fallen uns hier 2 Dinge auf:
        //  - Die While Schleife müssen wir mittels break beenden. Wir benötigen dazu keine Bedingung in der While Schleife.
        //    Eine häufige bzw. verschachtelte Verwendung von "break" und "continue" macht den Code unleserlich und schwer wartbar.

        //    (ABER wir werden später sehen dass unser 1. Versuch hier, gar nicht so schlecht ist!
        //    "continue", "break", usw. sind Werkzeuge und wenn wir diese sinnvoll verwenden können, sollen wir diese verwenden!
        //    Die Kunst ist zu wissen, wann und wann nicht.
        //    Hier eine Daumenregel, als Guards bzw. wenn keine Verschachtelungen vorhanden sind, sind break und continue gut.
        //    Schlecht sind diese in der "Kernlogik" eines Programmes welche komplexere Logik hat. Dort kann schwer vorhersehbares Verhalten entstehen.)

        //  - An sich wird die Steuerung, ob die Schleife beendet wird in der Bedingung der While Schleife gesteuert.
        //    Diese wird in den Runden Klammern gegeben. Da wir mit break arbeiten brauchen wir
        //    zusätzliche IF-Verzweigungen. Diese sind aber möglicherweise nicht in diesem Ausmaß notwendig.

        // Versuchen wir es nun ohne break zu schreiben.
        draw = random.nextInt(101);
        trials = 0;

        // Wir stoßen hier aber auf ein Problem. Wir können nicht guess und draw vergleichen,
        // wenn wir guess erst innerhalb der schleife zum ersten Mal mit einem Wert belegen (guess wird initialisiert).
        // Bedeutet wir können, um dieses Problem zu umgehen außerhalb der Schleife "ein mal" den gesamten Inhalt dieser ausführen.
        // TODO: vermeide doppelten Code! Schwer zu warten.
        System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

        guess = Integer.parseInt(scanner.nextLine());
        String hint;
        trials++;

        if (guess > draw) {
            hint = "groß";
            System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

        } else if (guess < draw) {
            hint = "klein";
            System.out.println("Inkorrekt! - Zahl ist zu  " + hint + "!");

        } else {
            System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
        }

        while (guess != draw) {
            guess = Integer.parseInt(scanner.nextLine());
            trials++;

            if (guess > draw) {
                hint = "groß";
                System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

            } else if (guess < draw) {
                hint = "klein";
                System.out.println("Inkorrekt! - Zahl ist zu  " + hint + "!");

            } else {
                System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
            }
        }

        // Natürlich ist dies nicht die eleganteste Lösung. Diese ist sogar sehr unübersichtlich.
        // Wir können dies ein wenig kürzer schreiben, jedoch das Hauptproblem verschwindet nicht.
        // Dieses ist, dass wir einmal am Anfang eine Eingabe des Users benötigen, um die Logik der Schleife für beliebige
        // Wiederholungen zu implementieren.

        // Wir können jedoch einen Standardwert für den "guess" festlegen.
        // Dieser muss aber mit Sicherheit "guess != draw" garantieren! Ansonsten ist das Spiel sofort gewonnen!
        // Hier ist dies einfach, da wir den User nur zwischen 1 und 100 raten lassen. Wir können also guess auf einen Wert
        // außerhalb legen (z.B. -5), um sicherzustellen, dass guess und draw unterschiedlich sind.
        // Wir sehen, dass in diesem Fall die WHILE Schleife mit Aufwand und dadurch mit potenziellen Bugs verbunden ist.
        System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");
        guess = -5;

        // Wir können nun weiters die IF Verzweigungen vereinfachen.
        // Wenn die Bedingung in der While loop nicht erfüllt ist, muss "guess == draw" gelten.
        // Dadurch wissen wir, dass nach der WHILE Schleife der Spieler die Zahl erraten hat.
        // Wir können dadurch den ELSE Teil und das break entfernen.
        // Wir sehen jetzt, dass wir in beiden IF's der gleiche "sout" steht und somit außerhalb der Verzweigung stehen kann.
        // Wir sehen auch, dass ein simples IF-ELSE, welches Variablen Werte zuweist, mit einem Ternären-Operator geschrieben werden kann.
        // TODO: Wir haben hier aber einen Fehler eingebaut! Welcher? Gewinne dazu das Spiel um es zu sehen.
        trials = 0;

        while (guess != draw) {
            guess = Integer.parseInt(scanner.nextLine());

            hint = guess > draw ? "groß" : "klein";
            System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

            trials++;
        }

        System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");

        // Wir sehen, dass dadurch unser Programm kürzer geworden ist.
        // Kürzer bedeutet nicht immer lesbarer, jedoch sollte dies auch hier der Fall sein.
        // Wir bemerken jedoch, dass wir hier Glück hatten.
        // Wenn es sehr kompliziert ist eine korrekte (bedeutet immer bzw. für jede) Belegung von der Variable "guess" zu finden,
        // kommt es im schlimmsten Fall zur Variante "einmal den Schleifeninhalt vor der Schleife ausführen".
        // Das soll unbedingt vermieden werden!

        // TODO: Der Fehler war, dass wir hier ein else-if in ein if-else (in der form eines ternären Operators) umgewandelt haben.
        //  Es ist irreführend, dass hier guess != draw in der Bedingung der While-Schleife steht.
        //  Jedoch ist der Fall, dass guess == draw während der Schleife nicht ausgeschlossen und muss deshalb noch behandelt werden.

        // Um diesen Fehler ausbessern zu können, müssen wir ein "if (guess != draw)" schreiben.
        trials = 0;

        while (guess != draw) {
            guess = Integer.parseInt(scanner.nextLine());

            if (guess != draw) {
                hint = guess > draw ? "groß" : "klein";
                System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");
            }

            trials++;
        }

        // Es schaut aber komisch aus, denn wir haben bereits die gleiche Bedingung, welche in der IF-Verzweigung ist
        // in der WHILE Schleife geschrieben.
        // Wir haben jedoch das Problem, dass nach der Überprüfung der Schleife "while(guess != draw)" unser
        // relevanter Input erst nach dieser Überprüfung eingelesen wird.
        // Versuchen wir deshalb folgendes: Schieben wir den User-Input ans Ende der Schleife,
        // dann wird im nächsten Schritt der passende User-Input in der While Bedingung verglichen.

        //TODO: Leider ist auch hier ein Fehler. Beginne das Spiel um diesen zu sehen.
        trials = 0;

        while (guess != draw) {
            hint = guess > draw ? "groß" : "klein";
            System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

            guess = Integer.parseInt(scanner.nextLine());

            trials++;
        }

        System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");

        // TODO: der Fehler war folgendes. Wir vergleichen den standard Wert von "guess", welcher "-5" ist, während des
        //  ersten Schleifendurchlaufs. Dies erzeugt immer einen falschen Vergleich.

        // Wir kommen also unsrem Problem nicht aus.
        // Eine Möglichkeit das zu umgehen ist die erste Iteration der Schleife auszuschalten. Dies ist auch mit einem
        // if() innerhalb der Schleife möglich.
        // Jedoch sind meist sogenannte "of by one Conditions" wenn möglich zu vermeiden. "Off by one" bedeutet hier,
        // der Code der Schleife ist korrekt für alle Schleifeniterationen, jedoch nicht für den 1. oder letzten.
        // Diese verursachen zusätzlichen Code, wie hier das "if(trials > 0)"
        trials = 0;

        // TODO: können wir eine "of by one Condition" vermeiden?
        while (guess != draw) {
            if (trials > 0) {
                hint = guess > draw ? "groß" : "klein";
                System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");
            }

            guess = Integer.parseInt(scanner.nextLine());

            trials++;
        }

        System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");

        // Eine kleine Vereinfachung erlaubt uns die DO-WHILE Schleife.
        // Damit können wir in diesem Fall:
        // - doppelten Code vermeiden,
        // - pre (vorher) initialisierung von guess,
        // - ABER nicht die if Verzweigungen.

        // Zuerst schauen wir uns aber die Syntax der DO-WHILE Schleife an.
        // Es wird zuerst einmal der Block der Schleife ausgeführt, und erst danach die Bedingung überprüft.
        // Dadurch haben wir kein Problem mit der Weiterverarbeitung der Eingabe des Users.

        // Wir schreiben nun unser Programm als DO-WHILE Schleife.
        // wir beginnen mit dem Keyword "do" und geben das keyword "while" am Ende der Schleife hin.
        // Dies soll auf die Überprüfung nach dem einmaligen Ausführen des Codes im Block der Schleife hinweisen.

        // Wir müssen uns nun nicht mehr um die Initialisierung von "guess" kümmern.
        // TODO: Es muss jedoch leider diese vor der Schleife deklariert werden. Frage: warum?

        Integer guessDoWhile;

        do {
            guessDoWhile = Integer.parseInt(scanner.nextLine());

            if (guessDoWhile != draw) {
//            if (trials == 0) {
                hint = guessDoWhile > draw  ? "groß" : "klein";
                System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");
            }

            trials++;
        } while (guessDoWhile != draw);

        System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");

        // Es mag nun die Nützlichkeit der DO-WHILE hier nicht sehr dramatisch ausfallen, was nach dem ganzen Aufbau
        // ernüchternd erscheinen mag.
        // Wir verwenden also ein DO-WHILE, wenn wir:
        //  - code einmal ausführen müssen und nicht eine Bedingung zusätzlich festlegen bzw. eine Variable initialisieren wollen.
        // Mehr nicht.
    }
}
