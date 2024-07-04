package org.example;

import org.junit.jupiter.api.function.Executable;
import org.testng.annotations.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class CalculatorTest {

    // Erstelle ein Objekt Calculator als Attribut der Klasse CalculatorTest

    // Wir verwenden nun die methode "asserEquals" von JUnit (unsere Testing Library).
    // Diese Methode hat 2 Argumente.
    // - das 1. ist das Ergebnis, welches wir erwarten und
    // - das 2. ist der Aufruf der Methode welche zu testen ist.
    // TODO: Erstelle eine Methode welche public ist und testAdd heißt.
    // TODO: Erstelle eine Methode welche public ist und testSubtract heißt.
    // TODO: Erstelle eine Methode welche public ist und testMultiply heißt.
    // TODO: Erstelle eine Methode welche public ist und testDivide heißt.

    // Um testen zu können ob eine Exception geworfen wird ist die Methode "assertThrows" anwendbar.
    // Erstelle dazu eine "Anonyme Klasse" Executable executable = new Executable() {...};.
    // Dies ist eine Klasse welche noch nicht alle Methoden implementiert hat.
    // Diese ist für uns public void execute() {  }
    // In diese Methode kommt nun der Aufruf der divide methode rein.
    // Danach müssen wir sicherstellen, dass die richtige Exception geworfen wurde.
    // AssertThrows
    // Optional: verwende noch assertEquals(...); um den Text der Geworfenen Exception abzufragen.
    // TODO: Erstelle eine Methode welche public ist und testDivideByZero heißt.

    // Versuche nun diese Methode als Lambda Ausdruck zu implementieren
    // (Intellij schlägt es dir vor, versuche zu verstehen was der Unterschied ist).
    // TODO: Erstelle eine Methode welche public ist und testDivideByZeroWithLambda heißt.

    // Um einen Rückgabewert einer Methode welcher True oder False sein kann überprüfen zu können verwenden wir
    // assertTrue(...); bzw. assertFalse(...);. Diese MEthode hat ein Argument welche der Aufruf der Methode ist.
    // Wenn wir erwarten, dass diese wahr zurückgeben soll, dann verwenden wir assertTrue, ansonsten assertFalse.
    // TODO: Erstelle eine Methode welche public ist und testIstTeilbarDurch heißt.


}
