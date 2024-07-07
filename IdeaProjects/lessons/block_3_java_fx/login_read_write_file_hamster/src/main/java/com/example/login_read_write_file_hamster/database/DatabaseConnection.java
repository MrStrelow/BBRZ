package com.example.login_read_write_file_hamster.database;

import com.example.login_read_write_file_hamster.DTO.User;
import com.example.login_read_write_file_hamster.exceptions.NoActiveUserFoundException;
import com.example.login_read_write_file_hamster.exceptions.NoAutoLoginDetectedException;
import com.example.login_read_write_file_hamster.exceptions.UserNotFoundException;
import java.io.FileNotFoundException;
import java.time.LocalDateTime;
import java.util.Scanner;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.time.format.DateTimeFormatter;

public class DatabaseConnection {
    private File database;

    public DatabaseConnection() {
        String fileName = "myDataBase.txt";
        database = new File(fileName);

        if (!database.exists()) {
            try {

                database.createNewFile();

            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
    }

    public User findUserByName(String userName) throws UserNotFoundException{
        try {

            Scanner scanner = new Scanner(database);

            while (scanner.hasNextLine()) {
                String result = scanner.nextLine();
                String[] line = result.split("~");

                String presentUserName = line[0];
                String presentUserPassword = line[1];
                boolean presentSaveLogin = line[2].equals("true");

                LocalDateTime presentLastLogin = null;

                if(!line[3].equals("null")) {
                    presentLastLogin = LocalDateTime.parse(line[3], DateTimeFormatter.ISO_LOCAL_DATE_TIME);
                }

                boolean isActive = line[4].equals("true");

                if(presentUserName.equals(userName)) {
                    User user = new User(userName, presentUserPassword, presentSaveLogin, presentLastLogin, isActive);
                    scanner.close();
                    return user;
                }
            }

            throw new UserNotFoundException(userName);

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

    public User createUser(User user) {
        try {

            FileWriter writer = new FileWriter(database.getName(), true);
            writer.write(user.getUserName() + "~" + user.getPassword() + "~" + user.getRememberMe() + "~" + user.getLastLogin() + "~" + user.isActive() + "\n");
            writer.close();

        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }

        return user;
    }

    public User updateUser(User user) throws UserNotFoundException {
        try {
            boolean userFound = false;
            User databaseUser = null;

            Scanner scanner = new Scanner(database);
            StringBuilder content = new StringBuilder();

            while (scanner.hasNextLine()) {
                String result = scanner.nextLine();
                String[] line = result.split("~");

                String presentUserName = line[0];

                if(presentUserName.equals(user.getUserName())) {
                    databaseUser = new User(presentUserName, user.getPassword(), user.getRememberMe(), user.getLastLogin(), user.isActive());
                    content.append(databaseUser).append("\n");
                    userFound = true;
                } else {
                    content.append(result).append("\n");
                }
            }

            scanner.close();

            try {

                FileWriter writer = new FileWriter(database, false);
                writer.write(content.toString());
                writer.close();

            } catch (IOException e) {
                throw new RuntimeException(e);
            }

            if (userFound) {
                return databaseUser;
            } else {
                 throw new UserNotFoundException(user.getUserName());
            }

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

    public User findLatestLoggedInUser() throws NoAutoLoginDetectedException {

        try {

            Scanner scanner = new Scanner(database);

            LocalDateTime earliestLogin = LocalDateTime.of(3000, 1, 1,1,1,1);
            User latestUser = null;

            while (scanner.hasNextLine()) {
                String result = scanner.nextLine();
                String[] line = result.split("~");

                boolean rememberIteratedUser = line[2].equals("true");

                LocalDateTime iteratedUserLoginDate = LocalDateTime.of(3000, 1, 1, 1,1,1);;

                if(!line[3].equals("null")) {
                    iteratedUserLoginDate = LocalDateTime.parse(line[3], DateTimeFormatter.ISO_LOCAL_DATE_TIME);
                }

                if(rememberIteratedUser && iteratedUserLoginDate.isBefore(earliestLogin)) {
                    latestUser = new User(line[0], line[1], true, iteratedUserLoginDate, true);
                    earliestLogin = latestUser.getLastLogin();
                }
            }

            scanner.close();

            if (latestUser == null) {
                throw new NoAutoLoginDetectedException();
            } else {
                return latestUser;
            }

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }

    }

    public User findActiveUser() throws NoActiveUserFoundException {
        try {

            Scanner scanner = new Scanner(database);
            User user = null;

            while (scanner.hasNextLine()) {
                String result = scanner.nextLine();
                String[] line = result.split("~");

                String presentUserName = line[0];
                String presentUserPassword = line[1];
                boolean presentSaveLogin = line[2].equals("true");

                LocalDateTime presentLastLogin = null;

                if(!line[3].equals("null")) {
                    presentLastLogin = LocalDateTime.parse(line[3], DateTimeFormatter.ISO_LOCAL_DATE_TIME);
                }

                boolean isActive = line[4].equals("true");

                if(isActive) {
                    user = new User(presentUserName, presentUserPassword, presentSaveLogin, presentLastLogin, isActive);
                    scanner.close();
                    return user;
                }


            }

            throw new NoActiveUserFoundException();

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}
