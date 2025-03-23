import pandas as pd
import pandasql as psql
from colorama import init, Fore, Style

import os

# Hilfsfunktionen
def psql_print(*args):
    print(f"{Style.RESET_ALL}🔷 Pandas mit SQL Style 🔷")
    print(Fore.BLUE, *args, Style.RESET_ALL)
    print(f"Zeilen und Spalten: {args[0].shape}")


def pd_print(*args):
    print(f"{Style.RESET_ALL}🟢 Pandas mit Python Style 🟢")
    print(Fore.GREEN, *args, Style.RESET_ALL)
    print(f"Zeilen und Spalten: {args[0].shape}")



# Task 0: Korrekten Pfad erstellen
print("◽◽◽◽◽◽◽◽◽◽◽◽◽◽ Aufgabe 0 ◽◽◽◽◽◽◽◽◽◽◽◽◽◽")
print(f"{Fore.BLUE}Aktuelles Arbeitsverzeichnis: {Style.RESET_ALL}", os.getcwd())

base_path = os.path.join(os.getcwd(), "L16DataAnalysis", "exercise1")
print(f"{Fore.BLUE}Pfad der py files: {Style.RESET_ALL}", base_path)

data_path = os.path.join(base_path, "data")
print(f"{Fore.BLUE}Pfad der csv files: {Style.RESET_ALL}", data_path)

print(f"{Fore.BLUE}Welche csv daten habe ich?{Fore.GREEN} - ", os.listdir(data_path))

print(f"{Fore.BLUE}Was ist der Pfad der aktuellen Dateil?{Style.RESET_ALL} - ", os.path.realpath(__file__))


# Task 1: Read and Display Data
print(f"◽◽◽◽◽◽◽◽◽◽◽◽◽◽ {Fore.CYAN}Aufgabe 1{Style.RESET_ALL} ◽◽◽◽◽◽◽◽◽◽◽◽◽◽")
sales = pd.read_csv(os.path.join(data_path, "sales.csv"))
customers = pd.read_csv(os.path.join(data_path, "customers.csv"))
print(sales.head())
print(customers.head())

# Task 2: Merge (SQL: join)
print(f"◽◽◽◽◽◽◽◽◽◽◽◽◽◽ {Fore.CYAN}Aufgabe 2{Style.RESET_ALL} ◽◽◽◽◽◽◽◽◽◽◽◽◽◽")
merged_file_path = os.path.join(data_path, "data.csv")

if not os.path.exists(merged_file_path):
    # sql style
    query = """
    SELECT *
    FROM sales
    INNER JOIN customers ON sales.CustomerID = customers.CustomerID
    """
    # Use pandasql to execute the query
    data = psql.sqldf(query, locals()) # oder globals() - zugriff auf variablen.

    psql_print(data.head())

    # python style
    data = sales.merge(customers, on='CustomerID', how='inner')
    # merged_left = sales.merge(customers, on='CustomerID', how='left')
    # merged_right = sales.merge(customers, on='CustomerID', how='right')
    # merged_outer = sales.merge(customers, on='CustomerID', how='outer')

    pd_print(data)

    data.to_csv(merged_file_path, index=False)

else:
    print(f"⚠️  \033[1m{Fore.RED}`data.csv` alreaday exists. Data loaded from file system.⚠️{Style.RESET_ALL}")
    data = pd.read_csv(os.path.join(merged_file_path))

    print(data)
    print(f"Zeilen und Spalten: {data.shape}")

# Task 3: Filtering (SQL: where)
# Nachteil davon! wenn alles auf einmal gespeichert wrid -> file ist zu groß warum joinen wenn wir es dann speichern als join?
print(f"◽◽◽◽◽◽◽◽◽◽◽◽◽◽ {Fore.CYAN}Aufgabe 3{Style.RESET_ALL} ◽◽◽◽◽◽◽◽◽◽◽◽◽◽")

## high value customers
# python style
high_value_sales = data[data['Amount'] > 500]
pd_print(high_value_sales)

# sql style
query = """
SELECT *
FROM data
WHERE Amount > 500
"""

high_value_sales = psql.sqldf(query, locals())

psql_print(high_value_sales)

## customers aus new york
# python style
my_customers = data[data['City'] == 'New York']
pd_print(my_customers)

# sql style
query = """
SELECT *
FROM data
WHERE City = 'New York'
"""

my_customers = psql.sqldf(query, locals())
psql_print(my_customers)

## Beide bedingungen müssen gelten
# python style
both = data[(data['City'] == 'New York') & (data['Amount'] > 500)] # das bekannte logische und "and" funktioniert hier nicht -> pandas verwendet das symbol &
pd_print(both)

