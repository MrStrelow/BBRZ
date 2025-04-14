import pandas as pd
import pandasql as psql
from colorama import init, Fore, Style
import os

# Hilfsfunktionen
def psql_print(*args):
    print(f"{Style.RESET_ALL}🔷 Pandas mit SQL Style 🔷")
    print(Fore.BLUE, *args, Style.RESET_ALL)
    print(f"Zeilen und Spalten: {args[0].shape}")


def pd_print(*args):
    print(f"{Style.RESET_ALL}🟢 Pandas mit Python Style 🟢")
    print(Fore.GREEN, *args, Style.RESET_ALL)
    print(f"Zeilen und Spalten: {args[0].shape}")



df = pd.read_csv("data.csv")

pd_print(df)