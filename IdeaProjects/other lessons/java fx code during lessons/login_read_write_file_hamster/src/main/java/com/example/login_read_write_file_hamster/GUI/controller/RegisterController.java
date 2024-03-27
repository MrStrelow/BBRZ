package com.example.login_read_write_file_hamster.GUI.controller;

import com.example.login_read_write_file_hamster.Application;
import com.example.login_read_write_file_hamster.DTO.User;
import com.example.login_read_write_file_hamster.database.DatabaseConnection;
import com.example.login_read_write_file_hamster.services.LoginService;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class RegisterController {
    LoginService loginService = new LoginService(new DatabaseConnection());

    private static final String EMAIL_REGEX = "^[a-zA-Z0-9_+&*-.]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,7}$";
    private static final String LOWER_CASE_REGEX = "(?=.*[a-z])";
    private static final String UPPER_CASE_REGEX = "(?=.*[A-Z])";
    private static final String DIGIT_REGEX = "(?=.*\\d)";
    private static final String SPECIAL_CHARACTER_REGEX = "(?=.*[@#$%^&+=])";
    private static final String AT_LEAST_EIGTH_CHARACTERS_REGEX = "(?=.*[a-zA-Z\\d@#$%^&+=]).{8,}";
    private static final String PASSWORD_REGEX =
            "^" +
                LOWER_CASE_REGEX + UPPER_CASE_REGEX + DIGIT_REGEX +
                SPECIAL_CHARACTER_REGEX + AT_LEAST_EIGTH_CHARACTERS_REGEX +
            "$";

    @FXML
    TextField userNameTextField;

    @FXML
    TextField firstPasswordTextField;

    @FXML
    TextField secondPasswordTextField;

    @FXML
    Button createUserButton;

    @FXML
    protected void createUser() {

        boolean failed = false;
        String failedText = "unspecified operation failed!";

        if (userNameTextField.getText().isEmpty()) {
            failedText = "Please enter a username!";
            failed = true;
        }

        if (firstPasswordTextField.getText().isEmpty()) {
            failedText = "Please enter a first password!";
            failed = true;
        }

        if (secondPasswordTextField.getText().isEmpty()) {
            failedText = "Please enter a second password!";
            failed = true;
        }

        if (!isValidEmail(userNameTextField.getText())) {
            failedText = "Please enter a valid mail address (based on:" + EMAIL_REGEX + ")";
            failed = true;
        }

        if (!isValidPassword(firstPasswordTextField.getText())) {
            failedText = "Please enter a valid mail address (based on:" + EMAIL_REGEX + ")";
            failed = true;
        }

        if (!isValidPassword(secondPasswordTextField.getText())) {
            failedText = "Please enter a valid password (based on:" + PASSWORD_REGEX + ")";
            failed = true;
        }

        if (!firstPasswordTextField.getText().equals(secondPasswordTextField.getText())) {
            failedText = "Both, the first and second password must be the same!";
            failed = true;
        }

        if (failed) {

            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle(failedText);
            alert.setHeaderText(null);
            alert.setContentText(failedText);
            alert.showAndWait();

        } else {

            User user = new User(userNameTextField.getText(), firstPasswordTextField.getText(), false, null, false);
            loginService.createUser(user);

            try {
                Stage stage = (Stage) createUserButton.getScene().getWindow();

                FXMLLoader fxmlLoader = new FXMLLoader(Application.class.getResource("login-view.fxml"));
                Scene scene = new Scene(fxmlLoader.load(), 463, 140);

                stage.setTitle("Please log in to start hamstering!");
                stage.setScene(scene);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }

        }

    }

    private boolean isValidEmail(String email) {
        Pattern pattern = Pattern.compile(EMAIL_REGEX);
        Matcher matcher = pattern.matcher(email);
        return matcher.matches();
    }

    private boolean isValidPassword(String password) {
        Pattern pattern = Pattern.compile(PASSWORD_REGEX);
        Matcher matcher = pattern.matcher(password);
        return matcher.matches();
    }

    @FXML
    protected void generatePasswordForUser() {
        //TODO: see first trial exam :)
        String generatedPassword = "aA#7".repeat(2);
        firstPasswordTextField.setText(generatedPassword);
        secondPasswordTextField.setText(generatedPassword);
    }
}
