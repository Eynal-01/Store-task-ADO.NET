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
[ImagePath] NVARCHAR(MAX) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories([CategoryId]) ON DELETE SET NULL
)
GO
INSERT INTO Categories([CategoryName])
VALUES('Category1'), ('Category2'), ('Category3'), ('Category4')
GO
INSERT INTO Products([ProductName], [ProductPrice], [ProductDiscount], [CategoryId], [ImagePath])
VALUES('Product 1', 12, 12, 1, NULL), ('Product 2', 23, 23, 2, NULL), ('Product 3', 34, 34, 3, NULL), ('Product 4', 45, 45, 4, NULL),
('Product 5', 56, 56, 1, NULL), ('Product 6', 67, 67, 2, NULL), ('Product 7', 78, 78, 3, NULL), ('Product 8', 89, 89, 4, NULL)