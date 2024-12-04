package lerneinheiten.L03FilesUndExceptions.exceptions;

import lerneinheiten.L03FilesUndExceptions.exceptions.MeineException;

import java.io.IOException;
import java.sql.SQLException;

public class Exceptions {
    static String filePath = "src/lerneinheiten/L03FilesUndExceptions/example.txt";
    // Wir haben bei Exceptions 2 Möglichkeiten.
    // - Wir behandlen (fangen) diese mit einem try-catch-block
    // - Wir geben den Fehler weiter (werfen) zu jener Methode, welche diese aufruft.

    // Wir haben zudem 2 Arten von Exceptions:
    // - Runtime Exceptions (unchecked):
    //      Diese können zur Laufzeit auftreten und werden nicht als Fehler vom Compiler angezeigt,
    //      wenn diese nicht mit einem try-catch Block behandelt werden. Ein Beispiel dafür ist die NullPointerException.
    //      Da im Prinzip jeder Objekt null sein kann, und wir bei jedem Aufruf einer Methode eine solche Exception auslösen könnten,
    //      müssten wir bei jedem Methodenaufruf ein try-catch hinzufügen, um diese zu behandeln.
    //      Da dies aber nicht sinnvoll ist, wird auf ein solches Verhalten verzichtet.
    //- Compiletime Exceptions (checked):
    //      Diese werden vom Compiler als Fehler angezeigt, wenn diese nicht in einem try-catch Block behandelt werden.
    //      Es ist auch möglich durch "throws" die Behandlung des Fehlers hinauszuzögern und diese an einer anderen Stelle zu behandeln (mit try-catch).
    public static void main(String[] args) { // throws IOException {

        // Geht nur, wenn wir throws IOException bei der Methode schreiben, welche meineMethode aufruft.
        // Das ist hier die main methode. Das hat jedoch zur Folge, dass wir die Exception nicht behandeln, denn die
        // main Methode wird nicht mehr von uns verwaltet.
//        meineMethode();


        try {
            meineMethode();

        } catch (SQLException sqle) { // müssen wir fangen, es steht in der Methodensignatur von meineMethode()
            // Hier sehen wir eine eigene Methode welche nur SQL Exceptions aufrufen können. Diese gibt einen Code aus
            // welcher mehrere Informationen über den Fehler gibt (Tabelle gibt es nicht, Authentifizierung fehlgeschlagen usw.).
            System.err.println(sqle.getSQLState());

        } catch (NullPointerException ne) {
            // Können wir fangen, es steht nicht in der Methodensignatur von meineMethode().
            // Es ist deshalb keine "checked-Exception", sondern eine "Runtime-Exception".
            // Achtung! Auch wenn diese in der Methodensignatur stehen würde,
            // müssten wir diese nicht hier in einem Catch-Block behandeln.
            System.out.println("wir geben hier den fehler aus");
            ne.printStackTrace();

        } catch (IOException ioe) { // müssen wir fangen, es steht in der Methodensignatur von meineMethode()
            // Wir können hier zusätzlich einen PrintStream angeben. Dieser erlaubt uns Nachrichten in verschiedene
            // Orte zu schreiben. z.B. Terminal/Konsole, Files, WebSockets, etc.
            ioe.printStackTrace(System.out);

        } catch (MeineException e) {
            e.printStackTrace();
            // Wir sehen hier eine eigene Methode, welche speziell in der MeineException erstellt wurde.
            e.weitereInfoMeinesFehlers();
        }
        // Dieses Catch Exception e hat zur Folge, dass in diesem Fall alle Exceptions hier gefangen werden.
        // Der Grund ist Exception ist der Supertype aller Exceptions und somit passen alle hier.
        // Wir verzichten aber auf ein solches Verhalten, denn so vergessen wir welche Exceptions wir
        // eigentlich behandeln wollen.
//        catch (Exception e) {
//            System.err.println(e.getMessage());
//            e.getStackTrace();
//        }
    }

    // Obwohl hier nur wirklich MeineException geworfen wird (throw new MeineException()) geben wir mit "throws"
    // an, welche Exceptions der Aufrufer der Methode "meineMethode" verwalten muss.
    // Diese werden "checked Exception" oder "compile time Exceptions" genannt.
    // Der Compiler überprüft eben diesen Zustand.
    public static void meineMethode() throws IOException, SQLException, MeineException {
        if (filePath.equals("hallo")) {
            throw new MeineException();
        }
    }
}
