CREATE DATABASE Users
use Users

CREATE TABLE Roles (
    ID INT PRIMARY KEY,
    Name VARCHAR(50)
);

CREATE TABLE Users (
    ID INT PRIMARY KEY,
    Username VARCHAR(50),
    Password VARCHAR(50),
    RoleID INT,
    FOREIGN KEY (RoleID) REFERENCES Roles(ID)
);

INSERT INTO Roles (ID, Name) VALUES (1, 'Admin');
INSERT INTO Roles (ID, Name) VALUES (2, 'Moderator');
INSERT INTO Roles (ID, Name) VALUES (3, 'User');
INSERT INTO Users (ID, Username, Password, RoleID) VALUES (1, 'Ilkin', 'ilkin2004', 1);
INSERT INTO Users (ID, Username, Password, RoleID) VALUES (2, 'Miraga', 'miraga2004', 2);
INSERT INTO Users (ID, Username, Password, RoleID) VALUES (3, 'Tunay', 'tunay2004', 3);

SELECT Users.Username, Roles.Name AS Role
FROM Users
JOIN Roles ON Users.RoleID = Roles.ID;