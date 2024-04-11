package com.example.logindemo.DTO;

import java.time.LocalDateTime;

public class User {
    private String userName; // irgendwas mit dem wir suche koennen -> eine ID
    private String passwort;

    private Boolean rememberMe;

    private LocalDateTime lastLogin;

    private Boolean isActive;

    public User(String userName, String passwort, Boolean rememberMe, LocalDateTime lastLogin, Boolean isActive) {
        this.userName = userName;
        this.passwort = passwort;
        this.rememberMe = rememberMe;
        this.lastLogin = lastLogin;
        this.isActive =  isActive;
    }

    public String toString() {
        return userName + "~" + passwort + "~" + rememberMe + "~" + lastLogin + "~" + isActive + "\n";
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

    public Boolean getRememberMe() {
        return rememberMe;
    }

    public void setRememberMe(Boolean rememberMe) {
        this.rememberMe = rememberMe;
    }

    public LocalDateTime getLastLogin() {
        return lastLogin;
    }

    public void setLastLogin(LocalDateTime lastLogin) {
        this.lastLogin = lastLogin;
    }

    public Boolean getActive() {
        return isActive;
    }

    public void setActive(Boolean active) {
        isActive = active;
    }
}
