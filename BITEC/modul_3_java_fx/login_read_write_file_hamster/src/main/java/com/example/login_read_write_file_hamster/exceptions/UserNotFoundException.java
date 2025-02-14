package com.example.login_read_write_file_hamster.exceptions;

import com.example.login_read_write_file_hamster.DTO.User;

public class UserNotFoundException extends Exception {
    public UserNotFoundException(String userName) {
        super("User with username: " + userName + " is not present in the database.");
    }
}
