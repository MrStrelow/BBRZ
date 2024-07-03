package com.example.demo;

import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.scene.transform.Rotate;
import javafx.util.Duration;

public class HelloController {
    @FXML
    private Label welcomeText;

    @FXML
    private Button onlyButton;

    @FXML
    private Button otherButton;

    @FXML
    private VBox myOnlyBox;

    private double winkel = 0.;

    @FXML
    protected void onHelloButtonClick() {
        winkel += 90.;
        onlyButton.setRotate(winkel);
        welcomeText.setText("Welcome to JavaFX Application!");
    }

    @FXML
    protected void onHelloButtonInfinityClick() {
        // na fast infinity aber machen wir mal 100
        Timeline timeline = new Timeline();
        timeline.setCycleCount(100);
        timeline.getKeyFrames().add(
                new KeyFrame(Duration.seconds(0.1), event1 -> {
                    otherButton.getTransforms().add(new Rotate(65));
                })
        );
        timeline.play();
    }

    @FXML
    protected void vboxlClick() {
        winkel+=130.;
        for ( Node element : myOnlyBox.getChildren() ) {
            element.setRotate(winkel);
        }
    }

    @FXML
    protected void onHelloLabelClick() {
        welcomeText.setText("");
    }
}