package com.example.login_read_write_file_hamster.exceptions;

public class NoAutoLoginDetectedException extends Exception {
    public NoAutoLoginDetectedException() {
        super("No automatic login possible. No User logged in on this device.");
    }
}
