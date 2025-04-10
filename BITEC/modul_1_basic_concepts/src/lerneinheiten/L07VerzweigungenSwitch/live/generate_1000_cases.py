import inflect

p = inflect.engine()

with open("switch_cases.txt", "w") as file:
    for i in range(1, 1001):
        file.write(f'case {i} -> "{p.number_to_words(i)}";\n')

print("1000 lines written to numbers_in_words.txt")
