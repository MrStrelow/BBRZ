package com.example.logindemo.datalayer;

import com.example.logindemo.DTO.User;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

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

        return null;
    }

    public User updateUser(User user) {
        return null;
    }

    public User findUser(User user) {
        return null;
    }
}
