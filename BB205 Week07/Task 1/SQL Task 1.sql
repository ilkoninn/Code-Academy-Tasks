CREATE DATABASE BB205

use BB205

CREATE TABLE Students
(
	[Name] nvarchar(50) NOT NULL,
	Surname nvarchar(50) DEFAULT 'XXX',
	Age int NOT NULL CHECK(Age >= 18),
	AvgPoint float NOT NULL CHECK(AvgPoint >= 0 and AvgPoint <= 100)
)

INSERT INTO Students Values
(
	'Ilkin', 'Rajabov', 19, 83
)
INSERT INTO Students Values
(
	'Miraga', 'Eliyev', 21, 98
)
INSERT INTO Students Values
(
	'Tunay', 'Huseynli', 19, 50
)
INSERT INTO Students Values
(
	'Amin', '', 19, 50
)
INSERT INTO Students([Name], Age, AvgPoint) Values
(
	'Senan', 21, 78
)
-- Ortalaması 51dən yuxarı olan tələbələri göstərsin
SELECT * FROM Students
WHERE AvgPoint > 51

-- Ortalaması 51dən böyük, 90dan az olan tələbələri göstərsin
SELECT * FROM Students
WHERE AvgPoint > 51 and AvgPoint < 90

-- A ilə başlayıb n ilə bitən tələbələri göstərsin
SELECT * FROM Students
WHERE [Name] LIKE 'A%n';

-- Ortalaması 51dən kicik ve yashi 20-den boyuk olan tələbələri göstərsin
SELECT * FROM Students
WHERE AvgPoint > 51 and Age > 20