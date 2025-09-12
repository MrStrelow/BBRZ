package lerneinheiten.L11Arrays.live;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class A01BubbleSort {
    public static void main(String[] args) {
        // userinput
//        int[] zahlen = {3, 5 ,9, 105, 64, 2};
        Scanner scanner = new Scanner(System.in);
        String inhaltDesArrays = scanner.nextLine();

        String[] userinput = inhaltDesArrays.split(" ");
        Integer[] zahlen = new Integer[userinput.length];

//        System.out.println(Arrays.toString(userinput));
//        System.out.println(userinput.getClass());

        for (int i = 0; i < userinput.length; i++) {
            zahlen[i] = Integer.parseInt(userinput[i]);
        }

//        System.out.println(Arrays.toString(zahlen));
//        System.out.println(zahlen.getClass());

        // sortiere User input
        // Schritt 1: Vergleiche die 1. (Index 0) und 2. (Index 1) Zahl im Array.
        // Falls die 1. größer ist wie die 2., dann vertausche diese, andernfalls mach nichts.
        for (int j = 0; j < userinput.length - 1; j++) {
            for (int i = 0; i < userinput.length - j - 1; i++) {
                if (zahlen[i] > zahlen[i+1]) {
                    int tmp = zahlen[i];
                    zahlen[i] = zahlen[i+1];
                    zahlen[i+1] = tmp;
                }
            }
            System.out.println(Arrays.toString(zahlen));
        }

    }
}
