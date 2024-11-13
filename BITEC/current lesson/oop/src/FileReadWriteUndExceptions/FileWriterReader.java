package FileReadWriteUndExceptions;

import java.io.*;
import java.sql.SQLException;
import java.util.Arrays;
import java.util.Scanner;

public class FileWriterReader {
    public static void main(String[] args) {
        String filePath = "example.txt";
        String content = "This is le content \n i can reed an writ\n dis.";

        try {
            BufferedWriter fileWriter = new BufferedWriter(new FileWriter(filePath));

            fileWriter.write(content);
            fileWriter.append(content);
            fileWriter.flush();


            BufferedReader fileReader = new BufferedReader(new FileReader(filePath));

//            while(true) {
//                String line = fileReader.readLine();
//                System.out.println(line);
//
//                if(line == null) {
//                   break;
//                }
//            }

            String line;
            while( (line = fileReader.readLine()) != null ) {
                System.out.println(line);
            }

            System.out.println("####################################");
            Scanner scanner = new Scanner(new File(filePath));

            while(scanner.hasNextLine()) {
                line = scanner.nextLine();
                System.out.println(line);
            }

            scanner.close();
            fileWriter.close();
            fileReader.close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    //        meineMethode();

//        try {
//            meineMethode();
//
//        } catch (SQLException sqle) { // müssen wir fangen, es steht in der Methodensignatur von meineMethode()
//            System.err.println(sqle.getSQLState());
//
//        } catch (IOException ioe) { // müssen wir fangen, es steht in der Methodensignatur von meineMethode()
//            ioe.printStackTrace();
//
//        }
//        catch (NullPointerException ne) { //können wir fangen, es steht nicht in der Methodensignatur von meineMethode()
//            // Achtung! auch wenn es dort stehne würde, müssten wir es nicht fangen, da es eine Runtime exception ist.
//            System.out.println("wir geben hier den fehler aus");
//            ne.printStackTrace();
//
//        }
//        catch (Exception e) {
//            System.err.println(e.getMessage());
//            e.getStackTrace();
//        }

//        meineMethode();


//    public static void meineMethode() throws IOException {
//
//    }
//     if (filePath.equals("hallo")) {
//        throw new MeineException();
//    }

}
