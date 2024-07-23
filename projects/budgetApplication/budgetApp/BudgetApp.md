# A Basic Budget App (User Story)

## Users should be able to:
- Add list transactions with location, dates, catagories, and amounts
- Add and edit catagories
- List categories and spending in categories
- View/Edit transactions by date or category

## Transactions:
- ID (INT, Primary Key)
- Location/Name (VARCHAR)
- Category (INT, Foreign Key)
- Date (DATETIME)
- Amount (DECIMAL)

## Categoies:
- ID (INT, Primary Key)
- Category Name (VARCHAR)