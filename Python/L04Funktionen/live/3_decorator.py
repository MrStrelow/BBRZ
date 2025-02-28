def decorator(func):
    print("Vor der Funktionsausführung")
    func()
    print("Nach der Funktionsausführung")


def say_hello():
    print("Hallo!")

decorator(say_hello)