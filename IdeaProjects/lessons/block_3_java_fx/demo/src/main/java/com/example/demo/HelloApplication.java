package com.example.demo;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

import java.io.IOException;

public class HelloApplication extends Application {
    @Override
    public void start(Stage stage) throws IOException {
        FXMLLoader fxmlLoader = new FXMLLoader(HelloApplication.class.getResource("hello-view.fxml"));
        Scene scene = new Scene(fxmlLoader.load(), 680, 480);
        stage.setTitle("Hello!");
        stage.setScene(scene);
        stage.show();





















//        stage.setTitle("JavaFX ohne Scene Builder");
//
//        // Erstellen eines Buttons
//        Button button = new Button("Klick mich!");
//
//        // Hinzufügen eines Event Listeners für den Button
////        button.setOnAction(event -> {
////            button.setText("Klick ausgeführt!");
////        });
//
////        button.setOnAction(new EventHandler<ActionEvent>() {
////            @Override
////            public void handle(ActionEvent event) {
////                button.setText("asdf");
////            }
////        });
//
//        button.setOnAction(new HelloEventHandler());
//
//        // Layout erstellen und den Button hinzufügen
//        StackPane layout = new StackPane();
//        layout.getChildren().add(button);
//
//        // Szene erstellen und dem Fenster hinzufügen
//        Scene scene = new Scene(layout, 300, 250);
//        stage.setScene(scene);
//
//        // Fenster anzeigen
//        stage.show();
    }

    public static void main(String[] args) {
        launch();
    }
}