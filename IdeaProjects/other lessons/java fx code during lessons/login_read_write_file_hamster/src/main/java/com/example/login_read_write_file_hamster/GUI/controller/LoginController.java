package com.example.login_read_write_file_hamster.GUI.controller;

import com.example.login_read_write_file_hamster.Application;
import com.example.login_read_write_file_hamster.DTO.User;
import com.example.login_read_write_file_hamster.database.DatabaseConnection;
import com.example.login_read_write_file_hamster.exceptions.UserNotFoundException;
import com.example.login_read_write_file_hamster.exceptions.WrongPasswordException;
import com.example.login_read_write_file_hamster.services.LoginService;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.*;
import javafx.stage.Stage;
import javafx.scene.Scene;

import java.io.IOException;

public class LoginController {
    private LoginService loginService = new LoginService(new DatabaseConnection());

    @FXML
    ButtonBar buttonBar;

    @FXML
    Button loginButton;

    @FXML
    Button registerButton;

    @FXML
    Button forgotPwButton;

    @FXML
    TextField passwordTextField;

    @FXML
    TextField usernameTextField;

    @FXML
    CheckBox rememberMeCheckBox;

    @FXML
    protected void doLogin() {
        User user = new User( usernameTextField.getText(), passwordTextField.getText(), rememberMeCheckBox.isSelected(), null, true );

        try {
            loginService.doUserLogin(user);

            Stage stage = (Stage) loginButton.getScene().getWindow();

            FXMLLoader fxmlLoader = new FXMLLoader(Application.class.getResource("game-view.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 320, 240);

            stage.setTitle("Welcome " + user.getUserName());
            stage.setScene(scene);

        } catch (UserNotFoundException | WrongPasswordException e) {

            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Username does not exist or password entered is wrong");
            alert.setHeaderText(null);
            alert.setContentText("Username does not exist or password entered is wrong");
            alert.showAndWait();

            throw new RuntimeException(e);

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    @FXML
    protected void doForgotPw() {
    // "write email with link to create new password" -> just show the password in a window.
    }

    @FXML
    protected void doRegister() {
        try {
            Stage stage = (Stage) registerButton.getScene().getWindow();

            FXMLLoader fxmlLoader = new FXMLLoader(Application.class.getResource("register-view.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 236, 152);

            stage.setTitle("Pleaser Register!");
            stage.setScene(scene);

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}