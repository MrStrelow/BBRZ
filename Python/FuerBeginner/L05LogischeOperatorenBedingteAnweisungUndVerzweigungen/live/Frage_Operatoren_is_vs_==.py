list_a = [1, 2, 3]
list_b = [1, 2, 3] # Same values as list_a
list_c = list_a     # list_c is just another name for list_a

######### is und == #########
# Value comparison
print(f"list_a == list_b is {list_a != list_b}") # True, because their values are equal.

# Identity comparison
print(f"list_a is list_b is {list_a is list_b}") # False, they are two separate objects in memory.
print(f"list_a is list_c is {list_a is list_c}") # True, they are the exact same object.


######### is not und != #########
print()
# Value comparison
print(f"list_a != list_b is {list_a != list_b}") # False, because their values are equal.

# Identity comparison
print(f"list_a is not list_b is {list_a is not list_b}") # True, they are two separate objects in memory.
print(f"list_a is not list_c is {list_a is not list_c}") # False, they are the exact same object.