package com.example.logindemo.gui;

import com.example.logindemo.LoginApplication;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;

public class MyStageConponents {
    private Scene scene;
    private Stage stage;
    private FXMLLoader fxmlLoader;
    private Node javafxElement;
    private Object controller;

    public MyStageConponents(Node javafxElement, String view) {
        try {
            this.javafxElement = javafxElement;
            stage = (Stage) javafxElement.getScene().getWindow();
            fxmlLoader = new FXMLLoader(LoginApplication.class.getResource(view + ".fxml"));
            scene = new Scene(fxmlLoader.load());
            controller = fxmlLoader.getController();

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public void changeScene() {
        stage.setScene(scene);
    }

    public <T> T getController() {
        return (T) controller;
    }

    public Stage getStage() {
        return stage;
    }
}
