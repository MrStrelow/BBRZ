package org.example;

import org.testng.annotations.Test;

import org.example.solution.Calculator;

import static org.junit.jupiter.api.Assertions.*;
import static org.junit.jupiter.api.Assertions.assertFalse;

public class CalculatorTest {

    // TODO: Erstelle ein Objekt Calculator als Attribut der Klasse CalculatorTest
    private Calculator calculator = new Calculator();

    // TODO: Erstelle eine Methode welche public ist und testAdd heißt.
    //  Diese hat keine Argumente und void als Rückgabetyp. Schreibe dort @Test darüber.
    // Wir verwenden nun die methode "assertEquals" von JUnit (unsere Testing Library).
    // Diese Methode hat 2 Argumente.
    // - das 1. ist das Ergebnis, welches wir erwarten und
    // - das 2. ist der Aufruf der Methode welche zu testen ist.

    @Test
    public void testAdd() {
        Integer expected = 65;
        Integer provided = calculator.add(18, 47);

        assertEquals(expected, provided);
    }

    // TODO: Erstelle eine Methode welche public ist und testSubtract heißt.
    //  Diese hat keine Argumente und void als Rückgabetyp hat. Schreibe dort @Test darüber.
    @Test
    public void testSubtract() {
        Integer expected = -29;
        Integer provided = calculator.subtract(18, 47);

        assertEquals(expected, provided);
    }

    // TODO: Erstelle eine Methode welche public ist und testMultiply heißt.
    //  Diese hat keine Argumente und void als Rückgabetyp hat. Schreibe dort @Test darüber.

    // TODO: Erstelle eine Methode welche public ist und testDivide heißt.
    //  Diese hat keine Argumente und void als Rückgabetyp  hat. Schreibe dort @Test darüber.

    // TODO: Erstelle eine Methode welche public ist und testDivideByZero heißt.
    //  Diese hat keine Argumente und void als Rückgabetyp hat. Schreibe dort @Test darüber.
    // Um testen zu können ob eine Exception geworfen wird ist die Methode "assertThrows" anwendbar.
    // Erstelle dazu eine "Anonyme Klasse" Executable executable = new Executable() {...};.
    // Dies ist eine Klasse welche noch nicht alle Methoden implementiert hat.
    // Diese ist für uns public void execute() {  }
    // In diese Methode kommt nun der Aufruf der divide methode rein.
    // Danach müssen außerhalb von Executable executable = new Executable() {...}; sicherstellen,
    // dass die richtige Exception geworfen wurde. Verwende dazu assertThrows().
    // Das erste Argument dieser Methode ist die Exception welche wir erwarten. Wir geben diese mit IllegalArgumentException.class an.
    // Das zweite Argument ist das erstellte objekt executable.

    @Test
    public void testDivideByZero() {
        Exception exception = assertThrows(IllegalArgumentException.class, () -> calculator.divide(4515, 0));
        assertEquals("Division by zero", exception.getMessage());
    }

    // Optional: verwende noch assertEquals(...); um den Text der Geworfenen Exception abzufragen.
    // Die Methode assertThrows gibt dir eine Exception zurück.
    // Diese Rückgabe können wir also einer Variable zuweisen und danach den Text der Exception abfragen.

    // Optional: Versuche nun diese Methode als Lambda Ausdruck zu implementieren
    // Intellij schlägt es dir vor, wenn du über new Executable() mit der Maus "hoverst".
    // Nimm diesen Vorschlag an um es direkt in einen Lambda umzuschreiben.
    // Versuche zu verstehen was der Unterschied ist.


    // TODO: Erstelle eine Methode welche public ist und testDivideByZeroWithLambda heißt.
    //  Diese hat keine argumente hat und void als rückgabe hat. Schreibe dort @Test darüber.

    // Um einen Rückgabewert einer Methode welcher True oder False sein kann überprüfen zu können verwenden wir
    // assertTrue(...); bzw. assertFalse(...);. Diese Methode hat ein Argument welche der Aufruf der Methode ist.
    // Wenn wir erwarten, dass diese wahr zurückgeben soll, dann verwenden wir assertTrue, ansonsten assertFalse.
    // TODO: Erstelle eine Methode welche public ist und testIstTeilbarDurch heißt.
    //  Diese hat keine argumente hat und void als rückgabe hat. Schreibe dort @Test darüber.
    @Test
    public void testIstTeilbarDurch() {
        assertTrue(calculator.istTeilbarDurch(10,2));
        assertFalse(calculator.istTeilbarDurch(10,3));
    }
}
