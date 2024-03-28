package com.example.logindemo.gui;

import javafx.scene.control.Alert;

public class MyAlert {
    public static void initAlert(String displayText) {
        Alert alert = new Alert(Alert.AlertType.ERROR);
        alert.setResizable(true);
        alert.setTitle(displayText);
        alert.setHeaderText(null);
        alert.setContentText(displayText);
        alert.showAndWait();
    }
}
