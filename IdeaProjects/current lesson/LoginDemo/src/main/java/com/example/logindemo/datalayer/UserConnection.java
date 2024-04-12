package com.example.logindemo.datalayer;

import com.example.logindemo.DTO.User;
import com.example.logindemo.exceptions.UserNotFoundException;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class UserConnection {
    private File database;

    public UserConnection() {
        String fileName = "myDataBase.txt";
        database = new File(fileName);

        if (!database.exists()) {
            try {

                database.createNewFile();

            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
    }

    // CRUD (Create Read Update Delete) -> das wollen wir mindestens hier implementieren
    public User createUser(User user) {
        try(UserFileWriter writer = new UserFileWriter(database.getPath(), true)) {

            writer.write(user);

        } catch (IOException e) {
            System.err.println("Error - der User: " + user + " konnte nicht angelegt werden\n" + e.getMessage());
        }

        return user;
    }


    //ACHTUNG! nur komplette guiUser hier übergeben!
    public User updateUser(User guiUser) throws UserNotFoundException {
        try {
            Boolean userFound = false;
            StringBuilder content = new StringBuilder();
            Scanner scanner = new Scanner(database);

            while (scanner.hasNextLine()) {

                String result = scanner.nextLine();
                String[] line = result.split("~");

                String presentUserName = line[0];

                if (presentUserName.equals(guiUser.getUserName())) {
                    content.append(guiUser);
                    userFound = true;
                } else {
                    content.append(result).append("\n");
                }
            }


            FileWriter writer = new FileWriter(database, false);
            writer.write(content.toString());

            writer.close();
            scanner.close();

            if (userFound) {
                return guiUser;
            } else {
                throw new UserNotFoundException(guiUser);
            }

        } catch (IOException e) {
            throw new RuntimeException(e);
        }

    }

    public User findUser(User guiUser) throws UserNotFoundException {
        // aufgrund vom Namen des users suche diesen in der "Datenbank"
        try {

            Scanner scanner = new Scanner(database);

            while (scanner.hasNextLine()) {
                String result = scanner.nextLine();
                String[] line = result.split("~");

                String databaseUserName = line[0];
                String databaseUserPassword = line[1];
                Boolean databaseRememberMe = line[2].equals("true");

                LocalDateTime databaseLastLogin = null;
                if(!line[3].equals("null")) {
                    databaseLastLogin = LocalDateTime.parse(line[3], DateTimeFormatter.ISO_LOCAL_DATE_TIME);
                }

                Boolean databaseIsActive = line[4].equals("true");

                if(databaseUserName.equals(guiUser.getUserName())) {
                    scanner.close();
                    return new User(databaseUserName, databaseUserPassword, databaseRememberMe, databaseLastLogin, databaseIsActive);
                }
            }

            throw new UserNotFoundException(guiUser);

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}
