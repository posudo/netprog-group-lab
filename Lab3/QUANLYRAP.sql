CREATE DATABASE QUANLYRAP
USE QUANLYRAP

CREATE TABLE Theaters (
    TheaterID INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);


CREATE TABLE Movies (
    MovieID INT PRIMARY KEY,
    Name VARCHAR(30) NOT NULL
);


CREATE TABLE Seats (
    SeatID INT PRIMARY KEY,
    TheaterID INT,
    Row CHAR(1),
    Number INT,
    FOREIGN KEY (TheaterID) REFERENCES Theaters(TheaterID)
);

CREATE TABLE SeatAvailability (
    SeatID INT,
    IsOccupied BIT,
    FOREIGN KEY (SeatID) REFERENCES Seats(SeatID)
);



INSERT INTO Seats (SeatID, TheaterID, Row, Number) VALUES 
    (1, 1, 'A', 1),
    (2, 1, 'A', 2),
    (3, 1, 'A', 3),
    (4, 1, 'A', 4),
    (5, 1, 'A', 5),
    (6, 1, 'B', 1),
    (7, 1, 'B', 2),
    (8, 1, 'B', 3),
    (9, 1, 'B', 4),
    (10, 1, 'B', 5),
	(11, 1, 'C', 1),
    (12, 1, 'C', 2),
    (13, 1, 'C', 3),
    (14, 1, 'C', 4),
    (15, 1, 'C', 5),
	(16, 2, 'A', 1),
    (17, 2, 'A', 2),
    (18, 2, 'A', 3),
    (19, 2, 'A', 4),
    (20, 2, 'A', 5),
    (21, 2, 'B', 1),
    (22, 2, 'B', 2),
    (23, 2, 'B', 3),
    (24, 2, 'B', 4),
    (25, 2, 'B', 5),
	(26, 3, 'C', 1),
    (27, 3, 'C', 2),
    (28, 3, 'C', 3),
    (29, 3, 'C', 4),
    (30, 3, 'C', 5);
	

INSERT INTO SeatAvailability (SeatID, IsOccupied) VALUES 
    (1, 0), (2, 0), (3, 0), (4, 0), (5, 0),
    (6, 0), (7, 0), (8, 0), (9, 0), (10, 0),
	(11, 0), (12, 0), (13, 0), (14, 0), (15, 0),
    (16, 0), (17, 0), (18, 0), (19, 0), (20, 0),
	(21, 0), (22, 0), (23, 0), (24, 0), (25, 0),
    (26, 0), (27, 0), (28, 0), (29, 0), (30, 0);
