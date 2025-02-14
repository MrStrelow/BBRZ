import functools
import time
import os

# ANSI-Farben für die Konsole
class Colors:
    RESET = "\033[0m"
    DEBUG = "\033[94m"   # Blau
    INFO = "\033[92m"    # Grün
    WARNING = "\033[93m" # Gelb
    ERROR = "\033[91m"   # Rot

# Unterstützte Log-Level
LOG_LEVELS = {"debug": 1, "info": 2, "warning": 3, "error": 4}

def Logging(level="info", show_env=True):
    """ Dekorator für Logging mit verschiedenen Log-Leveln. """
    level = level.lower()

    if level not in LOG_LEVELS:
        raise ValueError(f"Ungültiges Log-Level: {level}. Erlaubt: {list(LOG_LEVELS.keys())}")

    def decorator(func):
        @functools.wraps(func)
        def wrapper(*args, **kwargs):
            start_time = time.time()
            user = os.getenv('USER', 'Unbekannt')
            pid = os.getpid()

            log_prefix = f"[{level.upper()}] Funktion: {func.__name__} (PID: {pid}, User: {user if show_env else 'Hidden'})"

            # Farben zuweisen
            if level == "debug":
                color = Colors.DEBUG
            elif level == "info":
                color = Colors.INFO
            elif level == "warning":
                color = Colors.WARNING
            elif level == "error":
                color = Colors.ERROR

            # Loggen der Funktionsaufrufe
            print(f"{color}{log_prefix}{Colors.RESET}")
            if LOG_LEVELS[level] <= 2:  # Zeige Args nur bei DEBUG & INFO
                print(f"{Colors.DEBUG}  Args: {args}{Colors.RESET}")
                print(f"{Colors.DEBUG}  Kwargs: {kwargs}{Colors.RESET}")

            try:
                result = func(*args, **kwargs)
            except Exception as e:
                print(f"{Colors.ERROR}[ERROR] Fehler in {func.__name__}: {e}{Colors.RESET}")
                raise

            elapsed_time = time.time() - start_time
            print(f"{Colors.INFO}[RESULT] Rückgabewert: {result} (Dauer: {elapsed_time:.4f}s){Colors.RESET}")

            return result
        return wrapper
    return decorator
