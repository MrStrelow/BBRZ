from typing import List, Dict
from enum import Enum
from collections import defaultdict


class BoxType(Enum):
    BIG = "big"
    MEDIUM = "med"
    SMALL = "small"


class ProductType(Enum):
    FAHRRAD = "Fahrrad"
    TISCH = "Tisch"
    KULLI = "Kulli"


class Warehouse:
    def __init__(self):
        # Verwendung von defaultdict für dynamische Boxen.
        self.warehouse = defaultdict(list)

    def add_product_to_box(self, product_type: ProductType, box_type: BoxType, box_id: int):
        """Produkt in der entsprechenden Box hinzufügen."""
        if self.is_valid_for_box(product_type, box_type):
            self.warehouse[box_type].append((box_id, product_type))
            print(f"Product {product_type.value} added to {box_type.value} box with id {box_id}")
        else:
            print(f"Cannot add {product_type.value} to {box_type.value} box (wrong size or product).")

    def is_valid_for_box(self, product_type: ProductType, box_type: BoxType) -> bool:
        """Validierung, ob das Produkt in die Box passt."""
        if box_type == BoxType.BIG and product_type in {ProductType.FAHRRAD, ProductType.TISCH, ProductType.KULLI}:
            return True
        if box_type == BoxType.MEDIUM and product_type in {ProductType.FAHRRAD, ProductType.KULLI}:
            return True
        if box_type == BoxType.SMALL and product_type == ProductType.KULLI:
            return True
        return False

    def find_boxes(self, box_type: BoxType):
        """Zeigt den Inhalt der Boxen eines bestimmten Typs an."""
        print(f"Content of {box_type.value} boxes:")
        for box_id, product in self.warehouse.get(box_type, []):
            print(f"Box ID {box_id}: {product.value}")

    def find_product_in_warehouse(self, product_type: ProductType):
        """Suche nach einem Produkt in der Lagerbox und gibt die Box-IDs aus."""
        print(f"Searching for product {product_type.value}:")
        for box_type, products in self.warehouse.items():
            for box_id, product in products:
                if product == product_type:
                    print(f"{product.value} found in {box_type.value} box with ID {box_id}")


def main():
    # Produkte und Boxen initialisieren
    warehouse = Warehouse()

    fahrrad = ProductType.FAHRRAD
    tisch = ProductType.TISCH
    kulli = ProductType.KULLI

    # Produkte zu Boxen hinzufügen
    warehouse.add_product_to_box(fahrrad, BoxType.BIG, 0)
    warehouse.add_product_to_box(kulli, BoxType.BIG, 0)
    warehouse.add_product_to_box(fahrrad, BoxType.BIG, 1)
    warehouse.add_product_to_box(tisch, BoxType.MEDIUM, 0)
    warehouse.add_product_to_box(kulli, BoxType.SMALL, 0)

    # Box-Inhalte anzeigen
    warehouse.find_boxes(BoxType.BIG)
    warehouse.find_boxes(BoxType.MEDIUM)
    warehouse.find_boxes(BoxType.SMALL)

    # Produkt-Suche durchführen
    warehouse.find_product_in_warehouse(fahrrad)


if __name__ == "__main__":
    main()
