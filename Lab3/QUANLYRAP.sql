CREATE DATABASE QUANLYRAP
USE QUANLYRAP


CREATE TABLE SeatAvailability (
    Seats CHAR(2),
    TheaterID INT,
    IsOccupied BIT,
    PRIMARY KEY (Seats, TheaterID),
);

delete from SeatAvailability