using DemoEfCore.Data;
using DemoEfCore.Models;
using System;


// Michael Palkovics

// using: dispose of the context/connections after we dont use it anymore.
using PizzaContext context = new PizzaContext();


// ########################## CRUD ##########################

// ############# Create #############

// ####### Products #######
Product veggieSpecial = new Product()
{
    Name = "veggie special pizza",
    Price = 9.99m
};

Product deluxeMeat = new Product()
{
    Name = "Deluxe Meat Pizza",
    Price = 9.99M
};

Product maxMeat = new Product()
{
    Name = "Max Meat Pizza",
    Price = 19.99M
};

//context.Add(veggieSpecial);
//context.Add(deluxeMeat);
//context.Add(maxMeat);

var products = new List<Product>
{
    veggieSpecial,
    deluxeMeat,
    maxMeat
};

context.AddRange(products);

context.SaveChanges();
// In Async. Functions use this instead.
//context.SaveAsyncChanges();

// ####### Orders and Order Details #######
List<Order> blarksOrders = new List<Order>
{
    new Order
    {
        OrderPlaced = DateTime.Now,
        OrderDetails = new List<OrderDetail>{
            new OrderDetail()
            {
                Product = veggieSpecial,
                Quantity = 2
            },
            new OrderDetail()
            {
                Product = deluxeMeat,
                Quantity = 3
            }
        }
    }
};

// ####### Customers #######
Customer blark = new Customer()
{
    Address = "qwer",
    Email = "mer101@wer.at",
    FirstName = "Bla",
    LastName = "Rk",
    Orders = blarksOrders
};

context.Add(blark);
context.SaveChanges();
Console.WriteLine("HWRE");

// ############# Read #############

// Fluent API Syntax
//var products = context.Products
//    .Where(p => p.Price > 10.00M)
//    .OrderBy(p => p.Name);

// LINQ Syntax
var queriedProducts = from product in context.Products
               where product.Price > 10.00M
               orderby product.Name
               select product;

Console.WriteLine("------------------");
foreach (Product product in products)
{
    Console.WriteLine(product);
}

// ############# Update #############
veggieSpecial = context.Products
                    .Where(p => p.Name == "Veggie Special Pizza")
                    .FirstOrDefault();

// if (veggieSpecial is Product)
if(veggieSpecial != null)
{
    veggieSpecial.Price = 10.99M;
}

context.SaveChanges();

var moreProducts = from product in context.Products
               where product.Price > 10.00M
               orderby product.Name
               select product;

Console.WriteLine("------------------");
foreach (Product product in moreProducts)
{
    Console.WriteLine(product);
}


// ############# Delete #############

if (veggieSpecial != null)
{
    context.Remove(maxMeat);
}

context.SaveChanges();

var manyMoreProducts = from product in context.Products
                       select product;

Console.WriteLine("------------------");
foreach (Product product in manyMoreProducts)
{
    Console.WriteLine(product);
}

Console.WriteLine("------------------");
var mostBoughtProducts = context.ImportantProductsViews.ToList();

foreach (var product in mostBoughtProducts)
{
    Console.WriteLine($"Product: {product.ProductName}");
}