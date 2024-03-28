package com.example.logindemo.datalayer;

import com.example.logindemo.DTO.User;

import java.io.FileWriter;
import java.io.IOException;

public class UserFileWriter extends FileWriter {
    public UserFileWriter(String fileName, boolean append) throws IOException {
        super(fileName, append);
    }

    public void write(User user) throws IOException {
        super.write(user.toString());
    }
}
