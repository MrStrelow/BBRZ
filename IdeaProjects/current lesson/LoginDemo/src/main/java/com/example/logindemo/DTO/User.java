package com.example.logindemo.DTO;

public class User {
    private String userName; // irgendwas mit dem wir suche koennen -> eine ID
    private String passwort;

    public User(String userName, String passwort) {
        this.userName = userName;
        this.passwort = passwort;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getPasswort() {
        return passwort;
    }

    public void setPasswort(String passwort) {
        this.passwort = passwort;
    }
}
