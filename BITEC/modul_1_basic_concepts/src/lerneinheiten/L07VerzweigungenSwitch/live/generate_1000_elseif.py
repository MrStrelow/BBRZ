import inflect

p = inflect.engine()

with open("else_if_statements.java", "w") as file:
    for i in range(2, 1001):
        word = p.number_to_words(i)
        file.write(f"else if (variable == {i}) result = \"{word}\";\n")

print("999 else if statements written to else_if_statements.java")
