# [
#     ["🔷", "🔷", "🔷"], 
#     ["🔷", "🔷", "🔷"], 
#     ["🔷", "🔷", "🔷"]
# ]

# [
#   ['🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷'], 
#   ['🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷'], 
#   ['🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷', '🔷']
# ]

# kontrollstruktur - mit einem Statement
# field = []
# dimension = 3

# for _ in range(dimension): 
#     row = []
#     for _ in range(dimension):
#         row.append("🔷")

#     field.append(row)

# print(field)

# Expression (Comprehension)
dimension = 3

field = [[ "🔷" for _ in range(dimension) ] for _ in range(dimension) ]

row = [ "🔷" for _ in range(dimension) ]
field = [row for _ in range(dimension) ]
print(field)


