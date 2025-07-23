package com.example.demo;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;

import java.io.IOException;

public class LoginController {
    @FXML
    Button qwertos;

    @FXML
    public void fuehreAusAberWas() {
        qwertos.setText("GEDRÜCKT");
    }

    @FXML
    public void changeSceneUsingHover() throws IOException {
        Stage currentStage = (Stage) qwertos.getScene().getWindow();
        Scene myNewScene = new Scene(new FXMLLoader(HelloApplication.class.getResource("hello-view.fxml")).load());
        currentStage.setScene(myNewScene);
    }
}
