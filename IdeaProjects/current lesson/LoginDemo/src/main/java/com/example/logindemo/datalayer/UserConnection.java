package com.example.logindemo.datalayer;

import java.io.File;
import java.io.IOException;

public class UserConnection {
    private File database;

    public UserConnection() {
        String fileName = "myDataBase.txt";
        database = new File(fileName);

        try {

            database.createNewFile();

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
