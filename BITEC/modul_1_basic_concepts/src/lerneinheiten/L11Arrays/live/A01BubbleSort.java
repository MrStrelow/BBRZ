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

//        int[] zahlen = new int[];


        // sortiere userinput


        
    }
}
