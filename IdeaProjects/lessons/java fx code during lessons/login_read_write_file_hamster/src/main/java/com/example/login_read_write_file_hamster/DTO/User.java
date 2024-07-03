package com.example.login_read_write_file_hamster.DTO;

import java.time.LocalDate;
import java.time.LocalDateTime;

public class User {
    private String userName;
    private String password;
    private Boolean rememberMe;
    private LocalDateTime lastLogin;
    private boolean isActive;

    public User(String userName, String password, boolean rememberMe, LocalDateTime lastLogin, boolean isActive) {
        this.userName = userName;
        this.password = password;
        this.rememberMe = rememberMe;
        this.lastLogin = lastLogin;
        this.isActive = isActive;
    }

    public String toString() {
        return userName + "~" + password + "~" + rememberMe + "~" + lastLogin + "~" + isActive;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public LocalDateTime getLastLogin() {
        return lastLogin;
    }

    public void setLastLogin(LocalDateTime lastLogin) {
        this.lastLogin = lastLogin;
    }

    public Boolean getRememberMe() {
        return rememberMe;
    }

    public void setRememberMe(Boolean rememberMe) {
        this.rememberMe = rememberMe;
    }

    public boolean isActive() {
        return isActive;
    }

    public void setActive(boolean active) {
        isActive = active;
    }
}
