import math

def main():
    print("Gr\u00f6\u00dfe des Spielfields eingeben (gib 20 ein): ")

    # Get user input
    while True:
        try:
            dimension = int(input())
            break
        except ValueError:
            print("\033[91mInput is not an integer. Please try again.\033[0m")

    # Initialize chessboard
    field = [["⬜" if (i + j) % 2 == 0 else "⬛" for j in range(dimension)] for i in range(dimension)]

    # Set start and end points
    y_start, x_start = 0, 3
    y_end, x_end = 12, 15

    field[y_start][x_start] = "💢"
    field[y_end][x_end] = "💥"

    # Calculate slope and mark the line
    delta_x = x_end - x_start
    delta_y = y_end - y_start
    slope = delta_y / delta_x

    for x in range(x_start + 1, x_end):
        y = round(y_start + slope * (x - x_start))
        field[y][x] = "🟡"

    # Print the chessboard
    for row in field:
        print("".join(row))

if __name__ == "__main__":
    main()
