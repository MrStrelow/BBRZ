package org.example.solution.mocked;

public interface UserRepository {
    public User findById(String id);
    public void save(User user);
    public boolean isAvailable();
}