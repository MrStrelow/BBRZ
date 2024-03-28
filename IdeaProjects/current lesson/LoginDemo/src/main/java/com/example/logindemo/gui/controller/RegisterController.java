package com.example.logindemo.gui.controller;

import com.example.logindemo.DTO.User;
import com.example.logindemo.LoginApplication;
import com.example.logindemo.datalayer.UserConnection;
import com.example.logindemo.services.UserService;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.regex.Pattern;

public class RegisterController {

    private UserService userService = new UserService();

    private static final String EMAIL_REGEX = "^[a-zA-Z0-9_+&*-.]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,3}$";
    private static final String LOWER_CASE_REGEX = "(?=.*[a-z])";
    private static final String UPPER_CASE_REGEX = "(?=.*[A-Z])";
    private static final String DIGIT_REGEX = "(?=.*\\d)";
    private static final String SPECIAL_CHARACTER_REGEX = "(?=.*[@#$%^&+=])";
    private static final String AT_LEAST_EIGHT_CHARACTERS_REGEX = "(?=.*[a-zA-Z\\d@#$%^&+=]).{8,}";
    private static final String PASSWORD_REGEX =
            "^" +
                LOWER_CASE_REGEX + UPPER_CASE_REGEX + DIGIT_REGEX +
                SPECIAL_CHARACTER_REGEX + AT_LEAST_EIGHT_CHARACTERS_REGEX +
            "$";
    @FXML
    private TextField userNameTextField;

    @FXML
    private TextField firstPasswordTextField;

    @FXML
    private TextField secondPasswordTextField;

    @FXML
    private Button createUserButton;

    @FXML
    protected void createUser() {
        boolean failed = false;
        String failedText = "unspecified operation failed!";

        String username = userNameTextField.getText();
        String firstPassword = firstPasswordTextField.getText();
        String secondPassword = secondPasswordTextField.getText();

        boolean userNameIsValid = isMailValid(username);
        boolean firstPasswordIsValid = isPasswordValid(firstPassword);
        boolean secondPasswordIsValid = isPasswordValid(secondPassword);

        if (!userNameIsValid) {
            failedText = "Please enter a valid mail address (based on:" + EMAIL_REGEX + ")";
            failed = true;
        }

        if (!firstPasswordIsValid || !secondPasswordIsValid) {
            failedText = "Please enter a valid password (based on:" + PASSWORD_REGEX + ")";
            failed = true;
        }

        if (!firstPassword.equals(secondPassword)) {
            failedText = "Both passwords must be the same!";
            failed = true;
        }

        if (failed) {

            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle(failedText);
            alert.setHeaderText(null);
            alert.setContentText(failedText);
            alert.showAndWait();

        } else {
            // user anlegen und speichern in die "datenbank"
            User user = new User(username, firstPassword);
            userService.createUser(user);

            try {
                Stage stage = (Stage) createUserButton.getScene().getWindow();

                FXMLLoader fxmlLoader = new FXMLLoader(LoginApplication.class.getResource("login-view.fxml"));
                Scene scene = new Scene(fxmlLoader.load(), 460, 150);
                stage.setTitle("Hello, please log-in!");
                stage.setScene(scene);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
    }

    private boolean isMailValid(String username) {
        Pattern mailPattern = Pattern.compile(EMAIL_REGEX);
        return mailPattern.matcher(username).matches();
    }
    
    private boolean isPasswordValid(String password) {
        Pattern passwordPattern = Pattern.compile(PASSWORD_REGEX);
        return passwordPattern.matcher(password).matches();
    }

    @FXML
    protected void generatePasswordForUser() {

    }
}
