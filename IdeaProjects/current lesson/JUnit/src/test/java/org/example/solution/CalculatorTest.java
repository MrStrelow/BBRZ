package org.example.solution;

import org.junit.jupiter.api.function.Executable;
import org.testng.annotations.Test;

import static org.junit.jupiter.api.Assertions.*;

public class CalculatorTest {

    private Calculator calculator = new Calculator();

    @Test
    public void testAdd() {
        assertEquals(-1, calculator.add(2, -3));
    }

    @Test
    public void testSubtract() {
        assertEquals(5, calculator.subtract(3, -2));
    }

    @Test
    public void testMultiply() {
        assertEquals(6, calculator.multiply(2, 3));
    }

    @Test
    public void testDivide() {
        assertEquals(2, calculator.divide(6, 3));
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
        Exception exception = assertThrows(IllegalArgumentException.class, () -> {
            calculator.divide(1, 0);
        });

        assertEquals("Division by zero", exception.getMessage());
    }

    @Test
    public void testIstTeilbarDurch() {
        assertTrue(calculator.istTeilbarDurch(10,2));
        assertFalse(calculator.istTeilbarDurch(10,3));
    }
}