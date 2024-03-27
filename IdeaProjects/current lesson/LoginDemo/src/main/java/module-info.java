module com.example.logindemo {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.logindemo to javafx.fxml;
    exports com.example.logindemo;
}