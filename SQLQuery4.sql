CREATE DATABASE StoreDB
GO
USE StoreDB
GO
CREATE TABLE Categories(
[CategoryId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CategoryName] NVARCHAR(30) NOT NULL,
)
GO
CREATE TABLE Products(
[ProductId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[ProductName] NVARCHAR(30) NOT NULL,
[ProductPrice] MONEY NOT NULL,
[ProductDiscount] INT NOT NULL,
[ImagePath] NVARCHAR(MAX),
[Rating] INT NOT NULL,
[Description] NVARCHAR(MAX) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories([CategoryId]) NOT NULL
)
GO
INSERT INTO Categories([CategoryName])
VALUES('Category1'), ('Category2'), ('Category3'), ('Category4')
GO
INSERT INTO Products([ProductName], [ProductPrice], [ProductDiscount], [CategoryId], [ImagePath], [Rating], [Description])
VALUES('Product 1', 12, 12, 1, NULL, 5, 'Good product'), ('Product 2', 23, 23, 2, NULL, 2, 'Better product'), ('Product 3', 34, 34, 3, NULL, 1, 'Normal product'), ('Product 4', 45, 45, 4, NULL, 4, 'Better product'),
('Product 5', 56, 56, 1, NULL, 3, 'Good product'), ('Product 6', 67, 67, 2, NULL, 2, 'Normal product'), ('Product 7', 78, 78, 3, NULL, 5, 'Best product'), ('Product 8', 89, 89, 4, NULL, 4, 'Good product')