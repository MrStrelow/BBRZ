package com.example.logindemo.gui.controller;

import com.example.logindemo.DTO.User;
import com.example.logindemo.exceptions.UserNotFoundException;
import com.example.logindemo.exceptions.WrongPasswordException;
import com.example.logindemo.gui.MyStageConponents;
import com.example.logindemo.services.UserService;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import com.example.logindemo.gui.MyAlert;

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

            MyStageConponents stageComponents = new MyStageConponents(loginButton, "game-view");
            GameViewController gameViewController = stageComponents.getController();

            String welcomeText = "Welcome " + databaseUser.getUserName() + "!";

            gameViewController.setWelcomeTextsText(welcomeText);
            stageComponents.getStage().setTitle(welcomeText);

            stageComponents.changeScene();

        }
        catch (WrongPasswordException e) {
            MyAlert.initAlert("Entered password is wrong.");
        }
        catch (UserNotFoundException e){
            MyAlert.initAlert("User does not exist in the database.");
        }
    }

    @FXML
    protected void doRegister() {
        new MyStageConponents(registerButton, "register-view").changeScene();
    }

    @FXML
    protected void doForgotPw() {
    }
}