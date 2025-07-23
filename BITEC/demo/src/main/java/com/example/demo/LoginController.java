package com.example.demo;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.input.MouseEvent;

public class LoginController {
    @FXML
    Button qwertos;

    @FXML
    public void fuehreAusAberWas() {
        qwertos.setText("GEDRÜCKT");
    }

    @FXML
    public void changeText() {
        qwertos.setText("ok nochmal GEDRÜCKT");
    }
}
