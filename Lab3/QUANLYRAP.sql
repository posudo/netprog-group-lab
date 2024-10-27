CREATE DATABASE QUANLYRAP
USE QUANLYRAP

CREATE TABLE Theaters (
    TheaterID INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);


CREATE TABLE SeatAvailability (
    Seats CHAR(2),
    TheaterID INT,
    IsOccupied BIT,
    PRIMARY KEY (Seats, TheaterID),
    FOREIGN KEY (TheaterID) REFERENCES Theaters(TheaterID),
);

