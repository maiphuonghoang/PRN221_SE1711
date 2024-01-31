-- Tạo database mới
CREATE DATABASE PRN221_SE1711_Assignment2;
GO
-- DROP TABLE tblPhone
-- Sử dụng database mới được tạo
USE PRN221_SE1711_Assignment2;
GO

-- Tạo bảng tblPhone
CREATE TABLE tblPhone (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Branch NVARCHAR(MAX),
    [Name] NVARCHAR(MAX),
    DateofManufacture DATETIME,
    stopManufacture BIT
);
GO

SET IDENTITY_INSERT [tblPhone] ON;
INSERT INTO tblPhone (ID, Branch, [Name], DateofManufacture, stopManufacture)
VALUES
    (1, 'Samsung', 'Galaxy S21', '2022-01-01', 0),
    (2, 'Apple', 'iPhone 13', '2022-02-01', 0),
    (3, 'Google', 'Pixel 6', '2022-03-01', 1),
    (4, 'OnePlus', 'OnePlus 9', '2022-04-01', 0),
    (5, 'Xiaomi', 'Mi 11', '2022-05-01', 0),
    (6, 'Sony', 'Xperia 5 III', '2022-06-01', 1),
    (7, 'LG', 'G7 ThinQ', '2022-07-01', 0),
    (8, 'Nokia', 'Nokia 9 PureView', '2022-08-01', 0),
    (9, 'Motorola', 'Moto G Power', '2022-09-01', 1),
    (10, 'Huawei', 'Mate 40 Pro', '2022-10-01', 0);
SET IDENTITY_INSERT [tblPhone] OFF; 

SELECT * FROM tblPhone