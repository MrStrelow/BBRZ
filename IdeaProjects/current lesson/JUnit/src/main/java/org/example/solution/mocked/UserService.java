package org.example.solution.mocked;

public class UserService {
    private final UserRepository userRepository;

    public UserService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    public User getUserById(String id) {
        return userRepository.findById(id);
    }

    public void saveUser(User user) {
        // das ist eine guard clause
        if (user.getAge() < 18) {
            throw new IllegalArgumentException("User must be an adult");
        }
        userRepository.save(user);
    }
}
