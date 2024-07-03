package com.example.login_read_write_file_hamster;

import com.example.login_read_write_file_hamster.DTO.User;
import com.example.login_read_write_file_hamster.database.DatabaseConnection;
import com.example.login_read_write_file_hamster.exceptions.NoAutoLoginDetectedException;
import com.example.login_read_write_file_hamster.exceptions.UserNotFoundException;
import com.example.login_read_write_file_hamster.exceptions.WrongPasswordException;
import com.example.login_read_write_file_hamster.services.LoginService;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;

public class Application extends javafx.application.Application {
    @Override
    public void start(Stage stage) throws IOException {
        LoginService loginService = new LoginService(new DatabaseConnection());

        FXMLLoader fxmlLoader;

        try {

            User user = loginService.doRememberedUserLogin();
            loginService.doUserLogin(user);
            fxmlLoader = new FXMLLoader(Application.class.getResource("game-view.fxml"));

        } catch (NoAutoLoginDetectedException e) {
            fxmlLoader = new FXMLLoader(Application.class.getResource("login-view.fxml"));
            System.out.println(e.getMessage());
        } catch (UserNotFoundException | WrongPasswordException e) {
            throw new RuntimeException(e);
        }

        Scene scene = new Scene(fxmlLoader.load(), 463, 140);
        stage.setTitle("Please log in to start hamstering!");
        stage.setScene(scene);
        stage.show();
    }

    public static void main(String[] args) {
        launch();
    }
}