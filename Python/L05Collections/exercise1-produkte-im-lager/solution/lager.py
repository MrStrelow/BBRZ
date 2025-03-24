blue = "\u001B[34m"
red = "\u001B[31m"
reset = "\u001B[0m"

def main():
    # ProduktTypen
    fahrrad = "Fahrrad"
    tisch = "Tisch"
    kulli = "Kulli"

    # Boxen erstellen
    bigBox = []
    anotherBigBox = []
    mediumBox = []
    smallBox = []

    # Lager als Dictionary, das die Boxen nach Größe kategorisiert
    warehouse = {
        "big": [bigBox, anotherBigBox],
        "med": [mediumBox],
        "small": [smallBox]
    }

    # Überprüfe beim Hinzufügen, ob die ProduktTypen den Größen der Boxen entsprechen
    add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "big")
    add_product_to_box_in_warehouse(warehouse, 0, kulli, "big")

    add_product_to_box_in_warehouse(warehouse, 1, fahrrad, "big")
    add_product_to_box_in_warehouse(warehouse, 1, fahrrad, "big")
    add_product_to_box_in_warehouse(warehouse, 1, fahrrad, "big")
    add_product_to_box_in_warehouse(warehouse, 1, tisch, "big")
    add_product_to_box_in_warehouse(warehouse, 1, tisch, "big")

    add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "med")
    add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "med")
    add_product_to_box_in_warehouse(warehouse, 0, kulli, "med")
    add_product_to_box_in_warehouse(warehouse, 0, kulli, "med")

    add_product_to_box_in_warehouse(warehouse, 0, fahrrad, "small")
    add_product_to_box_in_warehouse(warehouse, 0, kulli, "small")
    add_product_to_box_in_warehouse(warehouse, 0, kulli, "small")

    # Box-Inhalte ausgeben
    print("\nBox-Inhalte ausgeben:")
    find_boxes_in_warehouse(warehouse, "big")
    find_boxes_in_warehouse(warehouse, "med")
    find_boxes_in_warehouse(warehouse, "small")
    find_boxes_in_warehouse(warehouse, "drüLb")

    # Produktinhalte ausgeben
    print("\nProduktinhalte mit dessen Boxen ausgeben:")
    find_product_categories_of_warehouse(warehouse, "Fahrrad")

def find_boxes_in_warehouse(warehouse, box_type):
    if box_type in ["big", "med", "small"]:
        for box in warehouse[box_type]:
            print(f"box ({box_type}): ")
            for product_type in box:
                print(f"\t{product_type}")
            print()
    else:
        print(f"\033[36m\033[41mBoxType is Wrong!\033[0m")
        print()

def find_product_categories_of_warehouse(warehouse, product_type):
    box_id = 0
    if product_type in ["Fahrrad", "Tisch", "Kulli"]:
        for boxes in warehouse.values():
            for box in boxes:
                box_id += 1
                for product_type_of_box in box:
                    if product_type_of_box == product_type:
                        print(f"{blue}{product_type}{reset}\t - was found in a {red}{boxes[0]}{reset} Box, with id {red}{box_id}{reset}")
                box_id = 0
    else:
        print("\033[36m\033[41mProductType is Wrong!\033[0m")
        print()

def add_product_to_box_in_warehouse(warehouse, box_id, product_type, destination):
    # Guard clause
    if (destination == "small" and product_type != "Kulli") or (destination == "med" and product_type == "Tisch"):
        print("\033[36m\033[41mBox zu klein! (oder falscher ProduktTyp übergeben, diese sind: [Fahrrad, Tisch, Kulli])\033[0m")
        return

    warehouse[destination][box_id].append(product_type)
    print(f"ProductType: {blue}{product_type}{reset}\t wurde in {red}{destination}{reset}\t hinzugefügt.")


if __name__ == "__main__":
    main()