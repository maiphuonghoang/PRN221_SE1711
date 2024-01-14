USE master
-- DROP DATABASE PRN221_Assignment01;
CREATE DATABASE PRN221_Assignment01;

USE PRN221_Assignment01;
GO

CREATE TABLE [Member] (
	MemberId INT PRIMARY KEY IDENTITY(1,1),
	Email VARCHAR(100) NOT NULL,
	CompanyName VARCHAR(40) NOT NULL,
	City VARCHAR(15) NOT NULL,
	Country VARCHAR(15) NOT NULL,
	[Password] VARCHAR(30) NOT NULL
);
GO

CREATE TABLE [Order] (
	OrderId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberId INT NOT NULL,
	OrderDate DATETIME NOT NULL,
	RequiredDate DATETIME,
	ShippedDate DATETIME,
	Freight MONEY,
	FOREIGN KEY (MemberID) REFERENCES Member(MemberId)
);
GO

CREATE TABLE [Product] (
	ProductId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CategoryId INT NOT NULL,
	ProductName VARCHAR(40) NOT NULL,
	Weight VARCHAR(20) NOT NULL,
	UnitPrice MONEY NOT NULL,
	UnitsInStock INT NOT NULL
);
GO

CREATE TABLE [OrderDetail] (
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	UnitPrice MONEY NOT NULL,
	Quantity INT NOT NULL,
	Discount FLOAT NOT NULL,
	PRIMARY KEY (OrderId, ProductId),
	FOREIGN KEY (OrderId) REFERENCES [Order](OrderId),
	FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);
GO
SET IDENTITY_INSERT [Member] ON;
INSERT INTO [Member] (MemberId, Email, CompanyName, City, Country, [Password])
VALUES
	(1,'email1@test.com', 'Company 1', 'City 1', 'Country 1', 'password1'),
	(2,'email2@test.com', 'Company 2', 'City 2', 'Country 2', 'password2'),
	(3,'email3@test.com', 'Company 3', 'City 3', 'Country 3', 'password3'),
	(4,'email4@test.com', 'Company 4', 'City 4', 'Country 4', 'password4'),
	(5,'email5@test.com', 'Company 5', 'City 5', 'Country 5', 'password5'),
	(6,'email6@test.com', 'Company 6', 'City 6', 'Country 6', 'password6'),
	(7,'email7@test.com', 'Company 7', 'City 7', 'Country 7', 'password7'),
	(8,'email8@test.com', 'Company 8', 'City 8', 'Country 8', 'password8'),
	(9,'email9@test.com', 'Company 9', 'City 9', 'Country 9', 'password9'),
	(10,'email10@test.com', 'Company 10', 'City 10', 'Country 10', 'password10'),
	(11,'email11@test.com', 'Company 11', 'City 11', 'Country 11', 'password11'),
	(12,'email12@test.com', 'Company 12', 'City 12', 'Country 12', 'password12');
SET IDENTITY_INSERT [Member] OFF;
SET IDENTITY_INSERT [Product] ON;
INSERT INTO [Product] (ProductId, CategoryId, ProductName, [Weight], UnitPrice, UnitsInStock)
VALUES
	(1, 1, 'Product 1', '5 kg', 15.99,100),
	(2, 2, 'Product 2', '4 kg', 12.50,90),
	(3, 3, 'Product 3', '3 kg', 10.25,80),
	(4, 1, 'Product 4', '2 kg', 18,70),
	(5, 2, 'Product 5', '1 kg', 18,60),
	(6, 3, 'Product 6', '2 kg', 20,50),
	(7, 1, 'Product 7', '3 kg', 22,40),
	(8, 2, 'Product 8', '4 kg', 21,30),
	(9, 3, 'Product 9', '5 kg', 19,20),
	(10,2, 'Product 10', '6 kg', 11.5,10);
SET IDENTITY_INSERT [Product] OFF;
SET IDENTITY_INSERT [Order] ON;
INSERT INTO [Order] (OrderId, MemberId, OrderDate, RequiredDate, ShippedDate, Freight)
VALUES
	(1,1, '2023-01-10','2023-01-10','2023-01-10',10.5),
	(2,2, '2023-01-10','2023-01-10','2023-01-10',11.5),
	(3,3, '2023-01-10','2023-01-10','2023-01-10',12.5),
	(4,4, '2023-01-10','2023-01-10','2023-01-10',13.5),
	(5,5, '2023-01-10','2023-01-10','2023-01-10',14.5),
	(6,6, '2023-01-10','2023-01-10','2023-01-10',15.5),
	(7,7, '2023-01-10','2023-01-10','2023-01-10',16.5),
	(8,8, '2023-01-10','2023-01-10','2023-01-10',17.5),
	(9,9, '2023-01-10','2023-01-10','2023-01-10',18.5),
	(10,10, '2023-01-10','2023-01-10','2023-01-10',19.5);
SET IDENTITY_INSERT [Order] OFF;
INSERT INTO [OrderDetail] (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES
	(1,1,15.99,2,0.10),
	(1,2,12.50,3,0.05),
	(2,3,10.25,4,0.15),
	(3,1,10.99,1,0.15),
	(4,5,18,2,0.10),
	(4,6,20,2,0.10),
	(5,6,20,3,0.05),
	(6,7,22,4,0.15),
	(7,8,24,1,0.15),
	(8,9,26,2,0.10),
	(9,7,28,3,0.05),
	(10,6,30,4,0.15);

SELECT * FROM [Member]
SELECT * FROM [Product]
SELECT * FROM [Order]
SELECT * FROM [OrderDetail]