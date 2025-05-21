package lerneinheiten.L10StringOperationen.live;

import java.util.regex.Pattern;

public class A01MailRegex {
    public static void main(String[] args) {
        String mail = "mathias.cammerlander@gmail.com";
        String regex = "^([a-zA-Z]+)\\.([a-zA-Z]+)@(yahoo|gmail)\\.[a-z]{2,63}";

        boolean hasMatched = Pattern.matches(regex, mail);

        String musterPasst = "Der Input: " + mail + " passt zum Muster " + regex + ".";
        String musterPasstNicht = "Der Input: " + mail + " passt nicht zum Muster " + regex + ".";

        if (hasMatched) {
            System.out.println(musterPasst);
        } else {
            System.out.println(musterPasstNicht);
        }
    }
}
