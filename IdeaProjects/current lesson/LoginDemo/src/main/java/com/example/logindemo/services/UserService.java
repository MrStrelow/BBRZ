package com.example.logindemo.services;

import com.example.logindemo.datalayer.UserConnection;

public class UserService {

    private UserConnection userConnection;

    public UserService() {
        this.userConnection = new UserConnection();
    }
}
