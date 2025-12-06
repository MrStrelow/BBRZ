from colorama import Fore, Back, Style, init
import time

# # Variante 1
# def potenz_1(x, z, y=2):
#     return x ** y + z

# print(potenz_1(z=3, x=2))

# # Variante 2
# quadrieren_2 = lambda x : x ** 2
# print(quadrieren_2(5))


# print((lambda x=5 : x ** 2)(5))

# # lambda in einer variable ist wie eine normaler funktionsaufruf
# print(list(map(quadrieren_2, [1,2,3,4,5]))) # print(a)

# # lambda ist wie ein wert - fire and forget
# print(list(map(lambda x : x ** 2, [1,2,3,4,5]))) # print(5)

##################################################################
# Definition

# Zuständigkeit: nimm die Parameter des decorators entgegen
def pre_post_call_print(vor_dem_aufruf_only = False):
    # Zuständigkeit: rufe func auf und davor und danach noch andere logik
    def decorator(func):
        # Zuständigkeit: nimm die Parameter der Funktion func entgegen
        def wrapper(*para):
            print("Vor dem Aufruf von func.")
            
            func(*para)

            if not vor_dem_aufruf_only:
                print("Nach dem Aufruf von func.")

        return wrapper
    
    return decorator

# neue schreibweise -> entferne das @ wenn du die alte schreibweise ausprobieren möchtest
@pre_post_call_print(vor_dem_aufruf_only=True)
def greet(postfix):
    print(f"hello {postfix}.")

# neue schreibweise -> entferne das @ wenn du die alte schreibweise ausprobieren möchtest
# @pre_post_call_print(vor_dem_aufruf_only=False)
@pre_post_call_print()
def farwell(prefix, postfix):
    print(f"{prefix} bye {postfix}.")


# main - rufe funktionen auf

# orginal schreibweise - sehr... komplex aber zeigt auf dass funktionen als variablen einer anderen funktion übergeben werden
# decorator = pre_post_call_print(vor_dem_aufruf_only=True)
# wrapper = decorator(greet)
# wrapper("DU")

# neue schreibweise -> braucht das @ neben der funktionsdefinition.
greet("DU")

# orginal schreibweise - sehr... komplex aber zeigt auf dass funktionen als variablen einer anderen funktion übergeben werden
# decorator = pre_post_call_print()
# wrapper = decorator(farwell)
# wrapper("ciao", "DU")

# neue schreibweise -> braucht das @ neben der funktionsdefinition.
farwell("ciao", "DU")

############ ein paar kleine Anwendungen ############

# Einfärben und Text verändern

# Zuständigkeit: rufe func auf und davor und danach noch andere logik
def red(func):
    # Zuständigkeit: nimm die Parameter der Funktion func entgegen
    def wrapper(*para):
        result = func(*para)
        # return f"\u001b[91m{result}\u001b[0m"
        return f"{Fore.RED}{result}{Fore.RESET}"

    return wrapper

# Zuständigkeit: rufe func auf und davor und danach noch andere logik
def bold(func):
    # Zuständigkeit: nimm die Parameter der Funktion func entgegen
    def wrapper(*para):
        return f"\u001b[1m{func(*para)}\u001b[0m"

    return wrapper

@bold
@red
def zahlen_berechnen():
    return 3

# wrapper = red(zahlen_berechnen)
# print(f"hallo das ist mein normaler text {wrapper()}. Ok danke.")

print(f"hallo das ist mein normaler text {zahlen_berechnen()}. Ok danke.")

# Zeitmessung der Funktion
def timing(number_of_repeats = 5):
    def decorator(func):
        def wrapper(*para):

            results = []
            for i in range(number_of_repeats):
                start_time = time.time()
                func(*para)
                end_time = time.time()

                results.append(end_time - start_time)

            average = sum(results) / number_of_repeats
            print(f"The function: {func.__name__} took {average:.3f} second to execute.")

        return wrapper
    return decorator


@timing(number_of_repeats=1000)
def slow_function():
    time.sleep(1)

@timing()
def even_slower_function():
    time.sleep(1.5)


slow_function()
even_slower_function()

# Logging

# authentication