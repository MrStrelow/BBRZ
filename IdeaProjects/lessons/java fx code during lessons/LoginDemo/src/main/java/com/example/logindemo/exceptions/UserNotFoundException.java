package com.example.logindemo.exceptions;

import com.example.logindemo.DTO.User;

public class UserNotFoundException extends Exception {

    public UserNotFoundException(User user) {
        super("Der User mit dem namen " + user.getUserName() + " konnte nicht in der Datenbank gefunden werden.");
    }
}
