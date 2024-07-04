package org.example;

import org.example.solution.mocked.User;
import org.example.solution.mocked.UserRepository;
import org.example.solution.mocked.UserService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import static org.mockito.internal.verification.VerificationModeFactory.times;

@ExtendWith(MockitoExtension.class)
public class UserServiceTest {
    private final String NAME = "Dubi Doe Joe";
    private UserService userService;

    // Hier sagen wir, erstelle einen Mock von dem userRepository.
    @Mock
    private UserRepository userRepository;

    // Da wir bei der initialisierung des userServices ein userRepository brauchen welches nicht null ist,
    // können wir hier eine art initialisierungs methode definieren, in der unser userService mit dem Mock angelegt wird.
    @BeforeEach
    void setUp() {
        MockitoAnnotations.openMocks(this);
        userService = new UserService(userRepository);
    }

    // TODO: teste hier wenn die findById Methode lege dazu einen User an und verwende folgende Logik.
    // Mockitos when() erlaubt uns eine gemocktes Objekt, welches quasi null ist, zu befüllen.
    // Wir sagen innerhalb von when() dass falls ein User mit der id = "1" mit dem repository gesucht wird.
    // Wir sagen dazu userRepository.findById("1"); aber innerhalb der when methode.
    // Die Rückgabe von when() erlaubt uns nun die konsequenz dieses "when" zu erstellen, indem wir thenReturn() mit unserem mockUser aufrufen.
    // Wir haben dann vor wenn wir nach id="1" suchen, dann soll unser mockUser zurückgegeben werden.
    // Das definiert unseren gemocktes userRepository für genau diesen einen Fall.
    @Test
    void testGetUserById() {
        User mockUser = new User("1", NAME, 28);
        //TODO: impement when() and thenResturn()

        // TODO: verwende nun den UserService und suche nach einem User welcher die id="1" hat.
        // Dadruch dass wir hier einen gemocktes UserRepository für den Fall id="1" angelegt haben,
        // wird der userService nun dieses gemockte UserRepository verwenden! (wir haben das in der setUp Methode so angelegt)

        // TODO: frage ab ob der User not null ist mit asserNotNull
        // Wir können nun mit JUnit's asserNotNull abfragen ob dieser User eben not null ist.

        // TODO: frage nach ob der retournierte User den user Namen "Dubi Doe Joe" welches in der variable NAME gespeichter ist.

        //TODO: verwende verify() um abzufragen wie oft die methode aufgerufen wurde. verify hat als erstes Argument das gemockte Objekt
        // und das zweite wie oft der Aufruf statt gefunden hat.
    }

    // TODO: teste nun die saveUser Methode mit dem user mit id="2".
    @Test
    void testSaveUser() {
    }

    // TODO: teste ob eine Exception geworfen wird welche ein IllegalArugument erzeugt bei der Methode saveUser.
    // dazu ist ein User mit alter < 18 zu übergeben.
    @Test
    void testSaveUserUnderage() {

    }
}
