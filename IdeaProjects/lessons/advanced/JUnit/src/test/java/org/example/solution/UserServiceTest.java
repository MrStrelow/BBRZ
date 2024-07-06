package org.example.solution;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import static org.mockito.internal.verification.VerificationModeFactory.times;

import org.example.solution.mocked.User;
import org.example.solution.mocked.UserRepository;
import org.example.solution.mocked.UserService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.mockito.junit.jupiter.MockitoExtension;

@ExtendWith(MockitoExtension.class)
public class UserServiceTest {

    private final String NAME = "Dubi Doe Joe";
    private UserService userService;

    @Mock
    private UserRepository userRepository;

    @BeforeEach
    void setUp() {
        MockitoAnnotations.openMocks(this);
        userService = new UserService(userRepository);
    }

    @Test
    void testGetUserById() {
        User mockUser = new User("1", NAME, 28);
        when(userRepository.findById("1")).thenReturn(mockUser);

        User userSolution = userService.getUserById("1");

        assertNotNull(userSolution);
        assertEquals(NAME, userSolution.getName());

        verify(userRepository, times(1)).findById("1");
    }

    @Test
    void testSaveUser() {
        User userSolution = new User("2", NAME, 20);

        userService.saveUser(userSolution);

        verify(userRepository, times(1)).save(userSolution);
    }

    @Test
    void testSaveUserUnderage() {
        User userSolution = new User("3", NAME, 17);

        Exception exception = assertThrows(IllegalArgumentException.class, () -> userService.saveUser(userSolution));
        assertEquals("User must be an adult", exception.getMessage());

        verify(userRepository, times(0)).save(userSolution);
    }
}
