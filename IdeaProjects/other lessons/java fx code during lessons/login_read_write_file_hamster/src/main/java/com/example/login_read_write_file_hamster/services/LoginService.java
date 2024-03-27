package com.example.login_read_write_file_hamster.services;

import com.example.login_read_write_file_hamster.DTO.User;
import com.example.login_read_write_file_hamster.database.DatabaseConnection;
import com.example.login_read_write_file_hamster.exceptions.NoActiveUserFoundException;
import com.example.login_read_write_file_hamster.exceptions.NoAutoLoginDetectedException;
import com.example.login_read_write_file_hamster.exceptions.UserNotFoundException;
import com.example.login_read_write_file_hamster.exceptions.WrongPasswordException;

import java.time.LocalDate;
import java.time.LocalDateTime;

public class LoginService {

    private DatabaseConnection connection;

    public LoginService(DatabaseConnection connection) {
        this.connection = connection;
    }

    public User createUser(User user) {
        return connection.createUser(user);
    }

    public User doUserLogin(User loginRequestUser) throws UserNotFoundException, WrongPasswordException {
        User databaseUser = connection.findUserByName(loginRequestUser.getUserName());

        if( loginRequestUser.getPassword().equals(databaseUser.getPassword()) ) {

            loginRequestUser.setLastLogin(LocalDateTime.now());
            loginRequestUser.setActive(true);

            return connection.updateUser(loginRequestUser);

        } else {
            throw new WrongPasswordException(databaseUser);
        }
    }

    public User doRememberedUserLogin() throws NoAutoLoginDetectedException {
        return connection.findLatestLoggedInUser();
    }

    public User getActiveUser() throws NoActiveUserFoundException {
        return connection.findActiveUser();
    }

    public User doUserLogout(User user) throws UserNotFoundException {
        user.setActive(false);
        return connection.updateUser(user);
    }

    public DatabaseConnection getConnection() {
        return connection;
    }

    public void setConnection(DatabaseConnection connection) {
        this.connection = connection;
    }
}
