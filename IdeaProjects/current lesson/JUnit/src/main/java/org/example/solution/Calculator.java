package org.example.solution;

public class Calculator {
    public Integer add(Integer a, Integer b) {
        if (a < 0) a = a * -1;
        if (b < 0) b = b * -1;

        return a + b;
    }

    public Integer subtract(Integer a, Integer b) {
        if (a < 0) a = a * -1;
        if (b < 0) b = b * -1;

        return a - b;
    }

    public Integer multiply(Integer a, Integer b) {
        if (a < 0) a = a * -1;
        if (b < 0) b = b * -1;
        return a * b;
    }

    public Integer divide(Integer a, Integer b) {
        if (b == 0) throw new IllegalArgumentException("Division by zero");
        if (a < 0)  a = a * -1;
        if (b < 0)  b = b * -1;
        return a / b;
    }
    
    public Boolean istTeilbarDurch(Integer number, Integer isDivided) {
        return number % isDivided == 0;
    }
}
