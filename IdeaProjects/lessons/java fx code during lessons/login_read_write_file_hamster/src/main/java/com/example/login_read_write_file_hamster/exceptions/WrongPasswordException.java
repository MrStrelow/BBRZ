package com.example.login_read_write_file_hamster.exceptions;

import com.example.login_read_write_file_hamster.DTO.User;

public class WrongPasswordException extends Exception {
    public WrongPasswordException(User user) {
        super("User with username: " + user.getUserName() + " entered the wrong password - " + user.getPassword() );
    }
}
