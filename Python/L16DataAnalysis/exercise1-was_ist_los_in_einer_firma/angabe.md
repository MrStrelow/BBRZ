# Pandas Business Data Analysis Exercise

This exercise progressively increases in difficulty and covers essential Pandas functionalities in a business data context. The dataset contains sales transactions and customer information.

## Dataset

Download the following CSV files:
- [sales.csv](sandbox:/mnt/data/sales.csv) (Sales transactions)
- [customers.csv](sandbox:/mnt/data/customers.csv) (Customer details)

## Tasks

### 1. Read and Display Data
- Load both datasets into Pandas using `pd.read_csv()`.
- Display the first few rows using `.head()`.
- Hint: Use `print(df.head())` to check the data structure.

### 2. Merge and Join Data
- Merge the datasets on `CustomerID`.
- Try different join types (`inner`, `left`, `right`, `outer`).
- Discuss the differences between these join types.
- Hint: Use `df.merge(other_df, on='CustomerID', how='inner')`.

### 3. SQL-like Filtering
- Filter transactions with an amount greater than $500.
- Filter customers from "New York".
- Hint: Use `df[df['Amount'] > 500]` and `df[df['City'] == 'New York']`.

### 4. Group By and Sorting
- Find total sales per customer.
- Sort the customers by total sales in descending order.
- Hint: Use `.groupby('CustomerID').sum()` and `.sort_values(by='Amount', ascending=False)`.

### 5. SQL `HAVING` Equivalent (Aggregation + Filtering)
- Find customers with total purchases above $1000.
- Compare different ways to filter after aggregation:
  - Using standard filtering.
  - Using the `query` function.
  - Using `filter` with a lambda function.
- Hint: Use `.groupby('CustomerID').agg({'Amount': 'sum'})`.

### 6. Creating an Index
- Set `CustomerID` as the index.
- Hint: Use `.set_index('CustomerID', inplace=True)`.

### 7. Pivot Wider and Longer (Reshape Data)
- Create a pivot table to restructure the data (one-hot encoding).
- Convert wide data to long format using `melt`.
- Hint: Use `.pivot_table()` and `.melt()`.

### 8. Pivot Table and Reshape
- Use `pivot_table` to summarize sales by customer and product.
- Reshape the data using `stack` and `unstack`.
- Hint: Use `.pivot_table(index='CustomerID', columns='Product', values='Amount', aggfunc='sum')`.

### 9. Utility Functions and Time Series Analysis
- Handle missing data (`dropna`, `fillna`).
- Convert `Date` to datetime format.
- Set `Date` as the index and resample sales data monthly.
- Plot the sales trend.
- Hint: Use `pd.to_datetime(df['Date'])` and `.resample('M').sum()`.
