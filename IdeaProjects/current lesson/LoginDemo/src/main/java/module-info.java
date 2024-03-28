module com.example.logindemo {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.logindemo to javafx.fxml;
    exports com.example.logindemo;
    exports com.example.logindemo.gui.controller;
    opens com.example.logindemo.gui.controller to javafx.fxml;
}