package lerneinheiten.L12Funktionen.live;

import java.util.Arrays;
import java.util.Scanner;

public class A02BubbleSortInFunktion {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] userZahlen = userInput(scanner);
        int[] sortierteZahlen = bubbleSort(userZahlen);
        System.out.println(Arrays.toString(sortierteZahlen));
    }

    public static int[] bubbleSort(int[] zahlen) {
        for (int j = 0; j < zahlen.length - 1; j++) {
            for (int i = 0; i < zahlen.length - j - 1; i++) {
                if (zahlen[i] > zahlen[i+1]) {
                    int tmp = zahlen[i];
                    zahlen[i] = zahlen[i+1];
                    zahlen[i+1] = tmp;
                }
            }
//            System.out.println(Arrays.toString(zahlen));
        }

        return zahlen;
    }

    public static int[] userInput(Scanner scanner) {
        String inhaltDesArrays = scanner.nextLine();

        String[] userinput = inhaltDesArrays.split(" ");
        int[] zahlen = new int[userinput.length];

        for (int i = 0; i < userinput.length; i++) {
            zahlen[i] = Integer.parseInt(userinput[i]);
        }

        return zahlen;
    }
}
//        String myString = hello.repeat(7); // ohne static - funktion lebt bei variable
//        Integer res = Integer.parseInt(myString); // mit static - Funktion lebt bei Typ
