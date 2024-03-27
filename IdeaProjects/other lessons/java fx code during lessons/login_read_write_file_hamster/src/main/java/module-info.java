module com.example.login_read_write_file_hamster {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.login_read_write_file_hamster to javafx.fxml;
    exports com.example.login_read_write_file_hamster;
    exports com.example.login_read_write_file_hamster.GUI.controller;
    opens com.example.login_read_write_file_hamster.GUI.controller to javafx.fxml;
}