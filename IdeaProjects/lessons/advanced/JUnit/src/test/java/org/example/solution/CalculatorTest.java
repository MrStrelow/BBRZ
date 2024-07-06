package org.example.solution;

import org.junit.jupiter.api.function.Executable;
import org.testng.annotations.Test;

import java.util.Random;

import static org.junit.jupiter.api.Assertions.*;

public class CalculatorTest {

    private Calculator calculator = new Calculator();

    @Test
    public void testAdd() {
        assertEquals(5, calculator.add(2, -3));
    }

    @Test
    public void testSubtract() {
        int wer = calculator.subtract(3, -2);
        assertEquals(1, wer);
    }

    @Test
    public void testMultiply() {
        assertEquals(6, calculator.multiply(2, 3));
    }

    @Test
    public void testDivide() {
        assertEquals(2, calculator.divide(6, 3));

        // ACHTUNG! Zufall in Unittests sind nur nützlich, wenn diese reproduzierbar sind UND falls ein Fehler gefunden wird,
        // dieser Fall in einem eigenen Test implementiert wird. Zufall ist immer mit Bedacht zu verwenden!
        Random random = new Random();
        Integer first = random.nextInt(1,100000);
        Integer second = random.nextInt(1,100000);

        Integer baseline = divideBaselineImplementation(first,second);
        Integer comparison = calculator.divide(first, second);
        assertEquals(baseline, comparison);
    }

    private int divideBaselineImplementation(int a, int b) {
        if (a < 0) a = a * -1;
        if (b < 0) b = b * -1;

        int ergebnis = a;
        int i = 0;
        while(ergebnis > b) {
            ergebnis = a - b;
            i++;
        }
        return i;
    }

    @Test
    public void testDivideByZero() {
        Executable executable = new Executable() {
            public void execute() {
                calculator.divide(1, 0);
            }
        };

        Exception exception = assertThrows(IllegalArgumentException.class, executable);

        assertEquals("Division by zero", exception.getMessage());
    }
    @Test
    public void testDivideByZeroKurz() {
        Exception exception = assertThrows(
                IllegalArgumentException.class,
                new Executable() {
                    public void execute() {
                        calculator.divide(1, 0);
                    }
                }
        );

        assertEquals("Division by zero", exception.getMessage());
    }

    @Test
    public void testDivideByZeroWithLambda() {
        Exception exception = assertThrows(IllegalArgumentException.class, () -> calculator.divide(1, 0));

        assertEquals("Division by zero", exception.getMessage());
    }

    @Test
    public void testIstTeilbarDurch() {
        assertTrue(calculator.istTeilbarDurch(10,2));
        assertFalse(calculator.istTeilbarDurch(10,3));
    }
}