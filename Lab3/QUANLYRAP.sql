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



