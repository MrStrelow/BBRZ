package com.example.logindemo.datalayer;

import com.example.logindemo.DTO.User;
import com.example.logindemo.exceptions.UserNotFoundException;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
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

    public User updateUser(User user) {
        return null;
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

                if(databaseUserName.equals(guiUser.getUserName())) {
                    scanner.close();
                    return new User(databaseUserName, databaseUserPassword);
                }
            }

            throw new UserNotFoundException(guiUser);

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}
