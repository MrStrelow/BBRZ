from typing import List, Dict
from dataclasses import dataclass, field
from enum import Enum


class BoxType(Enum):
    BIG = "big"
    MEDIUM = "med"
    SMALL = "small"


class ProductType(Enum):
    FAHRRAD = "Fahrrad"
    TISCH = "Tisch"
    KULLI = "Kulli"


@dataclass
class Product:
    product_id: int
    product_type: ProductType


@dataclass
class Box:
    box_id: int
    box_type: BoxType
    products: List[Product] = field(default_factory=list)

    def add_product(self, product: Product) -> bool:
        if self.is_valid_for_box(product.product_type):
            self.products.append(product)
            return True
        return False

    def is_valid_for_box(self, product_type: ProductType) -> bool:
        if self.box_type == BoxType.BIG:
            return product_type in {ProductType.FAHRRAD, ProductType.TISCH, ProductType.KULLI}
        if self.box_type == BoxType.MEDIUM:
            return product_type in {ProductType.FAHRRAD, ProductType.KULLI}
        if self.box_type == BoxType.SMALL:
            return product_type == ProductType.KULLI
        return False


class Warehouse:
    def __init__(self):
        self.boxes: Dict[int, Box] = {}

    def add_box(self, box: Box):
        self.boxes[box.box_id] = box

    def add_product_to_box(self, product: Product, box_id: int):
        box = self.boxes.get(box_id)
        if box and box.add_product(product):
            print(f"Product {product} added to {box}")
        else:
            print(f"Cannot add {product} to Box {box_id} (wrong size or non-existent box).")

    def find_boxes(self):
        for box in self.boxes.values():
            print(box)

    def find_product_in_warehouse(self, product_type: ProductType):
        print(f"Searching for product {product_type.value}:")
        for box in self.boxes.values():
            for product in box.products:
                if product.product_type == product_type:
                    print(f"{product} found in {box}")


def main():
    warehouse = Warehouse()

    # Boxen erstellen und zum Lager hinzufügen
    warehouse.add_box(Box(0, BoxType.BIG))
    warehouse.add_box(Box(1, BoxType.BIG))
    warehouse.add_box(Box(2, BoxType.MEDIUM))
    warehouse.add_box(Box(3, BoxType.SMALL))

    # Produkte erstellen
    p1 = Product(0, ProductType.FAHRRAD)
    p2 = Product(1, ProductType.KULLI)
    p3 = Product(2, ProductType.FAHRRAD)
    p4 = Product(3, ProductType.TISCH)
    p5 = Product(4, ProductType.KULLI)

    # Produkte zu Boxen hinzufügen
    warehouse.add_product_to_box(p1, 0)
    warehouse.add_product_to_box(p2, 0)
    warehouse.add_product_to_box(p3, 1)
    warehouse.add_product_to_box(p4, 2)
    warehouse.add_product_to_box(p5, 3)

    # Box-Inhalte anzeigen
    warehouse.find_boxes()

    # Produkt-Suche durchführen
    warehouse.find_product_in_warehouse(ProductType.FAHRRAD)


if __name__ == "__main__":
    main()
