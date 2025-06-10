import functools
import logging
import os
import time
import json
import matplotlib.pyplot as plt

# Logging-Konfiguration
logging.basicConfig(filename="logfile.log", level=logging.DEBUG, 
                    format="%(asctime)s - %(levelname)s - %(message)s")

# ANSI-Farben für die Konsole
class Colors:
    RESET = "\033[0m"
    BLUE = "\033[94m"
    GREEN = "\033[92m"
    YELLOW = "\033[93m"
    RED = "\033[91m"
    CYAN = "\033[96m"

def plot_args_and_return(args, ret, save=False):
    """ Erstellt einen Plot der Funktionsargumente und des Rückgabewerts. """
    try:
        plt.figure(figsize=(6, 4))
        plt.plot(args, label="Args", marker="o", linestyle="--", color="blue")
        plt.plot([ret] * len(args), label="Return", marker="x", linestyle="-", color="red")
        plt.legend()
        plt.title("Arguments vs Return Value")
        plt.grid()

        if save:
            filename = f"plot_{int(time.time())}.png"
            plt.savefig(filename)
            print(f"{Colors.YELLOW}[INFO] Plot gespeichert als {filename}{Colors.RESET}")

        plt.show()
    except Exception as e:
        print(f"{Colors.RED}[WARN] Konnte nicht plotten: {e}{Colors.RESET}")

def Logging(level="info", save_plots=False, show_env=True):
    """ Dekorator für Logging mit konfigurierbaren Optionen """
    def decorator(func):
        @functools.wraps(func)
        def wrapper(*args, **kwargs):
            start_time = time.time()
            
            try:
                args_str = json.dumps(args)
                kwargs_str = json.dumps(kwargs)
            except:
                args_str, kwargs_str = str(args), str(kwargs)

            user = os.getenv('USER', 'Unbekannt')
            log_message = (f"Funktion: {func.__name__}\n"
                           f"  Args: {args_str}\n"
                           f"  Kwargs: {kwargs_str}\n"
                           f"  PID: {os.getpid()} | User: {user if show_env else 'Hidden'}\n")
            
            if level.lower() in ["verbose", "debug"]:
                print(f"{Colors.CYAN}[LOG] {log_message}{Colors.RESET}")
            logging.info(log_message)

            result = func(*args, **kwargs)

            elapsed_time = time.time() - start_time
            return_message = f"  Return: {result} (Dauer: {elapsed_time:.4f}s)"
            
            if level.lower() in ["verbose", "debug"]:
                print(f"{Colors.GREEN}[RESULT] {return_message}{Colors.RESET}")
            logging.info(return_message)

            if save_plots and all(isinstance(x, (int, float)) for x in args):
                plot_args_and_return(args, result, save=True)

            return result
        return wrapper
    return decorator

# Nutzung
@Logging(level="verbose", save_plots=True, show_env=True)
def quadratic(x):
    return x ** 2

quadratic(4)
