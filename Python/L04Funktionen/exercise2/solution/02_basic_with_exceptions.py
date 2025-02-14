from functools import wraps
import time
import os
import socket

# ANSI-Farben für die Konsole
class Colors:
    RESET = "\033[0m"
    BLUE = "\033[94m"
    GREEN = "\033[92m"
    YELLOW = "\033[93m"
    RED = "\033[91m"
    CYAN = "\033[96m"

def Logging(level="info", show_env=False):
    """ Dekorator für Logging mit farbiger Konsolenausgabe und Fehlerbehandlung. """
    def decorator(func):

        @wraps(func)
        def wrapper(*args, **kwargs):
            # Vor dem Funktionsaufruf
            start_time = time.time()
            user = os.getlogin()  # Get login name of user
            pid = os.getpid()  # Process id
            IP = socket.gethostbyname(socket.gethostname())
            
            # Argumente und Umgebung ausgeben
            print(f"{Colors.CYAN}[LOG] Funktion: {func.__name__} (PID: {pid}, User: {user if show_env else 'Hidden'}, IP: {IP if show_env else 'Hidden'}){Colors.RESET}")
            print(f"{Colors.BLUE}  Args: {args}{Colors.RESET}")
            print(f"{Colors.BLUE}  Kwargs: {kwargs}{Colors.RESET}")

            try:
                # Funktionsaufruf
                result = func(*args, **kwargs)
                
                # Nach dem Funktionsaufruf
                elapsed_time = time.time() - start_time
                print(f"{Colors.GREEN}[RESULT] Rückgabewert: {result} (Dauer: {elapsed_time:.4f}s){Colors.RESET}")
                
                return result
            
            except Exception as e:
                # Fehlerbehandlung
                print(f"{Colors.RED}[ERROR] Fehler in Funktion '{func.__name__}': {e}{Colors.RESET}")
                return None  # or re-raise, or handle the error as desired
        
        return wrapper
    
    return decorator

# Umständliche Nutzung
def add(first, second):
    return first + second

decorator = Logging(level="verbose", show_env=True)

wrapper = decorator(add)
wrapper(3, 5)
wrapper(first=3, second=5)

# Einfache Nutzung
@Logging(level="verbose", show_env=True)
def add(first, second):
    return first + second

add(first=3, second=5)
add(second=5, first=3)
add(3, 5)

# Example that will cause an error
@Logging(level="verbose", show_env=True)
def divide(a, b):
    return a / b

divide(10, 0)  # This will trigger an exception and be handled in the decorator
