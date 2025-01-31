import math

def main():
    # Get user input
    dimension = int(input("Größe des Spielbretts eingeben (gib 20 ein): "))

    # Userinput welcher solange fragt bis eine richtige Eingabe erfolgt.
    # while True:
    #     try:
    #         dimension = int(input())
    #         break
    #     except ValueError:
    #         print("\033[91mInput is not an integer. Please try again.\033[0m")

    # Initialize chessboard
    field = []
    for i in range(dimension):
        row = []
        for j in range(dimension):
            if (i + j) % 2 == 0:
                row.append("⬜")  # Weißes Feld
            else:
                row.append("⬛")  # Schwarzes Feld
        
        field.append(row)

    # field = [["⬜" if (i + j) % 2 == 0 else "⬛" for j in range(dimension)] for i in range(dimension)]

    # Set start and end points
    y_start, x_start = 0, 8
    y_end, x_end = 5, 15

    field[y_start][x_start] = "🟡"
    field[y_end][x_end] = "❌"

    # Calculate slope and mark the line
    delta_x = x_end - x_start
    delta_y = y_end - y_start
    slope = delta_y / delta_x

    for x in range(1, x_end-x_start):
        y = round(slope * x)
        field[y][x + x_start] = "🔸"

    # Print the chessboard
    for row in field:
        print("".join(row))

if __name__ == "__main__":
    main()
