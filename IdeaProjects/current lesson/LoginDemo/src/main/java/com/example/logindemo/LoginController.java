package com.example.logindemo;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.stage.Stage;

import java.io.IOException;

public class LoginController {
    @FXML
    private Button loginButton;

    @FXML
    private Button registerButton;

    @FXML
    protected void doLogin() {
    }

    @FXML
    protected void doRegister() {
        try {
            Stage stage = (Stage) registerButton.getScene().getWindow();

            FXMLLoader fxmlLoader = new FXMLLoader(LoginApplication.class.getResource("register-view.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 236, 152);
            stage.setTitle("Pleaser Register!");
            stage.setScene(scene);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    @FXML
    protected void doForgotPw() {
    }
}