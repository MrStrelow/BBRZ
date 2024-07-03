package com.example.login_read_write_file_hamster.services;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class testRegex {
    private static final String EMAIL_REGEX =
            "^[a-zA-Z0-9_+&*-.]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,7}$";

    public static boolean isValidEmail(String email) {
        Pattern pattern = Pattern.compile(EMAIL_REGEX);
        Matcher matcher = pattern.matcher(email);
        return matcher.matches();
    }

    public static void main(String[] args) {
        String[] emails = {
                "example@example.com",      // Valid
                "john.doe@example.co.uk",   // Valid
                "user@domain",              // Invalid (missing top-level domain)
                "user@.com",                // Invalid (missing domain name)
                "@example.com",             // Invalid (missing local part)
                "user@example",             // Invalid (missing top-level domain)
                "user@example_com"          // Invalid (underscore in domain)
        };

        for (String email : emails) {
            System.out.println(email + " is " + (isValidEmail(email) ? "valid" : "invalid"));
        }
    }
}