package FileReadWriteUndExceptions;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class BetterFileWriterReader {
    public static void main(String[] args) {
        try {
            Path path = Path.of("excample.txt");
            StringBuilder textToWrite = new StringBuilder("as it was written...");

            // write
            Files.writeString(path, textToWrite);

            // read
            System.out.println(Files.readString(path));

            // kürzer, meist besser - aber weniger genau.
            BufferedReader reader = Files.newBufferedReader(path);

            // BufferedReader reader = new BufferedReader(new FileReader(new File(filePath)));
            // BufferedReader reader = new BufferedReader(new InputStreamReader(new FileInputStream(path.toString())));

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
