package com.example.logindemo.gui.controller;

import com.example.logindemo.LoginApplication;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.stage.Stage;

import java.io.IOException;

public class GameViewController {
    @FXML
    private Label welcomeText;

    @FXML
    private Button logoutButton;

    @FXML
    protected void doLogout() {
        try {

            Stage stage = (Stage) logoutButton.getScene().getWindow();
            FXMLLoader fxmlLoader = new FXMLLoader(LoginApplication.class.getResource("login-view.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 800, 400);
            stage.setTitle("Please log in!");
            stage.setScene(scene);

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public void setWelcomeTextsText(String welcomeTextsText) {
        welcomeText.setText(welcomeTextsText);
    }
}
