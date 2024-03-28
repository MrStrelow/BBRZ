package com.example.logindemo.gui.controller;

import com.example.logindemo.DTO.User;
import com.example.logindemo.LoginApplication;
import com.example.logindemo.exceptions.UserNotFoundException;
import com.example.logindemo.exceptions.WrongPasswordException;
import com.example.logindemo.services.UserService;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.io.IOException;

public class LoginController {
    private UserService userService = new UserService();

    @FXML
    private Button loginButton;

    @FXML
    private Button registerButton;

    @FXML
    private TextField passwordTextField;

    @FXML
    private TextField usernameTextField;

    @FXML
    protected void doLogin() {
        User guiUser = new User(usernameTextField.getText(), passwordTextField.getText());

        try {

            User databaseUser = userService.doUserLogin(guiUser);

            Stage stage = (Stage) loginButton.getScene().getWindow();

            FXMLLoader fxmlLoader = new FXMLLoader(LoginApplication.class.getResource("game-view.fxml"));

            Scene scene = new Scene(fxmlLoader.load(), 800, 400);
            stage.setTitle("Welcome " + databaseUser.getUserName() + "!");

            GameViewController gameViewController = fxmlLoader.getController();
            gameViewController.setWelcomeTextsText("Welcome " + databaseUser.getUserName() + "!");

            stage.setScene(scene);

        }
        catch (WrongPasswordException | UserNotFoundException e) {

            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Username does not exist or password entered is wrong");
            alert.setHeaderText(null);
            alert.setContentText("Username does not exist or password entered is wrong");
            alert.showAndWait();

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
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