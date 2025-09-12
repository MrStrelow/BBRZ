# def print_ungerade():
#     print("\u001b[91mVor der Funktionsausführung\u001b[0m") # soll in die dekoration kommen

#     for variable in [1,2,3]:  # das ist business logik
#         if variable % 2 == 1: # das ist business logik
#             print("\u001b[92mungerade\u001b[0m") # das ist business logik

#     print("\u001b[91mNach der Funktionsausführung\u001b[0m") # soll in die dekoration kommen

# print_ungerade()

# das ist business logik
def business_logik():
    for variable in [1,2,3]:  # das ist business logik
        if variable % 2 == 1: # das ist business logik
            print("\u001b[92mungerade\u001b[0m") # das ist business logik


# das ist der dekorator
def dekorator():
    ->
    pass

dekorator(business_logik)