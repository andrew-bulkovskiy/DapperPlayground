USE master;  
GO

CREATE DATABASE DapperPlaygroundShop;  
GO

USE DapperPlaygroundShop;  
GO
 
CREATE TABLE Users (
    UserID int NOT NULL IDENTITY(1,1),
    Username nvarchar(100) NOT NULL,
	Email nvarchar(100) NOT NULL
);
GO

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (UserID);
GO

CREATE TABLE Orders (
    OrderID int NOT NULL IDENTITY(1,1),
	UserID int NOT NULL,
	DateOrdered DATETIME NOT NULL,
	Comment nvarchar(200)
);
GO

ALTER TABLE Orders
ADD CONSTRAINT PK_Orders PRIMARY KEY (OrderID);
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_User
FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
GO