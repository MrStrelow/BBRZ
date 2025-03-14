def print_davor_und_danach(nur_vor_der_Funktion):
    def decorator(func):
        def wrapper(*args):
            print("Vor der Funktionsausführung")
            func(*args)

            if not nur_vor_der_Funktion:
                print("Nach der Funktionsausführung")

        return wrapper
    
    return decorator


@print_davor_und_danach(False)
def say_hello(eins, zwei):
    print(f"{eins}, Hallo! {zwei}")


@print_davor_und_danach(True)
def say_bye():
    print("Bye!")


####################### Main #######################
# decorator = print_davor_und_danach(True)
# wrapper = decorator(say_hello)
# wrapper("Du, ", "Wie gehts?")

say_hello("Du, ", "Wie gehts?")
say_bye()