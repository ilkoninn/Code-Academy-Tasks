CREATE DATABASE Department

use Department

CREATE TABLE Employees
(
	ID int PRIMARY KEY IDENTITY,
	[Name] nvarchar(50) NOT NULL CHECK(LEN([Name]) > 3),
	Surname nvarchar(50) NOT NULL CHECK(LEN(Surname) > 3),
	Salary float NOT NULL CHECK(Salary > 200),
	Degree nvarchar(20) NOT NULL,
)

INSERT INTO Employees VALUES
(
	'Ilkin', 'Rajabov', 300, 'Junior'
)
INSERT INTO Employees VALUES
(
	'Miraga', 'Eliyev', 600, 'Junior'
)
INSERT INTO Employees VALUES
(
	'Tunay', 'Huseynli', 1200, 'Middle'
)
INSERT INTO Employees VALUES
(
	'Rufet', 'Quliyev', 3000, 'Senior'
)
INSERT INTO Employees VALUES
(
	'Fidan', 'Alizade', 2500, 'Senior'
)

-- Maasi 400-den asagi olan iscileri gosteren query
SELECT * FROM Employees
WHERE Salary < 400

-- Butun iscilerin Name ve Surname deyerlerini Fullname adi ile gosteren query
SELECT [Name] + ' ' + Surname as Full_Name FROM Employees

-- Iscileri Id, Fullname ve Salary deyerlerine gore gosteren query
SELECT ID, [Name] + ' ' + Surname as Full_Name, Salary FROM Employees

-- Derecesi junior olan iscileri gosteren query
SELECT * FROM Employees
WHERE Degree = 'Junior'

-- En yuksek maas alan iscini gosteren query
SELECT * FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees)

-- En az maas alan iscini gosteren query
SELECT * FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- Ortalama maasi (Ortamala Maas adi ile) gosteren query
SELECT AVG(SALARY) FROM Employees

-- Maasi ortalama maasdan cox olan iscileri gosteren query
SELECT * FROM Employees	
WHERE Salary > (SELECT AVG(Salary) FROM Employees)

-- Soyadi "ov" ve ya "ova" ile biten iscileri gosteren query
SELECT * FROM Employees
WHERE Surname LIKE '%ov' or Surname LIKE '%ova';