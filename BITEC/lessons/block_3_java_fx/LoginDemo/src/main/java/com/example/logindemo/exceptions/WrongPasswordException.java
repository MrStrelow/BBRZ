package com.example.logindemo.exceptions;

import com.example.logindemo.DTO.User;

public class WrongPasswordException extends Exception {
    public WrongPasswordException(User user) {
        super("Der User mit dem namen " + user.getUserName() + " hat ein falsches passwort (sehr geheim: " + user.getPasswort() + ") angegeben.");
    }
}
