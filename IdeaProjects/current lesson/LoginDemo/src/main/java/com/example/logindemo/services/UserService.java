package com.example.logindemo.services;

import com.example.logindemo.DTO.User;
import com.example.logindemo.datalayer.UserConnection;
import com.example.logindemo.exceptions.UserNotFoundException;
import com.example.logindemo.exceptions.WrongPasswordException;

public class UserService {

    private UserConnection userConnection;

    public UserService() {
        this.userConnection = new UserConnection();
    }

    public User createUser(User user) {
        return userConnection.createUser(user);
    }

    public User doUserLogin(User guiUser) throws WrongPasswordException, UserNotFoundException {
        User databaseUser = userConnection.findUser(guiUser);

        if(guiUser.getPasswort().equals( databaseUser.getPasswort() )) {

            // happy

        } else {
            throw new WrongPasswordException(guiUser);
        }
        return databaseUser;
    }
}
