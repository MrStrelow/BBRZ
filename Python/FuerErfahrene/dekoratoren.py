# def print_ungerade():
#     print("\u001b[91mVor der Funktionsausführung\u001b[0m") # soll in die dekoration kommen

#     for variable in [1,2,3]:  # das ist business logik
#         if variable % 2 == 1: # das ist business logik
#             print("\u001b[92mungerade\u001b[0m") # das ist business logik

#     print("\u001b[91mNach der Funktionsausführung\u001b[0m") # soll in die dekoration kommen

# print_ungerade()

# ----------------- Definition hier werden Funktionen angelegt -----------------
# das ist der dekorator
def log(pre_print):
    def dekorator(func):
        def wrapper(*parameter):
            if pre_print:
                print("\u001b[91mVor der Funktionsausführung\u001b[0m") # soll in die dekoration kommen
            func(*parameter)
            print("\u001b[91mNach der Funktionsausführung\u001b[0m") # soll in die dekoration kommen

        return wrapper
    return dekorator

# das ist business logik
@log(False)
def business_logik(to_iterate):
    for variable in to_iterate:  # das ist business logik
        if variable % 2 == 1: # das ist business logik
            print("\u001b[92mungerade\u001b[0m") # das ist business logik

@log(False)
def business_logik_ohne_para():
    for variable in [1,2,3]:  # das ist business logik
        if variable % 2 == 1: # das ist business logik
            print("\u001b[92mungerade\u001b[0m") # das ist business logik


# ----------------- MAIN hier sind die aufrufe der Funktionen ----------------- 
# dekorator = log(pre_print=True)
# wrapper = dekorator(business_logik)
# wrapper([11,20,30])

business_logik([11,20,30])
business_logik_ohne_para()