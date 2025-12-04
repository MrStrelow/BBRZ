# Variante 1
def potenz_1(x, z, y=2):
    return x ** y + z

print(potenz_1(z=3, x=2))

# Variante 2
quadrieren_2 = lambda x : x ** 2
print(quadrieren_2(5))


print((lambda x=5 : x ** 2)(5))

# lambda in einer variable ist wie eine normaler funktionsaufruf
print(list(map(quadrieren_2, [1,2,3,4,5]))) # print(a)

# lambda ist wie ein wert - fire and forget
print(list(map(lambda x : x ** 2, [1,2,3,4,5]))) # print(5)

##################################################################
def decorator(funcy): # kümmert sich um aufruf der funtktion funky
    def wrapper(parameter): # kümmert sich um weitergabe der parameter der funktion funky
        print("Vor dem Aufruf von funcy")
        funcy(parameter)
        print("Nach dem Aufruf von funcy")
    
    return wrapper

@decorator(nach_dem_ufruf=True)
def say_hello(name):
    print(f"Hello! {name}")


# wrappy = decorator(say_hello)
# wrappy("Babsi")

say_hello("babsi")
