package com.example.logindemo.gui.controller;

import com.example.logindemo.gui.MyStageConponents;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.GridPane;

import java.util.Random;

public class GameViewController {
    @FXML
    private Label welcomeText;

    @FXML
    private Button logoutButton;

    @FXML
    private GridPane gameGrid;

    @FXML
    protected void doLogout() {
        new MyStageConponents(logoutButton, "login-view").changeScene();
    }

    public void setWelcomeTextsText(String welcomeTextsText) {
        welcomeText.setText(welcomeTextsText);
    }

    @FXML
    public void initialize() {
        Image sad = new Image("sad.jpg");
        Image happy = new Image("happy.jpg");

        Image[] sadOrHappy = {sad, happy};

        Integer ncols = gameGrid.getColumnCount();
        Integer nrows = gameGrid.getRowCount();

        Random random = new Random();


//        for (int col = 0; col < ncols; col++) {
//            for (int row = 0; row < nrows; row++) {
//                ImageView imageView = new ImageView(sadOrHappy[random.nextInt(sadOrHappy.length)]);
//
////                imageView.setPreserveRatio(true);
//
//                imageView.setFitWidth(gameGrid.getWidth() / (ncols*30));
//                imageView.setFitHeight(gameGrid.getHeight() / (nrows*30));
//
//                imageView.addEventHandler(MouseEvent.MOUSE_ENTERED, event -> handleMouseEnter(imageView));
//                imageView.addEventHandler(MouseEvent.MOUSE_EXITED, event -> handleMouseExit(imageView));
//
//                gameGrid.add(imageView, col, row);
//            }
//        }
    }

//    private void handleMouseEnter(Node node) {
//        System.out.println("Mouse entered grid cell: " + GridPane.getRowIndex(node) + ", " + GridPane.getColumnIndex(node));
//    }
//
//    private void handleMouseExit(Node node) {
//        System.out.println("Mouse exited grid cell: " + GridPane.getRowIndex(node) + ", " + GridPane.getColumnIndex(node));
//    }

    @FXML
    protected void toggleState() {


//        imageView.setFitHeight(80);
//        imageView.setFitHeight(80);


//        sadLabel.setGraphic(sadView);
//        happyLabel.setGraphic(happyView);
//        happyLabel.setBackground(new Background(new BackgroundFill(Color.LIGHTBLUE, null, null)));
    }
}
