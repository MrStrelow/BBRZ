zahlen = [6, 5, 3, 1, 8, 7, 2, 4]
anzahl_paare = len(zahlen) - 1

# 4. Lass mehrere Bubbles aufsteigen, bis wir sortiert sind.
for i in range(len(zahlen)):
    is_sorted = True

    # 3. Schiebe roten Slider (die Bubble) solange nach rechts bis wir am Ende sind.
    # for bubble in [0,1,2,3,4,5,6]: # range erzeugt uns [0,1,2,3,4,5,6]
    for bubble in range(anzahl_paare - i):
        # 2. vertausche wenn erste zahl größer zweite zahl
        if zahlen[bubble] > zahlen[bubble + 1]:
            # 1. vertausche zwei zahlen aus einer liste
            lostandfound = zahlen[bubble]
            zahlen[bubble] = zahlen[bubble + 1]
            zahlen[bubble + 1] = lostandfound
            is_sorted = False

            # 0. Greife auf Elmente der Liste zu
            # print(zahlen[0])
            # print(zahlen[1])
            # print(zahlen[0] > zahlen[1])

            # lostandfound = zahlen[0]
            # zahlen[0] = zahlen[1]
            # zahlen[1] = lostandfound
            # is_sorted = False

        print(zahlen)

    if is_sorted:
        break
    
    print()


    # Mit while

anzahl_paare = len(zahlen) - 1
is_sorted = True
repeated_bubbles = 0

# 4. Lass mehrere Bubbles aufsteigen, bis wir sortiert sind.
while is_sorted:
    # 3. Schiebe roten Slider (die Bubble) solange nach rechts bis wir am Ende sind.
    for bubble in range(anzahl_paare - repeated_bubbles):
        # 2. vertausche wenn erste zahl größer zweite zahl
        if zahlen[bubble] > zahlen[bubble + 1]:
            # 1. vertausche zwei zahlen aus einer liste
            lostandfound = zahlen[bubble]
            zahlen[bubble] = zahlen[bubble + 1]
            zahlen[bubble + 1] = lostandfound
            is_sorted = False

        print(zahlen)    
    print()

    repeated_bubbles += 1
