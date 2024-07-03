package com.example.login_read_write_file_hamster.exceptions;

public class NoActiveUserFoundException extends Exception {
    public NoActiveUserFoundException() {
        super("No active user is present in the database.");
    }
}
