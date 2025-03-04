import colorama
from colorama import init, Fore, Style

def bold(func):
    def wrapper(*arg):
        return f"\u001b[1m{func(*arg)}\u001b[0m"
        
    return wrapper

def italic():
    pass

def red(func):
    def wrapper(*arg):
        return f"\u001b[91m{func(*arg)}\u001b[0m"
        # return f"{Fore.RED}{func(*arg)}{Style.RESET_ALL}"

    return wrapper


######### main #########
@red
@bold
def greet():
    return greet_unstylisch()

@red
def greet_red():
    return greet_unstylisch()

def greet_unstylisch():
    return "Hello"

print(greet())
print(greet_red())
print(greet_unstylisch())
