CREATE DATABASE Users

use Users

CREATE TABLE Roles (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50)
);

CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY,
    Username VARCHAR(50),
    Password VARCHAR(50),
    RoleID INT,
    FOREIGN KEY (RoleID) REFERENCES Roles(ID)
);

INSERT INTO Roles (Name) VALUES ('Admin');
INSERT INTO Roles (Name) VALUES ('Moderator');
INSERT INTO Roles (Name) VALUES ('User');
INSERT INTO Users (Username, Password, RoleID) VALUES ('Ilkin', 'ilkin2004', 1);
INSERT INTO Users (Username, Password, RoleID) VALUES ('Miraga', 'miraga2004', 2);
INSERT INTO Users (Username, Password, RoleID) VALUES ('Tunay', 'tunay2004', 3);

SELECT Users.Username, Roles.Name AS Role
FROM Users
JOIN Roles ON Users.RoleID = Roles.ID;
