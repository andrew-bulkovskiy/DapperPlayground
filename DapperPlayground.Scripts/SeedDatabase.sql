USE DapperPlaygroundShop;
GO

INSERT INTO Users
	(Username, Email)
VALUES
	('Bob', 'bob@gmail.com'),
	('John', 'jonh@gmail.com')
GO

INSERT INTO Orders
	(UserID, DateOrdered, Comment)
VALUES
	(1, '2019-09-27 12:00:00', 'My first order'),
	(1, '2019-09-27 12:15:00', NULL),
	(2, '2019-10-01 00:00:00', 'Hope i will get my stuff quick')
GO