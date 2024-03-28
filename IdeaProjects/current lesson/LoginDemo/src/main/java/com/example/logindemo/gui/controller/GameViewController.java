package com.example.logindemo.gui.controller;

import com.example.logindemo.gui.MyStageConponents;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;

public class GameViewController {
    @FXML
    private Label welcomeText;

    @FXML
    private Button logoutButton;

    @FXML
    protected void doLogout() {
        new MyStageConponents(logoutButton, "login-view").changeScene();
    }

    public void setWelcomeTextsText(String welcomeTextsText) {
        welcomeText.setText(welcomeTextsText);
    }
}
