package lerneinheiten.L10StringManipulation;

import java.util.Random;

public class texst {
    public static void main(String[] args) {
        String text = "Wi🌊rd⬜🟩🟫.🐹";

        for (int i = 0; i < text.length(); i++) {
            int unicode = text.codePointAt(i);
            String korrekteDarstellung = Character.toString(unicode);
            String hexZiffern = Integer.toHexString(unicode);

            System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + korrekteDarstellung + " mit Unicode: " + hexZiffern + " ein Emoji: " + Character.isEmoji(unicode));

            if (Character.isEmoji(unicode)) {
                i++;
            }
        }
    }
}
