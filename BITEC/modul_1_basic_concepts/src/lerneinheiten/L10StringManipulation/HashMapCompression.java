package lerneinheiten.L10StringManipulation;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.*;

public class HashMapCompression {
    public static void main(String[] args) throws IOException {
        String text = Files.readString(Path.of("src/lerneinheiten/L10StringManipulation/A.java"));

        System.out.println("Original text: " + text);

        // Standard HashMap Compression (Absolute Positions)
        int originalSize = text.length() * 2; // Annahme!: UTF-16 (2 bytes per char)

        Map<Character, List<Byte>> map;
        String decodedText;

        if (text.length() < 127) {
            System.out.println("using: hashmap");
            map = compressUsingHashMap(text);
            decodedText = decodeFromHashMap(map, text.length());

        } else {
            System.out.println("using: hashmap + delta");
            map = compressUsingDeltaEncoding(text);
            decodedText = decodeFromDeltaEncoding(map, text.length());
        }

        System.out.println("Decoded text: " + decodedText);
        System.out.println("Decoding successful: " + text.equals(decodedText));

        int compressedSize = calculateSize(map, 1); // byte positions (1 byte each)
        System.out.println("[HashMap Compression] Original: " + originalSize + " bytes, Compressed: " + compressedSize + " bytes");
    }

    // Basic HashMap Compression: Stores absolute positions
    public static Map<Character, List<Byte>> compressUsingHashMap(String text) {
        Map<Character, List<Byte>> map = new HashMap<>();
        for (byte i = 0; i < text.length(); i++) {
            char c = text.charAt(i);
            map.putIfAbsent(c, new ArrayList<>());
            map.get(c).add(i);
        }
        return map;
    }

    // Enhanced Delta Encoding (Storing Differences)
    public static Map<Character, List<Byte>> compressUsingDeltaEncoding(String text) {
        Map<Character, List<Byte>> map = new HashMap<>();

        for (int i = 0; i < text.length(); i++) {
            char c = text.charAt(i);
            map.putIfAbsent(c, new ArrayList<>());
//            List<Number> list = map.get(c);
            List<Byte> list = map.get(c);

            if (list.isEmpty()) {
                list.add((byte) i); // First position stored normally

            } else {
                int lower = 0;

                for (byte position : list) {
                    lower += position;
                }

                int delta = i - lower;

                if (-128 <= delta && delta <= 127) {
                    list.add((byte) delta);

                } else {
                    System.err.println("Delta außerhalb von '-128 <= delta && delta <= 127'");
                }
            }
        }
        return map;
    }

    // Decodes the text from the HashMap compression
    public static String decodeFromHashMap(Map<Character, List<Byte>> map, int length) {
        char[] decodedText = new char[length];
        for (Map.Entry<Character, List<Byte>> entry : map.entrySet()) {
            char c = entry.getKey();
            for (int index : entry.getValue()) {
                decodedText[index] = c;
            }
        }
        return new String(decodedText);
    }

    // Decodes the text from the Delta Encoding compression
    public static String decodeFromDeltaEncoding(Map<Character, List<Byte>> deltaMap, int length) {
        char[] decodedText = new char[length];
        for (Map.Entry<Character, List<Byte>> entry : deltaMap.entrySet()) {
            char c = entry.getKey();
            List<Byte> deltas = entry.getValue();
            int position = deltas.get(0) & 0xFF; // Initial absolute position
            decodedText[position] = c;

            for (int i = 1; i < deltas.size(); i++) {
                position += deltas.get(i); // Apply delta
                decodedText[position] = c;
            }
        }
        return new String(decodedText);
    }

    // Calculates storage size
    public static <T> int calculateSize(Map<Character, List<T>> map, int bytesPerEntry) {
        int size = 0;
        for (Map.Entry<Character, List<T>> entry : map.entrySet()) {
            size += 2; // 2 bytes per character key
            size += entry.getValue().size() * bytesPerEntry;
        }
        return size;
    }
}
