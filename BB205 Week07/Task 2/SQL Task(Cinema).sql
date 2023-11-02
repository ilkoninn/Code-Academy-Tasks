CREATE DATABASE Cinema

use Cinema

CREATE TABLE Movies
(
	ID INT PRIMARY KEY IDENTITY,
	DirectorID INT REFERENCES Directors(ID),
	[Name] NVARCHAR(40) NOT NULL,
	Rate DECIMAL(3, 1) CHECK(Rate >= 0 AND Rate <= 10)
)
CREATE TABLE Genres
(
	ID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(40) NOT NULL,
)
CREATE TABLE Directors
(
	ID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(40) NOT NULL,
	Surname NVARCHAR(40) NOT NULL,
	Age INT NOT NULL CHECK(Age >= 18),
)
CREATE TABLE Actors
(
	ID INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(40) NOT NULL,
	Surname NVARCHAR(40) NOT NULL,
	Age INT NOT NULL CHECK(Age >= 18),
)
CREATE TABLE MoviesGenres
(
	ID INT PRIMARY KEY IDENTITY,
	MovieID INT REFERENCES Movies(ID),
	GenreID INT REFERENCES Genres(ID),
)
CREATE TABLE MoviesActors
(
	ID INT PRIMARY KEY IDENTITY,
	MovieID INT REFERENCES Movies(ID),
	ActorID INT REFERENCES Actors(ID),
)

INSERT INTO Movies (Name, Rate)
VALUES 
    (1, 'Se7en', 8.5),
    (1, 'Ford v Ferrari', 7.2),
    (3, 'Django Unchained', 7.8),
    (2, 'Interstellar', 9.0),
    (2, 'Forrest Gump', 9.2),
    (3, 'Joker', 9.5);

INSERT INTO Directors (Name, Surname, Age)
VALUES 
    ('David', 'Fincher', 35),
    ('Christopher', 'Nolan', 40),
    ('Quentin', 'Tarantino', 45);

INSERT INTO Genres (Name)
VALUES 
    ('Action'),
    ('Comedy'),
    ('Drama');

INSERT INTO Actors (Name, Surname, Age)
VALUES 
    ('Brad', 'Pitt', 59),
    ('Kevin', 'Spacey', 64),
    ('Matthew', 'McConaughey', 53),
    ('Jamie', 'Foxx', 55),
    ('Christian', 'Bale', 49),
    ('Joaquin', 'Phoenix', 49);

INSERT INTO MoviesGenres (MovieID, GenreID)
VALUES
    (1, 1),
    (1, 3),
    (2, 3),
    (3, 2);

INSERT INTO MoviesActors (MovieID, ActorID)
VALUES
    (1, 1),
    (1, 2),
    (3, 5),
    (6, 6),
    (3, 4);

-- Rate deyeri 8den yuxari olan kinolari ekrana cixaran query.
SELECT [Name] AS [Movie_Name] FROM Movies
WHERE Rate >= 8

-- Kinonun adini ve Rate deyerlerini ekrana cixaran query.
SELECT [Name] AS [Movie_Name], Rate FROM Movies
WHERE Rate >= 8

-- Yasi 40dan yuxari olan Aktyorlarin ve Rejissorlarin fullname, 
-- age deyerlerini ekrana cixaran query ( Bir siyahi icinde yazilmalidi).
SELECT [Name] + ' ' + Surname AS [Full_Name], Age FROM Actors
UNION
SELECT [Name] + ' ' + Surname AS [Full_Name], Age FROM Directors

-- Kinonun adini, Rate deyerini ve Rejissorunun fullname deyerlerini  
-- ekrana yazan bir View yaradin, sonra bu view-nu cagirib select edin.
CREATE VIEW MovieName_MovieRate_DirectorFullName AS
SELECT 
    Movies.Name AS Movie_Name, 
    Movies.Rate AS Movie_Rate, 
    Directors.Name + ' ' + Directors.Surname AS Director_Full_Name
FROM Movies
JOIN Directors
ON Movies.DirectorID = Directors.ID;

SELECT * FROM MovieName_MovieRate_DirectorFullName

-- Rejissorun adi, soyadi ve nece dene kinosu oldugunu ekrana cixaran query
CREATE VIEW DirectorName_DirectorSurname_MovieCount AS
SELECT 
    Directors.[Name] AS Director_Name, 
    Directors.Surname AS Director_Surname, 
    COUNT(Movies.DirectorID) AS Director_Movie_Count
FROM Directors
JOIN Movies
ON Directors.ID = Movies.DirectorID
GROUP BY Directors.[Name], Directors.Surname;

SELECT * FROM DirectorName_DirectorSurname_MovieCount

-- Kino adi, Rate, Rejissorunun fullname ve aktyorlarin 
-- fullname deyerlerini ekrana cixaran view yaradib daha 
-- sonra select edin
CREATE VIEW MovieName_MovieRate_DirectorFullName_ActorsFullName AS
SELECT 
    Movies.[Name] AS Movie_Name, 
    Movies.Rate AS Movie_Rate, 
    Directors.Name + ' ' + Directors.Surname AS Director_Full_Name,
	Actors.Name + ' ' + Actors.Surname AS Actor_Full_Name
FROM Movies
JOIN Directors
ON Movies.DirectorID = Directors.ID
JOIN MoviesActors
ON Movies.ID = MoviesActors.MovieID
JOIN Actors
ON Actors.ID = MoviesActors.ActorID

SELECT * FROM MovieName_MovieRate_DirectorFullName_ActorsFullName

-- Actor fullname, Rol aldigi kino,Kinonun janri, Kinonun rejissorunun
-- fullname, Kino rate deyerlerini ekrana cixaran query
CREATE VIEW ActorFullName_MovieActor_MovieGenre_DirectorFullName_MovieRate AS
SELECT 
	Actors.Name + ' ' + Actors.Surname AS Actor_Full_Name,
    Movies.Name AS Movie_Name,
	Genres.Name AS Genre_Name,
    Directors.Name + ' ' + Directors.Surname AS Director_Full_Name,
    Movies.Rate AS Movie_Rate
FROM Movies
JOIN Directors
ON Movies.DirectorID = Directors.ID
JOIN MoviesActors
ON Movies.ID = MoviesActors.MovieID
JOIN Actors
ON Actors.ID = MoviesActors.ActorID
JOIN MoviesGenres
ON Movies.ID = MoviesGenres.MovieID
JOIN Genres
ON Genres.ID = MoviesGenres.GenreID

SELECT * FROM ActorFullName_MovieActor_MovieGenre_DirectorFullName_MovieRate
