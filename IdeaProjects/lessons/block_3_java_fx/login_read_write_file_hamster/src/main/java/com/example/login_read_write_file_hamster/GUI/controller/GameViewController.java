package com.example.login_read_write_file_hamster.GUI.controller;

import com.example.login_read_write_file_hamster.Application;
import com.example.login_read_write_file_hamster.DTO.User;
import com.example.login_read_write_file_hamster.database.DatabaseConnection;
import com.example.login_read_write_file_hamster.exceptions.NoActiveUserFoundException;
import com.example.login_read_write_file_hamster.exceptions.UserNotFoundException;
import com.example.login_read_write_file_hamster.services.LoginService;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

import java.io.IOException;

public class GameViewController {

    LoginService loginService = new LoginService(new DatabaseConnection());

    @FXML
    Button logoutButton;

    @FXML
    protected void doLogout() {

        try {
            User user = loginService.getActiveUser();
            loginService.doUserLogout(user);

            Stage stage = (Stage) logoutButton.getScene().getWindow();

            FXMLLoader fxmlLoader = new FXMLLoader(Application.class.getResource("login-view.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 320, 240);

            stage.setTitle("Please log in to start hamstering!");
            stage.setScene(scene);

        } catch (IOException | NoActiveUserFoundException | UserNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

}
