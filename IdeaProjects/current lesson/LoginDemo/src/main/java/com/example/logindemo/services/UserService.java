package com.example.logindemo.services;

import com.example.logindemo.DTO.User;
import com.example.logindemo.datalayer.UserConnection;

public class UserService {

    private UserConnection userConnection;

    public UserService() {
        this.userConnection = new UserConnection();
    }

    public User createUser(User user) {
        return userConnection.createUser(user);
    }
}