# sql style
query = """
SELECT *
FROM data
WHERE 
    City = 'New York' AND
    Amount > 500
"""

both = psql.sqldf(query, locals())
psql_print(both)

## nur der Name, City und Amount soll ausgegeben werden
# python style
pd_print(both[['Name', 'City', 'Amount']])

# sql style
query = """
SELECT Name, City, Amount
FROM both
"""

filtered_columns = psql.sqldf(query, locals())
psql_print(filtered_columns)

# Task 4: Group By and Sorting
print(f"◽◽◽◽◽◽◽◽◽◽◽◽◽◽ {Fore.CYAN}Aufgabe 4{Style.RESET_ALL} ◽◽◽◽◽◽◽◽◽◽◽◽◽◽")
## verkaufsvolumen pro Kunde
# python style
sales_per_customer = \
    data.groupby('CustomerID').agg({'Amount': 'sum'}).reset_index().\
    merge(customers, on='CustomerID', how='inner').\
    sort_values(by='Amount', ascending=False)[['Name', 'Amount']]

pd_print(sales_per_customer)

# sql style
query = """
SELECT Name, SUM(Amount) as AmountPerCustomer
FROM data
GROUP BY CustomerID
ORDER BY Amount DESC;
"""
sales_per_customer = psql.sqldf(query, locals())

psql_print(sales_per_customer)

## Anzahl der Verkäufe pro Kunde
# python style
sales_per_customer = \
    data.groupby('CustomerID').agg({'Amount': 'count'}).reset_index().\
    merge(customers, on='CustomerID', how='inner').\
    sort_values(by='Amount', ascending=False)[['Name', 'Amount']]

pd_print(sales_per_customer)

# sql style
query = """
SELECT Name, count(Amount) as AmountPerCustomer
FROM data
GROUP BY CustomerID
ORDER BY Amount DESC;
"""
sales_per_customer = psql.sqldf(query, locals())

psql_print(sales_per_customer)

## beides
# python style
# sales_per_customer = \
#     data.groupby('CustomerID').agg({'Amount': ['sum', 'count']}).reset_index().\
#     merge(customers, on='CustomerID', how='inner').\
#     sort_values(by='Amount', ascending=False)[['Name', 'Amount']]

# pd_print(sales_per_customer)

# sql style
query = """
SELECT Name, SUM(Amount) as AmountPerCustomer, count(Amount) as NumberOfShops
FROM data
GROUP BY CustomerID
ORDER BY Amount DESC;
"""
sales_per_customer = psql.sqldf(query, locals())

psql_print(sales_per_customer)

# Task 5: SQL `HAVING` Equivalent
print(f"◽◽◽◽◽◽◽◽◽◽◽◽◽◽ {Fore.CYAN}Aufgabe 5{Style.RESET_ALL} ◽◽◽◽◽◽◽◽◽◽◽◽◽◽")
# pyton style
agg_sales = data.groupby('CustomerID').agg({'Amount': 'sum'})

top_sales_per_customer = agg_sales[agg_sales['Amount'] > 1000].\
    merge(customers, on='CustomerID', how='inner').\
    sort_values(by='Amount', ascending=False)[['Name', 'Amount']]

# top_sales_per_customer = agg_sales.query('Amount > 1000') # oder
# top_sales_per_customer = data.groupby('CustomerID').filter(lambda x: x['Amount'].sum() > 1000) # oder

pd_print(top_sales_per_customer)

# sql style
query = """
SELECT Name, SUM(Amount) as AmountPerCustomer, count(Amount) as NumberOfShops
FROM data
GROUP BY CustomerID
HAVING SUM(Amount) > 1000
ORDER BY Amount DESC;
"""

top_sales_per_customer = psql.sqldf(query, locals())

psql_print(top_sales_per_customer)

# Task 6: Creating an Index
sales.set_index('CustomerID', inplace=True)

# Task 7: Pivot Wider and Longer
sales_pivot = sales.pivot_table(index='CustomerID', columns='Product', values='Amount', fill_value=0)
sales_long = sales.melt(id_vars=['CustomerID'], value_vars=['Amount', 'Quantity'], var_name='Metric', value_name='Value')

# Task 8: Pivot Table and Reshape
sales_summary = sales.pivot_table(index='CustomerID', columns='Product', values='Amount', aggfunc='sum', fill_value=0)
reshaped = sales_summary.stack()

# Task 9: Utility Functions and Time Series
sales.dropna(inplace=True)
sales.fillna(0, inplace=True)
sales['Date'] = pd.to_datetime(sales['Date'])
sales.set_index('Date', inplace=True)
sales.resample('M').sum()['Amount'].plot(title='Monthly Sales')